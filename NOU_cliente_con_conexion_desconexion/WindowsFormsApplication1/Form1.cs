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
        string ip = "192.168.56.102";
        int puerto = 9285;
        string huesped;
        int idPartida;
        int contInvitados = 0;
        int contRespuestas = 0;
        int contAceptadas = 0;
        int contSolucionFinal = 0;
        int ResolucioFinal = 0;
        string broadcast;
        string ListaInvitados = "";
        bool Sala1Resuelta = false; //Sala 025V
        bool Sala2Resuelta = false; //Sala 023G
        bool Sala3Resuelta = false; //Sala 28G
        bool Sala4Resuelta = false; //Sala Drones 
        bool Sala5Resuelta = false; //Aula 27-2
        bool Sala6Resuelta = false; //Aula 021B
        bool Sala7Resuelta = false; //Sala de Actos
        bool jugandoPartida = false;
        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoDataGrid1(string [] trozos);
        delegate void DelegadoJugar(string mensaje);
        delegate void DelegadoActivarVideo(string mensaje);
        delegate void DelegadoBorrarcuenta();
        delegate void DelegadoCerrarMapaJuego();
        
        MapaJuego formMapa;
        
       
       
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Inicializamos el load
            timerF1.Interval = 1000;
            timerF1.Start();
            //Peticiones del usuario
            groupBox1.Visible = false;
            buttonBorrarCuenta.Visible = false;
           
            //Boton de logout
            LogOut_button.Visible = false; 

            //Contador de consultas 
            contSer.Visible = false; 

            //Inicializamos el datagridview
            dataGridView2.Visible = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.ColumnCount = 2;
            dataGridView2.Columns[0].HeaderCell.Value = "Usuarios Conectados";
            dataGridView2.Columns[1].HeaderCell.Value = "STATUS";
            dataGridView2.AutoSize = true;

            textBoxNom.Visible = false;  
            
            //Botones para aceptar y rechazar peticiones para jugar una partida
            buttonAceptarF1.Visible = false;
            buttonRechazarF1.Visible = false;

            //Botones y textbox que nos indican el numero de consultas realizadas y nos permiten hacer consultas al servidor
            MostrarCons.Visible = false;
            CerrarCons.Visible = false;
            buttonEnviar.Visible = false;

        }
        public void PonContador(string counter)
        {
            //Contador de peticiones
            contSer.Text = counter;
        }
        public void FuncDataGrid(string [] trozos)
        {
            //Nos permite actualizar la informacion de la datagridview
            dataGridView2.Rows.Clear();
            int i = 1;
            
            while (i <= (Convert.ToInt32(trozos[1]))*2)
            {
                if (Convert.ToInt32(trozos[i + 2]) == 0)
                {
                    dataGridView2.Rows.Add(trozos[i + 1], "Conectado"); 
                    //Si el jugador tiene un estado de 0 (no esta jugando a ninguna partida)
                }
                else if (Convert.ToInt32(trozos[i + 2]) == 1)
                {
                    dataGridView2.Rows.Add(trozos[i + 1], "Jugando"); 
                    //Si el jugador tiene un estado de 1 (esta jugando una partida)
                }

                i = i + 2;

            }
        }
        public void QuieresJugar(string mensaje)
        {
            //Cuando el servidor nos envia una notificacion de que alguien quiere jugar con nosotros
            //Nos da la opcion de aceptar o rechazar la peticion
            textBoxNom.Visible = true;
            buttonAceptarF1.Visible = true;
            buttonRechazarF1.Visible = true;
            textBoxNom.Text = "¿Quieres aceptar la invitación de " + mensaje + "?";
        }

        public void Borrarcuenta()
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            LogOut_button.Visible = false;
            contSer.Visible = false;
            dataGridView2.Visible = false;
            buttonBorrarCuenta.Visible = false;
            buttonEnviar.Visible = false;
            MostrarCons.Visible = false;
            CerrarCons.Visible = false;
        }


        private void AtenderServidor()
        {
            int codigo; //Para guardar el numero de petición que nos ha enviado el servidor
            string mensaje; //Para guardar el mensaje posterior al numero de petición
            while (true)
            {

                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');

                if (trozos[0] != null)
                {
                    codigo = Convert.ToInt32(trozos[0]);
                    mensaje = trozos[1].Split('\0')[0];

                    switch (codigo)
                    {
                        case 1: //Respuesta C1
                            //Petición de con quien ha jugado una persona que inserta el cliente
                            MessageBox.Show("Has jugado con: " + mensaje);
                            break;

                        case 2: //Respuesta C2
                            //Nos indica que jugador tiene mas puntos en una partida que nos inserta el cliente
                            MessageBox.Show("El jugador con más puntos es: " + mensaje);
                            break;

                        case 3:  //Respuesta C3
                            //Nos indica que partida ha sido la mas corta
                            MessageBox.Show(mensaje);
                            break;

                        case 4: //Respuesta 4
                            //Respuesta a la peticion de jugar una partida a otro jugador

                            if (mensaje == "aceptado") //Si dice que si, sumamos uno a aceptadas i a respuestas recibidas
                            {
                                contAceptadas = contAceptadas + 1;
                                contRespuestas = contRespuestas + 1;
                            }
                            else //Si dice que no, contamos uno solo en respuestas 
                                contRespuestas = contRespuestas + 1;
                            
                            //Le indicamos al cliente si el cliente ha aceptado o rechazado la partida
                            MessageBox.Show(trozos[2] + " ha " + mensaje + " jugar tu partida");

                            break;

                        case 5: //Respuesta 5
                            //Una vez nos han contestado todos los jugadores procedemos a jugar o avisar al cliente de que lo vuelva a hacer 
                            
                            if (mensaje == "aceptado")
                            {
                                //Si todos los jugadores han dicho que si, abrimos la partida nueva
                                //MessageBox.Show("Damos comienzo a la partida con ID "+ trozos[2] +", todos han aceptado jugar. Prepárate " + Nombre);
                                idPartida = Convert.ToInt32(trozos[2]);

                                ThreadStart ts = delegate { PonerEnMarchaMapa(); };
                                Thread T = new Thread(ts);
                                T.Start();
                                jugandoPartida = true;

                                contAceptadas = 0;
                                contRespuestas = 0;
                                contInvitados = 0;
                                
                            }
                            else
                            {
                                //Si algun jugador ha decicido que no le apetece jugar, avisamos al cliente
                                MessageBox.Show("No habéis aceptado todos la partida, no se puede jugar. Lo sentimos " + Nombre);
                                contAceptadas = 0;
                                contRespuestas = 0;
                                contInvitados = 0;
                                
                            }
                            break;

                        case 6: //Respuesta 6
                            //Notificación para actualizar la lista de conectados
                            DelegadoDataGrid1 delegado1 = new DelegadoDataGrid1(FuncDataGrid);
                            dataGridView2.Invoke(delegado1, new object[] { trozos });
                            break;

                        case 7: //Respuesta 7
                            //Notificación que recibiremos cuando juguemos una partida para poder comunicarnos por el chat
                            formMapa.RecibirMensaje(mensaje);
                            break;

                        case 8: //Respuesta 8
                            //Notificacion que nos indica que una persona ha realizado una petición
                            DelegadoParaEscribir delegado3 = new DelegadoParaEscribir(PonContador);
                            contSer.Invoke(delegado3, new object[] { mensaje });
                            break;

                        case 9: //Respuesta 9
                            //
                            DelegadoJugar delegado2 = new DelegadoJugar(QuieresJugar);
                            textBoxNom.Invoke(delegado2, new object[] { mensaje });
                            huesped = mensaje;
                            break;
                        case 10: //Respuesta 10
                            //Peticiones se envían al Mapa Juego para que se accionen los movimientos en el juego
                            formMapa.FuncionesSalas(Convert.ToInt32(mensaje));

                            break;
                        case 11: //Respuesta 11
                            //Recepción de las respuestas de las salas desbloqueadas
                            
                            formMapa.SalasResueltas(Convert.ToInt32(mensaje));
                            if (mensaje == "1")
                            {
                                Sala1Resuelta = true;

                            }
                            else if (mensaje == "2")
                            {
                                Sala2Resuelta = true;

                            }
                            else if (mensaje == "3")
                            {
                                Sala3Resuelta = true;

                            }
                            else if (mensaje == "4")
                            {
                                Sala4Resuelta = true;
                            }
                            else if (mensaje == "5")
                            {
                                Sala5Resuelta = true;
                                if (Sala6Resuelta == true)
                                {
                                    formMapa.EnableSalaFinal();
                                }
                            }
                            else if (mensaje == "6")
                            {
                                Sala6Resuelta = true;
                            }
                            else if (mensaje == "7") //No lo tenemos aún ni el caso ni el vídeo
                            {
                                Sala7Resuelta = true;
                            }
                            
                            break;
                        case 12: //Respuesta 12
                            //Una vez ya han resuelto todo el juego indicamos al servidor si lo han resuelto o no

                            if (mensaje == "bien")
                            {
                                contSolucionFinal = contSolucionFinal + 1;
                                if (contSolucionFinal == Convert.ToInt32(trozos[2]))
                                {
                                    MessageBox.Show("Habéis resuelto el juego, ¡muy bien!"); 
                                    //Vídeo final caso 1
                                    ResolucioFinal = 1;
                                 
                                    atender.Abort();
                                }
                            }
                            else if (mensaje=="mal")
                            {
                                MessageBox.Show("BOOM! Alguno de tus compañeros se ha equivocado, la EETAC ha explotado");
                                //Entra vídeo caso 2
                                ResolucioFinal = -1;
                                atender.Abort();
                            }
                            break;

                        case 13: //Respuesta 13
                            //Para asegurarnos que quiere borrar la cuenta

                            if (mensaje == "CUENTAELIMINADA")
                            {
                                MessageBox.Show("Tu cuenta se ha eliminado correctamente. Sentimos que te hayas dado de baja. Hasta pronto");
                                DelegadoBorrarcuenta delegado20 = new DelegadoBorrarcuenta(Borrarcuenta);
                                contSer.Invoke(delegado20, new object[] {});
                                
                                // Nos desconectamos
                                atender.Abort();
                                server.Close();
                            }
                            else if (mensaje == "NOCUENTAELIMINADA")
                                MessageBox.Show("Disculpe, no se ha podido eliminar la cuenta correctamente. Vuelva a pulsar el botón");
                            break;
                    }

                    //Codigo para empezar la partida
                    if ((contRespuestas == contInvitados) && (contInvitados != 0))
                    {
                        //Comprobamos que todas las personas con las que queremos jugar nos han dicho que si e informamos al servidor
                        if (contRespuestas == contAceptadas)
                        {                            
                            broadcast = "aceptado";
                        }
                        else
                        {
                            broadcast = "rechazado"; //Si no todos han dicho que si avisamos al cliente (para que no se haga ilusiones)
                            MessageBox.Show("No habéis aceptado todos la partida, no se puede jugar. Lo sentimos " + Nombre);
                        }
                        DateTime dateTime = DateTime.UtcNow.Date;
                        string fecha=dateTime.ToString("dd.MM.yyyy");
                        
                        // Enviamos al servidor el mensaje broadcast
                        broadcast = "11/" + broadcast + "/" +fecha+ "/"+ Nombre + "/" + Convert.ToString(contInvitados) + ListaInvitados ;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(broadcast);
                        server.Send(msg);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Nos sirve para enviar una de las 3 peticiones del groupbox1
            ID.BackColor = Color.White;
            partida.BackColor = Color.White;
            try
            {
                if (ConQuienJuego.Checked) 
                {
                    //Consulta 1
                    // Busca los jugadores con los que ha jugado la persona que introduces por consola
                    ID.BackColor = Color.White;
                    if ((ID.Text != null) && (ID.Text != ""))
                    {
                        string mensaje = "1/" + ID.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else
                    {
                        ID.BackColor = Color.Red;
                        MessageBox.Show("Rellene el campo del jugador a consultar");
                    }
                }
                else if (MasPuntos.Checked)
                {
                    //Consulta 2
                    //Busca que jugador que ha jugado en la partida introducida por consola tiene mas puntos acumulados
                    if ((partida.Text != null) && (partida.Text != ""))
                    {
                        string mensaje = "2/" + partida.Text;
                        // Enviamos al servidor el ID de la partida tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else
                    {
                        partida.BackColor = Color.Red;
                        MessageBox.Show("Introduce el número de partida a consultar");
                    }
                   

                }
                else if (Mascorta.Checked) //Para saber cual ha sido la partida mas corta
                {
                    //Consulta 3
                    // Busca la partida mas corta y que su tiempo es inferior a 1500s
                    string mensaje = "3/ ";
                    // En este caso no es necesario introducir ningún dato extra
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("No has seleccionado ninguna consulta. Por favor, seleccione una y obtendrá su respuesta");
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
            server.Close();
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            buttonEnviar.Visible = false;
            LogOut_button.Visible = false;
            contSer.Visible = false;
            dataGridView2.Visible = false;
            MostrarCons.Visible = false;
            CerrarCons.Visible = false;
            EnviarPeticion_button.Visible = false;
            buttonBorrarCuenta.Visible = false;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            //Log in
            //Nos permite comprobar que el usuario y la contraseña introducidos existen en la base de datos
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor al que deseamos conectarnos

            UsuariLogIn.BackColor = Color.White;
            contrasenyaLogIn.BackColor = Color.White;
            if (((UsuariLogIn.Text != null) && (contrasenyaLogIn.Text != null)) && ((UsuariLogIn.Text != "") && (contrasenyaLogIn.Text != "")))
            {
                IPAddress direc = IPAddress.Parse(ip);
                IPEndPoint ipep = new IPEndPoint(direc, puerto);
                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    MessageBox.Show("Conectado al Servidor. Comprobando credenciales...");
                    //Enviamos al servidor el nombre y la contraseña del usuario existente

                    string mensaje = "4/" + UsuariLogIn.Text + "/" + contrasenyaLogIn.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    //Nos encontramos con 3 casos diferentes
                    if (mensaje == "NO EXISTE")
                        MessageBox.Show("Este usuario no existe, por favor regístrate");

                    else if (mensaje == "LLENO")
                        MessageBox.Show("No podemos atenderte en este momento. Inténtalo más tarde");

                    else if (mensaje == "OK")
                    {
                        MessageBox.Show("Bienvenido a tu cuenta :)");
                        MostrarCons.Visible = true;
                        LogOut_button.Visible = true;
                        groupBox2.Visible = false;
                        dataGridView2.Visible = true;
                        buttonEnviar.Visible = true;
                        buttonBorrarCuenta.Visible = true;

                        //Pongo en marcha el thread que atenderá los mensajes del servidor
                        ThreadStart ts = delegate { AtenderServidor(); };
                        atender = new Thread(ts);
                        atender.Start();
                        contSer.Visible = true;
                        Nombre = UsuariLogIn.Text;
                    }
                    else if (mensaje == "USTED YA ESTA CONECTADO")
                    {
                        MessageBox.Show("Este usuario ya esta conectado");
                    }

                    else if (mensaje == "CONTRASEÑA INCORRECTA")
                        MessageBox.Show("La contraseña introducida es incorrecta");

                    else
                        MessageBox.Show("Error Genérico al inciar sesión");

                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
            }

            //EXCEPCIONES SI NO NOS RELLENAN LOS CAMPOS, PARA QUE EL CLIENTE NO DEJE DE FUNCIONAR
            else if (((UsuariLogIn.Text == null) && (contrasenyaLogIn.Text != null)) || ((UsuariLogIn.Text == "") && (contrasenyaLogIn.Text != "")))
            {
                //Si no nos ha introducido el nombre de usuario
                UsuariLogIn.BackColor = Color.Red;
                MessageBox.Show("Por favor, inserte el usuario. Gracias");

            }
            else if  (((UsuariLogIn.Text != null) && (contrasenyaLogIn.Text == null)) || ((UsuariLogIn.Text != "") && (contrasenyaLogIn.Text == "")))
            {
                //Si no ha introducido la contraseña
                contrasenyaLogIn.BackColor = Color.Red;
                MessageBox.Show("Por favor, inserte la contraseña. Gracias");
            }
            else if (((UsuariLogIn.Text == null) && (contrasenyaLogIn.Text == null)) || ((UsuariLogIn.Text == "") && (contrasenyaLogIn.Text == "")))
            {
                //Si no ha rellenado ninguno de los campos
                UsuariLogIn.BackColor = Color.Red;
                contrasenyaLogIn.BackColor = Color.Red;
                MessageBox.Show("Por favor, inserte el usuario y la contraseña. Gracias");
            }
            
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            //Sign in
            //Nos permite añadir un nuevo usuario en la base de datos

            UsuariSignIn.BackColor = Color.White;
            ContrasenyaSignIn.BackColor = Color.White;
            if (((UsuariSignIn.Text != null) && (ContrasenyaSignIn.Text != null)) && ((UsuariSignIn.Text != "") && (ContrasenyaSignIn.Text != "")))
            {
                IPAddress direc = IPAddress.Parse(ip);
                IPEndPoint ipep = new IPEndPoint(direc, puerto);

                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    MessageBox.Show("Conectado");

                    //Enviamos al servidor el nombre y la contraseña del usuario nuevo
                    string mensaje = "5/" + UsuariSignIn.Text + "/" + ContrasenyaSignIn.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

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
                server.Shutdown(SocketShutdown.Both);
                server.Close();

                groupBox1.Visible = false;
                groupBox2.Visible = true;
                contSer.Visible = false;
                dataGridView2.Visible = false;
                MostrarCons.Visible = false;
                CerrarCons.Visible = false;
            }

            //EXCEPCIONES SI NO RELLENAN LOS CAMPOS, PARA QUE EL CLIENTE NO DEJE DE FUNCIONAR
            else if (((UsuariSignIn.Text == null) && (ContrasenyaSignIn.Text != null)) || ((UsuariSignIn.Text == "") && (ContrasenyaSignIn.Text != "")))
            {
                //Si no nos ha introducido el nombre de usuario
                UsuariSignIn.BackColor = Color.Red;
                MessageBox.Show("Por favor, inserte el usuario. Gracias");

            }
            else if (((UsuariSignIn.Text != null) && (ContrasenyaSignIn.Text == null)) || ((UsuariSignIn.Text != "") && (ContrasenyaSignIn.Text == "")))
            {
                //Si no nos ha introducido la contraseña
                ContrasenyaSignIn.BackColor = Color.Red;
                MessageBox.Show("Por favor, inserte la contraseña. Gracias");
            }
            else if (((UsuariSignIn.Text == null) && (ContrasenyaSignIn.Text == null)) || ((UsuariSignIn.Text == "") && (ContrasenyaSignIn.Text == "")))
            {
                //Si no nos ha introducido ni el nombre ni la contraseña
                UsuariSignIn.BackColor = Color.Red;
                ContrasenyaSignIn.BackColor = Color.Red;
                MessageBox.Show("Por favor, inserte el usuario y la contraseña. Gracias");
            }
        }

        private void PonerEnMarchaMapa()
        {
            //Abre un nuevo mapa para jugar una partida
            MapaJuego form = new MapaJuego(Nombre, server, idPartida);
            formMapa = form;
            form.ShowDialog();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            //Sirve para enviar una peticion de juego a las personas que hemos seleccionado el la tabla
            int i=0;
            string mensaje="9/" + Nombre +"/";
            string mensaje2 = "";
            int contador = 0;
            bool encontrado = false ;
            bool jugando = false;
            string NombreComparar;

            //Buscamos qué personas ha seleccionado
            while ((i < dataGridView2.RowCount) && (encontrado==false) &&(jugando==false))
            {
                if ((dataGridView2.Rows[i].Cells[0].Selected == true) && (dataGridView2.Rows[i].Cells[1].Value == "Conectado"))
                {
                    NombreComparar = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value).Split('\0')[0];
                    if (NombreComparar == Nombre)
                    {
                        encontrado = true;
                    }
                    else
                    {
                        mensaje2 = mensaje2 + "/" + Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);

                        contador = contador + 1;
                    }

                }
                else if ((dataGridView2.Rows[i].Cells[0].Selected == true) && (dataGridView2.Rows[i].Cells[1].Value != "Conectado"))
                {
                    //Si la persona que ha seleccionado ya esta jugando una partida no le dejamos enviar la solicitud
                    jugando = true;
                }

                i = i + 1;
            }
            if (encontrado == true)
            {
                //Si se ha seleccionado a si mismo le avisamos 
                MessageBox.Show("No puedes enviarte una solicitud a ti mismo");
                contador = 0;
                mensaje2 = "";
            }
            else if (jugando == true)
            {
                //Avisamos que ha seleccionado a un jugador que ya esta jugando una partida
                contador = 0;
                mensaje2 = "";
                MessageBox.Show("Alguno de los usuarios seleccionados ya están jugando una partida");
            }
            else
            {
                //Si lo ha hecho todo bien enviamos la peticion al servidor 
                contInvitados = contador;
                ListaInvitados = mensaje2;

                mensaje = mensaje + Convert.ToString(contador) + mensaje2;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                MessageBox.Show("Se ha enviado tu solicitud correctamente");
            }
        }

        private void buttonAceptarF1_Click(object sender, EventArgs e)
        {
            //El cliente a recibido una solicitud de juego y la ha aceptado, por lo tanto, avisamos al servidor
            string mensaje = "10/" + huesped + "/aceptado/"+ Nombre;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            textBoxNom.Visible = false;
            buttonAceptarF1.Visible = false;
            buttonRechazarF1.Visible = false;

        }

        private void buttonRechazarF1_Click(object sender, EventArgs e)
        {
            //El cliente a recibido una solicitud de juego y la ha rechazado, por lo tanto, avisamos al servidor
            string mensaje = "10/" + huesped + "/rechazado/" + Nombre;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
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
            server.Close();
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            LogOut_button.Visible = false;
            contSer.Visible = false;
            dataGridView2.Visible = false;
            MostrarCons.Visible = false;
            CerrarCons.Visible = false;
        }


        public void CerrarMapaJ()
        {
            formMapa.Close();
        }

        private void MostrarCons_Click(object sender, EventArgs e)
        {
            //Boton que nos permite realizar consultas al servidor
            groupBox1.Visible = true;
            MostrarCons.Visible = false;
            CerrarCons.Visible = true;
        }

        private void CerrarCons_Click(object sender, EventArgs e)
        {
            //Boton que esconde las consultas
            groupBox1.Visible = false;
            MostrarCons.Visible = true;
            CerrarCons.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form_videos form = new Form_videos();
            form.ShowDialog();
            
        }

        private void buttonBorrarCuenta_Click(object sender, EventArgs e)
        {
            const string message =
            "¿Estás seguro de que quieres eliminar tu cuenta?";
            const string caption = "Verificar Eliminación de cuenta";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Borrando la cuenta...");
                //Mensaje de borrar cuenta
                string mensaje = "17/" + Nombre;

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (result == DialogResult.No)
                MessageBox.Show("Tu cuenta no ha sido eliminada");
        }
        int segundosfinal = 0;
        bool visto = false;
        int segundospartida = 0;
    
        private void timerF1_Tick(object sender, EventArgs e)
        {
            if (ResolucioFinal == 0 && jugandoPartida == true)
            {
                segundospartida = segundospartida + 1;
            }
            if (ResolucioFinal == 1 && visto==false)
            {
                visto = true;
                Form_videos formV = new Form_videos();
                formV.DameNumero(4);
                formV.ShowDialog();
            }
            else if (ResolucioFinal == -1 && visto==false)
            {
                visto = true;
                Form_videos formV = new Form_videos();
                formV.DameNumero(5);
                formV.ShowDialog();
            }
            if (visto == true)
            {
                segundosfinal = segundosfinal + 1;
            }
            if (ResolucioFinal == 1 && segundosfinal == 16 )
            {
                visto = false;
                ResolucioFinal = 0;
                segundosfinal = 0;
                int puntosPartida = 3600 - segundospartida;
                //Pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts1 = delegate { AtenderServidor(); };
                atender = new Thread(ts1);
                atender.Start();
                DelegadoCerrarMapaJuego delegado21 = new DelegadoCerrarMapaJuego(CerrarMapaJ);
                dataGridView2.Invoke(delegado21, new object[] { });
                string mensaje = "18/" + idPartida+"/"+Nombre+"/"+segundospartida+"/"+puntosPartida;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                segundospartida = 0;
                
            }
            if (ResolucioFinal == -1 && segundosfinal == 10)
            {
                visto = false;
                ResolucioFinal = 0;
                segundosfinal = 0;
               
                //Si pierde la partida, tiene 0 puntos y su "tiempo" es el máximo.
                //Pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts2 = delegate { AtenderServidor(); };
                atender = new Thread(ts2);
                atender.Start();
                DelegadoCerrarMapaJuego delegado21 = new DelegadoCerrarMapaJuego(CerrarMapaJ);
                dataGridView2.Invoke(delegado21, new object[] { });
                string mensaje = "18/" + idPartida + "/" + Nombre + "/3600/0";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                segundospartida = 0;

            }

        }
        
    }
}
