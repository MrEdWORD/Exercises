using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race_Track_Simulator
{
    public partial class Form1 : Form
    {
        Gambler[] gambler = new Gambler[3];
        Squirrel[] squirrels = new Squirrel[4];
        Random randomizer = new Random(); //Ensures all of the Squirrel objects share a Random object to avoid an issue where all of the squirrels generate the same sequence of random numbers

        public Form1()
        {
            InitializeComponent();

            gambler[0] = new Gambler() { Name = "Drey", MyBet = null, Cash = 10, MyLabel = lblBetsGambler1, MyRadioButton = rdoGambler1 };
            gambler[1] = new Gambler() { Name = "Megan", MyBet = null, Cash = 20, MyLabel = lblBetsGambler2, MyRadioButton = rdoGambler2 };
            gambler[2] = new Gambler() { Name = "Kat", MyBet = null, Cash = 30, MyLabel = lblBetsGambler3, MyRadioButton = rdoGambler3 };
            gambler[0].UpdateLabels();
            gambler[1].UpdateLabels();
            gambler[2].UpdateLabels();

            squirrels[0] = new Squirrel() { StartingPosition = 0, RacetrackLength = pictureBoxRaceTrack.Width, MyPictureBox = pictureBoxRacer1, Randomizer = randomizer };
            squirrels[1] = new Squirrel() { StartingPosition = 0, RacetrackLength = pictureBoxRaceTrack.Width, MyPictureBox = pictureBoxRacer2, Randomizer = randomizer };
            squirrels[2] = new Squirrel() { StartingPosition = 0, RacetrackLength = pictureBoxRaceTrack.Width, MyPictureBox = pictureBoxRacer3, Randomizer = randomizer };
            squirrels[3] = new Squirrel() { StartingPosition = 0, RacetrackLength = pictureBoxRaceTrack.Width, MyPictureBox = pictureBoxRacer4, Randomizer = randomizer };
        }

        private void btnRace_Click(object sender, EventArgs e)
        {

        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            //If gambler has already bet, disable button
            bool betSucceeded;

            if (rdoGambler1.Checked)
            {
                //Place bet for gamblers[0]
                betSucceeded = gambler[0].PlaceBet((int)numUpDownBet.Value, (int)numUpDownSquirrel.Value);
                if (betSucceeded)
                {
                    btnBet.Enabled = false;
                }
            }
            else if (rdoGambler2.Checked)
            {
                //Place bet for gamblers[1]
                betSucceeded = gambler[1].PlaceBet((int)numUpDownBet.Value, (int)numUpDownSquirrel.Value);
                if (betSucceeded)
                {
                    btnBet.Enabled = false;
                }
            }
            else if (rdoGambler3.Checked)
            {
                //Place bet for gamblers[2]
                betSucceeded = gambler[2].PlaceBet((int)numUpDownBet.Value, (int)numUpDownSquirrel.Value);
                if (betSucceeded)
                {
                    btnBet.Enabled = false;
                }
            }

            //If all gamblers have bet, enable race button
            if (gambler[0].MyBet != null & gambler[1].MyBet != null & gambler[2].MyBet != null)
            {
                btnRace.Enabled = true;
            }
            else
            {
                btnRace.Enabled = false;
            }
            
        }

        private void rdoGambler1_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectedGambler.Text = gambler[0].Name;

            //Disable button if gambler hasn't placed bet
            if (gambler[0].MyBet == null)
            {
                btnBet.Enabled = true;
            }
            else
            {
                btnBet.Enabled = false;
            }


        }

        private void rdoGambler2_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectedGambler.Text = gambler[1].Name;

            //Disable button if gambler hasn't placed bet
            if (gambler[1].MyBet == null)
            {
                btnBet.Enabled = true;
            }
            else
            {
                btnBet.Enabled = false;
            }
        }

        private void rdoGambler3_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectedGambler.Text = gambler[2].Name;

            //Disable button if gambler hasn't placed bet
            if (gambler[2].MyBet == null)
            {
                btnBet.Enabled = true;
            }
            else
            {
                btnBet.Enabled = false;
            }
        }
    }
}
