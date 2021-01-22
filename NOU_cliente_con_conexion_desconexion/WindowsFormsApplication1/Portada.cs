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
    public partial class Portada : Form
    {
        public Portada()
        {
            InitializeComponent();
            MaximizeBox = false;

        }

        private void Portada_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_videos formV = new Form_videos();
            formV.DameNumero(1);
            formV.ShowDialog();


            Form1 form = new Form1();
            form.ShowDialog();
            this.Hide();

            this.Visible = false;
            this.Dispose();
        }
    }
}
