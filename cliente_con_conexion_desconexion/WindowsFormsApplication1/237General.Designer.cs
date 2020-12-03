namespace WindowsFormsApplication1
{
    partial class _237General
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
            this.MesaMezclas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MesaMezclas
            // 
            this.MesaMezclas.Location = new System.Drawing.Point(829, 346);
            this.MesaMezclas.Name = "MesaMezclas";
            this.MesaMezclas.Size = new System.Drawing.Size(106, 48);
            this.MesaMezclas.TabIndex = 0;
            this.MesaMezclas.Text = "Mesa de mezclas";
            this.MesaMezclas.UseVisualStyleBackColor = true;
            this.MesaMezclas.Click += new System.EventHandler(this.MesaMezclas_Click);
            // 
            // _237General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources._237general;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 500);
            this.Controls.Add(this.MesaMezclas);
            this.Name = "_237General";
            this.Text = "_237General";
            this.Load += new System.EventHandler(this._237General_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MesaMezclas;
    }
}