namespace WindowsFormsApplication1
{
    partial class TaulaPeriodica
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
            this.buttonTaula = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTaula
            // 
            this.buttonTaula.Location = new System.Drawing.Point(634, 267);
            this.buttonTaula.Name = "buttonTaula";
            this.buttonTaula.Size = new System.Drawing.Size(76, 39);
            this.buttonTaula.TabIndex = 0;
            this.buttonTaula.Text = "Cerrar";
            this.buttonTaula.UseVisualStyleBackColor = true;
            this.buttonTaula.Click += new System.EventHandler(this.buttonTaula_Click);
            // 
            // TaulaPeriodica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.tabla_periodica_elementos;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(722, 318);
            this.ControlBox = false;
            this.Controls.Add(this.buttonTaula);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = false;
            this.Name = "TaulaPeriodica";
            this.Text = "TaulaPeriodica";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTaula;
    }
}