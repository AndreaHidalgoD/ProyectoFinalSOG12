#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <ctype.h>
#include <pthread.h>
//Conexion global BBDD
MYSQL *conn;
//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex= PTHREAD_MUTEX_INITIALIZER;
int i;
int sockets[100];


typedef struct {
	char nombre [20];
	int socket;
	int idPartida;
	int status; //0=Conectado 1=Jugando
	int sala; //Ninguna sala: 0; Sala 025V: 1, Sala 023G: 2, Sala 28G: 3,  Sala Drones (27-2):4 ,Sala 27-3:5, Sala 021B:6, Sala de Actos: 7
}Conectado;

typedef struct{
	Conectado conectados [100];
	int num;
	
} ListaConectados;

ListaConectados miLista;

ListaConectados Jugando;

//Consulta_1

void Consulta_1 (char respuesta[512], char nombre [20])
{
	// Consulta 1:
	// BUSCA LOS JUGADORES CON LOS QUE HA JUGADO LA PERSONA QUE INTRDUCES POR CONSOLA
	
	char consulta [512];
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy(consulta,"SELECT DISTINCT JUGADOR.ID FROM(PARTIDA, JUGADOR, CONNECTOR) WHERE PARTIDA.ID IN (SELECT PARTIDA.ID FROM(PARTIDA, JUGADOR, CONNECTOR) WHERE JUGADOR.ID= '");
	strcat(consulta,nombre);
	strcat(consulta,"' AND JUGADOR.ID= CONNECTOR.ID_J AND CONNECTOR.ID_P=PARTIDA.ID) AND PARTIDA.ID= CONNECTOR.ID_P AND CONNECTOR.ID_J=JUGADOR.ID AND JUGADOR.ID NOT IN ('");
	strcat(consulta,nombre);
	strcat(consulta,"')"); 
	
	printf("%s\n",consulta);
	// Establece connexión con la base de datos
	err=mysql_query (conn, consulta); 
	if(err!=0)
	{
		printf("Error al consultar datos de la base \u0153u \u0153s\n", mysql_errno(conn),mysql_error(conn));
		exit(1); 
	}
	
	//Retorna resultados de la consulta
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		row[0]='0';
		sprintf (respuesta, "1/%s" , row[0]); //Si no ha jugado con nadie le enviamos el valor de 0
	}
	else
	{
		sprintf (respuesta, "1/%s", row[0]);
		row = mysql_fetch_row (resultado);
		
		while (row!=NULL) //Si hemos encontrado con quien juega le enviamos una lista con los nombres separados por una coma
		{
			sprintf (respuesta, "%s,%s", respuesta, row[0]); //Encadenamos la respuesta ya que puede haber jugado con mas de una persona
			
			row = mysql_fetch_row (resultado);
		}
	}
	printf("%s\n",respuesta);
}

void Consulta_2 (char respuesta[512], char nombre [20])
{
	
	// Consulta 2
	// BUSCA QUE JUGADOR QUE HA JUGADO EN LA PARTIDA INTRODUCIDA POR CONSOLA TIENE MAS PUNTOS ACUMULADOS
	
	char consulta[512];
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy(consulta,"SELECT DISTINCT JUGADOR.ID FROM(JUGADOR,CONNECTOR,PARTIDA) WHERE JUGADOR.TOTALPUNTS = (SELECT DISTINCT MAX(JUGADOR.TOTALPUNTS) FROM(JUGADOR, PARTIDA, CONNECTOR) WHERE CONNECTOR.ID_P = ");
	strcat(consulta,nombre);
	strcat(consulta," AND CONNECTOR.ID_J =JUGADOR.ID) AND JUGADOR.ID = CONNECTOR.ID_J AND CONNECTOR.ID_P = ");
	strcat(consulta,nombre);
	
	printf("%s\n",consulta);
	// Establece connexión con la base de datos
	err=mysql_query (conn, consulta); 
	if(err!=0){
		printf("Error al consultar datos de la base \u0153u \u0153s\n", mysql_errno(conn),mysql_error(conn));
		exit(1);
	}
	
	//Retorna resultados de la consulta
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		row[0]='0';
		sprintf (respuesta, "2/%s" , row[0]); //Si no encontramos jugadores en la partida que nos ha introducido le devolvemos 0
	}
	else 
	{
		sprintf (respuesta, "2/%s", row[0]); //Devolvemos los puntos de la persona con mas puntos
	}
	
}

void Consulta_3 (char respuesta[512], char nombre [20])
{
	// Consulta 3
	// BUSCA LA PARTIDA MÁS CORTA Y QUE SU TIEMPO ES INFERIOR A 1500s
	
	char consulta [512];
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	strcpy (consulta,"SELECT PARTIDA.ID FROM(PARTIDA) WHERE PARTIDA.TEMPS =(SELECT MIN(PARTIDA.TEMPS) FROM PARTIDA) AND PARTIDA.TEMPS < 1500"); 
	
	// hacemos la consulta 
	err=mysql_query (conn, consulta); 
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1) ;
	}
	
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		sprintf (respuesta,"3/No se han obtenido datos en la consulta"); //Avisamos al cliente que no hemos encontrado una partida con esas caracteristicas
	}
	else
	{
		// El resultado debe ser una matriz con una sola fila y una columna que contiene el nombre
		sprintf (respuesta,"3/ID de la partida mas corta: %s", row[0] );
	}
	
}

int YaConectado (ListaConectados *lista, char nombre [20])
{
	//Verifica si un jugador ya ha abierto una partida.
	//Devuelve -1 si ya esta conectado y 0 si no esta
	int encontrado=0;
	int i=0;
	while((i<lista->num)&&(encontrado==0))
	{
		if(strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado=1;
		i=i+1;
	}
	if (encontrado==0)
		return 0;
	else 
		return -1;
}

int BuscaridPartida ()
{
	//Proporciona un nuevo numero de partida que no hayamos utilizado en la base de datos
	char consulta [512];
	int idPartida=1;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	
	strcpy (consulta,"SELECT MAX(PARTIDA.ID) FROM(PARTIDA)"); 
	printf("La consulta es %s\n", consulta);
	// hacemos la consulta 
	err=mysql_query (conn, consulta); 
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	if (row==NULL)
	{
		return idPartida; //Si no hemos encontrado ninguna partida en la base de datos le damos el valor de 1
	}
	else
	{
		printf("La fila es %s\n", row[0]); //Si no es asi le sumaremos 1 al valor obtenido en la consulta
		idPartida=atoi(row[0])+1;
		printf("Idpartida es %d\n",idPartida);
		
		return idPartida;
	}

}
void AddBBDDConnector(int idPartida, char nombre[20])
{
	//Creamos un conector en la base de datos entre el nombre y la partida introducida
	char consulta [512];
	
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	sprintf(consulta,"INSERT INTO CONNECTOR VALUES('%s', %d)",nombre, idPartida); 
	
	// hacemos la consulta 
	err=mysql_query (conn, consulta); 
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//Si no hay ningun error no devuelve ninguna respuesta
}
void AddBBDDPartida(int idPartida, char data[20])
{
	//Creamos una partida en la base de datos entre las personas en el data
	char consulta [512];
	int err;
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	//S'ha de canviar el temps
	sprintf(consulta,"INSERT INTO PARTIDA VALUES(%d,'%s',10000);",idPartida, data); 
	
	// hacemos la consulta 
	err=mysql_query (conn, consulta); 
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//Si no hay ningun error no devuelve ninguna respuesta
}


int LogIn ( char nombre[20], char contrasenya [20], int sock_conn)
{	
	//Poner las variables locales
	int err;
	char consulta[512];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	printf("Entro en el Log In\n");
	
	sprintf(consulta, "SELECT JUGADOR.CONTRASENYA FROM (JUGADOR) WHERE JUGADOR.ID ='%s'",nombre);
	
	//Realizamos la consulta
	err=mysql_query (conn, consulta); 
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
	printf("Ya he hecho la consulta\n");
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
	{
		return -1; //El usuario introducido no existe en la base de datos
		printf ("No se han obtenido datos en la consulta\n");
	}
	else
	{
		// El resultado debe ser una matriz con una sola fila
		// y una columna que contiene el nombre
		if (strcmp(row[0],contrasenya)==0)
		{	
			return 0; //SI la contraseña que nos proporciona el cliente es correcta devuelve 0
			printf("La contraseña es correcta\n");

		}
		else
		{
			return 1; //Existe el usuario introducido pero la contraseña proporcionada es incorrecta, nos devuelve 1
			printf ("CONTRASENYA INCORRECTA\n");
		}
	}
	
}

int SignIn (char nombre[20], char contrasenya[20])
{
	//CONSULTA que nos ayuda a registrar un nuevo usuario si este no esta en la base de datos
	int err;
	char consulta[512];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	//Primero buscamos si este usuario existe
	strcpy(consulta,"SELECT JUGADOR.CONTRASENYA FROM (JUGADOR) WHERE JUGADOR.ID = '");
	strcat(consulta,nombre);
	strcat(consulta,"'");
	printf("%s\n",consulta);
	
	//Realizamos la consulta
	err=mysql_query (conn, consulta); 
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
	{ 
		//Si el usuario no existe procederá a registrarlo
		char consulta2 [1000];
		strcpy(consulta2,"INSERT INTO JUGADOR VALUES ('");
		strcat(consulta2,nombre);
		strcat(consulta2,"','");
		strcat(consulta2,contrasenya);
		strcat(consulta2,"',0)");
		printf("%s\n",consulta2);
		err=mysql_query (conn, consulta2); 
		if (err!=0) {
			return -1;
			printf ("Error al introducir los datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		//recogemos el resultado de la consulta 
		else
		{
			return 0; //Hemos podido añadir correctamente el usuario en la base de datos
			printf ("OK\n");
		}
	}
	else
	{
		return 1; //El usuario introducido ya existe en la base de datos, por lo tanto no lo añadimos
		printf ("YA EXISTE EL USUARIO\n");
	}
}


int Pon(ListaConectados *lista, char nombre [20], int socket){
	//Añade nuevos conectados. Retorna 0 si ok y -1 si la lista está llena (no puede añadir)
	printf("Entro en la funcion del Pon\n");
	if (lista->num==100)
		return -1;
	else{
		strcpy(lista->conectados[lista->num].nombre,nombre);
		lista->conectados[lista->num].socket=socket;
		lista->conectados[lista->num].status=0;
		lista->num++;
		return 0;
	}
}
int DamePosicion (ListaConectados *lista, char nombre [20]){
	//Devuelve la posicion en la lista o -1 si no está en la lista
	int i=0;
	int encontrado=0;
	
	while ((i<lista->num) && !encontrado)
	{	
		if(strcmp(lista->conectados[i].nombre, nombre)==0)
		{encontrado=1;
			printf("Lista: %s",lista->conectados[i].nombre);}
		if (!encontrado)
			i=i+1;
		
	}
	if (encontrado==1)
		return i;
	else
		return -1;
	
}

int DameSocket (ListaConectados *lista, char nombre [20]){
	//Devuelve la posicion en la lista o -1 si no está en la lista
	int i=0;
	int encontrado=0;
	
	while ((i<lista->num) && !encontrado)
	{	
		if(strcmp(lista->conectados[i].nombre, nombre)==0)
		{encontrado=1;
		printf("Lista: %s",lista->conectados[i].nombre);}
		if (!encontrado)
			i=i+1;
		
	}
	if (encontrado==1)
		return lista->conectados[i].socket;
	else
		return -1;
	
}
int Elimina (ListaConectados *lista, char nombre[20])
	//Retorna 0 si elimina y -1 si ese usuario no está en la lista
{	
	int pos= DamePosicion (lista, nombre);
	if (pos==-1)
		return -1;
	else{
		int i;
		for (i=pos; i<lista->num-1; i++)
		{	lista->conectados[i] = lista->conectados [i+1];
		}
		lista->num--;
		return 0;
	}
}
int EliminaCuenta( char nombre[20], int sock_conn)
{	
	//Poner las variables locales
	int err;
	char consulta[512];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	printf("Entro en el Eliminar Cuenta\n");
	//1.-ELIMINAMOS LA CUENTA
	sprintf(consulta, "SELECT JUGADOR.CONTRASENYA FROM (JUGADOR) WHERE JUGADOR.ID ='%s'",nombre);
	
	
	//Realizamos la consulta
	err=mysql_query (conn, consulta); 
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
	printf("Ya he hecho la consulta de buscar el nombre a eliminar\n");
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
	{
		return -1; //El usuario introducido no existe en la base de datos
		printf ("No se han obtenido datos en la consulta\n");
	}
	else
	{
		// El resultado debe ser una matriz con una sola fila
		// y una columna que contiene el nombre
		//BORRAMOS DE LA TABLA DE JUGADOR
		sprintf(consulta, "DELETE FROM CONNECTOR WHERE CONNECTOR.ID_J ='%s';",nombre);
		//Realizamos la consulta
		err=mysql_query (conn, consulta); 
		if (err!=0) 
		{
			printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
			
		}
		printf("Ya he hecho la consulta de buscar el nombre a eliminar\n");
		//BORRAMOS DE LA TABLA DE CONECTOR
		sprintf(consulta, "DELETE FROM JUGADOR WHERE JUGADOR.ID ='%s';",nombre);
		//Realizamos la consulta
		err=mysql_query (conn, consulta); 
		if (err!=0) 
		{
			printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
			
		}
		printf("Ya he hecho la consulta de buscar el nombre a eliminar\n");
		
	}
	//2.-COMPROBAMOS QUE SE HA ELIMINADO CORRECTAMENTE YA QUE EL USUARIO NO EXSITE AHORA
	printf("Entro a comprobar si se ha eliminado correctamente la cuenta\n");
	
	sprintf(consulta, "SELECT JUGADOR.CONTRASENYA FROM (JUGADOR) WHERE JUGADOR.ID ='%s'",nombre);
	
	//Realizamos la consulta
	err=mysql_query (conn, consulta); 
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
	printf("Ya he hecho la consulta de buscar el nombre eliminado\n");
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
	{
		return 0; //El usuario introducido no existe en la base de datos
		printf ("CORRECTO: El usuario se ha eliminado correctamente\n");
	}
	else
	{
		return 1;
		printf("ERROR: El usuario no se ha eliminado\n");
		
	}
	
}

void DameConectados (ListaConectados *lista, char listaconectados [300]){
	//Pone en conectados los nombres de todos los conectados separados por /. Primero pone el número de conectados. 
	sprintf (listaconectados, "%d", lista->num);
	int i;
	for (i=0; i<lista->num;i++)
		sprintf (listaconectados, "%s/%s/%d", listaconectados, lista->conectados[i].nombre, lista->conectados[i].status);
	//A parte al final nos indicara si el jugador esta conectado o en una partida
}
void ActualizarBBDDFinalPartida( int idPartida,char nombre[20], int tiempoPartida, int puntosPartida)
{
	//Poner las variables locales
	int err;
	char consulta[512];
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	printf("Entro en el Actualizar los datos finales de la BBDD\n");
	//1.-ACTUALIZAMOS LOS DATOS DEL JUGADOR
	sprintf(consulta, "SELECT JUGADOR.TOTALPUNTS FROM (JUGADOR) WHERE JUGADOR.ID ='%s'",nombre);
	
	
	//Realizamos la consulta
	err=mysql_query (conn, consulta); 
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
	printf("Ya he hecho la consulta de buscar el nombre a eliminar\n");
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	printf("After Row\n");
	int puntosactuales=atoi(row[0]);
	int sumapuntosactualizados=puntosactuales+puntosPartida;
	printf("Antes del UPDATE JUGADOR\n");
	
	//1.-ACTUALIZAMOS LOS DATOS DEL JUGADOR
	sprintf(consulta, "UPDATE JUGADOR SET TOTALPUNTS =%d WHERE JUGADOR.ID ='%s'",sumapuntosactualizados, nombre);
	
	
	//Realizamos la consulta
	err=mysql_query (conn, consulta); 
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
	printf("Actualizacion final de BBDD Jugador\n");
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	printf("Antes del UPDATE PARTIDA\n");
	//2.-ACTUALIZAMOS LOS DATOS DE LA PARTIDA
	sprintf(consulta, "UPDATE PARTIDA SET TEMPS=%d WHERE PARTIDA.ID ='%d'",tiempoPartida,idPartida);
	
	
	//Realizamos la consulta
	err=mysql_query (conn, consulta); 
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
		
	}
	printf("Actualizacion final de BBDD Partida\n");
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	
}
int contador;

void *AtenderCliente (void *socket)
{	
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [80];
	
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//inicializar la conexion
	//Preguntar BBDD Miguel directorio
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDDdb",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	char peticion[512];
	char respuesta[512];
	char nombre [20];
	int ret;

	
	int terminar =0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	
	while (terminar ==0)
	{
		// Ahora recibimos la peticion
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que añadirle la marca de fin de string para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		printf ("Peticion: %s\n",peticion);
		
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		printf("numero de codigo %d\n",codigo);
		// Ya tenemos el c?digo de la peticion
		char nombre[20];
		
		if ( codigo!=3 && codigo!=0 && codigo!=6 && codigo!=8 && codigo !=9 && codigo!=11&& codigo!=12&& codigo!=13 && codigo!=14 && codigo!=15&& codigo!=16 && codigo!=17&& codigo!=18)
		{
			printf("entro codigo dif0\n");
			p = strtok( NULL, "/"); //segundo trozo
			strcpy (nombre, p);
			// Ya tenemos el nombre
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
		}
		
		if (codigo==0) //Desconexión
		{
			terminar=1;
		}
	
		
		else if ((codigo ==1) &&(codigo!=17))
		{
			// Consulta 1:
			// BUSCA LOS JUGADORES CON LOS QUE HA JUGADO LA PERSONA QUE INTRDUCES POR CONSOLA
			//pthread_mutex_lock( &mutex ) ; //Thread dice: No me interrumpas ahora
			Consulta_1(respuesta,nombre);
			sprintf(respuesta,"%s",respuesta);
			//pthread_mutex_unlock( &mutex ) ; //Thread dice: No me interrumpas ahora
		}
		
		else if (codigo ==2) 
		{
			// Consulta 2
			// BUSCA QUE JUGADOR QUE HA JUGADO EN LA PARTIDA INTRODUCIDA POR CONSOLA TIENE MAS PUNTOS ACUMULADOS
			//pthread_mutex_lock( &mutex ) ; //Thread dice: No me interrumpas ahora
			Consulta_2(respuesta, nombre);
			sprintf(respuesta, "%s", respuesta);
			//pthread_mutex_unlock( &mutex ) ; //Thread dice: No me interrumpas ahora
			
		}
		else if (codigo ==3)
		{
			// Consulta 3
			// BUSCA LA PARTIDA MÁS CORTA Y QUE SU TIEMPO ES INFERIOR A 1500s
			
			Consulta_3(respuesta,nombre);
			sprintf(respuesta, "%s", respuesta);
			
		}
		
		else if (codigo==4) 
			// Consulta 4
			// LOG IN
			// NOS PERMITE COMPROBAR SI EL USUARIO Y LA CONTRASEÑA INTRODUCIDOS EXISTEN EN LA BASE DE DATOS, EN CASO CONTRARIO NOS AVISA
		{
			
			p = strtok( NULL, "/"); //Cogemos contraseña
			char contrasenya [20];
			strcpy (contrasenya, p);
			printf("%s\n",nombre);
			printf("%s\n",contrasenya);
			int res=YaConectado(&miLista, nombre);
			if (res==0)
			{
				printf("El usuario no estaba conectado anteriormente\n");
				int resLogIn=LogIn(nombre, contrasenya, sock_conn);
				if (resLogIn==-1)
				{
					printf("El usuario no existe\n");
					sprintf(respuesta,"NO EXISTE");
				}
				else if (resLogIn==0)
				{	
					
					pthread_mutex_lock( &mutex ) ; //Thread dice: No me interrumpas ahora
					int resPon=0;
					
					resPon=Pon(&miLista, nombre, sock_conn);
					if (resPon==-1)
					{	
						
						sprintf(respuesta, "LLENO");
						printf("Esta llena la lista");
						
					}
					else
					{
						sprintf(respuesta,"OK");
						printf("Se ha añadido bien");
					}
					pthread_mutex_unlock( &mutex);
					//write (sock_conn,respuesta, strlen(respuesta));
				}
				else if (resLogIn==1)
					sprintf(respuesta, "CONTRASEÑA INCORRECTA");
				
				
			}
			else
			{
					sprintf(respuesta,"USTED YA ESTA CONECTADO");
					printf("Estoy usando el YACONECTADO\n");
			}
			
		}
		
		else if (codigo==5) 
			//Consulta 5
			//SIGN IN
			//Verifica si el usuario introducido ya existe y si no es asi lo añade a la base de datos
		{
			
			p = strtok( NULL, "/"); //Cogemos contraseña
			char contrasenya [20];
			strcpy (contrasenya, p);
			
			int resSignIn=0;
			resSignIn= SignIn(nombre, contrasenya);
			
			if (resSignIn==-1)
				sprintf(respuesta,"ERROR");
			
			else if (resSignIn==0)
				sprintf (respuesta,"OK");
			
			else if (resSignIn==1)
				sprintf (respuesta,"YA EXISTE");
			
		}
		
		else if (codigo==6) 
		{	
			//Codigo 6
			//Notificacion que nos envia las personas conectadas al servidor
			
			char misConectados[300];
			
			respuesta[0]='\0';
			
			DameConectados(&miLista,misConectados);
			
			sprintf(respuesta,"%s", misConectados);
			
			printf("Resultado: %s\n", misConectados);
			
		}
		else if (codigo ==7) //LogOut 
		{	
			//Codigo 7
			//LOG OUT 
			//Desconecta del servidor a la persona que envia el cliente 
			pthread_mutex_lock( &mutex);
			printf("Me estoy desconectando (==0)\n");
			
			int resElimina=Elimina(&miLista, nombre);
			printf("resElimina %d", resElimina);
			if (resElimina==0)
				printf("Se ha eliminado correctamente\n");
			terminar=1;
			pthread_mutex_unlock( &mutex);
			
		}
		else if (codigo==9)
		{
			//Codigo 9
			
			//pthread_mutex_lock( &mutex ) ; //Thread dice: No me interrumpas ahora
			p = strtok( NULL, "/");
			
			strcpy (nombre, p);
			printf("El huesped es: %s\n", nombre);
			
			char notificacion[20];
			sprintf(notificacion,"9/%s", nombre);
			
			p=strtok(NULL, "/");
			int contador=atoi(p);
			printf("El contador vale: %d\n", contador);
		
			char invitado [20];
			
			int j;
			
			
			for (j=0;j<contador;j++)
			{
				p = strtok( NULL, "/"); 
				strcpy (invitado, p);
				socket=DameSocket(&miLista,invitado);
					
				write (socket,notificacion, strlen(notificacion));
				
			}
	
		}
		
		else if (codigo==10)
		{
			//Codigo 10
			//Envia a los clientes con los que el huesped quiere trabajar una notificacion
			char notificacion[20];
			char aceptado[20];
			char persona[20];
			p=strtok(NULL, "/");
			strcpy(aceptado,p);
			p=strtok(NULL, "/");
			strcpy(persona,p);
			sprintf(notificacion, "4/%s/%s", aceptado, persona);
			int socket=DameSocket(&miLista,nombre);
			write(socket, notificacion, strlen(notificacion));
		}
		else if (codigo==11)
		{
			//Codigo 11
			//Crea una nueva partida con las personas que ha solicitado el huesped. 
			
			char aceptado[20];
			p = strtok( NULL, "/");
			
			strcpy (aceptado, p); //Aceptado
			char fecha[100];
			p = strtok( NULL, "/");
			strcpy(fecha, p); //Fecha
			
			p = strtok( NULL, "/");
			strcpy(nombre, p); //Nombre host
			
			
			
			printf("%s, la partida ha sido: %s \n", nombre,aceptado);
			int idPartida;
			int posicion;
			
			char notificacion[20];
			char notificacion2[20];
			if (strcmp(aceptado,"aceptado")==0)
			{
				//Si todas las personas han aceptado la solicitud busca un nuevo identificador de partida
				
				idPartida=BuscaridPartida();
				posicion=DamePosicion(&miLista,nombre);
				pthread_mutex_lock(&mutex);
				miLista.conectados[posicion].idPartida=idPartida;
				miLista.conectados[posicion].status=1;
				miLista.conectados[posicion].sala=0;
				pthread_mutex_unlock(&mutex);
				AddBBDDPartida(idPartida, fecha);
				AddBBDDConnector(idPartida, nombre);
				sprintf(notificacion,"5/%s/%d", aceptado, idPartida);
			}
			else
			{
				//En caso contrario notificamos al huesped que no quieren jugar con el
				
				sprintf(notificacion,"5/%s", aceptado);
			
			}
			//Enviamos la notificacion
			write(sock_conn, notificacion, strlen(notificacion));
		
			p=strtok(NULL, "/");
			int contador=atoi(p);
			printf("El contador vale: %d\n", contador);
			
			
			char invitado [20];
		

			int j;
			
			for (j=0;j<contador;j++)
			{
				//Buscamos a los invitados a la partida y cambiamos su estado y le asignamos un id de partida (el que hemos buscado antes)
				p = strtok( NULL, "/"); 
				strcpy (invitado, p);
				printf("El invitado es %s\n", invitado);
				if (strcmp(aceptado,"aceptado")==0)
				{
					//Cuando encontramos el invitado bloqueamos el mutex y cambiamos las variables
					pthread_mutex_lock( &mutex ) ; 
					posicion=DamePosicion(&miLista,invitado);
					miLista.conectados[posicion].idPartida=idPartida;
					miLista.conectados[posicion].status=1;
					miLista.conectados[posicion].sala=0;
					pthread_mutex_unlock( &mutex ) ; 
					printf("El idPartida de %s es %d\n", nombre, idPartida);
					AddBBDDConnector(idPartida, invitado);
				}
				
				printf("Entro en el for del codigo 11\n");
				socket=DameSocket(&miLista,invitado);
				
				write (socket,notificacion, strlen(notificacion));
			}
			int i=0;
			
			while (i< miLista.num)
			{
				//Enviamos una notificacion a todos los usuarios conectados para actualizar 
				//el estado de las personas que estan jugando en la partida
				char misConectados[300];
				DameConectados(&miLista, misConectados);
				sprintf(notificacion2,"6/%s", misConectados);
				write(miLista.conectados[i].socket, notificacion2, strlen(notificacion2));
				i=i+1;
					
			}
			
		}
		else if (codigo==12)
		{
			//Codigo 12
			//
			
			printf("Entro en el codigo 12\n");
			int idPartida;
			p=strtok(NULL, "/");
			idPartida=atoi(p);
			
			char mensaje[120];
			p=strtok(NULL, "/");
			strcpy(mensaje,p);
			
			char notificacion[120];
			sprintf(notificacion,"7/%s", mensaje);
			int j;
			for (j=0;j<miLista.num;j++)
			{
	
				if (miLista.conectados[j].idPartida==idPartida)
				{
					printf("Encuentro conectado\n");
					socket=DameSocket(&miLista, miLista.conectados[j].nombre);
					
					write(socket, notificacion, strlen(notificacion));
					
				}
			}
		}
		else if (codigo==13) 
		{
			printf("Entro en el codigo 13 de verdad\n");
			p = strtok( NULL, "/"); //segundo trozo
			strcpy (nombre, p);
			// Ya tenemos el nombre
			int sala;
			p=strtok(NULL, "/");
			sala=atoi(p);
			int idPartida;
			p=strtok(NULL, "/");
			idPartida=atoi(p);
			printf("Dels strtoks Nombre: %s,idPartida: %d, Sala: %d \n", nombre, idPartida, sala);
			int j;
			for (j=0;j<miLista.num;j++)
			{
				printf("Nombre: %s,idPartida: %d, Sala: %d \n", miLista.conectados[j].nombre,miLista.conectados[j].idPartida,miLista.conectados[j].sala);
				if ((miLista.conectados[j].idPartida==idPartida) && (strcmp(miLista.conectados[j].nombre,nombre)==0))
				{
					printf("Entro a asignar sala\n");
					miLista.conectados[j].sala=sala;
					
				}
			}
			
		}
		else if (codigo==14)
		{
			printf("Entro en el codigo 14 de verdad\n");
			p = strtok( NULL, "/"); //segundo trozo
			strcpy (nombre, p);
			// Ya tenemos el nombre
			int peticion;
			p=strtok(NULL, "/");
			peticion=atoi(p);
			int idPartida;
			p=strtok(NULL, "/");
			idPartida=atoi(p);
			char notificacion[200];
			int j;
			for (j=0;j<miLista.num;j++)
			{
				//Peticion desde la sala 1 para arreglar la luz de la sala 2
				if ((miLista.conectados[j].idPartida==idPartida))
				{
					if ((peticion==1)&&(miLista.conectados[j].sala==2))
					{
						printf("Arreglo la luz de la sala amarilla\n");
						sprintf(notificacion, "10/1");
						write(miLista.conectados[j].socket, notificacion, strlen(notificacion));
					}
					else if ((peticion==2) && (miLista.conectados[j].sala==3))
					{
						printf("Envio mensaje de ayuda del astronauta a la sala 028G\n");
						sprintf(notificacion, "10/2");
						write(miLista.conectados[j].socket, notificacion, strlen(notificacion));
						
					}
					else if ((peticion==3) && (miLista.conectados[j].sala==4))
					{
						printf("Envio numero de satelites a la sala de drones\n");
						sprintf(notificacion, "10/3");
						write(miLista.conectados[j].socket, notificacion, strlen(notificacion));
					}
					else if ((peticion==4) && (miLista.conectados[j].sala==6))
					{
						printf("Envio manual a la sala 021B\n");
						sprintf(notificacion, "10/4");
						write(miLista.conectados[j].socket, notificacion, strlen(notificacion));
					}
					else if ((peticion==5) && (miLista.conectados[j].sala==5))
					{
						printf("Marciana envia ayuda a la 27-3\n");
						sprintf(notificacion, "10/5");
						write(miLista.conectados[j].socket, notificacion, strlen(notificacion));
					}
					
					
				}
			}
			
		}
		else if (codigo==15)
		{
			int sala;
			p = strtok( NULL, "/"); 
			sala=atoi(p);
			int idPartida;
			p = strtok( NULL, "/"); 
			idPartida=atoi(p);
			char notificacion[200];
			int j;
			for (j=0;j<miLista.num;j++)
			{
				
				if ((miLista.conectados[j].idPartida==idPartida) )
				{	
					printf("Envio 15\n");
					//Enviamos a todos la sala que se ha desbloqueado
					sprintf(notificacion, "11/%d", sala);
					write(miLista.conectados[j].socket, notificacion, strlen(notificacion));
					
					
				}
			
			}
		}
		else if (codigo==16)
		{
			int idPartida;
			char solucion[20];
			char notificacion[200];
			p = strtok( NULL, "/"); 
			idPartida=atoi(p);	
			p = strtok( NULL, "/"); 
			strcpy(solucion,p);
			int contadorJugadores=0;
			int j;
			for (j=0;j<miLista.num;j++)
			{
				if ((miLista.conectados[j].idPartida==idPartida) )
				{
					contadorJugadores=contadorJugadores+1;
				}
					
			}
			for (j=0;j<miLista.num;j++)
			{
				
				if ((miLista.conectados[j].idPartida==idPartida) )
				{	
					printf("Envio 16\n");
					//Enviamos a todos la sala que se ha desbloqueado
					sprintf(notificacion, "12/%s/%d", solucion,contadorJugadores);
					write(miLista.conectados[j].socket, notificacion, strlen(notificacion));
					
					
				}
				
			}
		}
		else if (codigo==17)
		{
			char nombre[20];
			p = strtok( NULL, "/"); 
			strcpy(nombre,p);
			int resultadoElimina;
			int resultadoEliminarCuenta;
			//char respuesta [20];
			
			pthread_mutex_lock( &mutex);
			resultadoElimina=Elimina(&miLista,nombre);
			pthread_mutex_unlock( &mutex);
			
			
			if (resultadoElimina==0)
			{
				resultadoEliminarCuenta=EliminaCuenta(nombre, sock_conn);
				if (resultadoEliminarCuenta==0)
				{
					printf("CORRECTO: Entro dentro del ELIMINA y ELIMINAR CUENTA. La cuenta se ha eliminado correctamente\n");
					strcpy(respuesta, "13/CUENTAELIMINADA");
					//write(sock_conn, respuesta, strlen(respuesta));
				}
				else
				{
					printf("ERROR: Entro dentro del ELIMINA y ELIMINAR CUENTA. La cuenta NO se ha eliminado correctamente\n");
					strcpy(respuesta, "13/NOCUENTAELIMINADA");
					//write(sock_conn, respuesta, strlen(respuesta));
				}
			}
			else
			{
				printf("El Elimina no ha funcionado\n");
				strcpy(respuesta, "13/NOCUENTAELIMINADA");
				//write(sock_conn, respuesta, strlen(respuesta));
			}
		}
		else if (codigo==18)
		{
			p = strtok( NULL, "/"); 
			int idPartida=atoi(p);
			char nombre[20];
			p = strtok( NULL, "/"); 
			
			strcpy(nombre,p);
			p = strtok( NULL, "/"); 
			int segundosPartida=atoi(p);
			p = strtok( NULL, "/"); 
			int puntosPartida=atoi(p);
			
			int posicion=DamePosicion(&miLista,nombre);
			pthread_mutex_lock(&mutex);
			miLista.conectados[posicion].status=0;
			pthread_mutex_unlock(&mutex);
			ActualizarBBDDFinalPartida(idPartida,nombre,segundosPartida,puntosPartida);
			
			int i=0;
			
			while (i< miLista.num)
			{
				//Enviamos una notificacion a todos los usuarios conectados para actualizar 
				//el estado de las personas que estan jugando en la partida
				char misConectados[300];
				char notificacion2[200];
				DameConectados(&miLista, misConectados);
				sprintf(notificacion2,"6/%s", misConectados);
				write(miLista.conectados[i].socket, notificacion2, strlen(notificacion2));
				i=i+1;
				
			}
			
			
		}

		if ((codigo != 0) && (codigo != 9)&&(codigo!=10)&& (codigo!=11)&&(codigo!=12)&&(codigo!=13)&&(codigo!=14)&&(codigo!=15)&&(codigo!=16)&& (codigo!=18))
		{
			
			//Envia el mensaje a mi consola en C#
			printf("Respuesta: %s\n", respuesta);
			// Y lo enviamos
			write(sock_conn,respuesta, strlen(respuesta));// socket de conexion, respuesta, longitud de la respuesta
			
		}
		//Solo en consultas
		if ((codigo==1) || (codigo==2) || (codigo==3) ||(codigo==6) )
		{
			printf("Entrada d'on esta el mutex\n");
			pthread_mutex_lock( &mutex ) ; //Thread dice: No me interrumpas ahora
			contador=contador+1;
			pthread_mutex_unlock( &mutex); // Thread dice: Ya puedes interrumpirme
			//Notificar a todos los clientes conectados
			
			char notificacion[20];
		
			sprintf(notificacion, "8/%d", contador); //8/ pero ya se ha quitado la otra
			printf("%s\n",notificacion);
			int j;
			for(j=0; j<i; j++)
			{
				write (sockets[j],notificacion, strlen(notificacion));
			}
			
		}
		
		if ((codigo==4)||(codigo==7))
		{	
			//pthread_mutex_lock( &mutex ) ; //Thread dice: No me interrumpas ahora
			char notificacion[20];
			char misConectados[300];
			
			
			respuesta[0]='\0';
			DameConectados(&miLista,misConectados);
			printf("Estos son: %s\n",misConectados);
			sprintf(respuesta,"%s", misConectados);
			
			
			printf("Resultado: %s\n", misConectados);
			
			sprintf(notificacion, "6/%s", misConectados); //8/ pero ya se ha quitado la otra
			
			printf("%s\n",notificacion);
			
			int j;
			for(j=0; j<i; j++)
			{
				printf("Entro en for del notificacion 4 y 7\n");
				int socket=miLista.conectados[j].socket;
				write (socket,notificacion, strlen(notificacion));
			}
		}
		
	}
	close(sock_conn);
}
int main (int argc, char *argv[]) 
{
	miLista.num=0; 
	int puerto=9285; //Puertos shiva: 50085, 50086, 50087
	// CONECTAR SERVIDOR-CLIENT
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512]; //peticion buff
	char respuesta[512]; //respuesta buff2
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) //crear socket de escucha
		printf("Error creant socket");
	// Fem el bind al port
	contador=0;
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY); //indicamos a cualquier
	// escucharemos en el port 9200
	serv_adr.sin_port = htons(puerto); 
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0) //asociamos al socket las esecificaciones anteriores
		printf ("Error al bind\n");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0) //lo ponemos en pasivo. EL 2 es el numero de objetos en cola
		printf("Error en el Listen");
	

	pthread_t thread;
	i=0;
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		printf("Main socket: %d \n", sock_conn);
		//sock_conn es el socket que usaremos para este cliente
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
		
	}

}



