using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class AreaSizeForm : Form
    {
        public AreaSizeForm()
        {
            InitializeComponent();
        }

        // check that textbox input is integer and within reasonable range
        private bool ValidateTextBoxValueIsUInt32(ref TextBox textBox, ref ErrorProvider e)
        {
            bool success = false;
            try
            {
                uint value = Convert.ToUInt32(textBox.Text);
                success = true;
            }
            catch (FormatException)
            {
                textBox.Select(0, textBox.Text.Length);
                e.SetError(textBox, "Invalid input value");
            }
            catch (OverflowException)
            {
                textBox.Select(0, textBox.Text.Length);
                e.SetError(textBox, "Input value too large");
            }

            return success;
        }

        public int AreaWidth
        {
            get
            {
                return Convert.ToInt32(textBoxWidth.Text);
            }

            set
            {
                textBoxWidth.Text = Convert.ToString(value);
            }
        }

        public int AreaHeight
        {
            get
            {
                return Convert.ToInt32(textBoxHeight.Text);
            }

            set
            {
                textBoxHeight.Text = Convert.ToString(value);
            }
        }

        // Event method to validate width
        private void textBoxWidth_Validating(object sender, CancelEventArgs e)
        {
            bool valid = ValidateTextBoxValueIsUInt32(ref textBoxWidth, ref this.errorProviderWidth);
            if (!valid)
            {
                e.Cancel = true;
            }
        }

        // Event method after width validation
        private void textBoxWidth_Validated(object sender, EventArgs e)
        {
            errorProviderWidth.SetError(textBoxWidth, "");
        }

        // Event method for OK button
        private void OKbutton_Click(object sender, EventArgs e)
        {
            OKbutton.DialogResult = DialogResult.OK;
        }

        // Event method for Cancel button
        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Cancelbutton.DialogResult = DialogResult.Cancel;
            Close();
        }

        // Event method to validate height
        private void textBoxHeight_Validating(object sender, CancelEventArgs e)
        {
            bool valid = ValidateTextBoxValueIsUInt32(ref textBoxHeight, ref this.errorProviderHeight);
            if (!valid)
            {
                e.Cancel = true;
            }
        }

        // Event method after height validation
        private void textBoxHeight_Validated(object sender, EventArgs e)
        {
            errorProviderHeight.SetError(textBoxHeight, "");
        }

    }
}
