using FinalProjectCIS310;
using FinalProjectCIS310.DA;
using FinalProjectCIS310.UI;
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
    public partial class UserPurchases : Form
    {
        private Customer user;
        private ResponsibleParty rp;
        private string rpCurrent;

        public UserPurchases(string currentUserId, bool rpTest)
        {
            InitializeComponent();

            if (!rpTest)
            {
                buttonInvoice.Hide();

                user = CustomerDB.GetCustomer(currentUserId);
                ResponsiblePartyShow(currentUserId);

                //Customer's purchases
                string query = "SELECT p.ID, p.ProdID, p.Quantity, p.DOP "
                    + "FROM Purchases p "
                    + "JOIN Customers c "
                    + "ON c.ID = p.CustID "
                    + "WHERE c.ID = " + currentUserId;

                SqlConnection conn = JSMusicStudioDB.GetConnection();
                SqlCommand sqlCmd = new SqlCommand(query, conn);
                SqlDataReader reader;

                conn.Open();

                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    object ID = reader["ID"];
                    //object custID = reader["CustID"];
                    object prodID = reader["ProdID"];
                    object quantity = reader["Quantity"];
                    object DOP = reader["DOP"];

                    //Removed: custID.ToString()
                    listBoxUserPurchases.Items.Add(ID.ToString() + " \t" + prodID.ToString()
                        + " \t" + quantity.ToString() + " \t" + DOP.ToString());
                }
                conn.Close();
            }

            else
            {
                //labelResponsibleParty.Text = "test";

                rp = ResponsiblePartyDB.GetRP(currentUserId);
                rpCurrent = currentUserId;
                ResponsibleMembers(currentUserId);

                //RP's purchases
                string query = "SELECT p.ID, p.ProdID, p.Quantity, p.DOP "
                    + "FROM Purchases p "
                    + "JOIN Customers c "
                    + "ON c.ID = p.CustID "
                    + "WHERE c.RPID = " + currentUserId;

                SqlConnection conn = JSMusicStudioDB.GetConnection();
                SqlCommand sqlCmd = new SqlCommand(query, conn);
                SqlDataReader reader;

                conn.Open();

                reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    object ID = reader["ID"];
                    //object custID = reader["CustID"];
                    object prodID = reader["ProdID"];
                    object quantity = reader["Quantity"];
                    object DOP = reader["DOP"];

                    //Removed: custID.ToString()
                    listBoxUserPurchases.Items.Add(ID.ToString() + " \t" + prodID.ToString()
                        + " \t" + quantity.ToString() + " \t" + DOP.ToString());
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

        private void buttonInvoice_Click(object sender, EventArgs e)
        {
            UserInvoice invoice = new UserInvoice(rpCurrent);
            invoice.Show();
        }
    }
}
