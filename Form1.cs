using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSP_inputPersonalData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonOK.Enabled = false;

            //initialize the TAG property
            //intended to verify the admissibility of the data
            textBoxAddress.Tag = false;
            textBoxAge.Tag = false;
            textBoxName.Tag = false;
            textBoxOccupation.Tag = false;
            //Subscribing to events
            textBoxName.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            textBoxAddress.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            textBoxOccupation.Validating += new CancelEventHandler(textBoxOccupation_Validating);
            textBoxAge.Validating += new System.ComponentModel.CancelEventHandler(textBoxEmpty_Validating);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            
            string output;
            //concatenation of the text values of the four control controls of type TextBox
            output = "Name: " + textBoxName.Text + "\r\n";
            output += "Address: " + textBoxAddress.Text + "\r\n";
            output += "Occupation: " + textBoxOccupation.Text + "\r\n";
            output += "Age: " + textBoxAge.Text + "\r\n";
            //Insert new text
            textBoxOutput.Text = output;
        }

        private void ValidateOK()
        {

            //Activates the button OK if the values of all TAG are TRUE
            buttonOK.Enabled =
                ((bool)(textBoxAddress.Tag)
                && (bool)(textBoxAge.Tag)
                && (bool)(textBoxName.Tag)
                && (bool)(textBoxOccupation.Tag)
                );
        }
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            string output;
            //Record on short description on each control/type TextBox
            
            output = "Help information:\r\n\r\n";
            output += "Name:Your name\r\n";
            output += "Address:Your address\r\n";
            output += "Occupation:The only allowable value is 'Programmer'.\r\n";
            output += "Age:Your age";
            //Insert new text
            textBoxOutput.Text = output;
        }

        //Method for validation of textBoxName and textBoxAddress
        private void textBoxEmpty_Validating(object sender, CancelEventArgs e)
        {
            //sender object
            TextBox tb = (TextBox)sender;
            //If there is no text to indicate the presence of a problem, a red color is detected on the background of the TextBox control
            if (tb.TextLength == 0)
            {
                tb.BackColor = Color.Red;
                tb.Tag = false;

            }
            else
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
                tb.Tag = true;
            }
            //The function ValidateOk is called,
            //Which sets the value of the property Enabled if button OK
            ValidateOK();
        }
        //Method for validation of textBoxOccupation
        private void textBoxOccupation_Validating(object sender, CancelEventArgs e)
        {
            //sender object
            TextBox tb = (TextBox)sender;
            //check for correctness of values
            if (tb.Text.CompareTo("Programmer") == 0 || tb.TextLength == 0)
            {
                tb.Tag = true;
                tb.BackColor = System.Drawing.SystemColors.Window;

            }
            else
            {

                tb.Tag = false;
                tb.BackColor = Color.Red;
            }
            //The function ValidateOk is called,
            //Which sets the value of the property Enabled if button OK
            ValidateOK();
        }

        private void textBoxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //sender object
            TextBox tb = (TextBox)sender;

            //Checking for data validity and establishing values of the TAG property and the background color
            if (tb.Text.Length == 0 && tb != textBoxOccupation)
            {
                tb.Tag = false;
                tb.BackColor = Color.Red;

            }
            else if (tb == textBoxOccupation && (tb.Text.Length != 0 && tb.Text.CompareTo("Programmer") != 0))
            {
                //No color needs to be set because the color used will change during data entry
                tb.Tag = false;

            }
            else
            {
                tb.Tag = true;
                tb.BackColor = SystemColors.Window;

            }
            //The function ValidateOk is called,
            //Which sets the value of the property Enabled if button OK
            ValidateOK();
        }
    }
}
