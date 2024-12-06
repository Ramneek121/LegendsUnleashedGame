using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static System.Net.Mime.MediaTypeNames;

//Ramneek Nagi, Ishaq Naufi
//Jan 15th 2024
//This code implements cutscenes where multiple cutscenes show up with the press of the enter key, and music is played in the background for most of them. In this page, you can also select difficulties.

namespace LegendsUnleashed
{
    public partial class GameScreen : Form
    {
        // Variables to track the current image index for two picture boxes and sound players

        private int CurrentImageIndex1;
        private int CurrentImageIndex2;
        private SoundPlayer MusicPlayer;
        public SoundPlayer BackgroundMusic;

        public GameScreen()
        {
            //Configure buttomn styles to remove background
            InitializeComponent();
            btnImpossible.FlatStyle = FlatStyle.Flat;
            btnImpossible.BackColor = Color.Transparent;
            this.btnImpossible.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnImpossible.FlatAppearance.BorderSize = 0;

            btnEasy.FlatStyle = FlatStyle.Flat;
            btnEasy.BackColor = Color.Transparent;
            this.btnEasy.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEasy.FlatAppearance.BorderSize = 0;

            btnNormal.FlatStyle = FlatStyle.Flat;
            btnNormal.BackColor = Color.Transparent;
            this.btnNormal.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnNormal.FlatAppearance.BorderSize = 0;
        }

        // Check if Enter key is pressed
        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Change the image in the PictureBox
                ChangePictureTextImage();
                ChangePictureCharacterImage();
            }
        }

        // Method to change the image of PictureCharacter
        private void ChangePictureCharacterImage()
        {
            CurrentImageIndex2++;

            if (CurrentImageIndex2 >= 4) // Change 4 to the total number of cases
            {
                this.BackgroundImage = Properties.Resources.Goku_Black;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                lblEnter.Visible = false;
            }

            { 
                picCharacter.SizeMode = PictureBoxSizeMode.Zoom; // Set the size mode to Zoom

                // Switch between different images as enter is clicked
                switch (CurrentImageIndex2)
                {
                    case 1:
                        picCharacter.Image = Properties.Resources.Goku_Sensing;
                        MusicPlayer = new SoundPlayer(Properties.Resources.DBZSurprisedSound);
                        MusicPlayer.Play();
                        break;

                    case 2:
                        picCharacter.Image = Properties.Resources.Goku_Angry;
                        break;

                    case 3:
                        picCharacter.Image = Properties.Resources.Goku_Surprised;
                        MusicPlayer = new SoundPlayer(Properties.Resources.GokuBlackLaughing);
                        MusicPlayer.Play();
                        break;

                    case 4:
                        picCharacter.Image = null;
                        MusicPlayer = new SoundPlayer(Properties.Resources.GokuBlackThemeSong);
                        MusicPlayer.Play(); // Play goku black laughing
                        break;
                    

                }
            }

        }
        // method to change picture for text
        private void ChangePictureTextImage()
        {
            CurrentImageIndex1++;

            if (CurrentImageIndex1 >= 6) // Change 6 to the total number of cases
            {
                // Make all buttons visible once done all 6 cases
                btnNormal.Visible = true;
                btnImpossible.Visible = true;
                btnEasy.Visible = true;
            }

            // Switch between different images for Pictext
            switch (CurrentImageIndex1)
            {
                case 1:
                    picText.Image = Properties.Resources.Vegeta_Do_you_Sense__2_;
                    break;

                case 2:
                    picText.Image = Properties.Resources.It_cant_be;
                    break;

                case 3:
                    picText.Image = Properties.Resources.WhatIsHeDoing;
                    break;

                case 4:
                    picText.Image = Properties.Resources.Foolish_Mortals__2_;
                    break;

                case 5:
                    picText.Image = Properties.Resources.Come_At_Me;
                    break;

                case 6:
                    picText.Image = Properties.Resources.Will_Not_be_Bested;
                    break;
            }

        }

        // If next is clicked, open up the game window and stop the music
        private void btnNext_Click(object sender, EventArgs e)
        {
            LegendsUnleashed LegendsUnleashedWindow = new LegendsUnleashed();
            LegendsUnleashedWindow.Show();
            MusicPlayer.Stop();
            this.Close();


        }

        // if impossible is clicked, open up the impossible version and stop the music
        private void btnImpossible_Click(object sender, EventArgs e)
        {
            LegendsUnleashedImpossible LegendsUnleashedWindowImpossible = new LegendsUnleashedImpossible();
            LegendsUnleashedWindowImpossible.Show();
            MusicPlayer.Stop();
            this.Close();
        }

        // if easy is clicked, open up the easy window and turn off music.
        private void btnEasy_Click(object sender, EventArgs e)
        {
            LegendsUnleashedEasy LegendsUnleashedWindowEasy = new LegendsUnleashedEasy();
            LegendsUnleashedWindowEasy.Show();
            MusicPlayer.Stop();
            this.Close();
        }
    }
}
    


   

