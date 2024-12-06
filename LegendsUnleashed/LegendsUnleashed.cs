using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Media;
using WMPLib;
using System.Windows.Forms.VisualStyles;

//Ramneek Nagi, Ishaq Naufi
//Jan 15th 2024
//This code implements the medium mode of the 2D fighting game named "Legends Unleashed," featuring player-controlled movements, attack functionalities, and a medium difficulty boss fight  against Goku Black with additional game elements.

namespace LegendsUnleashed
{
    public partial class LegendsUnleashed : Form
    {
        //Set image variables

        Image Player;
        Image Background;
        Image GokuBlack;
        Image Kamehameha;

        // Initial positions of player, GokuBlack, and Kamehameha

        int PlayerX = 0;
        int PlayerY = 300;

        int GokuBlackX = 450;
        int GokuBlackY = 380;

        int KamehamehaX;
        int KamehamehaY;

        //other variables

        int GokuBlackMoveTime = 0;
        int ActionStrength = 0;
        int EndFrame = 0;
        int BackgroundPosition = 0;
        int TotalFrame = 0;
        int bg_number = 0;

        // Set player health
        int PlayerHealth = 200;
        int GokuBlackHealth = 200;

        // Arrays for animation frames
        private Image[] GokuBlackFrames;
        private Image[] GokuBlackPunchFrames;

        // Punching variables
        private int CurrentFrameIndex;
        private int CurrentPunchFrameIndex;
        private bool IsPunching;
        private int PunchDuration;
        private int PunchCooldown;
        private bool RandomPunch;

        // Random generator for goku black
        private Random Random = new Random();

        // Windows Media Player instances for different sounds

        WindowsMediaPlayer BackgroundPlayer = new WindowsMediaPlayer();
        WindowsMediaPlayer GokuBlackLaughing = new WindowsMediaPlayer();
        WindowsMediaPlayer GokuAlright = new WindowsMediaPlayer();
        WindowsMediaPlayer Teleport = new WindowsMediaPlayer();

        float num;

        // Boolean flags for player movement and actions

        bool GoLeft, GoRight;
        bool DirectionPressed;
        bool PlayingAction;
        bool ShotKamehameha;

        // List to store background images

        List<string> Background_Images = new List<string>();



        public LegendsUnleashed()
        {
            InitializeComponent();
            SetUpForm(); // Trigger first event to start the game

            // Initialize and set up background music and sound effects

            BackgroundPlayer.URL = "UltimateBattle1.wav";
            GokuBlackLaughing.URL = "GokuBlackLaughing.wav";
            GokuAlright.URL = "GokuAlright2.wav";
            Teleport.URL = "TeleportFX.wav";

            // Set up buttons appearance (Remove Background for buttons when game is complete)

            btnImpossible.FlatStyle = FlatStyle.Flat;
            btnImpossible.BackColor = Color.Transparent;
            this.btnImpossible.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnImpossible.FlatAppearance.BorderSize = 0;

            btnEasy.FlatStyle = FlatStyle.Flat;
            btnEasy.BackColor = Color.Transparent;
            this.btnEasy.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEasy.FlatAppearance.BorderSize = 0;

            btnExit3.FlatStyle = FlatStyle.Flat;
            btnExit3.BackColor = Color.Transparent;
            this.btnExit3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit3.FlatAppearance.BorderSize = 0;

            btnRestart.FlatStyle = FlatStyle.Flat;
            btnRestart.BackColor = Color.Transparent;
            this.btnRestart.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnRestart.FlatAppearance.BorderSize = 0;

            btnMainMenu.FlatStyle = FlatStyle.Flat;
            btnMainMenu.BackColor = Color.Transparent;
            this.btnMainMenu.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMainMenu.FlatAppearance.BorderSize = 0;

        }

        // SoundPlayer for fighting noises

        private SoundPlayer MusicPlayer;


        private void DrawHealthBars(Graphics g)
        {
            // Draw Player's (Goku) health bar
            g.FillRectangle(Brushes.Green, new Rectangle(10, 10, PlayerHealth * 2, 20));

            // Draw GokuBlack's health bar
            g.FillRectangle(Brushes.Red, new Rectangle(this.ClientSize.Width - GokuBlackHealth * 2 - 10, 10, GokuBlackHealth * 2, 20));
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Handle movement for Goku (Left and right arrow key press)

            if (e.KeyCode == Keys.Left && !DirectionPressed)
            {
                MovePlayerAnimation("Left");

            }

            if (e.KeyCode == Keys.Right && !DirectionPressed)
            {
                MovePlayerAnimation("Right");
            }

            if (e.KeyCode == Keys.Left && !DirectionPressed)
            {
                MovePlayerAnimation("Left");
                
            }
            if (e.KeyCode == Keys.Right && !DirectionPressed)
            {
                MovePlayerAnimation("Right");
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // Handle X key release for changing background

            if (e.KeyCode == Keys.X)
            {
                if (bg_number < Background_Images.Count - 1) // Check if there are more background images available
                {
                    bg_number++;
                }
                else
                {
                    bg_number = 0; // Reset to the first background image if reached the end
                }

                //Change Background and Goku Black Position
                Background = Image.FromFile(Background_Images[bg_number]);
                BackgroundPosition = 0;
                GokuBlackMoveTime = 0;
                GokuBlackX = 450;
            }

            // Handle key release for player movement
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                GoLeft = false;
                GoRight = false;
                DirectionPressed = false;
                PlayerY = 400;
                ResetPlayer();
            }

            if (e.KeyCode == Keys.S && !PlayingAction && !GoLeft && !GoRight)
            {
                // Play punch sound effect
                MusicPlayer = new SoundPlayer(Properties.Resources.PunchSoundEffect);
                MusicPlayer.Play();

                SetPlayerAction("Goku_Kicking.Gif", 5); // Trigger player kick action
            }

            // Handle key release for player Kamehameha action
            if (e.KeyCode == Keys.Space && !PlayingAction && !GoLeft && !GoRight)
            {
                // Kamehameha Sound Effect
                MusicPlayer = new SoundPlayer(Properties.Resources.GokuKamehamehaWaveSoundEffect);
                MusicPlayer.Play();

                // Trigger Kamehameha action and switch timer interval so gif can play
                SetPlayerAction("Kamehameha4.gif", 30);
                PlayerY = 275;
                tmrGame.Interval = 40; // or any other suitable value
                tmrGame.Start();
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            // Draw Background, Player, and GokuBlack
            e.Graphics.DrawImage(Background, new Point(BackgroundPosition, 0));
            e.Graphics.DrawImage(Player, new Point(PlayerX, PlayerY));
            e.Graphics.DrawImage(GokuBlack, new Point(GokuBlackX, GokuBlackY));

            // Draw Kamehameha if it is shot
            if (ShotKamehameha)
            {
                e.Graphics.DrawImage(Kamehameha, new Point(KamehamehaX, KamehamehaY));

            }

            DrawHealthBars(e.Graphics); // Draw health bars
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Initialize these variables when timer is on
            this.Invalidate();
            ImageAnimator.UpdateFrames();
            MovePlayerAndBackground();
            CheckKickHit();
            CheckPunchHit();

            // Update player action animation
            if (PlayingAction)
            {
                if (num < TotalFrame)
                {
                    num += 0.5f;
                }
            }

            // Check conditions for resetting player action animation
            if (num == TotalFrame)
            {
                ResetPlayer();
            }

            // Move and check Kamehameha hit
            if (ShotKamehameha)
            {
                KamehamehaX += 10;
                CheckKamehamehaHit();
            }

            // Stop Kamehameha when it reaches the end of the form
            if (KamehamehaX > this.ClientSize.Width)
            {
                ShotKamehameha = false;
            }

            // Shoot Kamehameha when conditions are met
            if (!ShotKamehameha && num > EndFrame && GokuBlackMoveTime == 0 && ActionStrength == 30)
            {
                ShootKamehameha();

            }

            // Update Goku Black's standing animation
            UpdateGokuBlackStandingAnimation();

            // Trigger GokuBlack punch animation with a probability
            if (GokuBlackHealth > 0 && PlayerHealth > 0)
            {
                if (Random.Next(0, 100) < 1.5) // Adjust the probability of attacking and moving (in normal 1.5%)
                {
                    GokuBlackPunch(); 
                    GokuBlackX += 250;
                }
            }

            // Move GokuBlack when hit and handle him getting hit animation
            if (GokuBlackMoveTime > 0)
            {
                GokuBlackMoveTime--;
                GokuBlackX += 10;
                GokuBlack = Image.FromFile("GokuBlackHit1.png");
            }

            else
            {
                // Use the current frame of Goku Black's standing animation
                GokuBlack = GokuBlackFrames[CurrentFrameIndex];
                GokuBlackMoveTime = 0;
            }

            //Reset Goku Black back to original position
            if (GokuBlackX > this.ClientSize.Width)
            {
                GokuBlackMoveTime = 0;
                GokuBlackX = 300;
            }

            // Update GokuBlack punch animation
            UpdateGokuBlackPunchAnimation();

            // Check if GokuBlack's health is below 0 and set all buttons and Win text to visible
            if (GokuBlackHealth <= 0)
            {
                picResult.Image = Properties.Resources.YouWin;
                picResult.SizeMode = PictureBoxSizeMode.Zoom;
                picResult.Visible = true;
                btnEasy.Visible = true;
                btnMainMenu.Visible = true;
                btnImpossible.Visible = true;
                btnExit3.Visible = true;
                btnRestart.Visible = true;

                // Change the image to Goku Black laying on the floor
                GokuBlack = Image.FromFile("GokuBlackDefeated1.png");
                GokuBlackY = 425;
                RandomPunch = false; //disable random movement

                GokuAlright.controls.play(); // Play Goku Winning Sound effect

            }

            // Check if Player's health is below 0 and set all buttons and lose text to visible
            if (PlayerHealth <= 0)
            {
                picResult.SizeMode = PictureBoxSizeMode.Zoom;
                picResult.Visible = true;
                btnEasy.Visible = true;
                btnMainMenu.Visible = true;
                btnImpossible.Visible = true;
                btnExit3.Visible = true;
                btnRestart.Visible = true;

                // Change the image to Goku Black laying on the floor
                Player = Image.FromFile("GokuDefeated1.png");
                PlayerY = 450;
                RandomPunch = false; // turn off random movement

                GokuBlackLaughing.controls.play(); // Goku Black winning sound effect playing
            }
        }

        private void UpdateGokuBlackPunchAnimation()
        {
            if (IsPunching)
            {
                // Check if it's time to switch to the next punch frame
                if (++CurrentPunchFrameIndex >= GokuBlackPunchFrames.Length)
                {
                    CurrentPunchFrameIndex = 0; // Reset to the first frame
                    IsPunching = false; // End the punch animation
                    PunchCooldown = 20; // Set a cooldown before the next punch can occur
                }
            }

            // Apply the current punch frame
            if (IsPunching)
            {
                GokuBlack = GokuBlackPunchFrames[CurrentPunchFrameIndex];
            }
        }

        private void UpdateGokuBlackStandingAnimation()
        {
            // Check if it's time to switch to the next frame
            if (++CurrentFrameIndex >= GokuBlackFrames.Length)
            {
                CurrentFrameIndex = 0; // Reset to the first frame
            }
        }

        // Set up punching animation with frames for Goku Black
        private void LoadGokuBlackPunchFrames()
        {
            Image gifImage = Image.FromFile("GokuBlackPunching.gif"); // Load punching animation for Goku Black
            FrameDimension dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
            int frameCount = gifImage.GetFrameCount(dimension);

            GokuBlackPunchFrames = new Image[frameCount];

            for (int i = 0; i < frameCount; i++)
            {
                gifImage.SelectActiveFrame(dimension, i);
                GokuBlackPunchFrames[i] = (Image)gifImage.Clone();
            }

            CurrentPunchFrameIndex = 0;
        }

        private void SetUpForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            // Load background images from a directory
            Background_Images = Directory.GetFiles("background", "*.jpg").ToList();
            Background = Image.FromFile(Background_Images[bg_number]);
            Player = Image.FromFile("GokuStanding.Gif");


            // Load and initialize Goku Black's standing animation frames
            LoadGokuBlackStandingFrames();

            // Set up the initial frame
            GokuBlack = GokuBlackFrames[0];

            LoadGokuBlackPunchFrames();
            GokuBlack = GokuBlackFrames[0];

            // Trigger Form animation
            SetUpAnimation();
        }

        private void GokuBlackPunch()
        {
            Teleport.controls.play(); // Play sound effect of teleporting
            IsPunching = true; 
            PunchDuration = GokuBlackPunchFrames.Length; // Set the punch duration
            CurrentPunchFrameIndex = 0; // Reset to the first frame
            PunchCooldown = 15; // Set a cooldown before the next punch can occur
        }

        private void LoadGokuBlackStandingFrames()
        {
            Image GifImage = Image.FromFile("GokuBlackStanding.gif");
            FrameDimension Dimension = new FrameDimension(GifImage.FrameDimensionsList[0]);
            int FrameCount = GifImage.GetFrameCount(Dimension);

            GokuBlackFrames = new Image[FrameCount];

            for (int i = 0; i < FrameCount; i++)
            {
                GifImage.SelectActiveFrame(Dimension, i);
                GokuBlackFrames[i] = (Image)GifImage.Clone();
            }

            CurrentFrameIndex = 0;
        }


        private void SetUpAnimation() 
        {
            //Animate Goku
            ImageAnimator.Animate(Player, this.OnFrameChangedHandler);
            FrameDimension Dimensions = new FrameDimension(Player.FrameDimensionsList[0]);
            TotalFrame = Player.GetFrameCount(Dimensions);
            EndFrame = TotalFrame - 3 ;
            tmrGame.Interval = 20; //Change Timer and Start
            tmrGame.Start();
        }

        // Handle the event when the frame of the player changes
        private void OnFrameChangedHandler(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        
        private void MovePlayerAndBackground()
        {
            // Move player left
            if (GoLeft)
            {
                if (PlayerX > 0)
                {
                    PlayerX -= 6;
                }
            }

            // Adjust background position and GokuBlackX when player is near left edge
            if (BackgroundPosition < 0 && PlayerX < 100)
            {
                BackgroundPosition += 5;
                GokuBlackX += 5;
            }
            
            // Move player right
            if (GoRight)
            {
                if (PlayerX + Player.Width < this.ClientSize.Width) 
                {
                    PlayerX += 6;
                }
            }

            // Adjust background position and GokuBlackX when player is near right edge
            if (BackgroundPosition + Background.Width > this.ClientSize.Width + 5 && PlayerX > 650) 
            {
                BackgroundPosition -= 5;
                GokuBlackX -= 5;
            }   
            
        }

        private void MovePlayerAnimation(string Direction)
        {
            // Move the player based on the specified direction
            if (Direction == "Left")
            {
                GoLeft = true;
                PlayerY = 400;
                Player = Image.FromFile("GokuFlying.gif"); //change to flying
            }

            if (Direction == "Right") 
            { 
                GoRight = true;
                PlayerY = 400;
                Player = Image.FromFile("GokuFlying.gif"); // change to flying
            }

            DirectionPressed = true;
            PlayingAction = false;
            SetUpAnimation(); // animate movement
        }

        private void ResetPlayer()
        {
            // Reset the player to the default standing position
            Player = Image.FromFile("GokuStanding.gif");
            PlayerY = 300;
            SetUpAnimation();

            num = 0;
            PlayingAction = false;

        }

        private void SetPlayerAction(string Animation, int Strength)
        {
            // Set the player's action with the specified animation and strength
            Player = Image.FromFile(Animation);
            ActionStrength = Strength;
            SetUpAnimation();
            PlayingAction = true;
        }

        private void ShootKamehameha() 
        {
            // Shoot the kamehameha and animate it
            Kamehameha = Image.FromFile("kamehamehaicon.gif"); // Load kamehameha
            ImageAnimator.Animate(Kamehameha, this.OnFrameChangedHandler);

            // Set position where it will generate
            KamehamehaX = PlayerX + Player.Width - 250;
            KamehamehaY = PlayerY + 100;
            ShotKamehameha = true; 
        }

        private void CheckPunchHit()
        {
            // Check if Goku Black is punching
            if (IsPunching && num < EndFrame)
            {
                // Calculate the bounding box for Goku Black's punch
                Rectangle PunchBounds = new Rectangle(GokuBlackX, GokuBlackY, GokuBlackPunchFrames[0].Width, GokuBlackPunchFrames[0].Height);

                // Adjust the punch bounding box to make it more accurate
                PunchBounds.Inflate(-20, -20);

                // Check if Player (Goku) is within the punch bounding box
                if (PlayerX + Player.Width > PunchBounds.Left && PlayerX < PunchBounds.Right &&
                    PlayerY + Player.Height > PunchBounds.Top && PlayerY < PunchBounds.Bottom)
                {
                    // Deduct health from Goku (Player)
                    PlayerHealth -= 5;
                }
            }
        }

        private void CheckKickHit()
        {
            // Check if the kick from player hits
            bool Collision = DetectCollision(PlayerX, PlayerY, Player.Width, Player.Height, GokuBlackX, GokuBlackY,
                GokuBlack.Width, GokuBlack.Height);

            if (Collision && PlayingAction && num > EndFrame)
            {
                GokuBlackMoveTime = ActionStrength; // push back strength
                GokuBlackHealth -= 5; // Decrease GokuBlack's health
            }

        }

        private void CheckKamehamehaHit() 
        {
            //Check if the kamehameha hits Goku Black
            bool Collision = DetectCollision(KamehamehaX, KamehamehaY, Kamehameha.Width, Kamehameha.Height, GokuBlackX, GokuBlackY,
               GokuBlack.Width, GokuBlack.Height);

            if (Collision)
            {
                GokuBlackMoveTime = ActionStrength; // push back 
                ShotKamehameha = false; // remove kamehameha when it hits
                GokuBlackHealth -= 40; // Decrease GokuBlack's health
            }
        }

        // Detect collision between two objects (used for player and Goku Black later)
        private bool DetectCollision(int Object1X, int Object1Y, int Object1Width, int Object1Height, 
            int Object2X, int Object2Y, int Object2Width, int Object2Height)
        {
            if (Object1X + Object1Width <= Object2X || Object1X >= Object2X + Object2Width || Object1Y
                + Object1Height <= Object2Y || Object1Y >= Object2Y + Object2Height)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Select Impossible mode and disable music
        private void btnImpossible_Click(object sender, EventArgs e)
        {
            LegendsUnleashedImpossible GameWindow = new LegendsUnleashedImpossible();
            GameWindow.Show();
            this.Close();
            BackgroundPlayer.controls.stop();
        }

        //Select easy mode and disable music
        private void btnEasy_Click(object sender, EventArgs e)
        {
            LegendsUnleashedEasy GameWindow = new LegendsUnleashedEasy();
            GameWindow.Show();
            this.Close();
            BackgroundPlayer.controls.stop();
        }

        // Restart and disable music
        private void btnRestart_Click(object sender, EventArgs e)
        {
            LegendsUnleashed GameWindow = new LegendsUnleashed();
            GameWindow.Show();
            this.Close();
            BackgroundPlayer.controls.stop();
        }

        // Go back to main menu
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu MainWindow = new MainMenu();
            MainWindow.Show();
            this.Close();
            BackgroundPlayer.controls.stop();
        }

        //Play fight music and goku black laughing
        private void LegendsUnleashed_Load(object sender, EventArgs e)
        {
            BackgroundPlayer.controls.play();
            GokuBlackLaughing.controls.play();
        }

        // Exit the game and disable music
        private void btnExit3_Click(object sender, EventArgs e)
        {
            BackgroundPlayer.controls.stop();
            Application.Exit();
        }

        // When form is closed, turn off music
        private void LegendsUnleashed_FormClosing(object sender, FormClosingEventArgs e)
        {
            BackgroundPlayer.controls.stop();
        }
    }
}

   

          