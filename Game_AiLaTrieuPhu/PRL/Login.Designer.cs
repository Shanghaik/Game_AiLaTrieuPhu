namespace Game_AiLaTrieuPhu.PRL
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.ptb_Play = new System.Windows.Forms.PictureBox();
            this.ptb_Exit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // ptb_Play
            // 
            this.ptb_Play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptb_Play.BackgroundImage")));
            this.ptb_Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptb_Play.Location = new System.Drawing.Point(625, 173);
            this.ptb_Play.Name = "ptb_Play";
            this.ptb_Play.Size = new System.Drawing.Size(236, 95);
            this.ptb_Play.TabIndex = 0;
            this.ptb_Play.TabStop = false;
            this.ptb_Play.Click += new System.EventHandler(this.ptb_Play_Click);
            // 
            // ptb_Exit
            // 
            this.ptb_Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptb_Exit.BackgroundImage")));
            this.ptb_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptb_Exit.Location = new System.Drawing.Point(625, 344);
            this.ptb_Exit.Name = "ptb_Exit";
            this.ptb_Exit.Size = new System.Drawing.Size(236, 95);
            this.ptb_Exit.TabIndex = 1;
            this.ptb_Exit.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(891, 604);
            this.Controls.Add(this.ptb_Exit);
            this.Controls.Add(this.ptb_Play);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox ptb_Play;
        private PictureBox ptb_Exit;
    }
}