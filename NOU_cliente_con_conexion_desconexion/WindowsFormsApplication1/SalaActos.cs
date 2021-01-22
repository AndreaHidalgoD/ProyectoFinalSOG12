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
    public partial class SalaActos : Form
    {
        //Si algun listillo no fa el que li diu el message box hi haura errors, i a més a més si volen corregir tampoc hi ha la opció
        //I jo crec que estaria prou be
        int intentos = 1;
        int contador = 0; //Lo que va a hacer es contar el orden en el que le da a los botones

        int vermell = 0;
        int taronja = 0;
        int groc = 0;
        int verd = 0;
        int blau = 0;
        int lila = 0;
        int rosa = 0;
        string Nombre;
        Socket server;
        int idPartida;

        Boolean resolviendo = false;
        
        public SalaActos()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void Dimeaquelehedado(int contador, string color)
        {
            if (contador == 1)
            {
                B1_but.Visible = true;
                B1_but.Text = Convert.ToString(contador) +": "+ color;
            }
            else if (contador == 2)
            {
                B2_but.Visible = true;
                B2_but.Text = Convert.ToString(contador) + ": " + color;
            }
            else if (contador == 3)
            {
                B3_but.Visible = true;
                B3_but.Text = Convert.ToString(contador) + ": " + color;
            }
            else if (contador == 4)
            {
                B4_but.Visible = true;
                B4_but.Text = Convert.ToString(contador) + ": " + color;
            }
            else if (contador == 5)
            {
                B5_but.Visible = true;
                B5_but.Text = Convert.ToString(contador) + ": " + color;
            }
            else if (contador == 6)
            {
                B6_but.Visible = true;
                B6_but.Text = Convert.ToString(contador) + ": " + color;
            }
            else if (contador == 7)
            {
                B7_but.Visible = true;
                B7_but.Text = Convert.ToString(contador) + ": " + color;
            }
        }
        private void Vuelveaesconder()
        {
            B1_but.Visible = false;
            B2_but.Visible = false;
            B3_but.Visible = false;
            B4_but.Visible = false;
            B5_but.Visible = false;
            B6_but.Visible = false;
            B7_but.Visible = false;
        }
        private void ColoresReset()
        {
            vermell = 0;
            taronja = 0;
            groc = 0;
            verd = 0;
            blau = 0;
            lila = 0;
            rosa = 0;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (intentos < 3)
            {
                if (groc == 7 && vermell == 3 && blau == 2 && lila == 4 && taronja == 1 && verd == 6 && rosa == 5)
                {
                    MessageBox.Show("Eres un crack lo has solucionado! A ver qué hacen tus compañeros...");
                    button2.Visible = false;
                    button2.Enabled = false;

                    string mensaje = "16/" + idPartida + "/bien";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    button1.Visible = false;
                    
                    ColoresReset();
                    Vuelveaesconder();
                }
                else
                {
                    MessageBox.Show("Te has equivocado vuelve a empezar");
                    intentos = intentos + 1;
                    textBox1.Text = Convert.ToString(intentos);
                    contador = 0;
                    Vuelveaesconder();
                    ColoresReset();
                }
            }
            else
            {
                MessageBox.Show("BOOOOOM");
                button2.Visible = false;
                button2.Enabled = false;
                string mensaje = "16/" + idPartida + "/mal";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                Vuelveaesconder();
                ColoresReset();

                button1.Visible = false;
                this.Hide();//Entra vídeo caso fatal
            }
        }

        private void SalaActos_Load(object sender, EventArgs e)
        {
            //Para que el usuario sepa en que orden ha dado click a los botones vamos a escribirselo
            B1_but.Visible = false;
            B2_but.Visible = false;
            B3_but.Visible = false;
            B4_but.Visible = false;
            B5_but.Visible = false;
            B6_but.Visible = false;
            B7_but.Visible = false;
        }

        public void RecogerDatos(string Nombre, Socket server, int idPartida)
        {
            this.Nombre = Nombre;
            this.server = server;
            this.idPartida = idPartida;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(contador==0)
            {
                MessageBox.Show("Creo que no le has dado a ningun boton");
            }
            else if (contador != 0)
            {
                contador = 0;
                Vuelveaesconder();
                ColoresReset();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (vermell == 0)
            {
                contador = contador + 1;
                vermell = contador;
                Dimeaquelehedado(contador, "Rojo");
            }
            else
            {
                MessageBox.Show("Al boton rojo ya le has dado antes");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (taronja == 0)
            {
                contador = contador + 1;
                taronja = contador;
                Dimeaquelehedado(contador, "Naranja");
            }
            else
            {
                MessageBox.Show("Al boton naranja ya le has dado antes");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (groc == 0)
            {
                contador = contador + 1;
                groc = contador;
                Dimeaquelehedado(contador, "Amarillo");
            }
            else
            {
                MessageBox.Show("Al boton amarillo ya le has dado antes");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (verd == 0)
            {
                contador = contador + 1;
                verd = contador;
                Dimeaquelehedado(contador, "Verde");
            }
            else
            {
                MessageBox.Show("Al boton verde ya le has dado antes");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (blau == 0)
            {
                contador = contador + 1;
                blau = contador;
                Dimeaquelehedado(contador, "Azul");
            }
            else
            {
                MessageBox.Show("Al boton azul ya le has dado antes");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (lila == 0)
            {
                contador = contador + 1;
                lila = contador;
                Dimeaquelehedado(contador, "Violeta");
            }
            else
            {
                MessageBox.Show("Al boton lila ya le has dado antes");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (rosa == 0)
            {
                contador = contador + 1;
                rosa = contador;
                Dimeaquelehedado(contador, "Rosa");
            }
            else
            {
                MessageBox.Show("Al boton rosa ya le has dado antes");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (vermell == 0)
            {
                contador = contador + 1;
                vermell = contador;
                Dimeaquelehedado(contador, "Rojo");
            }
            else
            {
                MessageBox.Show("Al boton rojo ya le has dado antes");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (taronja == 0)
            {
                contador = contador + 1;
                taronja = contador;
                Dimeaquelehedado(contador, "Naranja");
            }
            else
            {
                MessageBox.Show("Al boton naranja ya le has dado antes");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (groc == 0)
            {
                contador = contador + 1;
                groc = contador;
                Dimeaquelehedado(contador, "Amarillo");
            }
            else
            {
                MessageBox.Show("Al boton amarillo ya le has dado antes");
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (verd == 0)
            {
                contador = contador + 1;
                verd = contador;
                Dimeaquelehedado(contador, "Verde");
            }
            else
            {
                MessageBox.Show("Al boton verde ya le has dado antes");
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (blau == 0)
            {
                contador = contador + 1;
                blau = contador;
                Dimeaquelehedado(contador, "Azul");
            }
            else
            {
                MessageBox.Show("Al boton azul ya le has dado antes");
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (lila == 0)
            {
                contador = contador + 1;
                lila = contador;
                Dimeaquelehedado(contador, "Violeta");
            }
            else
            {
                MessageBox.Show("Al boton lila ya le has dado antes");
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (contador == 7)
            {
                MessageBox.Show("Dale al boton para ver si lo has hecho bien");
            }
            else if (rosa == 0)
            {
                contador = contador + 1;
                rosa = contador;
                Dimeaquelehedado(contador, "Rosa");
            }
            else
            {
                MessageBox.Show("Al boton rosa ya le has dado antes");
            }
        }
    }
}
