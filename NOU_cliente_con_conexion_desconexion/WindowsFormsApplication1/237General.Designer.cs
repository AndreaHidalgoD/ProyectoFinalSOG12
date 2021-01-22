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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.timer237 = new System.Windows.Forms.Timer(this.components);
            this.label237 = new System.Windows.Forms.Label();
            this.botonInvisible = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(777, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tiempo";
            // 
            // timer237
            // 
            this.timer237.Tick += new System.EventHandler(this.timer237_Tick);
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Location = new System.Drawing.Point(757, 52);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(112, 17);
            this.label237.TabIndex = 11;
            this.label237.Tag = "";
            this.label237.Text = "                          ";
            this.label237.Click += new System.EventHandler(this.label237_Click);
            // 
            // botonInvisible
            // 
            this.botonInvisible.BackColor = System.Drawing.Color.Transparent;
            this.botonInvisible.FlatAppearance.BorderSize = 0;
            this.botonInvisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonInvisible.Location = new System.Drawing.Point(56, 307);
            this.botonInvisible.Name = "botonInvisible";
            this.botonInvisible.Size = new System.Drawing.Size(318, 86);
            this.botonInvisible.TabIndex = 31;
            this.botonInvisible.UseVisualStyleBackColor = false;
            this.botonInvisible.Click += new System.EventHandler(this.botonInvisible_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(760, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 104);
            this.button2.TabIndex = 32;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _237General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources._237general;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 500);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.botonInvisible);
            this.Controls.Add(this.label237);
            this.Controls.Add(this.label3);
            this.MinimizeBox = false;
            this.Name = "_237General";
            this.Text = "_237General";
            this.Load += new System.EventHandler(this._237General_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer237;
        private System.Windows.Forms.Label label237;
        private System.Windows.Forms.Button botonInvisible;
        private System.Windows.Forms.Button button2;
    }
}