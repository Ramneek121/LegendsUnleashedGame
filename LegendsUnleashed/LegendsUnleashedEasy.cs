using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

//Ramneek Nagi, Ishaq Naufi
//Jan 15th 2024
//This code implements the easy mode of the 2D fighting game named "Legends Unleashed," featuring player-controlled movements, attack functionalities, and an easier boss fight against Goku Black with additional game elements.
// This does not contain any comments, since this is the exact same code as the medium version. Where there is a change, there is a comment 
// The main change in this version is that Goku Black has reduced health, and he attacks less

namespace LegendsUnleashed
{
    public partial class LegendsUnleashedEasy : Form
    {

        Image Player;
        Image Background;
        Image GokuBlack;
        Image Kamehameha;

        int PlayerX = 0;
        int PlayerY = 300;

        int GokuBlackX = 450;
        int GokuBlackY = 380;

        int KamehamehaX;
        int KamehamehaY;

        int GokuBlackMoveTime = 0;
        int ActionStrength = 0;
        int EndFrame = 0;
        int BackgroundPosition = 0;
        int TotalFrame = 0;
        int bg_number = 0;

        int PlayerHealth = 200;
        int GokuBlackHealth = 150; // Reduced Health

        private Image[] GokuBlackFrames;
        private int CurrentFrameIndex;

        private Image[] GokuBlackPunchFrames;
        private int CurrentPunchFrameIndex;
        private bool IsPunching;
        private int PunchDuration;
        private int PunchCooldown;
        private bool RandomPunch;

        private Random Random = new Random();

        WindowsMediaPlayer BackgroundPlayer = new WindowsMediaPlayer();
        WindowsMediaPlayer GokuBlackLaughing = new WindowsMediaPlayer();
        WindowsMediaPlayer GokuAlright = new WindowsMediaPlayer();
        WindowsMediaPlayer Teleport = new WindowsMediaPlayer();


        float num;

        bool GoLeft, GoRight;
        bool DirectionPressed;
        bool PlayingAction;
        bool ShotKamehameha;

        List<string> Background_Images = new List<string>();

        public LegendsUnleashedEasy()
        {
            InitializeComponent();
            SetUpForm();

            BackgroundPlayer.URL = "UltimateBattle1.wav";
            GokuBlackLaughing.URL = "GokuBlackLaughing.wav";
            GokuAlright.URL = "GokuAlright2.wav";
            Teleport.URL = "TeleportFX.wav";

            btnImpossible.FlatStyle = FlatStyle.Flat;
            btnImpossible.BackColor = Color.Transparent;
            this.btnImpossible.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnImpossible.FlatAppearance.BorderSize = 0;

            btnMedium.FlatStyle = FlatStyle.Flat;
            btnMedium.BackColor = Color.Transparent;
            this.btnMedium.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMedium.FlatAppearance.BorderSize = 0;

            btnExit1.FlatStyle = FlatStyle.Flat;
            btnExit1.BackColor = Color.Transparent;
            this.btnExit1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit1.FlatAppearance.BorderSize = 0;

            btnRestart.FlatStyle = FlatStyle.Flat;
            btnRestart.BackColor = Color.Transparent;
            this.btnRestart.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnRestart.FlatAppearance.BorderSize = 0;

            btnMainMenu.FlatStyle = FlatStyle.Flat;
            btnMainMenu.BackColor = Color.Transparent;
            this.btnMainMenu.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMainMenu.FlatAppearance.BorderSize = 0;
        }

        private SoundPlayer MusicPlayer;


        private void DrawHealthBars(Graphics g)
        {
            g.FillRectangle(Brushes.Green, new Rectangle(10, 10, PlayerHealth * 2, 20));

            g.FillRectangle(Brushes.Red, new Rectangle(this.ClientSize.Width - GokuBlackHealth * 2 - 10, 10, GokuBlackHealth * 2, 20));
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
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
            if (e.KeyCode == Keys.X)
            {
                if (bg_number < Background_Images.Count - 1)
                {

                    bg_number++;
                }
                else
                {
                    bg_number = 0;
                }

                Background = Image.FromFile(Background_Images[bg_number]);
                BackgroundPosition = 0;
                GokuBlackMoveTime = 0;
                GokuBlackX = 450;
            }

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
                MusicPlayer = new SoundPlayer(Properties.Resources.PunchSoundEffect);
                MusicPlayer.Play();

                SetPlayerAction("Goku_Kicking.Gif", 5);


            }
            if (e.KeyCode == Keys.Space && !PlayingAction && !GoLeft && !GoRight)
            {
                MusicPlayer = new SoundPlayer(Properties.Resources.GokuKamehamehaWaveSoundEffect);
                MusicPlayer.Play();

                SetPlayerAction("Kamehameha4.gif", 30);
                PlayerY = 275;
                tmrGame.Interval = 40;
                tmrGame.Start();
            }

        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Background, new Point(BackgroundPosition, 0));
            e.Graphics.DrawImage(Player, new Point(PlayerX, PlayerY));
            e.Graphics.DrawImage(GokuBlack, new Point(GokuBlackX, GokuBlackY));

            if (ShotKamehameha)
            {
                e.Graphics.DrawImage(Kamehameha, new Point(KamehamehaX, KamehamehaY));

            }
            DrawHealthBars(e.Graphics); // Draw health bars
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            this.Invalidate();
            ImageAnimator.UpdateFrames();
            MovePlayerAndBackground();
            CheckKickHit();
            CheckPunchHit();

            if (PlayingAction)
            {
                if (num < TotalFrame)
                {
                    num += 0.5f;
                }
            }

            if (num == TotalFrame)
            {
                ResetPlayer();
            }

            if (ShotKamehameha)
            {
                KamehamehaX += 10;
                CheckKamehamehaHit();
            }

            if (KamehamehaX > this.ClientSize.Width)
            {
                ShotKamehameha = false;
            }

            if (!ShotKamehameha && num > EndFrame && GokuBlackMoveTime == 0 && ActionStrength == 30)
            {
                ShootKamehameha();
            }

            UpdateGokuBlackStandingAnimation();

            if (GokuBlackHealth > 0 && PlayerHealth > 0)
            {
                if (Random.Next(0, 100) < 1) // The probability of him attacking is less (1%)
                {
                    GokuBlackPunch();
                    GokuBlackX += 250;
                }
            }

            if (GokuBlackMoveTime > 0)
            {
                GokuBlackMoveTime--;
                GokuBlackX += 10;
                GokuBlack = Image.FromFile("GokuBlackHit1.png");
            }

            else
            {
                GokuBlack = GokuBlackFrames[CurrentFrameIndex];
                GokuBlackMoveTime = 0;
            }

            if (GokuBlackX > this.ClientSize.Width)
            {
                GokuBlackMoveTime = 0;
                GokuBlackX = 300;
            }

            UpdateGokuBlackPunchAnimation();

            if (GokuBlackHealth <= 0)
            {
                picResult.Image = Properties.Resources.YouWin;
                picResult.SizeMode = PictureBoxSizeMode.Zoom;
                picResult.Visible = true;
                btnImpossible.Visible = true;
                btnMainMenu.Visible = true;
                btnMedium.Visible = true;
                btnExit1.Visible = true;
                btnRestart.Visible = true;

                GokuBlack = Image.FromFile("GokuBlackDefeated1.png");
                GokuBlackY = 425;
                RandomPunch = false;
                GokuAlright.controls.play();
            }

            if (PlayerHealth <= 0)
            {
                picResult.SizeMode = PictureBoxSizeMode.Zoom;
                picResult.Visible = true;
                btnImpossible.Visible = true;
                btnMainMenu.Visible = true;
                btnMedium.Visible = true;
                btnExit1.Visible = true;
                btnRestart.Visible = true;

                Player = Image.FromFile("GokuDefeated1.png");
                PlayerY = 450;
                RandomPunch = false;
                GokuBlackLaughing.controls.play();
            }
        }

        private void UpdateGokuBlackPunchAnimation()
        {
            if (IsPunching)
            {
                if (++CurrentPunchFrameIndex >= GokuBlackPunchFrames.Length)
                {
                    CurrentPunchFrameIndex = 0;
                    IsPunching = false; 
                    PunchCooldown = 20; 
                }
            }

            if (IsPunching)
            {
                GokuBlack = GokuBlackPunchFrames[CurrentPunchFrameIndex];
            }
        }

        private void UpdateGokuBlackStandingAnimation()
        {
            if (++CurrentFrameIndex >= GokuBlackFrames.Length)
            {
                CurrentFrameIndex = 0; 
            }
        }

        private void LoadGokuBlackPunchFrames()
        {
            Image gifImage = Image.FromFile("GokuBlackPunching.gif");
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

            Background_Images = Directory.GetFiles("background", "*.jpg").ToList();
            Background = Image.FromFile(Background_Images[bg_number]);
            Player = Image.FromFile("GokuStanding.Gif");


            LoadGokuBlackStandingFrames();
            GokuBlack = GokuBlackFrames[0];

            LoadGokuBlackPunchFrames();
            GokuBlack = GokuBlackFrames[0];

            SetUpAnimation();
        }

        private void GokuBlackPunch()
        {
            Teleport.controls.play();

            IsPunching = true;
            PunchDuration = GokuBlackPunchFrames.Length; 
            CurrentPunchFrameIndex = 0; 
            PunchCooldown = 15; 
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
            ImageAnimator.Animate(Player, this.OnFrameChangedHandler);
            FrameDimension Dimensions = new FrameDimension(Player.FrameDimensionsList[0]);
            TotalFrame = Player.GetFrameCount(Dimensions);
            EndFrame = TotalFrame - 3;
            tmrGame.Interval = 20; // or any other suitable value
            tmrGame.Start();
        }

        private void OnFrameChangedHandler(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void MovePlayerAndBackground()
        {
            if (GoLeft)
            {
                if (PlayerX > 0)
                {
                    PlayerX -= 6;
                }
            }

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

            if (BackgroundPosition + Background.Width > this.ClientSize.Width + 5 && PlayerX > 650)
            {
                BackgroundPosition -= 5;
                GokuBlackX -= 5;
            }
        }

        private void MovePlayerAnimation(string Direction)
        {

            if (Direction == "Left")
            {
                GoLeft = true;
                PlayerY = 400;
                Player = Image.FromFile("GokuFlying.gif");
            }

            if (Direction == "Right")
            {
                GoRight = true;
                PlayerY = 400;
                Player = Image.FromFile("GokuFlying.gif");
            }

            DirectionPressed = true;
            PlayingAction = false;
            SetUpAnimation();
        }

        private void ResetPlayer()
        {
            Player = Image.FromFile("GokuStanding.gif");
            PlayerY = 300;
            SetUpAnimation();

            num = 0;
            PlayingAction = false;
        }

        private void SetPlayerAction(string Animation, int Strength)
        {
            Player = Image.FromFile(Animation);
            ActionStrength = Strength;
            SetUpAnimation();
            PlayingAction = true;
        }

        private void ShootKamehameha()
        {
            Kamehameha = Image.FromFile("kamehamehaicon.gif");
            ImageAnimator.Animate(Kamehameha, this.OnFrameChangedHandler);
            KamehamehaX = PlayerX + Player.Width - 250;
            KamehamehaY = PlayerY + 100;
            ShotKamehameha = true;
        }

        private void CheckPunchHit()
        {
            if (IsPunching && num < EndFrame)
            {
                Rectangle PunchBounds = new Rectangle(GokuBlackX, GokuBlackY, GokuBlackPunchFrames[0].Width, GokuBlackPunchFrames[0].Height);

                PunchBounds.Inflate(-20, -20);

                if (PlayerX + Player.Width > PunchBounds.Left && PlayerX < PunchBounds.Right &&
                    PlayerY + Player.Height > PunchBounds.Top && PlayerY < PunchBounds.Bottom)
                {
                    PlayerHealth -= 5; 
                }
            }
        }

        private void CheckKickHit()
        {
            bool Collision = DetectCollision(PlayerX, PlayerY, Player.Width, Player.Height, GokuBlackX, GokuBlackY,
                GokuBlack.Width, GokuBlack.Height);

            if (Collision && PlayingAction && num > EndFrame)
            {
                GokuBlackMoveTime = ActionStrength;
                GokuBlackHealth -= 5; 
            }
        }

        private void CheckKamehamehaHit()
        {

            bool Collision = DetectCollision(KamehamehaX, KamehamehaY, Kamehameha.Width, Kamehameha.Height, GokuBlackX, GokuBlackY,
               GokuBlack.Width, GokuBlack.Height);

            if (Collision)

            {
                GokuBlackMoveTime = ActionStrength;
                ShotKamehameha = false;
                GokuBlackHealth -= 30; 
            }
        }

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

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu MainWindow = new MainMenu();
            MainWindow.Show();
            this.Close();
            BackgroundPlayer.controls.stop();
        }

        private void btnImpossible_Click(object sender, EventArgs e)
        {
            LegendsUnleashedImpossible GameWindow = new LegendsUnleashedImpossible();
            GameWindow.Show();
            this.Close();
            BackgroundPlayer.controls.stop();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            LegendsUnleashed GameWindow = new LegendsUnleashed();
            GameWindow.Show();
            this.Close();
            BackgroundPlayer.controls.stop();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            LegendsUnleashedEasy GameWindow = new LegendsUnleashedEasy();
            GameWindow.Show();
            this.Close();
            BackgroundPlayer.controls.stop();
        }

        private void LegendsUnleashed_EASY_Load(object sender, EventArgs e)
        {
            BackgroundPlayer.controls.play();
            GokuBlackLaughing.controls.play();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            BackgroundPlayer.controls.stop();
            Application.Exit();
        }
    }
           
}   
            

    

