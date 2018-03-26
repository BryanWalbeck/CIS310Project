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
    public partial class AddUpdatePurchases : Form
    {
        public bool addPurchase;
        public Purchase purchase;

        public AddUpdatePurchases()
        {
            InitializeComponent();

            SqlConnection connection = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT ID, Name FROM dbo.Products";

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            comboProducts.DataSource = dt;
            connection.Close();

            //Make sure you know the type (type of sheet music)
            comboProducts.ValueMember = "ID";
            comboProducts.DisplayMember = "Name";

            sqlCmd.CommandText = "SELECT ID, Last + ', ' + First AS Name FROM dbo.Customers";

            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            comboCustomers.DataSource = dt2;
            connection.Close();

            //Make sure you know the type (type of sheet music)
            comboCustomers.ValueMember = "ID";
            comboCustomers.DisplayMember = "Name";
        }

        private void NewPurchase()
        {
            int purchaseCustomerID = Int32.Parse(comboCustomers.SelectedValue.ToString());
            int purchaseProductID = Int32.Parse(comboProducts.SelectedValue.ToString());
            int purchaseQuantity = Int32.Parse(textBoxQuantity.Text);
            DateTime purchaseDate = datePurchased.Value;

            Purchase p = new Purchase(purchaseCustomerID, purchaseProductID, purchaseQuantity, purchaseDate);

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

        private void DisplayPurchase(Purchase purchase)
        {
            comboCustomers.SelectedValue = purchase.customerID;
            comboProducts.SelectedValue = purchase.productID;
            textBoxQuantity.Text = purchase.quantity.ToString();
            datePurchased.Value = purchase.purchaseDate;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (addPurchase)
                {
                    NewPurchase();

                    DialogResult result =
                    MessageBox.Show("Purchase Has Been Added Successfully! \n\n"
                        + "Would You Like To Add Another Purchase?", "Confirm Add", MessageBoxButtons.YesNo);

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
                    Purchase newPurchase = new Purchase();
                    newPurchase.ID = purchase.ID;
                    newPurchase.customerID = Int32.Parse(comboCustomers.SelectedValue.ToString());
                    newPurchase.productID = Int32.Parse(comboProducts.SelectedValue.ToString());
                    newPurchase.quantity = Int32.Parse(textBoxQuantity.Text);
                    newPurchase.purchaseDate = datePurchased.Value;
                    this.DisplayPurchase(newPurchase);
                    try
                    {
                        if (!PurchaseDB.UpdatePurchase(purchase, newPurchase))
                        {
                            MessageBox.Show("This purchase has already been " +
                                "updated or deleted.", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            purchase = newPurchase;
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

        private bool IsValid()
        {
            return
                Validator.IsPresent(comboCustomers) &&
                Validator.IsPresent(comboProducts) &&
                Validator.IsPresent(textBoxQuantity) &&
                Validator.IsInt32(textBoxQuantity);
        }
    }
}
