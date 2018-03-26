namespace FinalProjectCIS310.UI
{
    partial class UserProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProducts));
            this.dataGridUserProducts = new System.Windows.Forms.DataGridView();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.listBoxCart = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelTotalNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUserProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridUserProducts
            // 
            this.dataGridUserProducts.AllowUserToAddRows = false;
            this.dataGridUserProducts.AllowUserToDeleteRows = false;
            this.dataGridUserProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUserProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridUserProducts.Location = new System.Drawing.Point(52, 73);
            this.dataGridUserProducts.Name = "dataGridUserProducts";
            this.dataGridUserProducts.RowTemplate.Height = 40;
            this.dataGridUserProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUserProducts.Size = new System.Drawing.Size(921, 918);
            this.dataGridUserProducts.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(2103, 219);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(170, 74);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonBuy
            // 
            this.buttonBuy.Location = new System.Drawing.Point(2103, 73);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(170, 74);
            this.buttonBuy.TabIndex = 4;
            this.buttonBuy.Text = "Buy";
            this.buttonBuy.UseVisualStyleBackColor = true;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // listBoxCart
            // 
            this.listBoxCart.FormattingEnabled = true;
            this.listBoxCart.ItemHeight = 31;
            this.listBoxCart.Location = new System.Drawing.Point(1156, 73);
            this.listBoxCart.Name = "listBoxCart";
            this.listBoxCart.Size = new System.Drawing.Size(921, 934);
            this.listBoxCart.TabIndex = 5;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(990, 374);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(150, 61);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add >";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(990, 568);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(150, 61);
            this.buttonRemove.TabIndex = 7;
            this.buttonRemove.Text = "< Delete";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(1171, 959);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(87, 32);
            this.labelTotal.TabIndex = 8;
            this.labelTotal.Text = "Total:";
            // 
            // labelTotalNumber
            // 
            this.labelTotalNumber.AutoSize = true;
            this.labelTotalNumber.Location = new System.Drawing.Point(1264, 959);
            this.labelTotalNumber.Name = "labelTotalNumber";
            this.labelTotalNumber.Size = new System.Drawing.Size(63, 32);
            this.labelTotalNumber.TabIndex = 9;
            this.labelTotalNumber.Text = "$$$";
            // 
            // UserProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2306, 1152);
            this.Controls.Add(this.labelTotalNumber);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxCart);
            this.Controls.Add(this.buttonBuy);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.dataGridUserProducts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserProducts";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.From_Login);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUserProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUserProducts;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.ListBox listBoxCart;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelTotalNumber;
    }
}