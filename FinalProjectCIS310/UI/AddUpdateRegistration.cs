using FinalProjectCIS310;
using FinalProjectCIS310.DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FinalProjectCIS310
{
    public partial class AddUpdateRegistration : Form
    {
        public bool addReg;
        public Registration reg;

        public AddUpdateRegistration()
        {
            InitializeComponent();

            SqlConnection connection = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT ID, Last + ', ' + First AS Name FROM dbo.Customers";

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            comboCustomers.DataSource = dt;
            connection.Close();

            //Make sure you know the type (type of sheet music)
            comboCustomers.ValueMember = "ID";
            comboCustomers.DisplayMember = "Name";
            
            sqlCmd.CommandText = "SELECT ID, Name + ' - ' + Type AS Lesson  FROM dbo.Lessons";

            connection.Open();

            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            comboLessons.DataSource = dt2;
            connection.Close();

            //Make sure you know the type (type of sheet music)
            comboLessons.ValueMember = "ID";
            comboLessons.DisplayMember = "Lesson";

        }

        private void DisplayReg(Registration reg)
        {
            DateTime d = dateSchedule.Value;
            DateTime t = timeSchedule.Value;
            DateTime dc = dateCanceled.Value;
            DateTime tc = timeCanceled.Value;

            comboCustomers.SelectedValue = reg.customerID;
            comboLessons.SelectedValue = reg.lessonID;
            reg.scheduleDate = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);
            reg.cancelDate = new DateTime(dc.Year, dc.Month, dc.Day, tc.Hour, tc.Minute, tc.Second);

            string completeFlag = "N";

            if (checkBoxComplete.Checked)
            {
                completeFlag = "Y";
            }

            completeFlag = reg.completedLesson;
        }

        private void NewReg()
        {
            DateTime d = dateSchedule.Value;
            DateTime t = timeSchedule.Value;
            DateTime dc = dateCanceled.Value;
            DateTime tc = timeCanceled.Value;

            int purchaseCustomerID = Int32.Parse(comboCustomers.SelectedValue.ToString());
            int purchaseLessonID = Int32.Parse(comboLessons.SelectedValue.ToString());
            DateTime scheduleDate = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);
            DateTime canceledDate = new DateTime(dc.Year, dc.Month, dc.Day, tc.Hour, tc.Minute, tc.Second);
            string completeFlag = "N";

            if (checkBoxComplete.Checked)
            {
                completeFlag = "Y";
            }

            Registration r = new Registration(purchaseCustomerID, purchaseLessonID, scheduleDate, completeFlag, canceledDate);

            try
            {
                r.ID = Convert.ToInt32(RegistrationDB.AddReg(r));
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (addReg)
                {
                    NewReg();

                    DialogResult result =
                    MessageBox.Show("Registration Has Been Added Successfully! \n\n"
                        + "Would You Like To Add Another Registration?", "Confirm Add", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        return;
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    DateTime d = dateSchedule.Value;
                    DateTime t = timeSchedule.Value;

                    DateTime dc = dateCanceled.Value;
                    DateTime tc = timeCanceled.Value;

                    Registration newReg = new Registration();
                    newReg.ID = reg.ID;
                    newReg.customerID = Int32.Parse(comboCustomers.SelectedValue.ToString());
                    newReg.lessonID = Int32.Parse(comboLessons.SelectedValue.ToString());
                    newReg.scheduleDate = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);
                    newReg.cancelDate = new DateTime(dc.Year, dc.Month, dc.Day, tc.Hour, tc.Minute, tc.Second);

                    string completeFlag = "N";

                    if (checkBoxComplete.Checked)
                    {
                        completeFlag = "Y";
                    }

                    newReg.completedLesson = completeFlag;

                    this.DisplayReg(newReg);
                    try
                    {
                        if (!RegistrationDB.UpdateReg(reg, newReg))
                        {
                            MessageBox.Show("This registration has already been " +
                                "updated or deleted.", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            reg = newReg;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxCanceled_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxCanceled.Checked)
            {
                cancelText.Show();
                dateCanceled.Show();
                timeCanceled.Show();
            }
            else
            {
                cancelText.Hide();
                dateCanceled.Hide();
                timeCanceled.Hide();
            }
        }

        private bool IsValid()
        {
            return
                Validator.IsPresent(comboCustomers) &&
                Validator.IsPresent(comboLessons);
        }
    }
}
