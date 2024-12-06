namespace LegendsUnleashed
{
    partial class MainMenu
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnInstruction = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Image = global::LegendsUnleashed.Properties.Resources.PlayGame2;
            this.btnStart.Location = new System.Drawing.Point(379, 480);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(164, 41);
            this.btnStart.TabIndex = 0;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.LoadGame);
            // 
            // btnInstruction
            // 
            this.btnInstruction.BackColor = System.Drawing.Color.White;
            this.btnInstruction.ForeColor = System.Drawing.Color.Black;
            this.btnInstruction.Image = global::LegendsUnleashed.Properties.Resources.InstructionsText;
            this.btnInstruction.Location = new System.Drawing.Point(12, 480);
            this.btnInstruction.Name = "btnInstruction";
            this.btnInstruction.Size = new System.Drawing.Size(167, 41);
            this.btnInstruction.TabIndex = 1;
            this.btnInstruction.UseVisualStyleBackColor = false;
            this.btnInstruction.Click += new System.EventHandler(this.LoadInstructions);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Image = global::LegendsUnleashed.Properties.Resources.EXITGAME;
            this.btnExit.Location = new System.Drawing.Point(756, 480);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(151, 41);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.Exit);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LegendsUnleashed.Properties.Resources.TitleScreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(919, 533);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInstruction);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Legends Unleashed";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnInstruction;
        private System.Windows.Forms.Button btnExit;
    }
}

