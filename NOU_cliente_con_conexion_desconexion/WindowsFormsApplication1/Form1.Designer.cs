namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Usuari = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ConQuienJuego = new System.Windows.Forms.RadioButton();
            this.Mascorta = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.partida = new System.Windows.Forms.TextBox();
            this.MasPuntos = new System.Windows.Forms.RadioButton();
            this.EnviarPeticion_button = new System.Windows.Forms.Button();
            this.contSer = new System.Windows.Forms.Label();
            this.LogOut_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UsuariLogIn = new System.Windows.Forms.TextBox();
            this.contrasenyaLogIn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ContrasenyaSignIn = new System.Windows.Forms.TextBox();
            this.UsuariSignIn = new System.Windows.Forms.TextBox();
            this.SignIn = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.buttonAceptarF1 = new System.Windows.Forms.Button();
            this.buttonRechazarF1 = new System.Windows.Forms.Button();
            this.MostrarCons = new System.Windows.Forms.Button();
            this.CerrarCons = new System.Windows.Forms.Button();
            this.buttonBorrarCuenta = new System.Windows.Forms.Button();
            this.timerF1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // Usuari
            // 
            this.Usuari.AutoSize = true;
            this.Usuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuari.Location = new System.Drawing.Point(15, 29);
            this.Usuari.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Usuari.Name = "Usuari";
            this.Usuari.Size = new System.Drawing.Size(79, 25);
            this.Usuari.TabIndex = 1;
            this.Usuari.Text = "Usuario";
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(108, 31);
            this.ID.Margin = new System.Windows.Forms.Padding(4);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(217, 22);
            this.ID.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ConQuienJuego);
            this.groupBox1.Controls.Add(this.Mascorta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.partida);
            this.groupBox1.Controls.Add(this.MasPuntos);
            this.groupBox1.Controls.Add(this.Usuari);
            this.groupBox1.Controls.Add(this.EnviarPeticion_button);
            this.groupBox1.Controls.Add(this.contSer);
            this.groupBox1.Controls.Add(this.ID);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(38, 445);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(365, 240);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticiones";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Peticiones efectuadas";
            // 
            // ConQuienJuego
            // 
            this.ConQuienJuego.AutoSize = true;
            this.ConQuienJuego.Location = new System.Drawing.Point(20, 88);
            this.ConQuienJuego.Margin = new System.Windows.Forms.Padding(4);
            this.ConQuienJuego.Name = "ConQuienJuego";
            this.ConQuienJuego.Size = new System.Drawing.Size(201, 21);
            this.ConQuienJuego.TabIndex = 7;
            this.ConQuienJuego.TabStop = true;
            this.ConQuienJuego.Text = "Dime con quien has jugado";
            this.ConQuienJuego.UseVisualStyleBackColor = true;
            // 
            // Mascorta
            // 
            this.Mascorta.AutoSize = true;
            this.Mascorta.Location = new System.Drawing.Point(20, 115);
            this.Mascorta.Margin = new System.Windows.Forms.Padding(4);
            this.Mascorta.Name = "Mascorta";
            this.Mascorta.Size = new System.Drawing.Size(270, 21);
            this.Mascorta.TabIndex = 7;
            this.Mascorta.TabStop = true;
            this.Mascorta.Text = "Dime cual ha sido la partida más corta";
            this.Mascorta.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Partida";
            // 
            // partida
            // 
            this.partida.Location = new System.Drawing.Point(107, 55);
            this.partida.Margin = new System.Windows.Forms.Padding(4);
            this.partida.Name = "partida";
            this.partida.Size = new System.Drawing.Size(81, 22);
            this.partida.TabIndex = 9;
            // 
            // MasPuntos
            // 
            this.MasPuntos.AutoSize = true;
            this.MasPuntos.Location = new System.Drawing.Point(20, 142);
            this.MasPuntos.Margin = new System.Windows.Forms.Padding(4);
            this.MasPuntos.Name = "MasPuntos";
            this.MasPuntos.Size = new System.Drawing.Size(336, 21);
            this.MasPuntos.TabIndex = 8;
            this.MasPuntos.TabStop = true;
            this.MasPuntos.Text = "Dime que jugador tiene más puntos en la partida";
            this.MasPuntos.UseVisualStyleBackColor = true;
            // 
            // EnviarPeticion_button
            // 
            this.EnviarPeticion_button.Location = new System.Drawing.Point(20, 170);
            this.EnviarPeticion_button.Margin = new System.Windows.Forms.Padding(4);
            this.EnviarPeticion_button.Name = "EnviarPeticion_button";
            this.EnviarPeticion_button.Size = new System.Drawing.Size(100, 28);
            this.EnviarPeticion_button.TabIndex = 5;
            this.EnviarPeticion_button.Text = "Enviar";
            this.EnviarPeticion_button.UseVisualStyleBackColor = true;
            this.EnviarPeticion_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // contSer
            // 
            this.contSer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.contSer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contSer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contSer.Location = new System.Drawing.Point(215, 194);
            this.contSer.Name = "contSer";
            this.contSer.Size = new System.Drawing.Size(139, 34);
            this.contSer.TabIndex = 27;
            this.contSer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogOut_button
            // 
            this.LogOut_button.BackColor = System.Drawing.SystemColors.ControlText;
            this.LogOut_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOut_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LogOut_button.Location = new System.Drawing.Point(428, 101);
            this.LogOut_button.Margin = new System.Windows.Forms.Padding(4);
            this.LogOut_button.Name = "LogOut_button";
            this.LogOut_button.Size = new System.Drawing.Size(132, 47);
            this.LogOut_button.TabIndex = 10;
            this.LogOut_button.Text = "LOG OUT";
            this.LogOut_button.UseVisualStyleBackColor = false;
            this.LogOut_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "LOGIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Usuari";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Contrasenya";
            // 
            // UsuariLogIn
            // 
            this.UsuariLogIn.Location = new System.Drawing.Point(127, 56);
            this.UsuariLogIn.Name = "UsuariLogIn";
            this.UsuariLogIn.Size = new System.Drawing.Size(100, 22);
            this.UsuariLogIn.TabIndex = 14;
            // 
            // contrasenyaLogIn
            // 
            this.contrasenyaLogIn.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.contrasenyaLogIn.Location = new System.Drawing.Point(127, 84);
            this.contrasenyaLogIn.Name = "contrasenyaLogIn";
            this.contrasenyaLogIn.PasswordChar = '*';
            this.contrasenyaLogIn.Size = new System.Drawing.Size(100, 22);
            this.contrasenyaLogIn.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "SIGN IN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Usuari";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Contrasenya";
            // 
            // ContrasenyaSignIn
            // 
            this.ContrasenyaSignIn.Location = new System.Drawing.Point(127, 222);
            this.ContrasenyaSignIn.Name = "ContrasenyaSignIn";
            this.ContrasenyaSignIn.PasswordChar = '*';
            this.ContrasenyaSignIn.Size = new System.Drawing.Size(100, 22);
            this.ContrasenyaSignIn.TabIndex = 19;
            // 
            // UsuariSignIn
            // 
            this.UsuariSignIn.Location = new System.Drawing.Point(127, 187);
            this.UsuariSignIn.Name = "UsuariSignIn";
            this.UsuariSignIn.Size = new System.Drawing.Size(100, 22);
            this.UsuariSignIn.TabIndex = 20;
            // 
            // SignIn
            // 
            this.SignIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SignIn.Location = new System.Drawing.Point(161, 250);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(66, 32);
            this.SignIn.TabIndex = 22;
            this.SignIn.Text = "go";
            this.SignIn.UseVisualStyleBackColor = true;
            this.SignIn.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // Login
            // 
            this.Login.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Login.Location = new System.Drawing.Point(161, 112);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(66, 30);
            this.Login.TabIndex = 23;
            this.Login.Text = "go";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SignIn);
            this.groupBox2.Controls.Add(this.Login);
            this.groupBox2.Controls.Add(this.ContrasenyaSignIn);
            this.groupBox2.Controls.Add(this.UsuariSignIn);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.UsuariLogIn);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.contrasenyaLogIn);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(1068, 402);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(239, 322);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entrar";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Location = new System.Drawing.Point(38, 45);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(235, 282);
            this.dataGridView2.TabIndex = 29;
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnviar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonEnviar.Location = new System.Drawing.Point(428, 45);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(132, 49);
            this.buttonEnviar.TabIndex = 30;
            this.buttonEnviar.Text = "ENVIAR INVITACIÓN";
            this.buttonEnviar.UseVisualStyleBackColor = false;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // textBoxNom
            // 
            this.textBoxNom.BackColor = System.Drawing.SystemColors.ControlText;
            this.textBoxNom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxNom.Location = new System.Drawing.Point(38, 345);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(354, 19);
            this.textBoxNom.TabIndex = 31;
            // 
            // buttonAceptarF1
            // 
            this.buttonAceptarF1.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonAceptarF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptarF1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAceptarF1.Location = new System.Drawing.Point(38, 372);
            this.buttonAceptarF1.Name = "buttonAceptarF1";
            this.buttonAceptarF1.Size = new System.Drawing.Size(119, 46);
            this.buttonAceptarF1.TabIndex = 32;
            this.buttonAceptarF1.Text = "ACEPTAR";
            this.buttonAceptarF1.UseVisualStyleBackColor = false;
            this.buttonAceptarF1.Click += new System.EventHandler(this.buttonAceptarF1_Click);
            // 
            // buttonRechazarF1
            // 
            this.buttonRechazarF1.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonRechazarF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRechazarF1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRechazarF1.Location = new System.Drawing.Point(207, 374);
            this.buttonRechazarF1.Name = "buttonRechazarF1";
            this.buttonRechazarF1.Size = new System.Drawing.Size(133, 44);
            this.buttonRechazarF1.TabIndex = 33;
            this.buttonRechazarF1.Text = "RECHAZAR";
            this.buttonRechazarF1.UseVisualStyleBackColor = false;
            this.buttonRechazarF1.Click += new System.EventHandler(this.buttonRechazarF1_Click);
            // 
            // MostrarCons
            // 
            this.MostrarCons.BackColor = System.Drawing.SystemColors.ControlText;
            this.MostrarCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MostrarCons.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MostrarCons.Location = new System.Drawing.Point(428, 155);
            this.MostrarCons.Name = "MostrarCons";
            this.MostrarCons.Size = new System.Drawing.Size(132, 50);
            this.MostrarCons.TabIndex = 35;
            this.MostrarCons.Text = "MOSTRAR CONSULTAS";
            this.MostrarCons.UseVisualStyleBackColor = false;
            this.MostrarCons.Click += new System.EventHandler(this.MostrarCons_Click);
            // 
            // CerrarCons
            // 
            this.CerrarCons.BackColor = System.Drawing.SystemColors.ControlText;
            this.CerrarCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CerrarCons.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CerrarCons.Location = new System.Drawing.Point(38, 692);
            this.CerrarCons.Name = "CerrarCons";
            this.CerrarCons.Size = new System.Drawing.Size(148, 27);
            this.CerrarCons.TabIndex = 36;
            this.CerrarCons.Text = "Cerrar Consultas";
            this.CerrarCons.UseVisualStyleBackColor = false;
            this.CerrarCons.Click += new System.EventHandler(this.CerrarCons_Click);
            // 
            // buttonBorrarCuenta
            // 
            this.buttonBorrarCuenta.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonBorrarCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrarCuenta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonBorrarCuenta.Location = new System.Drawing.Point(428, 222);
            this.buttonBorrarCuenta.Name = "buttonBorrarCuenta";
            this.buttonBorrarCuenta.Size = new System.Drawing.Size(132, 50);
            this.buttonBorrarCuenta.TabIndex = 38;
            this.buttonBorrarCuenta.Text = "BORRAR CUENTA";
            this.buttonBorrarCuenta.UseVisualStyleBackColor = false;
            this.buttonBorrarCuenta.Click += new System.EventHandler(this.buttonBorrarCuenta_Click);
            // 
            // timerF1
            // 
            this.timerF1.Tick += new System.EventHandler(this.timerF1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.FUM;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1335, 735);
            this.ControlBox = false;
            this.Controls.Add(this.buttonBorrarCuenta);
            this.Controls.Add(this.CerrarCons);
            this.Controls.Add(this.MostrarCons);
            this.Controls.Add(this.buttonRechazarF1);
            this.Controls.Add(this.buttonAceptarF1);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LogOut_button);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Usuari;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.Button EnviarPeticion_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ConQuienJuego;
        private System.Windows.Forms.RadioButton MasPuntos;
        private System.Windows.Forms.RadioButton Mascorta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox partida;
        private System.Windows.Forms.Button LogOut_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UsuariLogIn;
        private System.Windows.Forms.TextBox contrasenyaLogIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ContrasenyaSignIn;
        private System.Windows.Forms.TextBox UsuariSignIn;
        private System.Windows.Forms.Button SignIn;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label contSer;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Button buttonAceptarF1;
        private System.Windows.Forms.Button buttonRechazarF1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button MostrarCons;
        private System.Windows.Forms.Button CerrarCons;
        private System.Windows.Forms.Button buttonBorrarCuenta;
        private System.Windows.Forms.Timer timerF1;
    }
}

