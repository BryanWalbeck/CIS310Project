namespace FinalProjectCIS310
{
    partial class AddUpdateRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateRegistration));
            this.labelCustomer = new System.Windows.Forms.Label();
            this.labelLesson = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelCompleted = new System.Windows.Forms.Label();
            this.comboCustomers = new System.Windows.Forms.ComboBox();
            this.comboLessons = new System.Windows.Forms.ComboBox();
            this.dateSchedule = new System.Windows.Forms.DateTimePicker();
            this.checkBoxComplete = new System.Windows.Forms.CheckBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.timeSchedule = new System.Windows.Forms.DateTimePicker();
            this.checkBoxCanceled = new System.Windows.Forms.CheckBox();
            this.labelCanceled = new System.Windows.Forms.Label();
            this.timeCanceled = new System.Windows.Forms.DateTimePicker();
            this.dateCanceled = new System.Windows.Forms.DateTimePicker();
            this.cancelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(30, 65);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(136, 32);
            this.labelCustomer.TabIndex = 0;
            this.labelCustomer.Text = "Customer";
            // 
            // labelLesson
            // 
            this.labelLesson.AutoSize = true;
            this.labelLesson.Location = new System.Drawing.Point(30, 133);
            this.labelLesson.Name = "labelLesson";
            this.labelLesson.Size = new System.Drawing.Size(105, 32);
            this.labelLesson.TabIndex = 1;
            this.labelLesson.Text = "Lesson";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(30, 207);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(73, 32);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "Date";
            // 
            // labelCompleted
            // 
            this.labelCompleted.AutoSize = true;
            this.labelCompleted.Location = new System.Drawing.Point(30, 287);
            this.labelCompleted.Name = "labelCompleted";
            this.labelCompleted.Size = new System.Drawing.Size(150, 32);
            this.labelCompleted.TabIndex = 3;
            this.labelCompleted.Text = "Completed";
            // 
            // comboCustomers
            // 
            this.comboCustomers.FormattingEnabled = true;
            this.comboCustomers.Location = new System.Drawing.Point(205, 57);
            this.comboCustomers.Name = "comboCustomers";
            this.comboCustomers.Size = new System.Drawing.Size(534, 40);
            this.comboCustomers.TabIndex = 4;
            this.comboCustomers.Tag = "Customer";
            // 
            // comboLessons
            // 
            this.comboLessons.FormattingEnabled = true;
            this.comboLessons.Location = new System.Drawing.Point(205, 125);
            this.comboLessons.Name = "comboLessons";
            this.comboLessons.Size = new System.Drawing.Size(534, 40);
            this.comboLessons.TabIndex = 5;
            this.comboLessons.Tag = "Lesson";
            // 
            // dateSchedule
            // 
            this.dateSchedule.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateSchedule.Location = new System.Drawing.Point(205, 200);
            this.dateSchedule.Name = "dateSchedule";
            this.dateSchedule.Size = new System.Drawing.Size(274, 39);
            this.dateSchedule.TabIndex = 6;
            // 
            // checkBoxComplete
            // 
            this.checkBoxComplete.AutoSize = true;
            this.checkBoxComplete.Location = new System.Drawing.Point(205, 286);
            this.checkBoxComplete.Name = "checkBoxComplete";
            this.checkBoxComplete.Size = new System.Drawing.Size(34, 33);
            this.checkBoxComplete.TabIndex = 8;
            this.checkBoxComplete.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(298, 523);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(181, 76);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click_1);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(558, 523);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(181, 76);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // timeSchedule
            // 
            this.timeSchedule.CustomFormat = "HH:mm";
            this.timeSchedule.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeSchedule.Location = new System.Drawing.Point(529, 200);
            this.timeSchedule.Name = "timeSchedule";
            this.timeSchedule.ShowUpDown = true;
            this.timeSchedule.Size = new System.Drawing.Size(210, 39);
            this.timeSchedule.TabIndex = 7;
            // 
            // checkBoxCanceled
            // 
            this.checkBoxCanceled.AutoSize = true;
            this.checkBoxCanceled.Location = new System.Drawing.Point(705, 289);
            this.checkBoxCanceled.Name = "checkBoxCanceled";
            this.checkBoxCanceled.Size = new System.Drawing.Size(34, 33);
            this.checkBoxCanceled.TabIndex = 12;
            this.checkBoxCanceled.UseVisualStyleBackColor = true;
            this.checkBoxCanceled.CheckedChanged += new System.EventHandler(this.checkBoxCanceled_CheckedChanged);
            // 
            // labelCanceled
            // 
            this.labelCanceled.AutoSize = true;
            this.labelCanceled.Location = new System.Drawing.Point(552, 290);
            this.labelCanceled.Name = "labelCanceled";
            this.labelCanceled.Size = new System.Drawing.Size(132, 32);
            this.labelCanceled.TabIndex = 11;
            this.labelCanceled.Text = "Canceled";
            // 
            // timeCanceled
            // 
            this.timeCanceled.CustomFormat = "HH:mm";
            this.timeCanceled.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeCanceled.Location = new System.Drawing.Point(529, 386);
            this.timeCanceled.Name = "timeCanceled";
            this.timeCanceled.ShowUpDown = true;
            this.timeCanceled.Size = new System.Drawing.Size(210, 39);
            this.timeCanceled.TabIndex = 15;
            this.timeCanceled.Visible = false;
            // 
            // dateCanceled
            // 
            this.dateCanceled.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateCanceled.Location = new System.Drawing.Point(208, 386);
            this.dateCanceled.Name = "dateCanceled";
            this.dateCanceled.Size = new System.Drawing.Size(274, 39);
            this.dateCanceled.TabIndex = 14;
            this.dateCanceled.Visible = false;
            // 
            // cancelText
            // 
            this.cancelText.AutoSize = true;
            this.cancelText.Location = new System.Drawing.Point(30, 386);
            this.cancelText.Name = "cancelText";
            this.cancelText.Size = new System.Drawing.Size(146, 32);
            this.cancelText.TabIndex = 13;
            this.cancelText.Text = "Canc Date";
            this.cancelText.Visible = false;
            // 
            // AddUpdateRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(836, 676);
            this.Controls.Add(this.timeCanceled);
            this.Controls.Add(this.dateCanceled);
            this.Controls.Add(this.cancelText);
            this.Controls.Add(this.checkBoxCanceled);
            this.Controls.Add(this.labelCanceled);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.checkBoxComplete);
            this.Controls.Add(this.timeSchedule);
            this.Controls.Add(this.dateSchedule);
            this.Controls.Add(this.comboLessons);
            this.Controls.Add(this.comboCustomers);
            this.Controls.Add(this.labelCompleted);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelLesson);
            this.Controls.Add(this.labelCustomer);
            this.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddUpdateRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lesson Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label labelLesson;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelCompleted;
        private System.Windows.Forms.ComboBox comboCustomers;
        private System.Windows.Forms.ComboBox comboLessons;
        private System.Windows.Forms.DateTimePicker dateSchedule;
        private System.Windows.Forms.CheckBox checkBoxComplete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DateTimePicker timeSchedule;
        private System.Windows.Forms.CheckBox checkBoxCanceled;
        private System.Windows.Forms.Label labelCanceled;
        private System.Windows.Forms.DateTimePicker timeCanceled;
        private System.Windows.Forms.DateTimePicker dateCanceled;
        private System.Windows.Forms.Label cancelText;
    }
}