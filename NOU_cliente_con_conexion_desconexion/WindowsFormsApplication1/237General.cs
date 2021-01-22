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
    public partial class _237General : Form
    {
        //Tiempo del timer
        int segundos = 0;
        int minutos = 3;

        string Nombre;
        Socket server;
        int idPartida;
        Aula237 formA237 = new Aula237();
        bool resueltoGeneral = false;

        public _237General()
        {
            InitializeComponent();
            timer237.Interval = 1000; //1s
           
            MaximizeBox = false;
        }
        public void RecogerDatos(string Nombre, Socket server, int idPartida)
        {
            //Variables para que funcione el servidor
            this.Nombre = Nombre;
            this.server = server;
            this.idPartida = idPartida;

        }
        public void PistaMarciana()
        {
            MessageBox.Show("Modula la señal para obtener la onda señalada. Para eso, combina los botones para ajustar la onda inicial");
        }

        private void _237General_Load(object sender, EventArgs e)
        {
            timer237.Start();
        }

        public bool EnableBlau()
        {
            return true;
        }

        public void EmpezarTimer()
        {
            //Empezamos el timer
            segundos = 0;
            minutos = 3;
            timer237.Start();
        }

        private void timer237_Tick(object sender, EventArgs e)
        {
            //Cada segundo el timer entrara aqui
            resueltoGeneral=formA237.SeHaResuelto();
            
            if (resueltoGeneral == true)
            {
                formA237.Close();
                timer237.Stop();
    
                this.Hide();
            }
                      if ((this.minutos == 3) && (this.segundos==0))
            { 
                label237.Text =  "03:00";
                this.minutos = this.minutos-1;
                this.segundos = 59;
                
            }

                      if ((this.segundos != 0) && (this.minutos >= 10) && (this.segundos >= 10))
                      {
                          this.segundos = this.segundos - 1;
                          label237.Text = Convert.ToString(this.minutos) + ": " + Convert.ToString(this.segundos);

                      }
                      else if ((this.segundos == 0) && (this.minutos != 0) && (this.minutos >= 10))
                      {
                          this.minutos = this.minutos - 1;
                          this.segundos = 59;
                          label237.Text = Convert.ToString(this.minutos) + ":" + Convert.ToString(this.segundos);
                      }

                      else if ((this.segundos == 0) && (this.minutos == 0))
                      {
                          timer237.Stop();

                          this.Hide();

                      }
                      else if ((this.segundos < 10))
                      {
                          if (this.minutos >= 10)
                          {
                              if (this.segundos == 1)
                              {
                                  label237.Text = Convert.ToString(this.minutos) + ":01";
                                  this.segundos = this.segundos - 1;
                              }
                              else if (this.segundos == 2)
                              {
                                  label237.Text = Convert.ToString(this.minutos) + ":02";
                                  this.segundos = this.segundos - 1;
                              }
                              else if (this.segundos == 3)
                              {
                                  label237.Text = Convert.ToString(this.minutos) + ":03";
                                  this.segundos = this.segundos - 1;
                              }
                              else if (this.segundos == 4)
                              {
                                  label237.Text = Convert.ToString(this.minutos) + ":04";
                                  this.segundos = this.segundos - 1;
                              }
                              else if (this.segundos == 5)
                              {
                                  label237.Text = Convert.ToString(this.minutos) + ":05";
                                  this.segundos = this.segundos - 1;
                              }
                              else if (this.segundos == 6)
                              {
                                  label237.Text = Convert.ToString(this.minutos) + ":06";
                                  this.segundos = this.segundos - 1;
                              }
                              else if (this.segundos == 7)
                              {
                                  label237.Text = Convert.ToString(this.minutos) + ":07";
                                  this.segundos = this.segundos - 1;
                              }
                              else if (this.segundos == 8)
                              {
                                  label237.Text = Convert.ToString(this.minutos) + ":08";
                                  this.segundos = this.segundos - 1;
                              }
                              else if (this.segundos == 9)
                              {
                                  label237.Text = Convert.ToString(this.minutos) + ":09";
                                  this.segundos = this.segundos - 1;
                              }
                              else if (this.segundos == 0)
                              {
                                  label237.Text = Convert.ToString(this.minutos) + ":00";
                                  this.segundos = 59;
                                  this.minutos = 0;
                              }
                          }
                          else
                          {
                              if (this.minutos == 1)
                              {
                                  if (this.segundos == 9)
                                  {
                                      label237.Text = "01:09";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 8)
                                  {
                                      label237.Text = "01:08";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 7)
                                  {
                                      label237.Text = "01:07";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 6)
                                  {
                                      label237.Text = "01:06";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 5)
                                  {
                                      label237.Text = "01:05";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 4)
                                  {
                                      label237.Text = "01:04";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 3)
                                  {
                                      label237.Text = "01:03";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 2)
                                  {
                                      label237.Text = "01:02";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 1)
                                  {
                                      label237.Text = "01:01";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 0)
                                  {
                                      label237.Text = "01:00";
                                      this.segundos = 59;
                                      this.minutos = 0;
                                  }



                              }
                              else if (this.minutos == 2)
                              {
                                  if (this.segundos == 9)
                                  {
                                      label237.Text = "02:09";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 8)
                                  {
                                      label237.Text = "02:08";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 7)
                                  {
                                      label237.Text = "02:07";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 6)
                                  {
                                      label237.Text = "02:06";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 5)
                                  {
                                      label237.Text = "02:05";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 4)
                                  {
                                      label237.Text = "02:04";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 3)
                                  {
                                      label237.Text = "02:03";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 2)
                                  {
                                      label237.Text = "02:02";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 1)
                                  {
                                      label237.Text = "02:01";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 0)
                                  {
                                      label237.Text = "02:00";
                                      this.segundos = 59;
                                      this.minutos = 1;
                                  }
                              }
                              else if (this.minutos == 3)
                              {
                                  if (this.segundos == 9)
                                  {
                                      label237.Text = "03:09";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 8)
                                  {
                                      label237.Text = "03:08";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 7)
                                  {
                                      label237.Text = "03:07";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 6)
                                  {
                                      label237.Text = "03:06";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 5)
                                  {
                                      label237.Text = "03:05";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 4)
                                  {
                                      label237.Text = "03:04";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 3)
                                  {
                                      label237.Text = "03:03";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 2)
                                  {
                                      label237.Text = "03:02";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 1)
                                  {
                                      label237.Text = "03:01";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 0)
                                  {
                                      label237.Text = "03:00";
                                      this.segundos = 59;
                                      this.minutos = 2;
                                  }
                              }
                              else if (this.minutos == 4)
                              {
                                  if (this.segundos == 9)
                                  {
                                      label237.Text = "04:09";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 8)
                                  {
                                      label237.Text = "04:08";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 7)
                                  {
                                      label237.Text = "04:07";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 6)
                                  {
                                      label237.Text = "04:06";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 5)
                                  {
                                      label237.Text = "04:05";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 4)
                                  {
                                      label237.Text = "04:04";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 3)
                                  {
                                      label237.Text = "04:03";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 2)
                                  {
                                      label237.Text = "04:02";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 1)
                                  {
                                      label237.Text = "04:01";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 0)
                                  {
                                      label237.Text = "04:00";
                                      this.segundos = 59;
                                      this.minutos = 3;
                                  }
                              }
                              else if (this.minutos == 5)
                              {
                                  if (this.segundos == 9)
                                  {
                                      label237.Text = "05:09";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 8)
                                  {
                                      label237.Text = "05:08";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 7)
                                  {
                                      label237.Text = "05:07";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 6)
                                  {
                                      label237.Text = "05:06";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 5)
                                  {
                                      label237.Text = "05:05";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 4)
                                  {
                                      label237.Text = "05:04";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 3)
                                  {
                                      label237.Text = "05:03";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 2)
                                  {
                                      label237.Text = "05:02";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 1)
                                  {
                                      label237.Text = "05:01";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 0)
                                  {
                                      label237.Text = "05:00";
                                      this.segundos = 59;
                                      this.minutos = 4;
                                  }
                              }
                              else if (this.minutos == 6)
                              {
                                  if (this.segundos == 9)
                                  {
                                      label237.Text = "06:09";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 8)
                                  {
                                      label237.Text = "06:08";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 7)
                                  {
                                      label237.Text = "06:07";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 6)
                                  {
                                      label237.Text = "06:06";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 5)
                                  {
                                      label237.Text = "06:05";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 4)
                                  {
                                      label237.Text = "06:04";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 3)
                                  {
                                      label237.Text = "06:03";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 2)
                                  {
                                      label237.Text = "06:02";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 1)
                                  {
                                      label237.Text = "06:01";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 0)
                                  {
                                      label237.Text = "06:00";
                                      this.segundos = 59;
                                      this.minutos = 5;
                                  }
                              }
                              else if (this.minutos == 7)
                              {
                                  if (this.segundos == 9)
                                  {
                                      label237.Text = "07:09";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 8)
                                  {
                                      label237.Text = "07:08";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 7)
                                  {
                                      label237.Text = "07:07";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 6)
                                  {
                                      label237.Text = "07:06";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 5)
                                  {
                                      label237.Text = "07:05";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 4)
                                  {
                                      label237.Text = "07:04";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 3)
                                  {
                                      label237.Text = "07:03";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 2)
                                  {
                                      label237.Text = "07:02";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 1)
                                  {
                                      label237.Text = "07:01";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 0)
                                  {
                                      label237.Text = "07:00";
                                      this.segundos = 59;
                                      this.minutos = 6;
                                  }
                              }
                              else if (this.minutos == 8)
                              {
                                  if (this.segundos == 9)
                                  {
                                      label237.Text = "08:09";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 8)
                                  {
                                      label237.Text = "08:08";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 7)
                                  {
                                      label237.Text = "08:07";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 6)
                                  {
                                      label237.Text = "08:06";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 5)
                                  {
                                      label237.Text = "08:05";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 4)
                                  {
                                      label237.Text = "08:04";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 3)
                                  {
                                      label237.Text = "08:03";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 2)
                                  {
                                      label237.Text = "08:02";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 1)
                                  {
                                      label237.Text = "08:01";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 0)
                                  {
                                      label237.Text = "08:00";
                                      this.segundos = 59;
                                      this.minutos = 7;
                                  }
                              }
                              else if (this.minutos == 9)
                              {
                                  if (this.segundos == 9)
                                  {
                                      label237.Text = "09:09";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 8)
                                  {
                                      label237.Text = "09:08";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 7)
                                  {
                                      label237.Text = "09:07";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 6)
                                  {
                                      label237.Text = "09:06";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 5)
                                  {
                                      label237.Text = "09:05";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 4)
                                  {
                                      label237.Text = "09:04";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 3)
                                  {
                                      label237.Text = "09:03";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 2)
                                  {
                                      label237.Text = "09:02";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 1)
                                  {
                                      label237.Text = "09:01";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 0)
                                  {
                                      label237.Text = "09:00";
                                      this.segundos = 59;
                                      this.minutos = 8;

                                  }
                              }
                              else if (this.minutos == 0)
                              {
                                  if (this.segundos == 9)
                                  {
                                      label237.Text = "00:09";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 8)
                                  {
                                      label237.Text = "00:08";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 7)
                                  {
                                      label237.Text = "00:07";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 6)
                                  {
                                      label237.Text = "00:06";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 5)
                                  {
                                      label237.Text = "00:05";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 4)
                                  {
                                      label237.Text = "00:04";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 3)
                                  {
                                      label237.Text = "00:03";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 2)
                                  {
                                      label237.Text = "00:02";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 1)
                                  {
                                      label237.Text = "00:01";
                                      this.segundos = this.segundos - 1;
                                  }
                                  else if (this.segundos == 0)
                                  {
                                      label237.Text = "00:00";
                                      MessageBox.Show("Final Countdown");
                                  }
                              }
                          }
                      }
                      else if ((this.minutos < 10) && (this.segundos >= 10))
                      {

                          if (this.minutos == 1)
                          {
                              if (this.segundos != 0)
                              {
                                  label237.Text = "01:" + Convert.ToString(this.segundos);
                                  this.segundos = this.segundos - 1;
                              }
                              else
                              {
                                  label237.Text = "01:00";
                                  this.minutos = 0;
                                  this.segundos = 59;
                              }
                          }
                          else if (this.minutos == 2)
                          {
                              if (this.segundos != 0)
                              {
                                  label237.Text = "02:" + Convert.ToString(this.segundos);
                                  this.segundos = this.segundos - 1;
                              }
                              else
                              {
                                  label237.Text = "02:00";
                                  this.minutos = 1;
                                  this.segundos = 59;
                              }

                          }
                          else if (this.minutos == 3)
                          {
                              if (this.segundos != 0)
                              {
                                  label237.Text = "03:" + Convert.ToString(this.segundos);
                                  this.segundos = this.segundos - 1;

                              }
                              else
                              {
                                  label237.Text = "03:00";
                                  this.minutos = 2;
                                  this.segundos = 59;
                              }
                          }
                          else if (this.minutos == 4)
                          {
                              if (this.segundos != 0)
                              {
                                  label237.Text = "04:" + Convert.ToString(this.segundos);
                                  this.segundos = this.segundos - 1;
                              }
                              else
                              {
                                  label237.Text = "04:00";
                                  this.minutos = 3;
                                  this.segundos = 59;
                              }

                          }
                          else if (this.minutos == 5)
                          {
                              if (this.segundos != 0)
                              {
                                  label237.Text = "05:" + Convert.ToString(this.segundos);
                                  this.segundos = this.segundos - 1;
                              }
                              else
                              {
                                  label237.Text = "05:00";
                                  this.minutos = 4;
                                  this.segundos = 59;
                              }
                          }
                          else if (this.minutos == 6)
                          {
                              if (this.segundos != 0)
                              {
                                  label237.Text = "06:" + Convert.ToString(this.segundos);
                                  this.segundos = this.segundos - 1;
                              }
                              else
                              {
                                  label237.Text = "06:00";
                                  this.minutos = 5;
                                  this.segundos = 59;
                              }
                          }
                          else if (this.minutos == 7)
                          {
                              if (this.segundos != 0)
                              {
                                  label237.Text = "07:" + Convert.ToString(this.segundos);
                                  this.segundos = this.segundos - 1;
                              }
                              else
                              {
                                  label237.Text = "07:00";
                                  this.minutos = 6;
                                  this.segundos = 59;
                              }
                          }
                          else if (this.minutos == 8)
                          {
                              if (this.segundos != 0)
                              {
                                  label237.Text = "08:" + Convert.ToString(this.segundos);
                                  this.segundos = this.segundos - 1;
                              }
                              else
                              {
                                  label237.Text = "08:00";
                                  this.minutos = 8;
                                  this.segundos = 59;
                              }
                          }
                          else if (this.minutos == 9)
                          {
                              if (this.segundos != 0)
                              {
                                  label237.Text = "09:" + Convert.ToString(this.segundos);
                                  this.segundos = this.segundos - 1;
                              }
                              else
                              {
                                  label237.Text = "09:00";
                                  this.minutos = 8;
                                  this.segundos = 59;
                              }
                          }
                          else if (this.minutos == 0)
                          {
                              if (this.segundos != 0)
                              {
                                  label237.Text = "00:" + Convert.ToString(this.segundos);
                                  this.segundos = this.segundos - 1;
                              }
                              else
                              {
                                  label237.Text = "00:00";
                                  MessageBox.Show("Fin 2.0");
                              }
                          }
                      }
        }

        private void label237_Click(object sender, EventArgs e)
        {

        }

        private void botonInvisible_Click(object sender, EventArgs e)
        {
            //Mensaje de conexión a la sala
            //Si es 4, Envía manual a la sala 021B
            string mensaje = "14/" + Nombre + "/4/" + Convert.ToString(idPartida);
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formA237.RecogerDatos(Nombre, server, idPartida);
            formA237.Show();
        }
    }
}
