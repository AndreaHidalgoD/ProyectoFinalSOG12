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
    public partial class _28G : Form
    {
        //Tiempo para resolver la sala
        int segundos = 0;
        int minutos = 5;

        string Nombre;
        Socket server;
        int idPartida;
        public _28G()
        {
            InitializeComponent();
            timer28.Interval = 1000; //1s
            
            MaximizeBox = false;
        }

        private void buttonTelefono_Click(object sender, EventArgs e)
        {
            if (textBoxTelefono.Text == "43")//42 minutos+Día 1=43
                MessageBox.Show("Código obtenido para el siguiente elemento: 5 y nombre elemento extraño en la clase");
            else
                MessageBox.Show("Marcación incorrecta, prúebalo de nuevo con otra combinación");

        }

        private void textBoxImpresora_TextChanged(object sender, EventArgs e)
        {

        }
        public void RecogerDatos(string Nombre, Socket server, int idPartida)
        {
            //Datos necesarios para que funcione el servidor
            this.Nombre = Nombre;
            this.server = server;
            this.idPartida = idPartida;

        }


        private void buttonImpresora_Click(object sender, EventArgs e)
        {
            //Cuando le dan a la impresora
            if ((textBoxImpresora.Text == "5 rata") || (textBoxImpresora.Text=="5rata") ||(textBoxImpresora.Text == "5 RATA") || (textBoxImpresora.Text == "5RATA") || (textBoxImpresora.Text == "cinco rata") || (textBoxImpresora.Text == "cincorata") || (textBoxImpresora.Text == "CINCORATA") || (textBoxImpresora.Text == "CINCO RATA") )
            {
                MessageBox.Show("Puedes archivar el fax obtenido con el código 723");
                //Mensaje de conexión a la sala
                //Si es 3, Ayuda de la sala 028G al aula de Drones 27-2
                string mensaje = "14/" + Nombre + "/3/" + Convert.ToString(idPartida);
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            else
                MessageBox.Show("No tienes los elementos necesarios para obtener el fax");
        }

        private void buttonCarpeta_Click(object sender, EventArgs e)
        {
            //Cuando hacen click a la carpeta entra aqui
            if (textBoxCarpeta.Text == "723")
            {
                MessageBox.Show("Código correcto, mensaje archivado y enigma resuelto. Anota el número 6 en el chat. NO PODRÁS VOLVER A ENTRAR EN LA SALA HASTA DENTRO DE UN TIEMPO");
                string mensaje = "15/3/" + idPartida;
                // Enviamos al servidor el ID de la partida tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                timer28.Stop();
                this.Hide();
            }
            else
                MessageBox.Show("Código incorrecto, revisa que hayas seguido bien los pasos del proceso y vuélvelo a intentar");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer28_Tick(object sender, EventArgs e)
        {
            //Cada segundo el timer entrara aqui
            if ((this.minutos == 5) && (this.segundos==0))
            { 
                label28.Text =  "05:00";
                this.minutos = this.minutos-1;
                this.segundos = 59;
                
            }

            if ((this.segundos != 0) && (this.minutos>=10) && (this.segundos>=10))
            {
                this.segundos = this.segundos - 1;
                label28.Text = Convert.ToString(this.minutos) + ": " + Convert.ToString(this.segundos);

            }
            else if ((this.segundos == 0) && (this.minutos != 0)&& (this.minutos>=10))
            {
                this.minutos = this.minutos - 1;
                this.segundos = 59;
                label28.Text = Convert.ToString(this.minutos) + ":" + Convert.ToString(this.segundos);
            }
            
            else if ((this.segundos==0)&&(this.minutos==0))
            {
                timer28.Stop();

                this.Hide();
                
            }
            else if ((this.segundos<10))

            {
                if (this.minutos >= 10)
                {
                    if (this.segundos == 1)
                    {
                        label28.Text = Convert.ToString(this.minutos) + ":01";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 2)
                    {
                        label28.Text = Convert.ToString(this.minutos) + ":02";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 3)
                    {
                        label28.Text = Convert.ToString(this.minutos) + ":03";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 4)
                    {
                        label28.Text = Convert.ToString(this.minutos) + ":04";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 5)
                    {
                        label28.Text = Convert.ToString(this.minutos) + ":05";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 6)
                    {
                        label28.Text = Convert.ToString(this.minutos) + ":06";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 7)
                    {
                        label28.Text = Convert.ToString(this.minutos) + ":07";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 8)
                    {
                        label28.Text = Convert.ToString(this.minutos) + ":08";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 9)
                    {
                        label28.Text = Convert.ToString(this.minutos) + ":09";
                        this.segundos = this.segundos - 1;
                    }
                    else if (this.segundos == 0)
                    {
                        label28.Text = Convert.ToString(this.minutos) + ":00";
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
                            label28.Text = "01:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            label28.Text = "01:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            label28.Text = "01:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            label28.Text = "01:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            label28.Text = "01:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            label28.Text = "01:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            label28.Text = "01:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            label28.Text = "01:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            label28.Text = "01:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            label28.Text = "01:00";
                            this.segundos = 59;
                            this.minutos = 0;
                        }



                    }
                    else if (this.minutos == 2)
                    {
                        if(this.segundos==9)
                        {
                            label28.Text = "02:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            label28.Text = "02:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            label28.Text = "02:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            label28.Text = "02:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            label28.Text = "02:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            label28.Text = "02:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            label28.Text = "02:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            label28.Text = "02:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            label28.Text = "02:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            label28.Text = "02:00";
                            this.segundos = 59;
                            this.minutos = 1;
                        }
                    }
                    else if (this.minutos == 3)
                    {
                        if(this.segundos==9)
                        {
                            label28.Text = "03:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            label28.Text = "03:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            label28.Text = "03:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            label28.Text = "03:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            label28.Text = "03:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            label28.Text = "03:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            label28.Text = "03:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            label28.Text = "03:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            label28.Text = "03:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            label28.Text = "03:00";
                            this.segundos = 59;
                            this.minutos = 2;
                        }
                    }
                    else if (this.minutos == 4)
                    {
                        if(this.segundos==9)
                        {
                            label28.Text = "04:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            label28.Text = "04:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            label28.Text = "04:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            label28.Text = "04:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            label28.Text = "04:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            label28.Text = "04:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            label28.Text = "04:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            label28.Text = "04:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            label28.Text = "04:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            label28.Text = "04:00";
                            this.segundos = 59;
                            this.minutos = 3;
                        }
                    }
                    else if (this.minutos == 5)
                    {
                        if(this.segundos==9)
                        {
                            label28.Text = "05:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            label28.Text = "05:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            label28.Text = "05:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            label28.Text = "05:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            label28.Text = "05:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            label28.Text = "05:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            label28.Text = "05:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            label28.Text = "05:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            label28.Text = "05:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            label28.Text = "05:00";
                            this.segundos = 59;
                            this.minutos = 4;
                        }
                    }
                    else if (this.minutos == 6)
                    {
                        if(this.segundos==9)
                        {
                            label28.Text = "06:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            label28.Text = "06:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            label28.Text = "06:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            label28.Text = "06:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            label28.Text = "06:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            label28.Text = "06:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            label28.Text = "06:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            label28.Text = "06:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            label28.Text = "06:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            label28.Text = "06:00";
                            this.segundos = 59;
                            this.minutos = 5;
                        }
                    }
                    else if (this.minutos == 7)
                    {
                        if(this.segundos==9)
                        {
                            label28.Text = "07:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            label28.Text = "07:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            label28.Text = "07:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            label28.Text = "07:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            label28.Text = "07:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            label28.Text = "07:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            label28.Text = "07:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            label28.Text = "07:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            label28.Text = "07:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            label28.Text = "07:00";
                            this.segundos = 59;
                            this.minutos = 6;
                        }
                    }
                    else if (this.minutos == 8)
                    {
                        if(this.segundos==9)
                        {
                            label28.Text = "08:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            label28.Text = "08:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            label28.Text = "08:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            label28.Text = "08:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            label28.Text = "08:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            label28.Text = "08:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            label28.Text = "08:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            label28.Text = "08:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            label28.Text = "08:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            label28.Text = "08:00";
                            this.segundos = 59;
                            this.minutos = 7;
                        }
                    }
                    else if (this.minutos == 9)
                    {
                        if(this.segundos==9)
                        {
                            label28.Text = "09:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            label28.Text = "09:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            label28.Text = "09:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            label28.Text = "09:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            label28.Text = "09:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            label28.Text = "09:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            label28.Text = "09:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            label28.Text = "09:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            label28.Text = "09:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            label28.Text = "09:00";
                            this.segundos = 59;
                            this.minutos = 8;
                            
                        }
                    }
                    else if (this.minutos == 0)
                    {
                        if(this.segundos==9)
                        {
                            label28.Text = "00:09";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==8)
                        {
                            label28.Text = "00:08";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==7)
                        {
                            label28.Text = "00:07";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==6)
                        {
                            label28.Text = "00:06";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==5)
                        {
                            label28.Text = "00:05";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==4)
                        {
                            label28.Text = "00:04";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==3)
                        {
                            label28.Text = "00:03";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==2)
                        {
                            label28.Text = "00:02";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==1)
                        {
                            label28.Text = "00:01";
                            this.segundos = this.segundos - 1;
                        }
                        else if (this.segundos==0)
                        {
                            label28.Text = "00:00";
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
                            label28.Text = "01:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                             else
                            {
                                label28.Text = "01:00";
                                this.minutos=0;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 2)
                        {
                            if (this.segundos!=0)
                            {
                            label28.Text = "02:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;}
                             else
                            {
                                label28.Text = "02:00";
                                this.minutos=1;
                                this.segundos=59;
                            }

                        }
                        else if (this.minutos  == 3)
                        {
                            if (this.segundos!=0)
                            {
                            label28.Text = "03:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;

                            }
                             else
                            {
                                label28.Text = "03:00";
                                this.minutos=2;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 4)
                        {
                            if (this.segundos!=0)
                            {
                            label28.Text = "04:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                             else
                            {
                                label28.Text = "04:00";
                                this.minutos=3;
                                this.segundos=59;
                            }
                            
                        }
                        else if (this.minutos  == 5)
                        {
                            if (this.segundos!=0)
                            {
                            label28.Text = "05:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                label28.Text = "05:00";
                                this.minutos=4;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 6)
                        {
                            if (this.segundos!=0)
                            {
                            label28.Text = "06:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                label28.Text = "06:00";
                                this.minutos=5;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 7)
                        {
                            if (this.segundos!=0)
                            {
                            label28.Text = "07:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                label28.Text = "07:00";
                                this.minutos=6;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos == 8)
                        {
                            if (this.segundos!=0)
                            {
                                label28.Text = "08:" + Convert.ToString(this.segundos);
                                 this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                label28.Text = "08:00";
                                this.minutos=8;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 9)
                        
                        {
                            if (this.segundos !=0)
                            {
                            label28.Text = "09:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;
                            }
                            else
                            {
                                label28.Text = "09:00";
                                this.minutos=8;
                                this.segundos=59;
                            }
                        }
                        else if (this.minutos  == 0)
                        {
                            if(this.segundos!=0)
                            {
                            label28.Text = "00:" + Convert.ToString(this.segundos);
                            this.segundos = this.segundos - 1;}
                            else
                            {
                                label28.Text = "00:00";
                                MessageBox.Show("Fin 2.0");
                            }
                            }
                        }
                    
        }
        public bool EnableDrones()
        {
            return true;
        }


        public void Pista028G()
        {
            //Cuando el compañero les ayude les enseñamos la pista
            MessageBox.Show("TU COMPAÑERO TE HA ENVIADO UNA PISTA: Mira en la basura, creo que alguien ha tirado un papel con unas anotaciones. ¡Otra cosa! Para resolverlo adecuadamente, comienza por el teléfono y utiliza los elementos girando en sentido horario");
        }

        private void _28G_Load(object sender, EventArgs e)
        {
            timer28.Start();
        }

        public void EmpezarTimer()
        {
            segundos = 0;
            minutos = 5;
            timer28.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnotacionesPapelera formAnotaciones = new AnotacionesPapelera();
            formAnotaciones.Show();
        }

    }
}
