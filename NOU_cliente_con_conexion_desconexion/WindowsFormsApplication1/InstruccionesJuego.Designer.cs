namespace WindowsFormsApplication1
{
    partial class InstruccionesJuego
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
            this.Ir2 = new System.Windows.Forms.Button();
            this.volver1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Ir2
            // 
            this.Ir2.BackColor = System.Drawing.Color.Transparent;
            this.Ir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ir2.Location = new System.Drawing.Point(624, 191);
            this.Ir2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ir2.Name = "Ir2";
            this.Ir2.Size = new System.Drawing.Size(65, 72);
            this.Ir2.TabIndex = 0;
            this.Ir2.UseVisualStyleBackColor = false;
            this.Ir2.Click += new System.EventHandler(this.Ir2_Click);
            // 
            // volver1
            // 
            this.volver1.BackColor = System.Drawing.Color.Transparent;
            this.volver1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.volver1.Location = new System.Drawing.Point(0, 182);
            this.volver1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volver1.Name = "volver1";
            this.volver1.Size = new System.Drawing.Size(50, 82);
            this.volver1.TabIndex = 1;
            this.volver1.UseVisualStyleBackColor = false;
            this.volver1.Click += new System.EventHandler(this.volver1_Click);
            // 
            // InstruccionesJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Instrucciones1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(687, 451);
            this.Controls.Add(this.volver1);
            this.Controls.Add(this.Ir2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = false;
            this.Name = "InstruccionesJuego";
            this.Text = "InstruccionesJuego";
            this.Load += new System.EventHandler(this.InstruccionesJuego_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ir2;
        private System.Windows.Forms.Button volver1;
    }
}