using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class AnotacionesPapelera : Form
    {
        public AnotacionesPapelera()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void AnotacionesPapelera_Load(object sender, EventArgs e)
        {

        }

        private void buttonDirector_Click(object sender, EventArgs e)
        {
          
            this.Hide();
        }
    }
}
