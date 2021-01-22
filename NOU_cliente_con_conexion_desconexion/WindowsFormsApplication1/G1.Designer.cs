namespace WindowsFormsApplication1
{
    partial class G1
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
            this.textBoxG1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonG1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.timerGroga2 = new System.Windows.Forms.Timer(this.components);
            this.labelTimeG = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxG1
            // 
            this.textBoxG1.Location = new System.Drawing.Point(429, 465);
            this.textBoxG1.Name = "textBoxG1";
            this.textBoxG1.Size = new System.Drawing.Size(100, 22);
            this.textBoxG1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "RESPUESTA:";
            // 
            // buttonG1
            // 
            this.buttonG1.Location = new System.Drawing.Point(642, 445);
            this.buttonG1.Name = "buttonG1";
            this.buttonG1.Size = new System.Drawing.Size(114, 53);
            this.buttonG1.TabIndex = 3;
            this.buttonG1.Text = "Comprobar Respuesta";
            this.buttonG1.UseVisualStyleBackColor = true;
            this.buttonG1.Click += new System.EventHandler(this.buttonG1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(725, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tiempo";
            // 
            // timerGroga2
            // 
            this.timerGroga2.Tick += new System.EventHandler(this.timerGroga2_Tick_1);
            // 
            // labelTimeG
            // 
            this.labelTimeG.AutoSize = true;
            this.labelTimeG.Location = new System.Drawing.Point(692, 64);
            this.labelTimeG.Name = "labelTimeG";
            this.labelTimeG.Size = new System.Drawing.Size(112, 17);
            this.labelTimeG.TabIndex = 12;
            this.labelTimeG.Tag = "";
            this.labelTimeG.Text = "                          ";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(51, 257);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(23, 23);
            this.button5.TabIndex = 37;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // G1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Groga1llum;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(836, 540);
            this.ControlBox = false;
            this.Controls.Add(this.button5);
            this.Controls.Add(this.labelTimeG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonG1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxG1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "G1";
            this.Text = "G1";
            this.Load += new System.EventHandler(this.G1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxG1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonG1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerGroga2;
        private System.Windows.Forms.Label labelTimeG;
        private System.Windows.Forms.Button button5;
    }
}