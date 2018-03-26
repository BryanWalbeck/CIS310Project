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
    public partial class UserProducts : Form
    {
        private Customer user;
        private Product prod;
        //private Purchase purch;
        private string quantity = "1";

        public UserProducts(string currentUser, bool rpID)
        {
            InitializeComponent();

            populateProduct();

            if(!rpID)
            {
                user = CustomerDB.GetCustomer(currentUser);
            }
            else
            {
                buttonBuy.Hide();
            }
        }

        private void populateProduct()
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT ID, Name, Type, Price FROM dbo.Products";

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridUserProducts.DataSource = dt;
            connection.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void From_Login(object sender, EventArgs e)
        {
            //Centers form
            this.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.X +
                (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                         System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Y +
                         (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //int row = dataGridUserProducts.SelectedCells[0].RowIndex;
            int ID = (from DataGridViewRow dr in dataGridUserProducts.SelectedRows
                           select (int)dr.Cells["ID"].Value).FirstOrDefault();
            string name = (from DataGridViewRow dr in dataGridUserProducts.SelectedRows
                           select (string)dr.Cells["Name"].Value).FirstOrDefault();
            string type = (from DataGridViewRow dr in dataGridUserProducts.SelectedRows
                           select (string)dr.Cells["Type"].Value).FirstOrDefault();
            decimal price = (from DataGridViewRow dr in dataGridUserProducts.SelectedRows
                             select (decimal)dr.Cells["Price"].Value).FirstOrDefault();

            prod = ProductDB.GetProduct(ID.ToString());

            string shortName = TruncString(name, 7);
            string shortType = TruncString(type, 6);

            listBoxCart.Items.Add(prod.ID + "\t" + shortName + " - " + shortType + "\t\t " + price + "\t " + quantity);
        }

        public string TruncString(string myStr, int threshold)
        {
            if (myStr.Length > threshold)
                return myStr.Substring(0, threshold) + "..";
            return myStr;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //Removes current selected item or duplicate item
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxCart);
            selectedItems = listBoxCart.SelectedItems;

            if (listBoxCart.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBoxCart.Items.Remove(selectedItems[i]);
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to buy these items?", "Purchase", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                foreach (var listBoxItem in listBoxCart.Items)
                {
                    Purchase p = new Purchase(user.ID, prod.ID, Convert.ToInt32(quantity), DateTime.Now);
                    
                    try
                    {
                        p.ID = Convert.ToInt32(PurchaseDB.AddPurchase(p));
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                MessageBox.Show("Your purchase has been completed!");
            }
            else
            {
                return;
            }
        }
    }
}
