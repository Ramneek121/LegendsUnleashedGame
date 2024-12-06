namespace LegendsUnleashed
{
    partial class LegendsUnleashedEasy
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
            this.btnImpossible = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnExit1 = new System.Windows.Forms.Button();
            this.picResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrGame
            // 
            this.tmrGame.Interval = 20;
            this.tmrGame.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // btnImpossible
            // 
            this.btnImpossible.BackColor = System.Drawing.Color.Transparent;
            this.btnImpossible.Image = global::LegendsUnleashed.Properties.Resources.Impossible;
            this.btnImpossible.Location = new System.Drawing.Point(47, 253);
            this.btnImpossible.Name = "btnImpossible";
            this.btnImpossible.Size = new System.Drawing.Size(182, 53);
            this.btnImpossible.TabIndex = 9;
            this.btnImpossible.UseVisualStyleBackColor = false;
            this.btnImpossible.Visible = false;
            this.btnImpossible.Click += new System.EventHandler(this.btnImpossible_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.Color.Transparent;
            this.btnMedium.Image = global::LegendsUnleashed.Properties.Resources.Medium;
            this.btnMedium.Location = new System.Drawing.Point(47, 312);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(182, 57);
            this.btnMedium.TabIndex = 8;
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Visible = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Transparent;
            this.btnRestart.Image = global::LegendsUnleashed.Properties.Resources.Restart1;
            this.btnRestart.Location = new System.Drawing.Point(47, 199);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(182, 48);
            this.btnRestart.TabIndex = 7;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMainMenu.Image = global::LegendsUnleashed.Properties.Resources.MainMenu;
            this.btnMainMenu.Location = new System.Drawing.Point(621, 264);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(168, 43);
            this.btnMainMenu.TabIndex = 6;
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Visible = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnExit1
            // 
            this.btnExit1.BackColor = System.Drawing.Color.Transparent;
            this.btnExit1.Image = global::LegendsUnleashed.Properties.Resources.EXITGAME;
            this.btnExit1.Location = new System.Drawing.Point(621, 209);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(168, 38);
            this.btnExit1.TabIndex = 5;
            this.btnExit1.UseVisualStyleBackColor = false;
            this.btnExit1.Visible = false;
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.Transparent;
            this.picResult.Image = global::LegendsUnleashed.Properties.Resources.GameOver;
            this.picResult.Location = new System.Drawing.Point(47, 29);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(786, 107);
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
            this.picResult.Visible = false;
            // 
            // LegendsUnleashedEasy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 534);
            this.Controls.Add(this.btnImpossible);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnExit1);
            this.Controls.Add(this.picResult);
            this.Name = "LegendsUnleashedEasy";
            this.Text = "Legends Unleashed EASY";
            this.Load += new System.EventHandler(this.LegendsUnleashed_EASY_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPaintEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Timer tmrGame;
        private System.Windows.Forms.Button btnExit1;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnImpossible;
    }
}