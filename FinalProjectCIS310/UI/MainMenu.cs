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
    public partial class MainMenu : Form
    {
        public int userType;
        public int currentUserId;
        public int currentResponsiblePartyId;

        public MainMenu()
        {
            InitializeComponent();
        }

        private int selection;
        private Customer customer;
        private ResponsibleParty rParty;
        private Product product;
        private Lessons lesson;
        private Purchase purch;
        private Registration reg;

        //Populates grid based on combo box selection
        //Populates using DB tables
        //Selection 1 = Customers
        //Selection 2 = RP
        //Selection 3 = Products
        //Selection 4 = Lessons
        //Selection 5 = Purchases
        //Selection 6 = Registrations
        private void populateListBox(object sender, EventArgs e)
        {

            if (comboBoxMain.SelectedItem.Equals("Customers"))
            {
                populateCustomers();
                selection = 1;
            }

            if (comboBoxMain.SelectedItem.Equals("Responsible Party"))
            {
                populateRP();
                selection = 2;
            }
            if (comboBoxMain.SelectedItem.Equals("Products"))
            {
                populateProduct();
                selection = 3;
            }
            if (comboBoxMain.SelectedItem.Equals("Lessons"))
            {
                populateLessons();
                selection = 4;
            }
            if (comboBoxMain.SelectedItem.Equals("Purchases"))
            {
                populatePurchases();
                selection = 5;
            }
            if (comboBoxMain.SelectedItem.Equals("Registrations"))
            {
                populateReg();
                selection = 6;
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

            dataGridViewMain.DataSource = dt;
            connection.Close();
        }

        private void populateLessons()
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT ID, Name, Type, Length, Price FROM dbo.Lessons";

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewMain.DataSource = dt;
            connection.Close();
        }

        private void populateRP()
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT ID, First, Last, Phone, Address, Email, [User] FROM dbo.ResponsibleParties";

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewMain.DataSource = dt;
            connection.Close();
        }

        private void populatePurchases()
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT ID, CustID, ProdID, Quantity, DOP FROM dbo.Purchases";

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewMain.DataSource = dt;
            connection.Close();
        }

        private void populateCustomers()
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT ID, RPID, First, Last, Phone, Address, Email, [User], Password FROM dbo.Customers";

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewMain.DataSource = dt;
            connection.Close();
        }

        private void populateReg()
        {
            SqlConnection connection = JSMusicStudioDB.GetConnection();
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT ID, CustID, LessonID, Scheduled, Completed, Canceled FROM dbo.Registrations";

            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewMain.DataSource = dt;
            connection.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult quitDialog =
                MessageBox.Show("Are You Sure You'd Like To Quit?", "Exit Message", MessageBoxButtons.YesNo);
            if (quitDialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
                return;
        }

        //Runs correct form based on the combo box drop down
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (SelectionIsPresent())
            {
                if (comboBoxMain.SelectedItem.Equals("Products"))
                {
                    AddUpdateProduct prod = new AddUpdateProduct();
                    prod.addProduct = true;
                    prod.Show();
                }
                if (comboBoxMain.SelectedItem.Equals("Customers"))
                {
                    AddUpdateCustomer cust = new AddUpdateCustomer();
                    cust.addCustomer = true;
                    cust.Show();
                }
                if (comboBoxMain.SelectedItem.Equals("Responsible Party"))
                {
                    AddUpdateResponsibleParty rp = new AddUpdateResponsibleParty();
                    rp.addRP = true;
                    rp.Show();
                }
                if (comboBoxMain.SelectedItem.Equals("Purchases"))
                {
                    AddUpdatePurchases purch = new AddUpdatePurchases();
                    purch.addPurchase = true;
                    purch.Show();
                }
                if (comboBoxMain.SelectedItem.Equals("Lessons"))
                {
                    AddUpdateLessons less = new AddUpdateLessons();
                    less.addLessons = true;
                    less.Show();
                }
                if (comboBoxMain.SelectedItem.Equals("Registrations"))
                {
                    AddUpdateRegistration reg = new AddUpdateRegistration();
                    reg.addReg = true;
                    reg.Show();
                }
            }
        }

        //Loads main menu based on user type
        //Admin - Customer - Responsible Pary
        private void LoadFromLogin(object sender, EventArgs e)
        {
            //Centers form
            this.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.X +
                (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                         System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Y +
                         (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

            //Hides buttons bases on user
            if (userType == 1)//customer
            {
                buttonDelete.Visible = false;
                buttonUpdate.Visible = false;
            }
            else if (userType == 0)//Admin
            {
                buttonDelete.Visible = true;
                buttonUpdate.Visible = true;
                //Form initialize all things visible, don't need to change
            }
        }

        //Deletes data from the grid based on combo box selection
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //Customer
            if (selection == 1)
            {
                //Read data from the selected rows (use for updating data)
                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();
                string first = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                                select (string)dr.Cells["First"].Value).FirstOrDefault();
                string last = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Last"].Value).FirstOrDefault();

                DialogResult result = MessageBox.Show("Would you like to delete " + first.ToString() + " " + last.ToString() + "?",
                "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        customer = CustomerDB.GetCustomer(ID.ToString());
                        if (!CustomerDB.DeleteCustomer(customer))
                        {
                            MessageBox.Show("Another user has updated or deleted " +
                                "that customer.", "Database Error");
                            this.GetCustomer(Convert.ToString(customer.ID));
                            if (customer != null)
                                populateCustomers();
                            else
                                return;
                        }
                        else
                            populateCustomers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                    return;
                }
            }

            //RP
            if (selection == 2)
            {
                //int row = dataGridViewMain.SelectedCells[0].RowIndex;
                string first = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                                select (string)dr.Cells["First"].Value).FirstOrDefault();
                string last = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Last"].Value).FirstOrDefault();

                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();

                DialogResult result = MessageBox.Show("Would you like to delete " + first.ToString() + " " + last.ToString() + "?",
                "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        rParty = ResponsiblePartyDB.GetRP(ID.ToString());
                        if (!ResponsiblePartyDB.DeleteRP(rParty))
                        {
                            MessageBox.Show("Another rp has updated or deleted " +
                                "that rp.", "Database Error");
                            this.GetRP(Convert.ToString(rParty.ID));
                            if (rParty != null)
                                populateRP();
                            else
                                return;
                        }
                        else
                            populateRP();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                    return;
                }
            }

            //Products
            if (selection == 3)
            {
                //int row = dataGridViewMain.SelectedCells[0].RowIndex;
                string name = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Name"].Value).FirstOrDefault();
                string type = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Type"].Value).FirstOrDefault();

                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();

                //MessageBox.Show("Would you like to delete " + name.ToString() + ", " + type.ToString());
                DialogResult result = MessageBox.Show("Would you like to delete " + name.ToString() + ", " + type.ToString() + "?",
                "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        product = ProductDB.GetProduct(ID.ToString());
                        if (!ProductDB.DeleteProduct(product))
                        {
                            MessageBox.Show("Another rp has updated or deleted " +
                                "that rp.", "Database Error");
                            this.GetProduct(Convert.ToString(product.ID));
                            if (product != null)
                                populateProduct();
                            else
                                return;
                        }
                        else
                            populateProduct();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                    return;
                }
            }

            //Lessons
            if (selection == 4)
            {
                string name = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Name"].Value).FirstOrDefault();
                string type = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Type"].Value).FirstOrDefault();

                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();

                //MessageBox.Show("Would you like to delete " + name.ToString() + ", " + type.ToString());
                DialogResult result = MessageBox.Show("Would you like to delete " + name.ToString() + ", " + type.ToString() + "?",
                "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        lesson = LessonsDB.GetLesson(ID.ToString());
                        if (!LessonsDB.DeleteProduct(lesson))
                        {
                            MessageBox.Show("Another rp has updated or deleted " +
                                "that rp.", "Database Error");
                            this.GetLesson(Convert.ToString(lesson.ID));
                            if (lesson != null)
                                populateLessons();
                            else
                                return;
                        }
                        else
                            populateLessons();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                    return;
                }
            }

            //Purchases
            if (selection == 5)
            {
                int cust = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                            select (int)dr.Cells["CustID"].Value).FirstOrDefault();
                int prod = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                            select (int)dr.Cells["ProdID"].Value).FirstOrDefault();

                Product p = ProductDB.GetProduct(prod.ToString());
                Customer c = CustomerDB.GetCustomer(cust.ToString());

                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();

                //MessageBox.Show("Would you like to delete " + c.firstName + ", " + c.lastName + " - " + p.productType);
                DialogResult result = MessageBox.Show("Would you like to delete the following purchase: \n\n "
                    + c.firstName + " " + c.lastName + " - " + p.productType + "?",
                    "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        purch = PurchaseDB.GetPurchase(ID.ToString());
                        if (!PurchaseDB.DeletePurchase(purch))
                        {
                            MessageBox.Show("Another purchase has updated or deleted " +
                                "that purchase.", "Database Error");
                            this.GetPurchase(Convert.ToString(purch.ID));
                            if (purch != null)
                                populatePurchases();
                            else
                                return;
                        }
                        else
                            populatePurchases();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                    return;
                }
            }

            //Registration
            if (selection == 6)
            {
                int cust = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                            select (int)dr.Cells["CustID"].Value).FirstOrDefault();
                int less = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                            select (int)dr.Cells["LessonID"].Value).FirstOrDefault();

                Lessons l = LessonsDB.GetLesson(less.ToString());
                Customer c = CustomerDB.GetCustomer(cust.ToString());

                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();
                
                DialogResult result = MessageBox.Show("Would you like to delete the following resgistered lesson: \n\n "
                    + c.firstName + " " + c.lastName + "\n\n" + l.lessonName + " - " + l.lessonType + "?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        reg = RegistrationDB.GetReg(ID.ToString());
                        if (!RegistrationDB.DeleteReg(reg))
                        {
                            MessageBox.Show("Another rp has updated or deleted " +
                                "that rp.", "Database Error");
                            this.GetReg(Convert.ToString(reg.ID));
                            if (reg != null)
                                populateReg();
                            else
                                return;
                        }
                        else
                            populateReg();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //Customers
            if (selection == 1)
            {
                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();
                string first = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                                select (string)dr.Cells["First"].Value).FirstOrDefault();
                string last = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Last"].Value).FirstOrDefault();

                DialogResult result = MessageBox.Show("Would you like to update " + first.ToString() + " "
                    + last.ToString() + "?", "Confirm Update", MessageBoxButtons.YesNo);

                AddUpdateCustomer update = new AddUpdateCustomer();
                update.addCustomer = false;
                update.customer = CustomerDB.GetCustomer(Convert.ToString(ID));

                if (result == DialogResult.Yes)
                {
                    result = update.ShowDialog();
                    customer = update.customer;
                    populateCustomers();
                }
                else
                {
                    return;
                }
            }

            //RP
            if (selection == 2)
            {
                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();
                string first = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                                select (string)dr.Cells["First"].Value).FirstOrDefault();
                string last = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Last"].Value).FirstOrDefault();

                DialogResult result = MessageBox.Show("Would you like to update " + first.ToString()
                    + ", " + last.ToString() + "?", "Confirm Update", MessageBoxButtons.YesNo);

                AddUpdateResponsibleParty updateRP = new AddUpdateResponsibleParty();
                updateRP.addRP = false;
                updateRP.RP = ResponsiblePartyDB.GetRP(Convert.ToString(ID));

                if (result == DialogResult.Yes)
                {
                    result = updateRP.ShowDialog();
                    rParty = updateRP.RP;
                    populateRP();
                }
                else
                {
                    return;
                }
            }

            //Products
            if (selection == 3)
            {
                string name = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Name"].Value).FirstOrDefault();
                string type = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Type"].Value).FirstOrDefault();

                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();

                DialogResult result = MessageBox.Show("Would you like to update " + name.ToString() + " " + type.ToString() + "?",
                    "Confirm Update", MessageBoxButtons.YesNo);
                AddUpdateProduct updateProduct = new AddUpdateProduct();
                updateProduct.addProduct = false;
                updateProduct.product = ProductDB.GetProduct(Convert.ToString(ID));

                if (result == DialogResult.Yes)
                {
                    result = updateProduct.ShowDialog();
                    product = updateProduct.product;
                    populateProduct();
                }
                else
                {
                    return;
                }
            }

            //Lessons
            if (selection == 4)
            {
                //Read data from selected rows (for use in Updating data)
                int row = dataGridViewMain.SelectedCells[0].RowIndex;
                string name = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Name"].Value).FirstOrDefault();
                string type = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                               select (string)dr.Cells["Type"].Value).FirstOrDefault();

                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();

                DialogResult result = MessageBox.Show("Would you like to update the following lesson: \n\n" + name.ToString() + " "
                    + type.ToString() + "?", "Confirm Update", MessageBoxButtons.YesNo);
                AddUpdateLessons updateLessons = new AddUpdateLessons();
                updateLessons.addLessons = false;
                updateLessons.lessons = LessonsDB.GetLesson(Convert.ToString(ID));

                if (result == DialogResult.Yes)
                {
                    result = updateLessons.ShowDialog();
                    lesson = updateLessons.lessons;
                    populateLessons();
                }
                else if (result == DialogResult.Retry)
                {
                    return;
                }
            }

            //Purchases
            if (selection == 5)
            {
                //Read data from selected rows (for use in Updating data)
                int row = dataGridViewMain.SelectedCells[0].RowIndex;
                int cust = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                            select (int)dr.Cells["CustID"].Value).FirstOrDefault();
                int prod = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                            select (int)dr.Cells["ProdID"].Value).FirstOrDefault();

                Product p = ProductDB.GetProduct(prod.ToString());
                Customer c = CustomerDB.GetCustomer(cust.ToString());

                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();

                DialogResult result = MessageBox.Show("Would you like to update the following purchase: \n\n" + c.firstName + " "
                    + c.lastName + "\n\n" + p.productName + " - " + p.productType + "?",
                    "Confirm Update", MessageBoxButtons.YesNo);
                AddUpdatePurchases updatePurchase = new AddUpdatePurchases();
                updatePurchase.addPurchase = false;
                updatePurchase.purchase = PurchaseDB.GetPurchase(Convert.ToString(ID));

                if (result == DialogResult.Yes)
                {
                    result = updatePurchase.ShowDialog();
                    purch = updatePurchase.purchase;
                    populatePurchases();
                }
                else
                {
                    return;
                }
            }

            //Registration
            if (selection == 6)
            {
                //Read data from selected rows (for use in Updating data)
                int row = dataGridViewMain.SelectedCells[0].RowIndex;
                int cust = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                            select (int)dr.Cells["CustID"].Value).FirstOrDefault();
                int less = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                            select (int)dr.Cells["LessonID"].Value).FirstOrDefault();

                int ID = (from DataGridViewRow dr in dataGridViewMain.SelectedRows
                          select (int)dr.Cells["ID"].Value).FirstOrDefault();

                Lessons l = LessonsDB.GetLesson(less.ToString());
                Customer c = CustomerDB.GetCustomer(cust.ToString());

                DialogResult result = MessageBox.Show("Would you like to update the following registered lesson: \n\n" + c.firstName + " "
                    + c.lastName + "\n\n" + l.lessonName + " - " + l.lessonType + "?",
                    "Confirm Update", MessageBoxButtons.YesNo);
                AddUpdateRegistration updateReg = new AddUpdateRegistration();
                updateReg.addReg = false;
                updateReg.reg = RegistrationDB.GetReg(Convert.ToString(ID));

                if (result == DialogResult.Yes)
                {
                    result = updateReg.ShowDialog();
                    reg = updateReg.reg;
                    populateReg();
                }
                else if (result == DialogResult.Retry)
                {
                    return;
                }
            }
        }

        private void GetCustomer(string customerID)
        {
            try
            {
                customer = CustomerDB.GetCustomer(customerID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void GetRP(string rpID)
        {
            try
            {
                rParty = ResponsiblePartyDB.GetRP(rpID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void GetProduct(string prodID)
        {
            try
            {
                product = ProductDB.GetProduct(prodID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void GetLesson(string lessID)
        {
            try
            {
                lesson = LessonsDB.GetLesson(lessID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void GetPurchase(string purchID)
        {
            try
            {
                purch = PurchaseDB.GetPurchase(purchID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void GetReg(string regID)
        {
            try
            {
                reg = RegistrationDB.GetReg(regID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private bool SelectionIsPresent()
        {
            return
            Validator.IsPresent(comboBoxMain);
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Quit?", "Exit", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
