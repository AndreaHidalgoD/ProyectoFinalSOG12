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
    public partial class InstruccionesJuego : Form
    {
        string background1 = "Instrucciones1.jpg";
        string background2 = "Intrucciones2.jpg";
        
        public InstruccionesJuego()
        {
            InitializeComponent();
            volver1.Visible=false;
            Ir2.Visible=true;
            MaximizeBox = false;
        }

        private void InstruccionesJuego_Load(object sender, EventArgs e)
        {

        }

        private void Ir2_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(background2);
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            volver1.Visible=true;
            Ir2.Visible=false;
        }

        private void volver1_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(background1);
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            volver1.Visible = false;
            Ir2.Visible = true;
        }
    }
}
