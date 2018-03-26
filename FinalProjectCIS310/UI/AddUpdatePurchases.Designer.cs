namespace FinalProjectCIS310
{
    partial class AddUpdatePurchases
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdatePurchases));
            this.labelCustomer = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelDOP = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.datePurchased = new System.Windows.Forms.DateTimePicker();
            this.comboCustomers = new System.Windows.Forms.ComboBox();
            this.comboProducts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(67, 91);
            this.labelCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(136, 32);
            this.labelCustomer.TabIndex = 0;
            this.labelCustomer.Text = "Customer";
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(67, 157);
            this.labelProduct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(112, 32);
            this.labelProduct.TabIndex = 1;
            this.labelProduct.Text = "Product";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(67, 224);
            this.labelQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(119, 32);
            this.labelQuantity.TabIndex = 2;
            this.labelQuantity.Text = "Quantity";
            // 
            // labelDOP
            // 
            this.labelDOP.AutoSize = true;
            this.labelDOP.Location = new System.Drawing.Point(67, 292);
            this.labelDOP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDOP.Name = "labelDOP";
            this.labelDOP.Size = new System.Drawing.Size(76, 32);
            this.labelDOP.TabIndex = 3;
            this.labelDOP.Text = "DOP";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(250, 217);
            this.textBoxQuantity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(523, 39);
            this.textBoxQuantity.TabIndex = 6;
            this.textBoxQuantity.Tag = "Quantity";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(410, 395);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(161, 84);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(612, 395);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(161, 84);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // datePurchased
            // 
            this.datePurchased.Location = new System.Drawing.Point(250, 285);
            this.datePurchased.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.datePurchased.Name = "datePurchased";
            this.datePurchased.Size = new System.Drawing.Size(523, 39);
            this.datePurchased.TabIndex = 10;
            this.datePurchased.Tag = "Date of Purchase";
            // 
            // comboCustomers
            // 
            this.comboCustomers.FormattingEnabled = true;
            this.comboCustomers.Location = new System.Drawing.Point(250, 83);
            this.comboCustomers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboCustomers.Name = "comboCustomers";
            this.comboCustomers.Size = new System.Drawing.Size(523, 40);
            this.comboCustomers.TabIndex = 11;
            this.comboCustomers.Tag = "Customer";
            // 
            // comboProducts
            // 
            this.comboProducts.FormattingEnabled = true;
            this.comboProducts.Location = new System.Drawing.Point(250, 149);
            this.comboProducts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboProducts.Name = "comboProducts";
            this.comboProducts.Size = new System.Drawing.Size(523, 40);
            this.comboProducts.TabIndex = 12;
            this.comboProducts.Tag = "Product";
            // 
            // AddUpdatePurchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(918, 658);
            this.Controls.Add(this.comboProducts);
            this.Controls.Add(this.comboCustomers);
            this.Controls.Add(this.datePurchased);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.labelDOP);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.labelCustomer);
            this.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "AddUpdatePurchases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelDOP;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DateTimePicker datePurchased;
        private System.Windows.Forms.ComboBox comboCustomers;
        private System.Windows.Forms.ComboBox comboProducts;
    }
}