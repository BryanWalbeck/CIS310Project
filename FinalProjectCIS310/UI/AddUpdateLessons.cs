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
    public partial class AddUpdateLessons : Form
    {
        public AddUpdateLessons()
        {
            InitializeComponent();
        }

        public bool addLessons;
        public Lessons lessons;

        private void NewLesson()
        {
            string lessonName = textBoxName.Text;
            string lessonType = textBoxType.Text;
            decimal lessonPrice = Decimal.Parse(textBoxPrice.Text);
            int lessonLength = Int32.Parse(textBoxLength.Text);

            Lessons l = new Lessons(lessonName, lessonType, lessonPrice, lessonLength);
            try
            {
                l.ID = Convert.ToInt32(LessonsDB.AddLesson(l));
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void DisplayLesson(Lessons lessons)
        {
            textBoxName.Text = lessons.lessonName;
            textBoxType.Text = lessons.lessonType;
            textBoxPrice.Text = lessons.lessonPrice.ToString();
            textBoxLength.Text = lessons.lessonLength.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (addLessons)
                {
                    NewLesson();

                    DialogResult result =
                    MessageBox.Show("Lesson Has Been Added Successfully! \n\n"
                        + "Would You Like To Add Another Lesson?", "Confirm Add", MessageBoxButtons.YesNo);

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
                    Lessons newLesson = new Lessons();
                    newLesson.ID = lessons.ID;
                    newLesson.lessonName = textBoxName.Text;
                    newLesson.lessonType = textBoxType.Text;
                    newLesson.lessonPrice = decimal.Parse(textBoxPrice.Text);
                    newLesson.lessonLength = Int32.Parse(textBoxLength.Text);
                    this.DisplayLesson(newLesson);
                    try
                    {
                        if (!LessonsDB.UpdateLesson(lessons, newLesson))
                        {
                            MessageBox.Show("Another user has updated or " +
                                "deleted that customer.", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            lessons = newLesson;
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
            Validator.IsDecimal(textBoxPrice) &&
            Validator.IsPresent(textBoxLength) &&
            Validator.IsInt32(textBoxLength);
        }
    }
}
