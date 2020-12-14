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
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        Funciones funciones = new Funciones();
        string Nombre;
        string ip = "147.83.117.22";
        int puerto = 50085;
        string huesped;
        int idPartida;
        int contInvitados = 0;
        int contRespuestas = 0;
        int contAceptadas = 0;
        string broadcast;
        string ListaInvitados = "";
        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoDataGrid1(string [] trozos);
        delegate void DelegadoJugar(string mensaje);
        MapaJuego formMapa;
       
       
        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser
            //accedidos desde threads difetentes a los que los crearon
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            groupBox1.Visible = false;
            button3.Visible = false;
            //Servicios.Visible = false;
            contSer.Visible = false;
            dataGridView2.Visible = false;
            //dataGridView1.RowCount = 1;
            dataGridView2.ColumnCount = 1;
            dataGridView2.Columns[0].HeaderCell.Value = "Usuarios Conectados";
            dataGridView2.AutoSize = true;
            textBoxNom.Visible = false;
            buttonAceptarF1.Visible = false;
            buttonRechazarF1.Visible = false;






        }
        public void PonContador(string counter)
        {
            contSer.Text = counter;
        }
        public void FuncDataGrid(string [] trozos)
        {
            //Recibimos mensaje del servidor
            //byte[] msg2 = new byte[80];
            //server.Receive(msg2);
            //string[] trozos;
            //string mensaje = mensaje = trozos[0].Split('\0')[0];
           
            //dataGridView2.Rows.Clear();

            dataGridView2.Rows.Clear();
            int i = 1;
            while (i <= Convert.ToInt32(trozos[1]))
            {

                dataGridView2.Rows.Add(trozos[i + 1]);
                i = i + 1;

            }
        }
        public void QuieresJugar(string mensaje)
        {
            textBoxNom.Visible = true;
            buttonAceptarF1.Visible = true;
            buttonRechazarF1.Visible = true;
            textBoxNom.Text = "¿Quieres aceptar la invitación de " + mensaje + "?";
        }

      
         private void AtenderServidor()
        {
            //try
            //{
            int codigo;
            string mensaje;
         

                while (true)
                {   
                    
                    //Recibimos mensaje del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                    //string mensaje = mensaje = trozos[0].Split('\0')[0];
                    //Aqui arriba quan es desconnecta algu, es para el server--> ARREGLAR, Miguel
                    if (trozos[0] != null)
                    {
                        codigo = Convert.ToInt32(trozos[0]);
                        mensaje = mensaje = trozos[1].Split('\0')[0];

                        switch (codigo)
                        {
                            case 1: //respuesta C1
                                //string mensaje = funciones.ConQuienJuego(ID.Text, server);

                                MessageBox.Show("Has jugado con: " + mensaje);
                                break;
                            case 2: //respuesta C2

                                MessageBox.Show("El jugador con más puntos es: " + mensaje);
                                break;
                            case 3:  //respuesta C3

                                MessageBox.Show(mensaje);
                                break;

                            case 4:
                                if (mensaje == "aceptado")
                                {

                                    contAceptadas = contAceptadas + 1;
                                    contRespuestas = contRespuestas + 1;
                                }
                                else
                                    contRespuestas = contRespuestas + 1;
                                MessageBox.Show(trozos[2] + " ha " + mensaje + " jugar tu partida");

                                break;
                            case 5:
                                if (mensaje == "aceptado")
                                {

                                    MessageBox.Show("Damos comienzo a la partida con ID "+ trozos[2] +", todos han aceptado jugar. Prepárate " + Nombre);
                                    idPartida = Convert.ToInt32(trozos[2]);
                                    
                                    ThreadStart ts = delegate { PonerEnMarchaMapa(); };
                                    Thread T = new Thread(ts);
                                    T.Start();
                                    //this.Close();
                                    
                                    contAceptadas = 0;
                                    contRespuestas = 0;
                                    contInvitados = 0;
                                    //this.Close();

                                }
                                else
                                {
                                    MessageBox.Show("No habéis aceptado todos la partida, no se puede jugar. Lo sentimos " + Nombre);


                                }
                                break;
                            
                            case 6: //ListaConectados
                                DelegadoDataGrid1 delegado1= new DelegadoDataGrid1(FuncDataGrid);
                                dataGridView2.Invoke(delegado1,new object [] {trozos});
                                
                                /*dataGridView2.Rows.Clear();
                                int i=1;
                                while (i <= Convert.ToInt32(trozos[1]))
                                {
                                    
                                    dataGridView2.Rows.Add(trozos[i + 1]);
                                    i = i + 1;

                                }*/
                                break;
                            case 7: //Chat
                                
                                formMapa.RecibirMensaje(mensaje);
                                break;
                            case 8: //Recibimos notificación

                                //contSer.Text = mensaje;
                                DelegadoParaEscribir delegado = new DelegadoParaEscribir(PonContador);
                                contSer.Invoke(delegado, new object[] {mensaje});
                                break;
                            case 9:
                                
                                
                                //textBoxNom.Text = "¿Quieres aceptar la invitación de " + mensaje + "?";
                                DelegadoJugar delegado2 = new DelegadoJugar(QuieresJugar);
                                textBoxNom.Invoke(delegado2, new object[] { mensaje });
                                huesped = mensaje;
                                /* Invitacion form = new Invitacion();

                                 form.TomarNombre(mensaje);
                                 form.ShowDialog();
                                 this.Close();
                                 MessageBox.Show(Convert.ToString(aceptado));*/

                                break;
                              
                        }
                        if ((contRespuestas == contInvitados)&&(contInvitados!=0))
                        {

                            if (contRespuestas == contAceptadas)
                            {

                                broadcast = "aceptado";
                                //MessageBox.Show("Damos comienzo a la partida, todos han aceptado jugar. Prepárate " + Nombre);
                                //MapaJuego form = new MapaJuego();
                                //form.ShowDialog();
                                //this.Close();
                            }
                            else
                            {
                                broadcast ="rechazado";
                                MessageBox.Show( "No habéis aceptado todos la partida, no se puede jugar. Lo sentimos " + Nombre);
                            }
                            // Enviamos al servidor el mensaje broadcast
                            broadcast = "11/" + broadcast+"/"+Nombre+"/"+Convert.ToString(contInvitados)+ListaInvitados;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(broadcast);
                            server.Send(msg);
                            

                        }

                        
                    }
                }
            //}
            //catch (FormatException t)
            //{
            //    MessageBox.Show("Error: " + t.Message);
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (ConQuienJuego.Checked)
                {
                    //Consulta 1
                    // Busca los jugadores con los que ha jugado la persona que introduces por consola

                    string mensaje = "1/" + ID.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    //string mensaje = funciones.ConQuienJuego(ID.Text, server);
                    //MessageBox.Show("Has jugado con: " + mensaje);
                }
                else if (MasPuntos.Checked)
                {
                    //Consulta 2
                    //Busca que jugador que ha jugado en la partida introducida por consola tiene mas puntos acumulados
                    string mensaje = "2/" + partida.Text;
                    // Enviamos al servidor el ID de la partida tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    //string mensaje = funciones.QuienTieneMasPuntos(partida.Text, server);
                    //MessageBox.Show("El jugador con más puntos es: " + mensaje);

                }
                else
                {
                    //Consulta 3
                    // Busca la partida mas corta y que su tiempo es inferior a 1500s
                    string mensaje = "3/ ";
                    // En este caso no es necesario introducir ningún dato extra
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    //string mensaje = funciones.PartidaMasCorta(server);
                    //MessageBox.Show(mensaje);
                }
            }
            catch (FormatException t)
            {
                MessageBox.Show("Hay un error: " + t.Message);
            }
                

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "7/" + Nombre;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            
            
            //funciones.Desconnectar(server);
            this.BackColor = Color.Gray;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            button3.Visible = false;
            //Servicios.Visible = false;
            contSer.Visible = false;
            dataGridView2.Visible = false;
  

        }

        private void Login_Click(object sender, EventArgs e)
        {
            //Log in
            //Nos permite comprobar que el usuario y la contraseña introducidos existen en la base de datos
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse(ip);
            IPEndPoint ipep = new IPEndPoint(direc, puerto);



                //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                
            //Boolean conectado = funciones.Connectar();
            try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.Green;
                    MessageBox.Show("Conectado");
                    //Enviamos al servidor el nombre y la contraseña del usuario existente
                    string mensaje = "4/" + UsuariLogIn.Text + "/" + contrasenyaLogIn.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    //string mensaje = funciones.LogIn(UsuariLogIn.Text, contrasenyaLogIn.Text, server);
                    
                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("Este es el mensaje:" + mensaje);
                    //Nos encontramos con 3 casos diferentes
                    if (mensaje == "NO EXISTE")
                        MessageBox.Show("Este usuario no existe, por favor regístrate");
                    else if (mensaje == "LLENO")
                        MessageBox.Show("No podemos atenderte en este momento. Inténtalo más tarde");
                    else if (mensaje == "OK")
                    {
                        MessageBox.Show("Bienvenido a tu cuenta :)");
                        groupBox1.Visible = true;
                        button3.Visible = true;
                        groupBox2.Visible = false;
                        dataGridView2.Visible = true;
                        //Pongo en marcha el thread que atenderá los mensajes del servidor
                        ThreadStart ts = delegate { AtenderServidor(); };
                        atender = new Thread(ts);
                        atender.Start();

                        //Servicios.Visible = true;
                        contSer.Visible = true;
                        Nombre = UsuariLogIn.Text;
                    }

                    else
                        MessageBox.Show("La contraseña introducida es incorrecta");

                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;

                }
            

            

            
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            //Sign in

            
                //Nos permite añadir un nuevo usuario en la base de datos
            IPAddress direc = IPAddress.Parse(ip);
            IPEndPoint ipep = new IPEndPoint(direc, puerto);

                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //Boolean conectado = funciones.Connectar();
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.Green;
                    MessageBox.Show("Conectado");

                    //Enviamos al servidor el nombre y la contraseña del usuario nuevo
                    string mensaje = "5/" + UsuariSignIn.Text + "/" + ContrasenyaSignIn.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    //string mensaje = funciones.SignIn(UsuariSignIn.Text, ContrasenyaSignIn.Text, server);
                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];



                    //Nos encontramos con 3 casos
                    if (mensaje == "ERROR")
                        MessageBox.Show("Ha habido un error, revisa bien los campos");
                    else if (mensaje == "OK")
                    {
                        MessageBox.Show("Registrado correctamente! Bienvenido :)");
                       // groupBox1.Visible = true;

                        
                    }
                    else
                        MessageBox.Show("Lo sentimos, ese usuario ya existe");
                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;

                }
                //Mensaje de desconexión
                string mensaje2 = "0/";

                byte[] msg3 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
                server.Send(msg3);

                // Nos desconectamos
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();


                //funciones.Desconnectar(server);
                this.BackColor = Color.Gray;
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                //Servicios.Visible = false;
                contSer.Visible = false;
                dataGridView2.Visible = false;
            
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UsuariLogIn_TextChanged(object sender, EventArgs e)
        {

        }



        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Usuario_Click(object sender, EventArgs e)
        {

        }


        private void PonerEnMarchaMapa()
        {
            MapaJuego form = new MapaJuego(Nombre, server, idPartida);
            formMapa = form;
            form.ShowDialog();
        }
        private void Enter_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate {PonerEnMarchaMapa();};
            Thread T= new Thread(ts);
            T.Start();
            //this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contSer_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            int i=0;
            string mensaje="9/" + Nombre +"/";
            string mensaje2 = "";
            int contador = 0;
            bool encontrado = false ;
            string NombreComparar;
            //string mensaje = mensaje = trozos[0].Split('\0')[0];
            while ((i < dataGridView2.RowCount) && (encontrado==false))
            {
              
                    if (dataGridView2.Rows[i].Cells[0].Selected == true)
                    {
                        NombreComparar=Convert.ToString(dataGridView2.Rows[i].Cells[0].Value).Split('\0')[0];
                        if (NombreComparar==Nombre)
                        {
                            encontrado=true;
                        }
                        else
                        {
                            mensaje2 = mensaje2 + "/" + Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);

                            contador = contador + 1;
                        }

                    }

                    i = i + 1;
                

            }
            if (encontrado == true)
            {
                MessageBox.Show("No puedes enviarte una solicitud a ti mismo");
                contador = 0;
                mensaje2 = "";
            }
            else
            {
                
                contInvitados = contador;
                ListaInvitados = mensaje2;

                mensaje = mensaje + Convert.ToString(contador) + mensaje2;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                MessageBox.Show("Se ha enviado tu solicitud correctamente");
            }
            //MessageBox.Show(mensaje);

        }

        private void buttonAceptarF1_Click(object sender, EventArgs e)
        {
            string mensaje = "10/" + huesped + "/aceptado/"+ Nombre;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            //MessageBox.Show(mensaje);
            textBoxNom.Visible = false;
            buttonAceptarF1.Visible = false;
            buttonRechazarF1.Visible = false;

        }

        private void buttonRechazarF1_Click(object sender, EventArgs e)
        {
            string mensaje = "10/" + huesped + "/rechazado/" + Nombre;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            //MessageBox.Show(mensaje);
            textBoxNom.Visible = false;
            buttonAceptarF1.Visible = false;
            buttonRechazarF1.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "7/" + Nombre;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();


            //funciones.Desconnectar(server);
            this.BackColor = Color.Gray;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            button3.Visible = false;
            //Servicios.Visible = false;
            contSer.Visible = false;
            dataGridView2.Visible = false;
        }
        //bool aceptado;
        /*public void AceptarPartida(bool aceptado)
        {
            this.aceptado = aceptado;
            
        }*/
        

        

       

       
    }
}
