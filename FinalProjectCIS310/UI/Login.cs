using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectCIS310;

namespace FinalProjectCIS310.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string userName = textBoxUser.Text;
            string password = textBoxPassword.Text;
            int userType = 1;

            if (IsValid())
            {
                //Validate user exists.  Set user type of form
                Customer user = CustomerDB.GetCustomerByUserName(userName, password);
                Administrator admin = AdministratorDB.GetAdmin(userName, password);
                ResponsibleParty rp = ResponsiblePartyDB.GetRP(userName, password);
                if (admin != null)
                {
                    userType = 0;
                }
                else if (user != null)
                {
                    userType = 1;
                }
                else if(rp != null)
                {
                    userType = 2;
                }
                else
                {
                    MessageBox.Show("Invalid User or Password");
                    return;
                }

                if (userType == 1)
                {
                    UserMenu userForm = new UserMenu(userName, password, userType);
                    userForm.currentUserId = user.ID;
                    userForm.currentResponsiblePartyId = user.responsiblePartyID;
                    userForm.Show();
                    this.Hide();
                }
                if (userType == 2)
                {
                    UserMenu userForm = new UserMenu(userName, password, userType);
                    userForm.currentUserId = rp.ID;
                    //userForm.currentResponsiblePartyId = user.responsiblePartyID;
                    userForm.Show();
                    this.Hide();
                }
                if (userType == 0)
                {
                    MainMenu mainForm = new UI.MainMenu();
                    mainForm.Show();
                    this.Hide();
                }
            }
        }

        private bool IsValid()
        {
            return
                Validator.IsPresent(textBoxUser) &&
                Validator.IsPresent(textBoxPassword);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
