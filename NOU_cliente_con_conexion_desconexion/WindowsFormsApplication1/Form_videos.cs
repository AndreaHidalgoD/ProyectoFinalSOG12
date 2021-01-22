using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;


namespace WindowsFormsApplication1
{
    public partial class Form_videos : Form
    {
        int numero;
        string ruta;
        int segundos;
        public Form_videos()
        {
            InitializeComponent();
            MaximizeBox = false;

        }

        private void Form_videos_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            axWindowsMediaPlayer1.Ctlcontrols.pause();
         
        }
        public void DameNumero(int numero)
        {
            this.numero = numero;
        }

        private void Form_videos_Load(object sender, EventArgs e)
        {
            timerVideo.Interval = 1000;//1s
            timerVideo.Start();

            try
            {
                if (numero == 1)
                {
                    //Poso el video de la intro
                    ruta = "IntroJuego.mp4";

                }
                else if (numero == 2)
                {
                    ruta = "PrimerVideo.mp4";
                }
                else if (numero == 3)
                {
                    ruta = "SegundoVideo.mp4";
                }
                else if (numero == 4)
                {
                    ruta = "VideoFinalBueno.mp4";
                }
                else if (numero == 5)
                {
                    ruta = "VideoFinalMalo.mp4";
                }

               
              
                
                axWindowsMediaPlayer1.URL = ruta;
                
               
            }
            catch
            {
                MessageBox.Show("Hay un error");
            }
        }
        
        private void timerVideo_Tick(object sender, EventArgs e)
        {
            this.segundos = this.segundos + 1;
            if (this.numero == 1 && this.segundos >= 123) //120s
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                this.Close();
            }
            else if (this.numero == 2 && this.segundos >= 46) //44s
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                this.Close();
            }
            else if (this.numero == 3 && this.segundos >= 35) //33s
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                this.Close();
            }
            else if (this.numero == 4 && this.segundos >= 17)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                this.Close();
            }
            else if (this.numero == 5 && this.segundos >= 12)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                this.Close();
            }

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

    }
}