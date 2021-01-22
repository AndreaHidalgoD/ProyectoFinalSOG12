using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Libreria;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Blau1_2 : Form
    {
        Boolean pelotagolf2 = false;
        Boolean pelotagolf = false;
        string Nombre;
        Socket server;
        int idPartida;
        public Blau1_2()
        {
            InitializeComponent();
            MaximizeBox = false;
        }
        public void RecogerDatos(string Nombre, Socket server, int idPartida)
        {
            //Variables necesarias para que funcione el servidor
            this.Nombre = Nombre;
            this.server = server;
            this.idPartida = idPartida;

        }

        private void Blau1_2_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recoger las pelotas de golf no sirve de nada jaja...No obstante, envío una pista a tus compañeros!"); //Pista per els de l'altre sala
            
            //Mensaje de conexión a la sala
            //Si es 5, Ayuda de la sala 021B al aula 27-3
            string mensaje = "14/" + Nombre + "/5/" + Convert.ToString(idPartida);
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Color del cable a cortar: Estoy en la sangre y no en el agua, brillo en el fuego y no en la leña. Número que no se considera ni primo ni compuesto"); // Cable rojo1
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pelotagolf == false)
            {
                MessageBox.Show("Ha recogido la pelota de golf!");
                pelotagolf = true;
            }
            else
                MessageBox.Show("Esta pelota ya la has recogido");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pelotagolf2 == false)
            {
                MessageBox.Show("Ha recogido la pelota de golf!");
                pelotagolf2 = true;
            }
            else
                MessageBox.Show("Esta pelota ya la has recogido");
        }
        
    }
}
