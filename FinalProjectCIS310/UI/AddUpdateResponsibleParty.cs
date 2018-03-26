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
using System.Xml;
using System.Xml.Linq;

namespace FinalProjectCIS310
{
    public partial class AddUpdateResponsibleParty : Form
    {
        public AddUpdateResponsibleParty()
        {
            InitializeComponent();
        }

        public bool addRP;
        public ResponsibleParty RP;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (addRP)
                {
                    NewRP();

                    DialogResult result =
                    MessageBox.Show("Responsible Party Has Been Added Successfully! \n\n"
                        + "Would You Like To Add Another Responsible Party?", "Confirm Add", MessageBoxButtons.YesNo);

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
                    ResponsibleParty newRP = new ResponsibleParty();
                    newRP.ID = RP.ID;
                    newRP.firstName = textBoxFirstName.Text;
                    newRP.lastName = textBoxLastName.Text;
                    newRP.phoneNumber = textBoxPhoneNumber.Text;
                    newRP.address = textBoxAddress.Text;
                    newRP.email = textBoxEmail.Text;
                    newRP.userName = textBoxUserName.Text;
                    newRP.password = textBoxPassword.Text;
                    this.DisplayRP(newRP);

                    try
                    {
                        if (!ResponsiblePartyDB.UpdateRP(RP, newRP))
                        {
                            MessageBox.Show("Another rp has updated or " +
                                "deleted that rp.", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            RP = newRP;
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

        private void NewRP()
        {
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string phoneNumber = textBoxPhoneNumber.Text;
            string address = textBoxAddress.Text;
            string email = textBoxEmail.Text;
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;

            ResponsibleParty rp = new ResponsibleParty(firstName, lastName, phoneNumber, address, email, userName, password, 0);

            try
            {
                rp.ID = Convert.ToInt32(ResponsiblePartyDB.AddRP(rp));
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void DisplayRP(ResponsibleParty RP)
        {
            textBoxFirstName.Text = RP.firstName;
            textBoxLastName.Text = RP.lastName;
            textBoxPhoneNumber.Text = RP.phoneNumber;
            textBoxAddress.Text = RP.address;
            textBoxEmail.Text = RP.email;
            textBoxUserName.Text = RP.userName;
            textBoxPassword.Text = RP.password;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool IsValid()
        {
            return
                Validator.IsPresent(textBoxFirstName) &&
                Validator.IsLetter(textBoxFirstName) &&
                Validator.IsPresent(textBoxLastName) &&
                Validator.IsLetter(textBoxLastName) &&
                Validator.IsPresent(textBoxPhoneNumber) &&
                Validator.IsValidPhone(textBoxPhoneNumber) &&
                Validator.IsPresent(textBoxAddress) &&
                Validator.IsPresent(textBoxEmail) &&
                Validator.IsPresent(textBoxUserName) &&
                Validator.IsPresent(textBoxPassword);
        }
    }
}
