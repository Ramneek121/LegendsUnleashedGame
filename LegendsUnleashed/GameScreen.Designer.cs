namespace LegendsUnleashed
{
    partial class GameScreen
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
            this.lblEnter = new System.Windows.Forms.Label();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnImpossible = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.picCharacter = new System.Windows.Forms.PictureBox();
            this.picText = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picText)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEnter
            // 
            this.lblEnter.AutoSize = true;
            this.lblEnter.Location = new System.Drawing.Point(964, 527);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new System.Drawing.Size(122, 13);
            this.lblEnter.TabIndex = 2;
            this.lblEnter.Text = "Press Enter to Continue*";
            // 
            // btnEasy
            // 
            this.btnEasy.ForeColor = System.Drawing.Color.Transparent;
            this.btnEasy.Image = global::LegendsUnleashed.Properties.Resources.Easy;
            this.btnEasy.Location = new System.Drawing.Point(32, 488);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(143, 52);
            this.btnEasy.TabIndex = 4;
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Visible = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnImpossible
            // 
            this.btnImpossible.ForeColor = System.Drawing.Color.Transparent;
            this.btnImpossible.Image = global::LegendsUnleashed.Properties.Resources.Impossible;
            this.btnImpossible.Location = new System.Drawing.Point(32, 322);
            this.btnImpossible.Name = "btnImpossible";
            this.btnImpossible.Size = new System.Drawing.Size(143, 51);
            this.btnImpossible.TabIndex = 5;
            this.btnImpossible.UseVisualStyleBackColor = true;
            this.btnImpossible.Visible = false;
            this.btnImpossible.Click += new System.EventHandler(this.btnImpossible_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.ForeColor = System.Drawing.Color.Transparent;
            this.btnNormal.Image = global::LegendsUnleashed.Properties.Resources.Normal;
            this.btnNormal.Location = new System.Drawing.Point(32, 403);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(143, 50);
            this.btnNormal.TabIndex = 3;
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Visible = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // picCharacter
            // 
            this.picCharacter.BackColor = System.Drawing.Color.Transparent;
            this.picCharacter.Image = global::LegendsUnleashed.Properties.Resources.Goku_Happy;
            this.picCharacter.Location = new System.Drawing.Point(834, -11);
            this.picCharacter.Name = "picCharacter";
            this.picCharacter.Size = new System.Drawing.Size(252, 197);
            this.picCharacter.TabIndex = 1;
            this.picCharacter.TabStop = false;
            // 
            // picText
            // 
            this.picText.BackColor = System.Drawing.Color.Transparent;
            this.picText.Image = global::LegendsUnleashed.Properties.Resources.CantWaitToTrain;
            this.picText.Location = new System.Drawing.Point(12, 31);
            this.picText.Name = "picText";
            this.picText.Size = new System.Drawing.Size(783, 89);
            this.picText.TabIndex = 0;
            this.picText.TabStop = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::LegendsUnleashed.Properties.Resources.TrunksBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1115, 566);
            this.Controls.Add(this.btnImpossible);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.lblEnter);
            this.Controls.Add(this.picCharacter);
            this.Controls.Add(this.picText);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "GameScreen";
            this.Text = "Legends Unleashed";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picText;
        private System.Windows.Forms.PictureBox picCharacter;
        private System.Windows.Forms.Label lblEnter;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnImpossible;
    }
}