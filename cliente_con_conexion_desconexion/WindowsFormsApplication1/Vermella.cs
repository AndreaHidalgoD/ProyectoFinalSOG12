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
    public partial class Vermella : Form
    {
        int minutos =0;
        int segundos=0;
        public Vermella()
        {
            InitializeComponent();
            //Només que obri la pestanya comença el timer
            timer1.Interval = 1000; //1s
            timer1.Start();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (segundos>=60)
            {
                minutos=minutos+1;
                segundos=0;
            }
            label3.Text="Minutos:" + Convert.ToString(minutos)+", segundos: "+ Convert.ToString(segundos);
            if (minutos >= 3)
            {
                timer1.Stop();
                MessageBox.Show("Has acabado tu tiempo");
                this.Close();
            }
        }

        private void TaulaPeriodica_Click(object sender, EventArgs e)
        {
            TaulaPeriodica form = new TaulaPeriodica();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxTaulaP.Text == "3")
                MessageBox.Show("Respuesta correcta, engima resuelto. Anota el valor 3");
            else
                MessageBox.Show("Respuesta incorrecta, sigue pensando");
        }
    }
}
