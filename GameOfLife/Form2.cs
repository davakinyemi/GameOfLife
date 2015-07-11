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
    public partial class ColorChoiceForm2 : Form
    {

        public MainFormGameOfLife parentForm;

        public uint pixelSize
        {
            get
            {
                return Convert.ToUInt32(pixelSizeBox.Text);
            }
        }

        public ColorChoiceForm2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void OKbutton_Click_1(object sender, EventArgs e)
        {
            OKbutton.DialogResult = DialogResult.OK;
        }

        private void Cancelbutton_Click_1(object sender, EventArgs e)
        {
            Cancelbutton.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
