namespace LegendsUnleashed
{
    partial class LegendsUnleashed
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
            this.lblPlayerHealth = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.tmrGame = new System.Windows.Forms.Timer(this.components);
            this.btnImpossible = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnExit3 = new System.Windows.Forms.Button();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.picResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerHealth
            // 
            this.lblPlayerHealth.AutoSize = true;
            this.lblPlayerHealth.Location = new System.Drawing.Point(13, 13);
            this.lblPlayerHealth.Name = "lblPlayerHealth";
            this.lblPlayerHealth.Size = new System.Drawing.Size(0, 13);
            this.lblPlayerHealth.TabIndex = 0;
            // 
            // lblHitPoints
            // 
            this.lblHitPoints.AutoSize = true;
            this.lblHitPoints.Location = new System.Drawing.Point(69, 13);
            this.lblHitPoints.Name = "lblHitPoints";
            this.lblHitPoints.Size = new System.Drawing.Size(0, 13);
            this.lblHitPoints.TabIndex = 4;
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(72, 37);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(0, 13);
            this.lblGold.TabIndex = 5;
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(80, 61);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(0, 13);
            this.lblExperience.TabIndex = 6;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(72, 90);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(0, 13);
            this.lblLevel.TabIndex = 7;
            // 
            // tmrGame
            // 
            this.tmrGame.Enabled = true;
            this.tmrGame.Interval = 20;
            this.tmrGame.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // btnImpossible
            // 
            this.btnImpossible.BackColor = System.Drawing.Color.Transparent;
            this.btnImpossible.Image = global::LegendsUnleashed.Properties.Resources.Impossible;
            this.btnImpossible.Location = new System.Drawing.Point(35, 237);
            this.btnImpossible.Name = "btnImpossible";
            this.btnImpossible.Size = new System.Drawing.Size(182, 53);
            this.btnImpossible.TabIndex = 18;
            this.btnImpossible.UseVisualStyleBackColor = false;
            this.btnImpossible.Visible = false;
            this.btnImpossible.Click += new System.EventHandler(this.btnImpossible_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMainMenu.Image = global::LegendsUnleashed.Properties.Resources.MainMenu;
            this.btnMainMenu.Location = new System.Drawing.Point(626, 237);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(168, 43);
            this.btnMainMenu.TabIndex = 17;
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Visible = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnExit3
            // 
            this.btnExit3.BackColor = System.Drawing.Color.Transparent;
            this.btnExit3.Image = global::LegendsUnleashed.Properties.Resources.EXITGAME;
            this.btnExit3.Location = new System.Drawing.Point(626, 183);
            this.btnExit3.Name = "btnExit3";
            this.btnExit3.Size = new System.Drawing.Size(168, 38);
            this.btnExit3.TabIndex = 16;
            this.btnExit3.UseVisualStyleBackColor = false;
            this.btnExit3.Visible = false;
            this.btnExit3.Click += new System.EventHandler(this.btnExit3_Click);
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.Transparent;
            this.btnEasy.Image = global::LegendsUnleashed.Properties.Resources.Easy;
            this.btnEasy.Location = new System.Drawing.Point(35, 296);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(182, 53);
            this.btnEasy.TabIndex = 14;
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Visible = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Transparent;
            this.btnRestart.Image = global::LegendsUnleashed.Properties.Resources.Restart1;
            this.btnRestart.Location = new System.Drawing.Point(35, 183);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(182, 48);
            this.btnRestart.TabIndex = 13;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.Transparent;
            this.picResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picResult.Image = global::LegendsUnleashed.Properties.Resources.GameOver1;
            this.picResult.Location = new System.Drawing.Point(54, 12);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(786, 107);
            this.picResult.TabIndex = 8;
            this.picResult.TabStop = false;
            this.picResult.Visible = false;
            // 
            // LegendsUnleashed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 534);
            this.Controls.Add(this.btnImpossible);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnExit3);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblHitPoints);
            this.Controls.Add(this.lblPlayerHealth);
            this.Name = "LegendsUnleashed";
            this.Text = "Legends Unleashed";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPaintEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerHealth;
        private System.Windows.Forms.Label lblHitPoints;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Timer tmrGame;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnExit3;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnImpossible;
    }
}