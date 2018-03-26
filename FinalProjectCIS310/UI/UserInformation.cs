using FinalProjectCIS310;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectCIS310.UI
{
    public partial class UserInformation : Form
    {
        public UserInformation(string currentUserId)
        {
            InitializeComponent();
            populateUser(currentUserId);
        }
        
        private Customer user;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string first = labelFirstName.Text;
            string last = labelLastName.Text;

            AddUpdateCustomer update = new AddUpdateCustomer();
            update.addCustomer = false;
            update.customer = CustomerDB.GetCustomer(Convert.ToString(user.ID));

            DialogResult result = MessageBox.Show("Would you like to update " + first.ToString() + " "
                + last.ToString() + "?", "Confirm Update", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                result = update.ShowDialog();
                user = update.customer;
                string userID = user.ToString();
                populateUser(Convert.ToString(user.ID));
            }
            else
            {
                return;
            }
        }

        private void populateUser(string currentUser)
        {
            user = CustomerDB.GetCustomer(currentUser);

            labelFirstName.Text = user.firstName;
            labelLastName.Text = user.lastName;
            labelPhoneNumber.Text = user.phoneNumber;
            labelEmailAddress.Text = user.email;
            labelStreetAddress.Text = user.address;
            labelUserName.Text = user.userName;
            labelUserPassword.Text = user.password;
        }
    }
}
