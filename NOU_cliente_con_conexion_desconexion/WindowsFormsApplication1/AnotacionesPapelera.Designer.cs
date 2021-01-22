namespace WindowsFormsApplication1
{
    partial class AnotacionesPapelera
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
            this.buttonDirector = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDirector
            // 
            this.buttonDirector.Location = new System.Drawing.Point(433, 440);
            this.buttonDirector.Name = "buttonDirector";
            this.buttonDirector.Size = new System.Drawing.Size(241, 74);
            this.buttonDirector.TabIndex = 0;
            this.buttonDirector.Text = "Entendido! Muchas gracias Director, le salvaremos!";
            this.buttonDirector.UseVisualStyleBackColor = true;
            this.buttonDirector.Click += new System.EventHandler(this.buttonDirector_Click);
            // 
            // AnotacionesPapelera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Pista028G;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(674, 526);
            this.ControlBox = false;
            this.Controls.Add(this.buttonDirector);
            this.MaximizeBox = false;
            this.Name = "AnotacionesPapelera";
            this.Text = "AnotacionesPapelera";
            this.Load += new System.EventHandler(this.AnotacionesPapelera_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDirector;
    }
}