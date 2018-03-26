namespace FinalProjectCIS310
{
    partial class UserMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMenu));
            this.buttonBuyProducts = new System.Windows.Forms.Button();
            this.buttonMyLessons = new System.Windows.Forms.Button();
            this.buttonMyPurchases = new System.Windows.Forms.Button();
            this.buttonAccountInfo = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBuyProducts
            // 
            this.buttonBuyProducts.Location = new System.Drawing.Point(106, 248);
            this.buttonBuyProducts.Name = "buttonBuyProducts";
            this.buttonBuyProducts.Size = new System.Drawing.Size(462, 270);
            this.buttonBuyProducts.TabIndex = 0;
            this.buttonBuyProducts.Text = "Buy Products";
            this.buttonBuyProducts.UseVisualStyleBackColor = true;
            this.buttonBuyProducts.Click += new System.EventHandler(this.buttonBuyProducts_Click);
            // 
            // buttonMyLessons
            // 
            this.buttonMyLessons.Location = new System.Drawing.Point(106, 625);
            this.buttonMyLessons.Name = "buttonMyLessons";
            this.buttonMyLessons.Size = new System.Drawing.Size(462, 270);
            this.buttonMyLessons.TabIndex = 1;
            this.buttonMyLessons.Text = "My Lessons";
            this.buttonMyLessons.UseVisualStyleBackColor = true;
            this.buttonMyLessons.Click += new System.EventHandler(this.buttonMyLessons_Click);
            // 
            // buttonMyPurchases
            // 
            this.buttonMyPurchases.Location = new System.Drawing.Point(705, 248);
            this.buttonMyPurchases.Name = "buttonMyPurchases";
            this.buttonMyPurchases.Size = new System.Drawing.Size(462, 270);
            this.buttonMyPurchases.TabIndex = 2;
            this.buttonMyPurchases.Text = "My Purchases";
            this.buttonMyPurchases.UseVisualStyleBackColor = true;
            this.buttonMyPurchases.Click += new System.EventHandler(this.buttonMyPurchases_Click);
            // 
            // buttonAccountInfo
            // 
            this.buttonAccountInfo.Location = new System.Drawing.Point(705, 625);
            this.buttonAccountInfo.Name = "buttonAccountInfo";
            this.buttonAccountInfo.Size = new System.Drawing.Size(462, 270);
            this.buttonAccountInfo.TabIndex = 3;
            this.buttonAccountInfo.Text = "My Account";
            this.buttonAccountInfo.UseVisualStyleBackColor = true;
            this.buttonAccountInfo.Click += new System.EventHandler(this.buttonAccountInfo_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Arial", 20.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(322, 96);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(320, 76);
            this.labelWelcome.TabIndex = 4;
            this.labelWelcome.Text = "Welcome";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Arial", 20.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(648, 96);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(215, 76);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Name";
            // 
            // UserMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1308, 1032);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.buttonAccountInfo);
            this.Controls.Add(this.buttonMyPurchases);
            this.Controls.Add(this.buttonMyLessons);
            this.Controls.Add(this.buttonBuyProducts);
            this.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserMenu";
            this.Padding = new System.Windows.Forms.Padding(80);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBuyProducts;
        private System.Windows.Forms.Button buttonMyLessons;
        private System.Windows.Forms.Button buttonMyPurchases;
        private System.Windows.Forms.Button buttonAccountInfo;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelName;
    }
}

