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
    
    public partial class G1 : Form
    {
        bool tecnico = false;

        //Tiempo para resolver la sala
        int segundos = 0;
        int minutos = 3;

        string Nombre;
        Socket server;
        int idPartida;
        bool ApagadoLuces = false;
        public G1()
        {
            InitializeComponent();
            timerGroga2.Interval = 1000; //1s
    
            MaximizeBox = false;

        }
        string background1 = "Groga1llum.png"; //Para apagar y encender la luz
        string background2 = "Groga1Nollum.png";
        public void RecogerDatos(string Nombre, Socket server, int idPartida)
        {
            this.Nombre = Nombre;
            this.server = server;
            this.idPartida = idPartida;
            
        }
        public void EmpezarTimer()
        {
             this.segundos = 0;
             this.minutos = 3;
            timerGroga2.Start();
        }

        public void CambiarEstadoTecnico()
        {
            tecnico = true;
            MessageBox.Show("Se ha arreglado la luz, ya se puede clicar");
        }

        private void buttonG1_Click(object sender, EventArgs e)
        {
            //Para intentar resolver la sala
            if ((textBoxG1.Text == "7") || (textBoxG1.Text=="Siete") || (textBoxG1.Text=="siete") || (textBoxG1.Text=="SIETE"))
            {
                MessageBox.Show("Respuesta correcta, enigma resuelto. Anota el valor 7 y escríbelo EN EL CHAT para tus compañeros. NO PODRÁS VOLVER A ENTRAR EN LA SALA HASTA DENTRO DE UN TIEMPO");
                string mensaje = "15/2/" + idPartida;
                // Enviamos al servidor el ID de la partida tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                timerGroga2.Stop();
                this.Hide();
                
            }
            else
                MessageBox.Show("Respuesta incorrecta, sigue pensando");
        }


        public bool EnableVermella()
        {
            return true;
        }



        private void G1_Load(object sender, EventArgs e)
        {
            this.segundos = 0;
            this.minutos = 3;
            timerGroga2.Start();
        }

        private void timerGroga2_Tick_1(object sender, EventArgs e)
        {
            //Cada segundo el timer entrara aqui
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
                timerGroga2.Stop();
                this.Hide();
                
            }
            else if ((this.segundos<10))

            {
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
                    }

        private void button5_Click(object sender, EventArgs e)
        {
            //Boton para arreglar las luces
            if ((ApagadoLuces == false) && (tecnico == true))
            {
                Bitmap img = new Bitmap(background2);
                this.BackgroundImage = img;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                ApagadoLuces = true;
            }
            else if ((ApagadoLuces == true) && (tecnico == true))
            {
                Bitmap img = new Bitmap(background1);
                this.BackgroundImage = img;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                ApagadoLuces = false;
            }
            else
                MessageBox.Show("Avisa a tus compañeros POR EL CHAT para que llamen al técnico y arregle la luz");

        }

    }


}
    
