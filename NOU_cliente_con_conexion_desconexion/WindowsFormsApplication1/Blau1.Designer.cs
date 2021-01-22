namespace WindowsFormsApplication1
{
    partial class Blau1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Blau1));
            this.Resolver = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.G1 = new System.Windows.Forms.CheckBox();
            this.Verd1 = new System.Windows.Forms.CheckBox();
            this.V2 = new System.Windows.Forms.CheckBox();
            this.B2 = new System.Windows.Forms.CheckBox();
            this.B1 = new System.Windows.Forms.CheckBox();
            this.V1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAula = new System.Windows.Forms.Button();
            this.timerBlau = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.labelBlau = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Resolver
            // 
            this.Resolver.Location = new System.Drawing.Point(182, 180);
            this.Resolver.Name = "Resolver";
            this.Resolver.Size = new System.Drawing.Size(95, 37);
            this.Resolver.TabIndex = 14;
            this.Resolver.Text = "Resolver";
            this.Resolver.UseVisualStyleBackColor = true;
            this.Resolver.Click += new System.EventHandler(this.Resolver_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.G1);
            this.panel1.Controls.Add(this.Verd1);
            this.panel1.Controls.Add(this.V2);
            this.panel1.Controls.Add(this.B2);
            this.panel1.Controls.Add(this.B1);
            this.panel1.Controls.Add(this.V1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Resolver);
            this.panel1.Location = new System.Drawing.Point(837, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 241);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // G1
            // 
            this.G1.AutoSize = true;
            this.G1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.G1.Location = new System.Drawing.Point(199, 131);
            this.G1.Name = "G1";
            this.G1.Size = new System.Drawing.Size(78, 21);
            this.G1.TabIndex = 6;
            this.G1.Text = "Cable 6";
            this.G1.UseVisualStyleBackColor = false;
            // 
            // Verd1
            // 
            this.Verd1.AutoSize = true;
            this.Verd1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Verd1.Location = new System.Drawing.Point(199, 89);
            this.Verd1.Name = "Verd1";
            this.Verd1.Size = new System.Drawing.Size(78, 21);
            this.Verd1.TabIndex = 5;
            this.Verd1.Text = "Cable 5";
            this.Verd1.UseVisualStyleBackColor = false;
            // 
            // V2
            // 
            this.V2.AutoSize = true;
            this.V2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.V2.Location = new System.Drawing.Point(199, 50);
            this.V2.Name = "V2";
            this.V2.Size = new System.Drawing.Size(78, 21);
            this.V2.TabIndex = 4;
            this.V2.Text = "Cable 4";
            this.V2.UseVisualStyleBackColor = false;
            // 
            // B2
            // 
            this.B2.AutoSize = true;
            this.B2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.B2.Location = new System.Drawing.Point(28, 131);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(78, 21);
            this.B2.TabIndex = 3;
            this.B2.Text = "Cable 3";
            this.B2.UseVisualStyleBackColor = false;
            // 
            // B1
            // 
            this.B1.AutoSize = true;
            this.B1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.B1.Location = new System.Drawing.Point(28, 89);
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(78, 21);
            this.B1.TabIndex = 2;
            this.B1.Text = "Cable 2";
            this.B1.UseVisualStyleBackColor = false;
            // 
            // V1
            // 
            this.V1.AutoSize = true;
            this.V1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.V1.Location = new System.Drawing.Point(28, 50);
            this.V1.Name = "V1";
            this.V1.Size = new System.Drawing.Size(78, 21);
            this.V1.TabIndex = 1;
            this.V1.Text = "Cable 1";
            this.V1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dime que cables quieres cortar";
            // 
            // buttonAula
            // 
            this.buttonAula.Location = new System.Drawing.Point(437, 35);
            this.buttonAula.Name = "buttonAula";
            this.buttonAula.Size = new System.Drawing.Size(219, 68);
            this.buttonAula.TabIndex = 21;
            this.buttonAula.Text = "Mirar el resto del aula";
            this.buttonAula.UseVisualStyleBackColor = true;
            this.buttonAula.Click += new System.EventHandler(this.buttonAula_Click);
            // 
            // timerBlau
            // 
            this.timerBlau.Tick += new System.EventHandler(this.timerBlau_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tiempo";
            // 
            // labelBlau
            // 
            this.labelBlau.AutoSize = true;
            this.labelBlau.Location = new System.Drawing.Point(60, 302);
            this.labelBlau.Name = "labelBlau";
            this.labelBlau.Size = new System.Drawing.Size(112, 17);
            this.labelBlau.TabIndex = 24;
            this.labelBlau.Tag = "";
            this.labelBlau.Text = "                          ";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(854, 11);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(270, 106);
            this.button3.TabIndex = 25;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(437, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 89);
            this.button1.TabIndex = 34;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(135, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 45);
            this.button2.TabIndex = 35;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(235, 508);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(44, 26);
            this.button5.TabIndex = 36;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(263, 526);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(44, 26);
            this.button6.TabIndex = 37;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Blau1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1150, 564);
            this.ControlBox = false;
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelBlau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAula);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Blau1";
            this.Text = "Blau1_Instruccions";
            this.Load += new System.EventHandler(this.Blau1_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Resolver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox G1;
        private System.Windows.Forms.CheckBox Verd1;
        private System.Windows.Forms.CheckBox V2;
        private System.Windows.Forms.CheckBox B2;
        private System.Windows.Forms.CheckBox B1;
        private System.Windows.Forms.CheckBox V1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAula;
        private System.Windows.Forms.Timer timerBlau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelBlau;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}