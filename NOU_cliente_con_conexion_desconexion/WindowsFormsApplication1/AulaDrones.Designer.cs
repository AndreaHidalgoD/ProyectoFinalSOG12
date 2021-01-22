namespace WindowsFormsApplication1
{
    partial class AulaDrones
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
            this.textBoxDrones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.timerDrones = new System.Windows.Forms.Timer(this.components);
            this.buttonAstronauta = new System.Windows.Forms.Button();
            this.labelDrones = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(747, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "RESPUESTA:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxDrones
            // 
            this.textBoxDrones.Location = new System.Drawing.Point(741, 478);
            this.textBoxDrones.Name = "textBoxDrones";
            this.textBoxDrones.Size = new System.Drawing.Size(270, 22);
            this.textBoxDrones.TabIndex = 1;
            this.textBoxDrones.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(194, 477);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(528, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "¿Nºplanetas*8+NºPlanetasEnanos*3+NºSatélites*7+NºEstrellas*2+NºNaves*5?";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(903, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Comprobar Respuesta";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(830, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tiempo";
            // 
            // timerDrones
            // 
            this.timerDrones.Tick += new System.EventHandler(this.timerDrones_Tick);
            // 
            // buttonAstronauta
            // 
            this.buttonAstronauta.BackColor = System.Drawing.Color.Transparent;
            this.buttonAstronauta.FlatAppearance.BorderSize = 0;
            this.buttonAstronauta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAstronauta.Location = new System.Drawing.Point(403, 327);
            this.buttonAstronauta.Name = "buttonAstronauta";
            this.buttonAstronauta.Size = new System.Drawing.Size(195, 146);
            this.buttonAstronauta.TabIndex = 8;
            this.buttonAstronauta.UseVisualStyleBackColor = false;
            this.buttonAstronauta.Click += new System.EventHandler(this.buttonAstronauta_Click);
            // 
            // labelDrones
            // 
            this.labelDrones.AutoSize = true;
            this.labelDrones.Location = new System.Drawing.Point(806, 40);
            this.labelDrones.Name = "labelDrones";
            this.labelDrones.Size = new System.Drawing.Size(112, 17);
            this.labelDrones.TabIndex = 12;
            this.labelDrones.Tag = "";
            this.labelDrones.Text = "                          ";
            // 
            // AulaDrones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.AulaDronesEdited;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1023, 504);
            this.ControlBox = false;
            this.Controls.Add(this.labelDrones);
            this.Controls.Add(this.buttonAstronauta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDrones);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "AulaDrones";
            this.Text = "AulaDrones";
            this.Load += new System.EventHandler(this.AulaDrones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDrones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerDrones;
        private System.Windows.Forms.Button buttonAstronauta;
        private System.Windows.Forms.Label labelDrones;
    }
}