using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectCIS310
{
    public static class Validator
    {
        private static string title = "Entry Error";

        /// <summary>
        /// The title that will appear in dialog boxes.
        /// </summary>
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// Checks whether the user entered data into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered data.</returns>
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", "Entry Error");
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks whether the user entered a decimal value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered a decimal value.</returns>
        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered an int value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered an int value.</returns>
        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered a value within a specified range into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <param name="min">The minimum value for the range.</param>
        /// <param name="max">The maximum value for the range.</param>
        /// <returns>True if the user has entered a value within the specified range.</returns>
        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min.ToString()
                    + " and " + max.ToString() + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsLetter(TextBox textBox)
        {
            Regex pattern = new Regex(@"^[a-zA-Z]+$");
            if (pattern.IsMatch(textBox.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be a letter.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsValidPhone(TextBox textBox)
        {
            Regex pattern = new Regex(@"^([0-9]{3})(\-*)([0-9]{3})(\-*)([0-9]{4})$");
            //^ starts string
            //[0-9] digit 0-9
            //\- with optional dash * zero or more times
            //$ ends string
            if (pattern.IsMatch(textBox.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be a valid 10-digit phone number. \n\nxxx-xxx-xxxx\nxxxxxxxxxx", Title);
                textBox.Focus();
                return false;
            }
        }

        //public static bool UserExists(TextBox textBox)
        //{
        //    SqlConnection con = JSMusicStudioDB.GetConnection();

        //    SqlCommand cmd = new SqlCommand("Select Count(*) From Customers Where [User]= @User", con);
        //    cmd.Parameters.AddWithValue("@User", textBox.Text);
        //    con.Open();
        //    var result = cmd.ExecuteScalar();
        //    if (result != null)
        //    {
        //        MessageBox.Show(string.Format("Username {0} already exist", textBox.Text));
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
    }
}
