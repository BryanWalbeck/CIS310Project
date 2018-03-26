namespace FinalProjectCIS310
{
    partial class UserLessons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLessons));
            this.buttonClose = new System.Windows.Forms.Button();
            this.listBoxUserLessons = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelResponsibleParty = new System.Windows.Forms.Label();
            this.jSMusicStudioDatabaseDataSet = new FinalProjectCIS310.JSMusicStudioDatabaseDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.jSMusicStudioDatabaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(1183, 724);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(220, 121);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // listBoxUserLessons
            // 
            this.listBoxUserLessons.FormattingEnabled = true;
            this.listBoxUserLessons.HorizontalScrollbar = true;
            this.listBoxUserLessons.IntegralHeight = false;
            this.listBoxUserLessons.ItemHeight = 38;
            this.listBoxUserLessons.Location = new System.Drawing.Point(89, 195);
            this.listBoxUserLessons.Name = "listBoxUserLessons";
            this.listBoxUserLessons.ScrollAlwaysVisible = true;
            this.listBoxUserLessons.Size = new System.Drawing.Size(1021, 650);
            this.listBoxUserLessons.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Responsible Party:";
            // 
            // labelResponsibleParty
            // 
            this.labelResponsibleParty.AutoSize = true;
            this.labelResponsibleParty.Location = new System.Drawing.Point(383, 121);
            this.labelResponsibleParty.Name = "labelResponsibleParty";
            this.labelResponsibleParty.Size = new System.Drawing.Size(367, 39);
            this.labelResponsibleParty.TabIndex = 4;
            this.labelResponsibleParty.Text = "Responsible Party Here";
            // 
            // jSMusicStudioDatabaseDataSet
            // 
            this.jSMusicStudioDatabaseDataSet.DataSetName = "JSMusicStudioDatabaseDataSet";
            this.jSMusicStudioDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UserLessons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1485, 1015);
            this.Controls.Add(this.labelResponsibleParty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxUserLessons);
            this.Controls.Add(this.buttonClose);
            this.Font = new System.Drawing.Font("Arial", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserLessons";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Lessons";
            ((System.ComponentModel.ISupportInitialize)(this.jSMusicStudioDatabaseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListBox listBoxUserLessons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelResponsibleParty;
        private JSMusicStudioDatabaseDataSet jSMusicStudioDatabaseDataSet;
    }
}