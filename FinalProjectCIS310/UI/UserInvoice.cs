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
    public partial class UserInvoice : Form
    {
        ResponsibleParty rp;

        public UserInvoice(string rpCurrent)
        {
            InitializeComponent();

            string query = "SELECT p.ID, p.Quantity*pr.Price AS Total, p.DOP "
                                     + "FROM dbo.Purchases p "
                                     + "JOIN dbo.Products pr "
                                     + "ON pr.ID = p.ProdID "
                                     + "JOIN dbo.Customers c "
                                     + "ON c.ID = p.CustID "
                                     + "WHERE c.RPID = " + rpCurrent 
                                     + "AND p.DOP > '01-JAN-2017'";

            SqlConnection conn = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            SqlDataReader reader;

            conn.Open();

            reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                object pID = reader["ID"];
                object total = reader["Total"];
                object DOP = reader["DOP"];

                rp = ResponsiblePartyDB.GetRP(rpCurrent);

                decimal appliedDiscount = Convert.ToDecimal(total) - (rp.discount * (Convert.ToDecimal(total)));

                listBoxInvoice.Items.Add(pID.ToString() + " \t" + appliedDiscount.ToString()
                    + "\t\t" + DOP.ToString());
            }
            conn.Close();
        }
    }
}
