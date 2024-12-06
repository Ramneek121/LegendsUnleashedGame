namespace LegendsUnleashed
{
    partial class LegendsUnleashedImpossible
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
            this.tmrGame = new System.Windows.Forms.Timer(this.components);
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.picResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrGame
            // 
            this.tmrGame.Interval = 20;
            this.tmrGame.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Image = global::LegendsUnleashed.Properties.Resources.MainMenu;
            this.btnMainMenu.Location = new System.Drawing.Point(588, 251);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(168, 43);
            this.btnMainMenu.TabIndex = 5;
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Visible = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnExit2
            // 
            this.btnExit2.BackColor = System.Drawing.Color.Transparent;
            this.btnExit2.Image = global::LegendsUnleashed.Properties.Resources.EXITGAME;
            this.btnExit2.Location = new System.Drawing.Point(588, 197);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(168, 38);
            this.btnExit2.TabIndex = 4;
            this.btnExit2.UseVisualStyleBackColor = false;
            this.btnExit2.Visible = false;
            this.btnExit2.Click += new System.EventHandler(this.btnExit2_Click);
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.Transparent;
            this.btnEasy.Image = global::LegendsUnleashed.Properties.Resources.Easy;
            this.btnEasy.Location = new System.Drawing.Point(53, 330);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(182, 53);
            this.btnEasy.TabIndex = 3;
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Visible = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.Color.Transparent;
            this.btnMedium.Image = global::LegendsUnleashed.Properties.Resources.Medium;
            this.btnMedium.Location = new System.Drawing.Point(53, 251);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(182, 57);
            this.btnMedium.TabIndex = 2;
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Visible = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Transparent;
            this.btnRestart.Image = global::LegendsUnleashed.Properties.Resources.Restart1;
            this.btnRestart.Location = new System.Drawing.Point(53, 187);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(182, 48);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.Transparent;
            this.picResult.Image = global::LegendsUnleashed.Properties.Resources.GameOver;
            this.picResult.Location = new System.Drawing.Point(33, 32);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(823, 117);
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
            this.picResult.Visible = false;
            // 
            // LegendsUnleashedImpossible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 534);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnExit2);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.picResult);
            this.Name = "LegendsUnleashedImpossible";
            this.Text = "Legends Unleashed IMPOSSIBLE";
            this.Load += new System.EventHandler(this.LegendsUnleashed_IMPOSSIBLE__Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPaintEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrGame;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Button btnMainMenu;
    }
}