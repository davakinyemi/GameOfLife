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
    public partial class SpielfeldHoeheForm : Form
    {
        public SpielfeldHoeheForm()
        {
            InitializeComponent();
        }

        public int height
        {
            get
            {
                return Int32.Parse(textBoxHeight.Text);
            }
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
    }
}
