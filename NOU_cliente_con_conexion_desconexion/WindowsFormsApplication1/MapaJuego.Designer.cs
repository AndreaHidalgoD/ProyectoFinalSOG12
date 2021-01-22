namespace WindowsFormsApplication1
{
    partial class MapaJuego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.buttonChat = new System.Windows.Forms.Button();
            this.ChatTextBox = new System.Windows.Forms.RichTextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTimeG = new System.Windows.Forms.Label();
            this.Instrucciones = new System.Windows.Forms.Button();
            this.timerVermellaG = new System.Windows.Forms.Timer(this.components);
            this.timerGrogaG = new System.Windows.Forms.Timer(this.components);
            this.timer28GG = new System.Windows.Forms.Timer(this.components);
            this.timerDronesG = new System.Windows.Forms.Timer(this.components);
            this.timer21BG = new System.Windows.Forms.Timer(this.components);
            this.timer237G = new System.Windows.Forms.Timer(this.components);
            this.Mapa = new System.Windows.Forms.Panel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.buttonConsergeria = new System.Windows.Forms.Button();
            this.buttonSalaActos = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button28 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.buttonDrones = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.buttonBlau = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TextBox237 = new System.Windows.Forms.TextBox();
            this.button237 = new System.Windows.Forms.Button();
            this.VermellaButton = new System.Windows.Forms.Button();
            this.buttonG1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.Mapa.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHAT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(553, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mapa EETAC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tiempo restante";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxChat
            // 
            this.textBoxChat.Location = new System.Drawing.Point(14, 318);
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.Size = new System.Drawing.Size(207, 22);
            this.textBoxChat.TabIndex = 29;
            // 
            // buttonChat
            // 
            this.buttonChat.BackColor = System.Drawing.Color.Transparent;
            this.buttonChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonChat.Location = new System.Drawing.Point(227, 318);
            this.buttonChat.Name = "buttonChat";
            this.buttonChat.Size = new System.Drawing.Size(63, 29);
            this.buttonChat.TabIndex = 30;
            this.buttonChat.Text = "Enviar";
            this.buttonChat.UseVisualStyleBackColor = false;
            this.buttonChat.Click += new System.EventHandler(this.buttonChat_Click);
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Location = new System.Drawing.Point(12, 60);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(266, 252);
            this.ChatTextBox.TabIndex = 32;
            this.ChatTextBox.Text = "";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.Transparent;
            this.labelID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelID.Location = new System.Drawing.Point(15, 23);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(42, 19);
            this.labelID.TabIndex = 33;
            this.labelID.Text = "        ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(12, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "ID Partida";
            // 
            // labelTimeG
            // 
            this.labelTimeG.AutoSize = true;
            this.labelTimeG.BackColor = System.Drawing.Color.Firebrick;
            this.labelTimeG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTimeG.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeG.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTimeG.Location = new System.Drawing.Point(15, 385);
            this.labelTimeG.Name = "labelTimeG";
            this.labelTimeG.Size = new System.Drawing.Size(167, 53);
            this.labelTimeG.TabIndex = 35;
            this.labelTimeG.Text = "             ";
            // 
            // Instrucciones
            // 
            this.Instrucciones.BackColor = System.Drawing.Color.Transparent;
            this.Instrucciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Instrucciones.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Instrucciones.Location = new System.Drawing.Point(847, 467);
            this.Instrucciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Instrucciones.Name = "Instrucciones";
            this.Instrucciones.Size = new System.Drawing.Size(124, 30);
            this.Instrucciones.TabIndex = 36;
            this.Instrucciones.Text = "Instrucciones";
            this.Instrucciones.UseVisualStyleBackColor = false;
            this.Instrucciones.Click += new System.EventHandler(this.Instrucciones_Click);
            // 
            // timerVermellaG
            // 
            this.timerVermellaG.Tick += new System.EventHandler(this.timerVermella_Tick);
            // 
            // timerGrogaG
            // 
            this.timerGrogaG.Enabled = true;
            this.timerGrogaG.Tick += new System.EventHandler(this.timerGrogaG_Tick);
            // 
            // timer28GG
            // 
            this.timer28GG.Tick += new System.EventHandler(this.timer28GG_Tick);
            // 
            // timerDronesG
            // 
            this.timerDronesG.Tick += new System.EventHandler(this.timerDronesG_Tick);
            // 
            // timer21BG
            // 
            this.timer21BG.Tick += new System.EventHandler(this.timer21BG_Tick);
            // 
            // timer237G
            // 
            this.timer237G.Tick += new System.EventHandler(this.timer237G_Tick);
            // 
            // Mapa
            // 
            this.Mapa.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.pmta_p03;
            this.Mapa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Mapa.Controls.Add(this.textBox7);
            this.Mapa.Controls.Add(this.buttonConsergeria);
            this.Mapa.Controls.Add(this.buttonSalaActos);
            this.Mapa.Controls.Add(this.textBox6);
            this.Mapa.Controls.Add(this.button28);
            this.Mapa.Controls.Add(this.textBox5);
            this.Mapa.Controls.Add(this.buttonDrones);
            this.Mapa.Controls.Add(this.textBox4);
            this.Mapa.Controls.Add(this.buttonBlau);
            this.Mapa.Controls.Add(this.textBox3);
            this.Mapa.Controls.Add(this.textBox2);
            this.Mapa.Controls.Add(this.textBox1);
            this.Mapa.Controls.Add(this.TextBox237);
            this.Mapa.Controls.Add(this.button237);
            this.Mapa.Controls.Add(this.VermellaButton);
            this.Mapa.Controls.Add(this.buttonG1);
            this.Mapa.Location = new System.Drawing.Point(297, 10);
            this.Mapa.Name = "Mapa";
            this.Mapa.Size = new System.Drawing.Size(677, 308);
            this.Mapa.TabIndex = 0;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox7.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(386, 56);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(105, 19);
            this.textBox7.TabIndex = 15;
            this.textBox7.Text = "Consergería";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonConsergeria
            // 
            this.buttonConsergeria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConsergeria.Location = new System.Drawing.Point(414, 69);
            this.buttonConsergeria.Name = "buttonConsergeria";
            this.buttonConsergeria.Size = new System.Drawing.Size(56, 24);
            this.buttonConsergeria.TabIndex = 14;
            this.buttonConsergeria.Text = "ENTRAR";
            this.buttonConsergeria.UseVisualStyleBackColor = true;
            this.buttonConsergeria.Click += new System.EventHandler(this.buttonConsergeria_Click);
            // 
            // buttonSalaActos
            // 
            this.buttonSalaActos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalaActos.Location = new System.Drawing.Point(587, 33);
            this.buttonSalaActos.Name = "buttonSalaActos";
            this.buttonSalaActos.Size = new System.Drawing.Size(77, 19);
            this.buttonSalaActos.TabIndex = 13;
            this.buttonSalaActos.Text = "ENTRAR";
            this.buttonSalaActos.UseVisualStyleBackColor = true;
            this.buttonSalaActos.Click += new System.EventHandler(this.buttonSalaActos_Click);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(564, 16);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(110, 19);
            this.textBox6.TabIndex = 12;
            this.textBox6.Text = "SALA DE ACTOS";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button28
            // 
            this.button28.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button28.Location = new System.Drawing.Point(143, 48);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(59, 26);
            this.button28.TabIndex = 11;
            this.button28.Text = "ENTRAR";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.textBox5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(143, 26);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(59, 22);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "028G";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonDrones
            // 
            this.buttonDrones.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDrones.Location = new System.Drawing.Point(78, 56);
            this.buttonDrones.Name = "buttonDrones";
            this.buttonDrones.Size = new System.Drawing.Size(55, 19);
            this.buttonDrones.TabIndex = 9;
            this.buttonDrones.Text = "ENTRAR";
            this.buttonDrones.UseVisualStyleBackColor = true;
            this.buttonDrones.Click += new System.EventHandler(this.buttonDrones_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Purple;
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(77, 37);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(57, 22);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "27-2";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonBlau
            // 
            this.buttonBlau.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBlau.Location = new System.Drawing.Point(304, 148);
            this.buttonBlau.Name = "buttonBlau";
            this.buttonBlau.Size = new System.Drawing.Size(54, 18);
            this.buttonBlau.TabIndex = 7;
            this.buttonBlau.Text = "ENTRAR";
            this.buttonBlau.UseVisualStyleBackColor = true;
            this.buttonBlau.Click += new System.EventHandler(this.buttonBlau_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(304, 127);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(54, 22);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "021B";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Yellow;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(164, 139);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(54, 22);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "023G";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(32, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "025V";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBox237
            // 
            this.TextBox237.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TextBox237.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TextBox237.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox237.Location = new System.Drawing.Point(208, 49);
            this.TextBox237.Name = "TextBox237";
            this.TextBox237.Size = new System.Drawing.Size(57, 22);
            this.TextBox237.TabIndex = 3;
            this.TextBox237.Text = "27-3";
            this.TextBox237.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button237
            // 
            this.button237.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button237.Location = new System.Drawing.Point(208, 69);
            this.button237.Name = "button237";
            this.button237.Size = new System.Drawing.Size(57, 24);
            this.button237.TabIndex = 2;
            this.button237.Text = "ENTRAR";
            this.button237.UseVisualStyleBackColor = true;
            this.button237.Click += new System.EventHandler(this.button237_Click);
            // 
            // VermellaButton
            // 
            this.VermellaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VermellaButton.Location = new System.Drawing.Point(32, 148);
            this.VermellaButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VermellaButton.Name = "VermellaButton";
            this.VermellaButton.Size = new System.Drawing.Size(60, 22);
            this.VermellaButton.TabIndex = 1;
            this.VermellaButton.Text = "ENTRAR";
            this.VermellaButton.UseVisualStyleBackColor = true;
            this.VermellaButton.Click += new System.EventHandler(this.VermellaButton_Click);
            // 
            // buttonG1
            // 
            this.buttonG1.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonG1.Location = new System.Drawing.Point(164, 160);
            this.buttonG1.Name = "buttonG1";
            this.buttonG1.Size = new System.Drawing.Size(54, 26);
            this.buttonG1.TabIndex = 0;
            this.buttonG1.Text = "ENTRAR";
            this.buttonG1.UseVisualStyleBackColor = true;
            this.buttonG1.Click += new System.EventHandler(this.buttonG1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(114, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "Usuario";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.BackColor = System.Drawing.Color.Transparent;
            this.labelUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelUsuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelUsuario.Location = new System.Drawing.Point(117, 23);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(86, 19);
            this.labelUsuario.TabIndex = 38;
            this.labelUsuario.Text = "                   ";
            // 
            // MapaJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.redsmokeabajo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1043, 517);
            this.ControlBox = false;
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Instrucciones);
            this.Controls.Add(this.labelTimeG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.buttonChat);
            this.Controls.Add(this.textBoxChat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Mapa);
            this.MinimizeBox = false;
            this.Name = "MapaJuego";
            this.Text = "MapaJuego";
            this.Load += new System.EventHandler(this.MapaJuego_Load);
            this.Mapa.ResumeLayout(false);
            this.Mapa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Mapa;
        private System.Windows.Forms.Button buttonG1;
        private System.Windows.Forms.Button VermellaButton;
        private System.Windows.Forms.Button button237;
        private System.Windows.Forms.TextBox TextBox237;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button buttonConsergeria;
        private System.Windows.Forms.Button buttonSalaActos;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button buttonDrones;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button buttonBlau;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.Button buttonChat;
        private System.Windows.Forms.RichTextBox ChatTextBox;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTimeG;
        private System.Windows.Forms.Button Instrucciones;
        private System.Windows.Forms.Timer timerVermellaG;
        private System.Windows.Forms.Timer timerGrogaG;
        private System.Windows.Forms.Timer timer28GG;
        private System.Windows.Forms.Timer timerDronesG;
        private System.Windows.Forms.Timer timer21BG;
        private System.Windows.Forms.Timer timer237G;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelUsuario;
    }
}