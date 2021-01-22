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
    public partial class Blau1 : Form
    {
        //Tiempo para resolver la sala
        int minutos = 3;
        int segundos = 0;
        Boolean HaTocadoelAvion = false;
        int pelotasdegolf = 0;
        
        string Nombre;
        
        Socket server;
        int idPartida;
        Blau1_2 formBlau12 = new Blau1_2();
        Boolean pelotagolf1 = false;
        Boolean Cables = false;
        Boolean PistaInstrucciones = false; 
        string background = "Blau1_CablesTallats";

        public Blau1()
        {
            InitializeComponent();
            timerBlau.Interval = 1000; //1s
            timerBlau.Start();
            MaximizeBox = false;
           
        }
        public void EmpezarTimer()
        {
            segundos = 0;
            minutos = 3;
            timerBlau.Start();
        }
        public void PistaInstruccionesFuncion()
        {
            PistaInstrucciones = true;
            MessageBox.Show("Has recibido el mensaje con el libro de instrucciones. Ya puedes volver a clicar y podrás leer su contenido!");
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (pelotagolf1 == false)
            {
                pelotasdegolf = pelotasdegolf + 1;
                pelotagolf1 = true;
            }
            else
                MessageBox.Show("Esta pelota ya la has guardado");
        }
        public void RecogerDatos(string Nombre, Socket server, int idPartida)
        {
            this.Nombre = Nombre;
            this.server = server;
            this.idPartida = idPartida;

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Blau1_2 form = new Blau1_2();
            form.ShowDialog();

        }

        private void Resolver_Click(object sender, EventArgs e)
        {
            //Cable 1,3,6
            if (V1.Checked == true && B2.Checked == true && G1.Checked == true && V2.Checked==false && B1.Checked==false && Verd1.Checked==false)
            {
                //Le da la pista
                MessageBox.Show("Eres una maquina! Anota el valor 4 en el chat. NO PODRÁS VOLVER A ENTRAR EN LA SALA HASTA DENTRO DE UN TIEMPO");

                //Cambia el fondo de pantalla

                //Bitmap img = new Bitmap(background);
                //this.Blau1.BackgroundImage = img;
                //this.BackgroundImageLayout = ImageLayout.Stretch;
                string mensaje = "15/6/" + idPartida;
                // Enviamos al servidor el ID de la partida tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);


                
                formBlau12.Hide();
                timerBlau.Stop();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Lo siento te has equivocado");
            }
        }

        private void Blau1_Load(object sender, EventArgs e)
        {
            Resolver.Visible = false;
            panel1.Visible = false;
        }

        private void buttonAula_Click(object sender, EventArgs e)
        {
            //Variables necesarias para que funcione el servidor
            formBlau12.RecogerDatos(Nombre, server, idPartida);
            formBlau12.Show();
        }

        private void Blau1_Load_1(object sender, EventArgs e)
        {
            Resolver.Visible = false;
            panel1.Visible = false;
            timerBlau.Start();
        }
        public bool Enable237()
        {
            return true;
        }

        private void timerBlau_Tick(object sender, EventArgs e)
        {
                      if ((this.minutos == 3) && (this.segundos==0))
            { 
                labelBlau.Text =  "03:00";
                this.minutos = this.minutos-1;
                this.segundos = 59;
                
            }

            if ((this.segundos != 0) && (this.minutos>=10) && (this.segundos>=10))
            {
                this.segundos = this.segundos - 1;
                labelBlau.Text = Convert.ToString(this.minutos) + ": " + Convert.ToString(this.segundos);

            }
            else if ((this.segundos == 0) && (this.minutos != 0)&& (this.minutos>=10))
            {
                this.minutos = this.minutos - 1;
                this.segundos = 59;
                labelBlau.Text = Convert.ToString(this.minutos) + ":" + Convert.ToString(this.segundos);
            }
            
            else if ((this.segundos==0)&&(this.minutos==0))
            {
                timerBlau.Stop();
                this.Hide();
                
            }
            else if ((this.segundos<10))

            {
                if (this.minutos >= 10)
                {
                    if (this.segundos == 1)
                    {
                        labelBlau.Text = Convert.ToString(this.minutos) + ":01";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 2)
                    {
                        labelBlau.Text = Convert.ToString(this.minutos) + ":02";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 3)
                    {
                        labelBlau.Text = Convert.ToString(this.minutos) + ":03";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 4)
                    {
                        labelBlau.Text = Convert.ToString(this.minutos) + ":04";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 5)
                    {
                        labelBlau.Text = Convert.ToString(this.minutos) + ":05";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 6)
                    {
                        labelBlau.Text = Convert.ToString(this.minutos) + ":06";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 7)
                    {
                        labelBlau.Text = Convert.ToString(this.minutos) + ":07";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 8)
                    {
                        labelBlau.Text = Convert.ToString(this.minutos) + ":08";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 9)
                    {
                        labelBlau.Text = Convert.ToString(this.minutos) + ":09";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 0)
                    {
                        labelBlau.Text = Convert.ToString(this.minutos) + ":00";
                        this.segundos = 59;
                        this.minutos = 0;
                    }
                }
                else
                {
                    if (this.minutos == 1)
                    {
                        if(this.segundos==9)
                        {
                            labelBlau.Text = "01:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelBlau.Text = "01:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelBlau.Text = "01:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelBlau.Text = "01:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelBlau.Text = "01:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelBlau.Text = "01:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelBlau.Text = "01:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelBlau.Text = "01:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelBlau.Text = "01:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelBlau.Text = "01:00";
                            this.segundos = 59;
                            this.minutos = 0;
                        }



                    }
                    else if (this.minutos == 2)
                    {
                        if(this.segundos==9)
                        {
                            labelBlau.Text = "02:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelBlau.Text = "02:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelBlau.Text = "02:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelBlau.Text = "02:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelBlau.Text = "02:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelBlau.Text = "02:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelBlau.Text = "02:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelBlau.Text = "02:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelBlau.Text = "02:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelBlau.Text = "02:00";
                            this.segundos = 59;
                            this.minutos = 1;
                        }
                    }
                    else if (this.minutos == 3)
                    {
                        if(this.segundos==9)
                        {
                            labelBlau.Text = "03:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelBlau.Text = "03:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelBlau.Text = "03:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelBlau.Text = "03:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelBlau.Text = "03:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelBlau.Text = "03:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelBlau.Text = "03:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelBlau.Text = "03:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelBlau.Text = "03:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelBlau.Text = "03:00";
                            this.segundos = 59;
                            this.minutos = 2;
                        }
                    }
                    else if (this.minutos == 4)
                    {
                        if(this.segundos==9)
                        {
                            labelBlau.Text = "04:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelBlau.Text = "04:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelBlau.Text = "04:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelBlau.Text = "04:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelBlau.Text = "04:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelBlau.Text = "04:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelBlau.Text = "04:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelBlau.Text = "04:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelBlau.Text = "04:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelBlau.Text = "04:00";
                            this.segundos = 59;
                            this.minutos = 3;
                        }
                    }
                    else if (this.minutos == 5)
                    {
                        if(this.segundos==9)
                        {
                            labelBlau.Text = "05:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelBlau.Text = "05:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelBlau.Text = "05:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelBlau.Text = "05:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelBlau.Text = "05:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelBlau.Text = "05:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelBlau.Text = "05:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelBlau.Text = "05:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelBlau.Text = "05:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelBlau.Text = "05:00";
                            this.segundos = 59;
                            this.minutos = 4;
                        }
                    }
                    else if (this.minutos == 6)
                    {
                        if(this.segundos==9)
                        {
                            labelBlau.Text = "06:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelBlau.Text = "06:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelBlau.Text = "06:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelBlau.Text = "06:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelBlau.Text = "06:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelBlau.Text = "06:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelBlau.Text = "06:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelBlau.Text = "06:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelBlau.Text = "06:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelBlau.Text = "06:00";
                            this.segundos = 59;
                            this.minutos = 5;
                        }
                    }
                    else if (this.minutos == 7)
                    {
                        if(this.segundos==9)
                        {
                            labelBlau.Text = "07:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelBlau.Text = "07:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelBlau.Text = "07:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelBlau.Text = "07:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelBlau.Text = "07:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelBlau.Text = "07:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelBlau.Text = "07:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelBlau.Text = "07:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelBlau.Text = "07:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelBlau.Text = "07:00";
                            this.segundos = 59;
                            this.minutos = 6;
                        }
                    }
                    else if (this.minutos == 8)
                    {
                        if(this.segundos==9)
                        {
                            labelBlau.Text = "08:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelBlau.Text = "08:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelBlau.Text = "08:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelBlau.Text = "08:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelBlau.Text = "08:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelBlau.Text = "08:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelBlau.Text = "08:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelBlau.Text = "08:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelBlau.Text = "08:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelBlau.Text = "08:00";
                            this.segundos = 59;
                            this.minutos = 7;
                        }
                    }
                    else if (this.minutos == 9)
                    {
                        if(this.segundos==9)
                        {
                            labelBlau.Text = "09:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelBlau.Text = "09:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelBlau.Text = "09:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelBlau.Text = "09:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelBlau.Text = "09:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelBlau.Text = "09:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelBlau.Text = "09:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelBlau.Text = "09:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelBlau.Text = "09:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelBlau.Text = "09:00";
                            this.segundos = 59;
                            this.minutos = 8;
                            
                        }
                    }
                    else if (this.minutos == 0)
                    {
                        if(this.segundos==9)
                        {
                            labelBlau.Text = "00:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            labelBlau.Text = "00:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            labelBlau.Text = "00:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            labelBlau.Text = "00:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            labelBlau.Text = "00:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            labelBlau.Text = "00:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            labelBlau.Text = "00:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            labelBlau.Text = "00:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            labelBlau.Text = "00:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            labelBlau.Text = "00:00";
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
                            labelBlau.Text = "01:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                             else
                            {
                                labelBlau.Text = "01:00";
                                this.minutos=0;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 2)
                        {
                            if (this.segundos!=0)
                            {
                            labelBlau.Text = "02:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;}
                             else
                            {
                                labelBlau.Text = "02:00";
                                this.minutos=1;
                                this.segundos=59;
                            }

                        }
                        else if (this.minutos  == 3)
                        {
                            if (this.segundos!=0)
                            {
                            labelBlau.Text = "03:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;

                            }
                             else
                            {
                                labelBlau.Text = "03:00";
                                this.minutos=2;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 4)
                        {
                            if (this.segundos!=0)
                            {
                            labelBlau.Text = "04:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                             else
                            {
                                labelBlau.Text = "04:00";
                                this.minutos=3;
                                this.segundos=59;
                            }
                            
                        }
                        else if (this.minutos  == 5)
                        {
                            if (this.segundos!=0)
                            {
                            labelBlau.Text = "05:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                labelBlau.Text = "05:00";
                                this.minutos=4;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 6)
                        {
                            if (this.segundos!=0)
                            {
                            labelBlau.Text = "06:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                labelBlau.Text = "06:00";
                                this.minutos=5;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 7)
                        {
                            if (this.segundos!=0)
                            {
                            labelBlau.Text = "07:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                labelBlau.Text = "07:00";
                                this.minutos=6;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos == 8)
                        {
                            if (this.segundos!=0)
                            {
                                labelBlau.Text = "08:" + Convert.ToString(this.segundos);
                                 this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                labelBlau.Text = "08:00";
                                this.minutos=8;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 9)
                        
                        {
                            if (this.segundos !=0)
                            {
                            labelBlau.Text = "09:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                labelBlau.Text = "09:00";
                                this.minutos=8;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 0)
                        {
                            if(this.segundos!=0)
                            {
                            labelBlau.Text = "00:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;}
                            else
                            {
                                labelBlau.Text = "00:00";
                                MessageBox.Show("Fin 2.0");
                            }
                            }
                        }
                    
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Para intentar solucionar el panel 
            if (Cables == false)
            {
                panel1.Visible = true;
                Resolver.Visible = true;
                Cables = true;
            }

            else
            {
                Cables = false;
                panel1.Visible = false;
                Resolver.Visible = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (PistaInstrucciones == true)
            {
                Blau1_Instruccions form = new Blau1_Instruccions();
                form.Show();
            }
            else
                MessageBox.Show("Pidele a tus compañeros por el chat que te envíen por correo el manual de instrucciones. Una vez recibas el mensaje enviado, vuelve a clicar y podrás leer las instrucciones.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (HaTocadoelAvion == false)
            {
                MessageBox.Show("Que te he dicho de tocarme... a la próxima te vas a arrepentir");
                HaTocadoelAvion = true;
            }
            else
            {
                MessageBox.Show("Pues te quedas sin pelotas de golf!");
                pelotasdegolf = 0;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Color del cable a cortar: Estoy en el cielo, estoy en el mar, también en las turquesas y en un pavo real. ¿Cuál de los dos? El numerado con el segundo número primo."); //Cable azul con Nº3
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Color del cable a cortar: Con vida estoy medio año, sin vida la otra mitad, ando siempre por el mundo y no me canso jamás. Si aún no sabes quién soy, prueba a mirarme comiendo un plátano y verás como no me podrás volver a ver jamás!"); //Es el sol cable amarillo
        }

    }
}
