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
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class MapaJuego : Form
    {
        string Nombre;
        Socket server;
        int idPartida;
        string mensaje;
        Vermella formVerm = new Vermella();
        G1 formG1 = new G1();
        AulaDrones formDrones = new AulaDrones();
        _28G form28 = new _28G();
        Blau1 formBlau1 = new Blau1();
        _237General form237 = new _237General();
        SalaActos salaActos = new SalaActos();
        bool Sala1Resuelta = false; //Sala 025V
        bool Sala2Resuelta = false; //Sala 023G
        bool Sala3Resuelta = false; //Sala 28G
        bool Sala4Resuelta = false; //Sala Drones 
        bool Sala5Resuelta = false; //Sala 237G
        bool Sala6Resuelta = false; //Sala 021B
        bool Sala7Resuelta = false; //Sala de Actos

        int segundos=3;
        int minutos = 60; //60 mins temps+ 3' instruccions //2 mins --> 65 

        //Minutos totales por parejas de sala
        //Pareja A
        int minutosMaxA=5;

        //Pareja B
        int minutosMaxB = 1;

        //Pareja C
        int minutosMaxC=3;

        //Pareja B
        //Vermella
        int segundosv=0;
        int minutosv;
           
        //Groga
        int segundosg = 0;
        int minutosg;

        //Pareja A
        //Drones
        int segundosdrones = 0;
        int minutosdrones;

        //28G
        int segundos28 = 0;
        int minutos28;

        //Pareja C
        //237
        int segundos237 = 0;
        int minutos237;

        //Blava
        int segundosblava = 0;
        int minutosblava;

        delegate void DelegadoChat(string mensaje);

        public MapaJuego(string Nombre, Socket server, int idPartida)
        {
            InitializeComponent();
            this.Nombre = Nombre;
            this.server = server;
            this.idPartida=idPartida;

            //Salas Invisibles al principio
            button237.Visible = false;
            button28.Visible = false;
            buttonBlau.Visible = false;
            buttonDrones.Visible = false;
            buttonSalaActos.Visible = false;
            VermellaButton.Visible = false;
            buttonG1.Visible = false;
            buttonConsergeria.Visible = false;
            MaximizeBox = false;
            
            this.labelID.Text = Convert.ToString(idPartida);
            this.labelUsuario.Text = Nombre;
            timer1.Interval = 1000; //1s
            timer1.Start();
            
        }
        
        public void SalasResueltas(int sala)
        {
            //A medida que se vayan resolviendo las salas actualizamos su estado
            if (sala == 1)
            {
                MessageBox.Show("Se ha resuelto la clase 025V");
                Sala1Resuelta = true;
                
            }
            else if (sala == 2)
            {
                MessageBox.Show("Se ha resuelto la clase 023G");
                Sala2Resuelta = true;
            }
            else if (sala == 3)
            {
                MessageBox.Show("Se ha resuelto la clase 028G");
                Sala3Resuelta = true;
            }
            else if (sala == 4)
            {
                MessageBox.Show("Se ha resuelto la aula de Drones, 27-2");
                Sala4Resuelta = true;
            }
            else if (sala == 5)
            {
                MessageBox.Show("Se ha resuelto la clase 27-3");
                Sala5Resuelta = true;
                if (Sala6Resuelta == true)
                {
                    buttonSalaActos.Enabled = true; //Una vez hayan resuelto todas las salas podran entrar en la salón de actos
                }
            }
            else if (sala == 6)
            {
                MessageBox.Show("Se ha resuelto la clase 021B");
                Sala6Resuelta = true;
                if (Sala5Resuelta == true)
                {
                    buttonSalaActos.Enabled = true; //Una vez hayan resuelto todas las salas podran entrar en la salón de actos
                }
            }
            else if (sala == 7)
            {
                MessageBox.Show("Se ha resuelto la Sala de Actos"); 
                Sala7Resuelta = true;
            }
        }

        public void FuncionesSalas(int peticion)
        {
            //Funcion para la comunicación entre salas
            if (peticion == 1)
            {
                formG1.CambiarEstadoTecnico(); 
            }
            else if (peticion == 2)
            {
                form28.Pista028G();
            }
            else if (peticion == 3)
            {
                formDrones.PistaSatelites();
            }
            else if (peticion == 4)
            {
                formBlau1.PistaInstruccionesFuncion();
            }
            else if (peticion == 5)
            {
                form237.PistaMarciana();
            }
        }


        public void Chatear(string mensaje)
        {
            //Función para añadir mensajes en el chat
            ChatTextBox.Text += System.Environment.NewLine + mensaje;
            
        }
        public void RecibirMensaje(string mensaje)
        {
            //Sirve para actualizar el chat si alguien nos envia un mensaje 
            this.mensaje = mensaje;
            DelegadoChat delegadochat = new DelegadoChat(Chatear);
            ChatTextBox.Invoke(delegadochat, new object[] { mensaje });
        }

        private void buttonG1_Click(object sender, EventArgs e)
        {
            //Abrimos la sala amarilla 1
            VermellaButton.Enabled = false;
            timerGrogaG.Interval = 1000; //1s
            segundosg = 0;
            minutosg = minutosMaxB;
            timerGrogaG.Start();
            formG1.EmpezarTimer();
            
            formG1.RecogerDatos(Nombre, server, idPartida);
            
            //Mensaje de conexión a la sala
            string mensaje = "13/" + Nombre + "/2/" + Convert.ToString(idPartida);

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            formG1.Show();
        }
        
        private void VermellaButton_Click(object sender, EventArgs e)
        {
            //Abrimos la sala Roja
            timerVermellaG.Interval = 1000; //1s
            segundosv = 0;
            minutosv = minutosMaxB;
            timerVermellaG.Start();
            VermellaButton.Enabled = false;
            buttonG1.Enabled = false;
            formVerm.EmpezarTimer();
            formVerm.RecogerDatos(Nombre, server, idPartida);
            
            
            //Mensaje de conexión a la sala
            string mensaje = "13/" + Nombre + "/1/" + Convert.ToString(idPartida);

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            formVerm.Show();
        }

        private void button237_Click(object sender, EventArgs e)
        {
            //Abrimos la sala 237
            timer237G.Interval = 1000; //1s
            segundos237 = 0;
            minutos237 = minutosMaxC;
            timer237G.Start();
            buttonBlau.Enabled = false;
            button237.Enabled = false;
            form237.EmpezarTimer();
            form237.RecogerDatos(Nombre, server, idPartida);

            //Mensaje de conexión a la sala
            string mensaje = "13/" + Nombre + "/5/" + Convert.ToString(idPartida);

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            form237.Show();
        }

        private void buttonDrones_Click(object sender, EventArgs e)
        {
            //Abrimos la sala de drones
            timerDronesG.Interval = 1000; //1s
            segundosdrones = 0;
            minutosdrones = minutosMaxA;
            timerDronesG.Start();
            button28.Enabled = false;
            buttonDrones.Enabled = false;
  
            formDrones.EmpezarTimer();
            formDrones.RecogerDatos(Nombre, server, idPartida);
            
            //Mensaje de conexión a la sala
            string mensaje = "13/" + Nombre + "/4/"+Convert.ToString(idPartida);

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            formDrones.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //Abrimos la sala 28G
            timer28GG.Interval = 1000; //1s
            segundos28 = 0;
            minutos28 = minutosMaxA;
            timer28GG.Start();
            button28.Enabled = false;
            buttonDrones.Enabled = false;
            form28.EmpezarTimer();
          
            form28.RecogerDatos(Nombre, server, idPartida);
            //Mensaje de conexión a la sala
            string mensaje = "13/" + Nombre + "/3/" + Convert.ToString(idPartida);

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            form28.Show();
        }

        private void MapaJuego_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            labelTimeG.Visible = false;
            buttonSalaActos.Enabled = false;
        }
        public void EnableSalaFinal()
        {
            buttonSalaActos.Enabled = true;
        }

        private void buttonChat_Click(object sender, EventArgs e)
        {

            //Enviar mensaje chat

            string textComplet =  Nombre +": " + textBoxChat.Text;
            string mensaje = "12/" +idPartida+ "/"+ textComplet;

            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void buttonSalaActos_Click(object sender, EventArgs e)
        {
            //Abrimos el salón de actos
            salaActos.RecogerDatos(Nombre,server,idPartida);
            buttonSalaActos.Enabled = false;

            //Mensaje de conexión a la sala
            string mensaje = "13/" + Nombre + "/7/" + Convert.ToString(idPartida);

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            salaActos.Show();
        }

        private void buttonBlau_Click(object sender, EventArgs e)
        {
            //Abrimos la sala azul
            timer21BG.Interval = 1000; //1s
            segundosblava = 0;
            minutosblava = minutosMaxC;
            timer21BG.Start();
            buttonBlau.Enabled = false;
            button237.Enabled = false;
            formBlau1.EmpezarTimer();
            formBlau1.RecogerDatos(Nombre, server, idPartida);
            
            //Mensaje de conexión a la sala
            string mensaje = "13/" + Nombre + "/6/" + Convert.ToString(idPartida);

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            formBlau1.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((segundos == 0) && (minutos == 60))
            {
                label3.Visible = true;
                labelTimeG.Visible = true;
            }
                      if ((this.minutos == 3) && (this.segundos==0))
            { 
                labelTimeG.Text =  "03:00";
                this.minutos = this.minutos-1;
                this.segundos = 59;
                
            }

            if ((this.segundos != 0) && (this.minutos>=10) && (this.segundos>=10))
            {
                this.segundos = this.segundos - 1;
                labelTimeG.Text = Convert.ToString(this.minutos) + ": " + Convert.ToString(this.segundos);

            }
            else if ((this.segundos == 0) && (this.minutos != 0)&& (this.minutos>=10))
            {
                this.minutos = this.minutos - 1;
                this.segundos = 59;
                labelTimeG.Text = Convert.ToString(this.minutos) + ":" + Convert.ToString(this.segundos);
            }
            
            else if ((this.segundos==0)&&(this.minutos==0))
            {
                timer1.Stop();
                MessageBox.Show("End of times");

                string mensaje = "16/" + idPartida + "/mal";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                this.Hide();
                
            }
            else if ((this.segundos<10))
            {
                //Añadimos un zero delante de los ultimos 9 segundos para que se entienda bien el tiempo restante
                if (this.minutos >= 10)
                {
                    if (this.segundos == 1)
                    {
                        labelTimeG.Text = Convert.ToString(this.minutos) + ":01";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 2)
                    {
                        labelTimeG.Text = Convert.ToString(this.minutos) + ":02";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 3)
                    {
                        labelTimeG.Text = Convert.ToString(this.minutos) + ":03";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 4)
                    {
                        labelTimeG.Text = Convert.ToString(this.minutos) + ":04";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 5)
                    {
                        labelTimeG.Text = Convert.ToString(this.minutos) + ":05";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 6)
                    {
                        labelTimeG.Text = Convert.ToString(this.minutos) + ":06";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 7)
                    {
                        labelTimeG.Text = Convert.ToString(this.minutos) + ":07";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 8)
                    {
                        labelTimeG.Text = Convert.ToString(this.minutos) + ":08";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 9)
                    {
                        labelTimeG.Text = Convert.ToString(this.minutos) + ":09";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 0)
                    {
                        labelTimeG.Text = Convert.ToString(this.minutos) + ":00";
                        this.segundos = 59;
                        this.minutos = 0;
                    }
                }
                else
                {
                    //Hacemos lo mismo para los ultimos 9 minutos
                    if (this.minutos == 1)
                    {
                        if(this.segundos==9)
                        {
                            labelTimeG.Text = "01:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelTimeG.Text = "01:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelTimeG.Text = "01:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelTimeG.Text = "01:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelTimeG.Text = "01:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelTimeG.Text = "01:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelTimeG.Text = "01:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelTimeG.Text = "01:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelTimeG.Text = "01:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelTimeG.Text = "01:00";
                            this.segundos = 59;
                            this.minutos = 0;
                        }
                    }
                    else if (this.minutos == 2)
                    {
                        if(this.segundos==9)
                        {
                            labelTimeG.Text = "02:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelTimeG.Text = "02:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelTimeG.Text = "02:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelTimeG.Text = "02:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelTimeG.Text = "02:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelTimeG.Text = "02:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelTimeG.Text = "02:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelTimeG.Text = "02:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelTimeG.Text = "02:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelTimeG.Text = "02:00";
                            this.segundos = 59;
                            this.minutos = 1;
                        }
                    }
                    else if (this.minutos == 3)
                    {
                        if(this.segundos==9)
                        {
                            labelTimeG.Text = "03:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelTimeG.Text = "03:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelTimeG.Text = "03:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelTimeG.Text = "03:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelTimeG.Text = "03:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelTimeG.Text = "03:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelTimeG.Text = "03:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelTimeG.Text = "03:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelTimeG.Text = "03:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelTimeG.Text = "03:00";
                            this.segundos = 59;
                            this.minutos = 2;
                        }
                    }
                    else if (this.minutos == 4)
                    {
                        if(this.segundos==9)
                        {
                            labelTimeG.Text = "04:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelTimeG.Text = "04:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelTimeG.Text = "04:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelTimeG.Text = "04:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelTimeG.Text = "04:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelTimeG.Text = "04:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelTimeG.Text = "04:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelTimeG.Text = "04:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelTimeG.Text = "04:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelTimeG.Text = "04:00";
                            this.segundos = 59;
                            this.minutos = 3;
                        }
                    }
                    else if (this.minutos == 5)
                    {
                        if(this.segundos==9)
                        {
                            labelTimeG.Text = "05:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelTimeG.Text = "05:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelTimeG.Text = "05:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelTimeG.Text = "05:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelTimeG.Text = "05:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelTimeG.Text = "05:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelTimeG.Text = "05:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelTimeG.Text = "05:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelTimeG.Text = "05:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelTimeG.Text = "05:00";
                            this.segundos = 59;
                            this.minutos = 4;
                        }
                    }
                    else if (this.minutos == 6)
                    {
                        if(this.segundos==9)
                        {
                            labelTimeG.Text = "06:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelTimeG.Text = "06:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelTimeG.Text = "06:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelTimeG.Text = "06:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelTimeG.Text = "06:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelTimeG.Text = "06:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelTimeG.Text = "06:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelTimeG.Text = "06:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelTimeG.Text = "06:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelTimeG.Text = "06:00";
                            this.segundos = 59;
                            this.minutos = 5;
                        }
                    }
                    else if (this.minutos == 7)
                    {
                        if(this.segundos==9)
                        {
                            labelTimeG.Text = "07:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelTimeG.Text = "07:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelTimeG.Text = "07:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelTimeG.Text = "07:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelTimeG.Text = "07:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelTimeG.Text = "07:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelTimeG.Text = "07:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelTimeG.Text = "07:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelTimeG.Text = "07:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelTimeG.Text = "07:00";
                            this.segundos = 59;
                            this.minutos = 6;
                        }
                    }
                    else if (this.minutos == 8)
                    {
                        if(this.segundos==9)
                        {
                            labelTimeG.Text = "08:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelTimeG.Text = "08:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelTimeG.Text = "08:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelTimeG.Text = "08:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelTimeG.Text = "08:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelTimeG.Text = "08:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelTimeG.Text = "08:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelTimeG.Text = "08:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelTimeG.Text = "08:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelTimeG.Text = "08:00";
                            this.segundos = 59;
                            this.minutos = 7;
                        }
                    }
                    else if (this.minutos == 9)
                    {
                        if(this.segundos==9)
                        {
                            labelTimeG.Text = "09:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelTimeG.Text = "09:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelTimeG.Text = "09:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelTimeG.Text = "09:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelTimeG.Text = "09:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelTimeG.Text = "09:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelTimeG.Text = "09:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelTimeG.Text = "09:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelTimeG.Text = "09:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelTimeG.Text = "09:00";
                            this.segundos = 59;
                            this.minutos = 8;
                            
                        }
                    }
                    else if (this.minutos == 0)
                    {
                        if(this.segundos==9)
                        {
                            labelTimeG.Text = "00:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelTimeG.Text = "00:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelTimeG.Text = "00:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelTimeG.Text = "00:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelTimeG.Text = "00:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelTimeG.Text = "00:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelTimeG.Text = "00:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelTimeG.Text = "00:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelTimeG.Text = "00:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelTimeG.Text = "00:00";
                            MessageBox.Show("Final Countdown");
                        }
                    }
                }
            }
                else if ((this.minutos<10)&&(this.segundos>=10))
                {
                    
                        if (this.minutos  == 1)
                        {
                            if (this.segundos!=0)
                            {
                            labelTimeG.Text = "01:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                             else
                            {
                                labelTimeG.Text = "01:00";
                                this.minutos=0;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 2)
                        {
                            if (this.segundos!=0)
                            {
                            labelTimeG.Text = "02:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;}
                             else
                            {
                                labelTimeG.Text = "02:00";
                                this.minutos=1;
                                this.segundos=59;
                            }

                        }
                        else if (this.minutos  == 3)
                        {
                            if (this.segundos!=0)
                            {
                            labelTimeG.Text = "03:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;

                            }
                             else
                            {
                                labelTimeG.Text = "03:00";
                                this.minutos=2;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 4)
                        {
                            if (this.segundos!=0)
                            {
                            labelTimeG.Text = "04:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                             else
                            {
                                labelTimeG.Text = "04:00";
                                this.minutos=3;
                                this.segundos=59;
                            }
                            
                        }
                        else if (this.minutos  == 5)
                        {
                            if (this.segundos!=0)
                            {
                            labelTimeG.Text = "05:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                labelTimeG.Text = "05:00";
                                this.minutos=4;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 6)
                        {
                            if (this.segundos!=0)
                            {
                            labelTimeG.Text = "06:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                labelTimeG.Text = "06:00";
                                this.minutos=5;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 7)
                        {
                            if (this.segundos!=0)
                            {
                            labelTimeG.Text = "07:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                labelTimeG.Text = "07:00";
                                this.minutos=6;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos == 8)
                        {
                            if (this.segundos!=0)
                            {
                                labelTimeG.Text = "08:" + Convert.ToString(this.segundos);
                                 this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                labelTimeG.Text = "08:00";
                                this.minutos=8;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 9)
                        
                        {
                            if (this.segundos !=0)
                            {
                            labelTimeG.Text = "09:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                labelTimeG.Text = "09:00";
                                this.minutos=8;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 0)
                        {
                            if(this.segundos!=0)
                            {
                            labelTimeG.Text = "00:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;}
                            else
                            {
                                labelTimeG.Text = "00:00";
                                MessageBox.Show("Fin 2.0");
                            }
                        }
                        
                    }
            else if ((segundos==0)&& (minutos==0))
            {
                timer1.Stop();
                MessageBox.Show("Has acabado tu tiempo de juego. Los terroristas han ganado la partida");
                //this.Close(); //Vídeo final con 2 casos
            }
            if ((minutos == 60) && (segundos == 0))
            {
                VermellaButton.Visible = true;
                buttonG1.Visible = true;
                buttonConsergeria.Visible = true; 
            }
            if ((Sala1Resuelta == true) && (Sala2Resuelta == true))
            {
                buttonDrones.Visible = true;
                button28.Visible = true;
                //Pasamos video 2
            }
            if ((Sala3Resuelta == true) && (Sala4Resuelta == true))
            {
                buttonBlau.Visible = true;
                button237.Visible = true;
                //Pasamos video 3
            }
            if ((Sala5Resuelta == true) && (Sala6Resuelta == true))
            {
                buttonSalaActos.Visible = true;
            }
            
        }

        private void Instrucciones_Click(object sender, EventArgs e)
        {
            //Para enseñarles las instrucciones del juego
            InstruccionesJuego form = new InstruccionesJuego();
            form.Show();
        }

        private void timerVermella_Tick(object sender, EventArgs e)
        {
            //Cronometro de la sala roja
            if ((segundosv == 0) && (minutosv == minutosMaxB))
            {
                VermellaButton.Enabled = false;
            }
            if (segundosv != 0)
            {
                segundosv = segundosv - 1;
               
            }
            else if ((segundosv == 0) && (minutosv != 0))
            {
                minutosv = minutosv - 1;
                segundosv = 59;

            }
            else if ((segundosv == 0) && (minutosv == 0))
            {
                timerVermellaG.Stop();
                VermellaButton.Enabled = true;
                buttonG1.Enabled = true;
            }
        }

        private void timerGrogaG_Tick(object sender, EventArgs e)
        {
            //Cronometro de la sala amarilla
            if ((segundosg == 0) && (minutosg == minutosMaxB))
            {
                buttonG1.Enabled = false;
            }
            if (segundosg != 0)
            {
                segundosg = segundosg - 1;

            }
            else if ((segundosg == 0) && (minutosg != 0))
            {
                minutosg = minutosg - 1;
                segundosg = 59;

            }
            else if ((segundosg == 0) && (minutosg == 0))
            {
                timerGrogaG.Stop();
                buttonG1.Enabled = true;
                VermellaButton.Enabled = true;
            }
        }

        private void timer28GG_Tick(object sender, EventArgs e)
        {
            //Cronometro de la sala 28G
            if ((segundos28 == 0) && (minutos28 == minutosMaxA))
            {
                button28.Enabled = false;
            }
            if (segundos28 != 0)
            {
                segundos28 = segundos28 - 1;

            }
            else if ((segundos28 == 0) && (minutos28 != 0))
            {
                minutos28 = minutos28 - 1;
                segundos28 = 59;

            }
            else if ((segundos28 == 0) && (minutos28 == 0))
            {
                timer28GG.Stop();
                button28.Enabled = true;
                buttonDrones.Enabled = true;
            }
        }

        private void timerDronesG_Tick(object sender, EventArgs e)
        {
            //Cronometro de la sala de drones
            if ((segundosdrones == 0) && (minutosdrones == minutosMaxA))
            {
                buttonDrones.Enabled = false;
            }
            if (segundosdrones != 0)
            {
                segundosdrones = segundosdrones - 1;

            }
            else if ((segundosdrones == 0) && (minutosdrones != 0))
            {
                minutosdrones = minutosdrones - 1;
                segundosdrones = 59;

            }
            else if ((segundosdrones == 0) && (minutosdrones == 0))
            {
                timerDronesG.Stop();
                buttonDrones.Enabled = true;
                button28.Enabled = true;
            }
        }

        private void timer21BG_Tick(object sender, EventArgs e)
        {
            //Cronometro de la sala azul
            if ((segundosblava == 0) && (minutosblava == minutosMaxC))
            {
                buttonBlau.Enabled = false;
            }
            if (segundosblava != 0)
            {
                segundosblava = segundosblava - 1;

            }
            else if ((segundosblava == 0) && (minutosblava != 0))
            {
                minutosblava = minutosblava - 1;
                segundosblava = 59;

            }
            else if ((segundosblava == 0) && (minutosblava == 0))
            {
                timer21BG.Stop();
                buttonBlau.Enabled = true;
                button237.Enabled = true;
            }
        }

        private void timer237G_Tick(object sender, EventArgs e)
        {
            //Cronometro de la sala 237G
            if ((segundos237 == 0) && (minutos237 == minutosMaxC))
            {
                button237.Enabled = false;
            }
            if (segundos237 != 0)
            {
                segundos237 = segundos237 - 1;

            }
            else if ((segundos237 == 0) && (minutos237 != 0))
            {
                minutos237 = minutos237 - 1;
                segundos237 = 59;

            }
            else if ((segundos237 == 0) && (minutos237 == 0))
            {
                timer237G.Stop();
                button237.Enabled = true;
                buttonBlau.Enabled = true;
            }
        }

        private void buttonConsergeria_Click(object sender, EventArgs e)
        {
            //Boton para abrir la consergeria
            Consergeria form = new Consergeria();
            form.Show();
        }
    }
}
