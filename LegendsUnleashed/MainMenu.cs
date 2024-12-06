using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Ramneek Nagi, Ishaq Naufi
//Jan 15th 2024
//This code implements the loading screen, the main screen with the button that leads to the actual game, instructions, and exit game with music in the back.

namespace LegendsUnleashed
{
    public partial class MainMenu : Form
    {
        // Define MusicPlayer variable
        private SoundPlayer MusicPlayer;

        public MainMenu()
        {
            InitializeComponent();

            // Play music
            MusicPlayer = new SoundPlayer(Properties.Resources.StartingMusic);
            MusicPlayer.Play();

            //Modify button design to remove background
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.BackColor = Color.Transparent;
            this.btnStart.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnStart.FlatAppearance.BorderSize = 0;

            btnInstruction.FlatStyle = FlatStyle.Flat;
            btnInstruction.BackColor = Color.Transparent;
            this.btnInstruction.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnInstruction.FlatAppearance.BorderSize = 0;
            
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.BackColor = Color.Transparent;
            this.btnExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit.FlatAppearance.BorderSize = 0;
        }

        // Load the game, turn off music
        private void LoadGame(object sender, EventArgs e)
        {
            GameScreen GameWindow = new GameScreen();
            GameWindow.Show();
            MusicPlayer.Stop();
        }

        // Load the instruction screen
        private void LoadInstructions(object sender, EventArgs e)
        {
            InstructionScreen InstructionWindow = new InstructionScreen();
            InstructionWindow.Show();
        }

        // Leave Game
        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
