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
using System.Xml.Linq;

namespace FinalProjectCIS310
{
    public partial class AddUpdateProduct : Form
    {
        public AddUpdateProduct()
        {
            InitializeComponent();
        }

        public bool addProduct;
        public Product product;

        private void NewProduct()
        {
            string productName = textBoxName.Text;
            string productType = textBoxType.Text;
            decimal productPrice = Decimal.Parse(textBoxPrice.Text);

            Product p = new Product(productName, productType, productPrice);

            try
            {
                p.ID = Convert.ToInt32(ProductDB.AddProduct(p));
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void DisplayProduct(Product product)
        {
            textBoxName.Text = product.productName;
            textBoxType.Text = product.productType;
            textBoxPrice.Text = product.productPrice.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (addProduct)
                {
                    NewProduct();

                    DialogResult result =
                    MessageBox.Show("Product Has Been Added Successfully! \n\n"
                        + "Would You Like To Add Another Product?", "Confirm Add", MessageBoxButtons.YesNo);

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
                    Product newProduct = new Product();
                    newProduct.ID = product.ID;
                    newProduct.productName = textBoxName.Text;
                    newProduct.productType = textBoxType.Text;
                    newProduct.productPrice = Decimal.Parse(textBoxPrice.Text);
                    this.DisplayProduct(newProduct);

                    try
                    {
                        if (!ProductDB.UpdateProduct(product, newProduct))
                        {
                            MessageBox.Show("Another rp has updated or " +
                                "deleted that rp.", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            product = newProduct;
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
                Validator.IsPresent(textBoxName) &&
                Validator.IsPresent(textBoxType) &&
                Validator.IsPresent(textBoxPrice) &&
                Validator.IsDecimal(textBoxPrice);
        }
    }
}
