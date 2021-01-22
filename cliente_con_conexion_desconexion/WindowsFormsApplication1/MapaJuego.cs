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
    public partial class MapaJuego : Form
    {
        string Nombre;
        Socket server;
        int idPartida;
        string mensaje;
        delegate void DelegadoChat(string mensaje);
        public MapaJuego(string Nombre, Socket server, int idPartida)
        {
            InitializeComponent();
            this.Nombre = Nombre;
            this.server = server;
            this.idPartida=idPartida;
        }
        public void Chatear(string mensaje)
        {
            ChatTextBox.Text += System.Environment.NewLine + mensaje;
            
        }
        public void RecibirMensaje(string mensaje)
        {
            this.mensaje = mensaje;
            DelegadoChat delegadochat = new DelegadoChat(Chatear);
            ChatTextBox.Invoke(delegadochat, new object[] { mensaje });
             
        }


        private void buttonG1_Click(object sender, EventArgs e)
        {
            G1 form = new G1();
            form.ShowDialog();
            //this.Close();

        }

        private void Vermella_Click(object sender, EventArgs e)
        {
            Vermella form = new Vermella();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _237General form = new _237General();
            form.ShowDialog();
        }

        private void TextBox237_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AulaDrones form = new AulaDrones();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _28G form = new _28G();
            form.ShowDialog();
        }

        private void MapaJuego_Load(object sender, EventArgs e)
        {
            
        }

        private void MapaJuego_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close(); //Preguntar Miguel martes 15, ¿se podría volver a jugar a la partida si se cierra el forms en el estado que se ha quedado o en el que continua?
        }

       

        private void textBoxChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonChat_Click(object sender, EventArgs e)
        {

            //Enviar mensaje chat

            //string textComplet = "\b " + Nombre + ":\b0 " + textBoxChat.Text; ¿Miguel?
            string textComplet =  Nombre +": " + textBoxChat.Text;
            string mensaje = "12/" +idPartida+ "/"+ textComplet;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            

        }

        private void ChatTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SalaActos form = new SalaActos();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Blau1_Instruccions form = new Blau1_Instruccions();
            form.ShowDialog();
        }

        
    }
}
