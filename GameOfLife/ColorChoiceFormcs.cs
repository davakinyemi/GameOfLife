using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace GameOfLife
{
    public partial class SpielfeldBreiteForm : Form
    {
        public MainFormGameOfLife parentForm;
        public int width
        {
            get
            {
                return Int32.Parse(textBoxWidth.Text);
            }
        }

        public SpielfeldBreiteForm()
        {
            InitializeComponent();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            OKbutton.DialogResult = DialogResult.OK;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Cancelbutton.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ColorChoiceFormcs_Load(object sender, EventArgs e)
        {

        }
    }
}
