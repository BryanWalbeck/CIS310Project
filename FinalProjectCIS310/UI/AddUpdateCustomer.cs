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

namespace FinalProjectCIS310.UI
{
    public partial class AddUpdateCustomer : Form
    {
        public AddUpdateCustomer()
        {
            InitializeComponent();

            SqlConnection connection = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT ID, Last FROM dbo.ResponsibleParties";

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBoxCustomer.DataSource = dt;
            connection.Close();

            //Make sure you know the type (type of sheet music)
            comboBoxCustomer.ValueMember = "ID";
            comboBoxCustomer.DisplayMember = "Last";
        }

        public bool addCustomer;
        public Customer customer;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (addCustomer)
                {
                    NewCustomer();

                    DialogResult result =
                    MessageBox.Show("Customer Has Been Added Successfully! \n\n"
                        + "Would You Like To Add Another Customer?", "Confirm Add", MessageBoxButtons.YesNo);

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
                    Customer newCust = new Customer();
                    newCust.ID = customer.ID;
                    newCust.responsiblePartyID = Int32.Parse(comboBoxCustomer.SelectedValue.ToString());
                    newCust.firstName = textBoxFirst.Text;
                    newCust.lastName = textBoxLast.Text;
                    newCust.phoneNumber = textBoxPhone.Text;
                    newCust.address = textBoxAddress.Text;
                    newCust.email = textBoxEmail.Text;
                    newCust.userName = textBoxUser.Text;
                    newCust.password = textBoxPassword.Text;
                    this.DisplayCustomer(newCust);
                    try
                    {
                        if (!CustomerDB.UpdateCustomer(customer, newCust))
                        {
                            MessageBox.Show("Another user has updated or " +
                                "deleted that customer.", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            customer = newCust;
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

        private void NewCustomer()
        {
            int rpID = Int32.Parse(comboBoxCustomer.SelectedValue.ToString());
            string firstName = textBoxFirst.Text;
            string lastName = textBoxLast.Text;
            string phoneNumber = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string email = textBoxEmail.Text;
            string userName = textBoxUser.Text;
            string password = textBoxPassword.Text;

            Customer c = new Customer(rpID, firstName, lastName, phoneNumber, address, email, userName, password);

            try
            {
                c.ID = Convert.ToInt32(CustomerDB.AddCustomer(c));
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void DisplayCustomer(Customer customer)
        {
            comboBoxCustomer.SelectedValue = customer.responsiblePartyID;
            textBoxFirst.Text = customer.firstName;
            textBoxLast.Text = customer.lastName;
            textBoxPhone.Text = customer.phoneNumber;
            textBoxAddress.Text = customer.address;
            textBoxEmail.Text = customer.email;
            textBoxUser.Text = customer.userName;
            textBoxPassword.Text = customer.password;
        }

        private void buttonAdd_Load(object sender, EventArgs e)
        {
            this.comboBoxCustomer.SelectedValue.ToString();
            if (addCustomer)
            {
                this.Text = "Add Customer";
                comboBoxCustomer.SelectedValue = -1;
            }
            else
            {
                this.Text = "Modify Customer";
                this.DisplayCustomer(customer);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool IsValid()
        {
            return
                Validator.IsPresent(comboBoxCustomer) &&
                Validator.IsPresent(textBoxFirst) &&
                Validator.IsLetter(textBoxFirst) &&
                Validator.IsPresent(textBoxLast) &&
                Validator.IsLetter(textBoxLast) &&
                Validator.IsPresent(textBoxPhone) &&
                Validator.IsValidPhone(textBoxPhone) &&
                Validator.IsPresent(textBoxAddress) &&
                Validator.IsPresent(textBoxEmail) &&
                Validator.IsPresent(textBoxUser) &&
                Validator.IsPresent(textBoxPassword);
        }
    }
}
