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

namespace FinalProjectCIS310
{
    public partial class UserLessons : Form
    {
        public int currentUser;
        private Customer user;
        private ResponsibleParty rp;

        public UserLessons(string currentUserId, bool rpTest)
        {
            InitializeComponent();
            
            if (!rpTest)
            {
                ResponsiblePartyShow(currentUserId);

                user = CustomerDB.GetCustomer(currentUserId);

                //Customer's purchases
                string query = "SELECT l.LessonID, l.Scheduled, l.Completed, l.Canceled "
                    + "FROM Registrations l "
                    + "JOIN Customers c "
                    + "ON c.ID = l.CustID "
                    + "WHERE c.ID = " + currentUserId;

                SqlConnection conn = JSMusicStudioDB.GetConnection();
                SqlCommand sqlCmd = new SqlCommand(query, conn);
                SqlDataReader reader;

                conn.Open();

                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    //object ID = reader["ID"];
                    //object custID = reader["CustID"];
                    object lessonID = reader["LessonID"];
                    object scheduled = reader["Scheduled"];
                    object completed = reader["Completed"];
                    object canceled = reader["Canceled"];

                    //Removed: ID.ToString() + " \t" + custID.ToString() + " \t"
                    string[] listLesson = { lessonID.ToString() };
                    string[] listScheduled = { scheduled.ToString() };
                    string[] listCompleted = { completed.ToString() };
                    string[] listCanceled = { canceled.ToString() };

                    // Add the array items to the list box.
                    for (int i = 0; i <= listLesson.Length - 1; i++)
                        listBoxUserLessons.Items.Add(listLesson[i] + "\t" + listScheduled[i] 
                            + "\t" + listCompleted[i] + "\t" + listCanceled[i]);
                    //listBoxUserLessons.Items.Add(lessonID.ToString() + " \t" + scheduled.ToString()
                    //    + " \t" + completed.ToString() + " \t" + canceled.ToString());
                }
                conn.Close();
            }
            else
            {
                ResponsibleMembers(currentUserId);

                rp = ResponsiblePartyDB.GetRP(currentUserId);

                //Customer's purchases
                string query = "SELECT l.LessonID, l.Scheduled, l.Completed, l.Canceled "
                    + "FROM Registrations l "
                    + "JOIN Customers c "
                    + "ON c.ID = l.CustID "
                    + "WHERE c.RPID = " + currentUserId;

                SqlConnection conn = JSMusicStudioDB.GetConnection();
                SqlCommand sqlCmd = new SqlCommand(query, conn);
                SqlDataReader reader;

                conn.Open();

                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    //object ID = reader["ID"];
                    //object custID = reader["CustID"];
                    object lessonID = reader["LessonID"];
                    object scheduled = reader["Scheduled"];
                    object completed = reader["Completed"];
                    object canceled = reader["Canceled"];

                    //Removed: ID.ToString() + " \t" + custID.ToString() + " \t"
                    listBoxUserLessons.Items.Add(lessonID.ToString() + " \t" + scheduled.ToString()
                        + " \t" + completed.ToString() + " \t" + canceled.ToString());
                }
                conn.Close();
            }
        }

        private void ResponsiblePartyShow(string currentUserId)
        {
            string query = "SELECT rp.First, rp.Last "
                + "FROM ResponsibleParties rp "
                + "JOIN Customers c "
                + "ON c.RPID = rp.ID "
                + "WHERE c.ID = " + currentUserId;
            SqlConnection conn = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            conn.Open();

            reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                object first = reader["First"];
                object last = reader["Last"];
                labelResponsibleParty.Text = first.ToString() + " " + last.ToString();
            }
        }

        private void ResponsibleMembers(string currentUserId)
        {
            labelResponsibleParty.Text = "";

            string query = "SELECT c.First, c.Last "
                + "FROM Customers c "
                + "JOIN ResponsibleParties rp "
                + "ON c.RPID = rp.ID "
                + "WHERE c.RPID = " + currentUserId;
            SqlConnection conn = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            conn.Open();

            reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                object first = reader["First"];
                object last = reader["Last"];
                label1.Text = "Responsible For: ";
                labelResponsibleParty.Text += first.ToString() + " " + last.ToString() + " ";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
