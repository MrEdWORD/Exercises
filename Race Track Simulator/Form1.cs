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
            gambler[1] = new Gambler() { Name = "Megan", MyBet = null, Cash = 25, MyLabel = lblBetsGambler2, MyRadioButton = rdoGambler2 };
            gambler[2] = new Gambler() { Name = "Kat", MyBet = null, Cash = 300, MyLabel = lblBetsGambler3, MyRadioButton = rdoGambler3 };
            gambler[0].UpdateLabels();
            gambler[1].UpdateLabels();
            gambler[2].UpdateLabels();

            //TODO Random isn't working. Squirrels are generating the same 'random' numbers.
            //Note: the specific values below for StartingPosition (19) and RacetrackLength (-91) provide a more visually appealing location of the squirrel image
            squirrels[0] = new Squirrel() { StartingPosition = 19, RacetrackLength = (pictureBoxRaceTrack.Width - 91), MyPictureBox = pictureBoxRacer1, Randomizer = randomizer };
            squirrels[1] = new Squirrel() { StartingPosition = 19, RacetrackLength = (pictureBoxRaceTrack.Width - 91), MyPictureBox = pictureBoxRacer2, Randomizer = randomizer };
            squirrels[2] = new Squirrel() { StartingPosition = 19, RacetrackLength = (pictureBoxRaceTrack.Width - 91), MyPictureBox = pictureBoxRacer3, Randomizer = randomizer };
            squirrels[3] = new Squirrel() { StartingPosition = 19, RacetrackLength = (pictureBoxRaceTrack.Width - 91), MyPictureBox = pictureBoxRacer4, Randomizer = randomizer };
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            //Reset location before proceeding with race
            foreach (Squirrel s in squirrels)
            {
                s.TakeStartingPosition();
            }

            bool isWinner = false;

            while (!isWinner)
            {
                for (int i = 0; i < squirrels.Length; i++)
                {
                    Application.DoEvents();
                    bool winningRun = squirrels[i].Run();
                    if (winningRun)
                    {
                        isWinner = true;
                        MessageBox.Show("We have a winner - squirrel #" + i++ + "!");
                    }
                }
            }
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            //TODO need messaging when player tries to make a bet with not enough cash

            //If gambler has already bet, disable betting button but enable clear bet button
            bool betSucceeded;

            if (rdoGambler1.Checked)
            {
                //Place bet for gamblers[0]
                betSucceeded = gambler[0].PlaceBet((int)numUpDownBet.Value, (int)numUpDownSquirrel.Value);
                if (betSucceeded)
                {
                    btnBet.Enabled = false;
                    btnClearBet.Enabled = true;
                }
            }
            else if (rdoGambler2.Checked)
            {
                //Place bet for gamblers[1]
                betSucceeded = gambler[1].PlaceBet((int)numUpDownBet.Value, (int)numUpDownSquirrel.Value);
                if (betSucceeded)
                {
                    btnBet.Enabled = false;
                    btnClearBet.Enabled = true;
                }
            }
            else if (rdoGambler3.Checked)
            {
                //Place bet for gamblers[2]
                betSucceeded = gambler[2].PlaceBet((int)numUpDownBet.Value, (int)numUpDownSquirrel.Value);
                if (betSucceeded)
                {
                    btnBet.Enabled = false;
                    btnClearBet.Enabled = true;
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

            //If player hasn't made a bet, show the bet button but hide the clear bet button
            if (gambler[0].MyBet == null)
            {
                btnBet.Enabled = true;
                btnClearBet.Enabled = false;
            }
            else
            {
                btnBet.Enabled = false;
                btnClearBet.Enabled = true;
            }


        }

        private void rdoGambler2_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectedGambler.Text = gambler[1].Name;

            //If player hasn't made a bet, show the bet button but hide the clear bet button
            if (gambler[1].MyBet == null)
            {
                btnBet.Enabled = true;
                btnClearBet.Enabled = false;
            }
            else
            {
                btnBet.Enabled = false;
                btnClearBet.Enabled = true;
            }
        }

        private void rdoGambler3_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectedGambler.Text = gambler[2].Name;

            //If player hasn't made a bet, show the bet button but hide the clear bet button
            if (gambler[2].MyBet == null)
            {
                btnBet.Enabled = true;
                btnClearBet.Enabled = false;
            }
            else
            {
                btnBet.Enabled = false;
                btnClearBet.Enabled = true;
            }
        }

        private void btnClearBet_Click(object sender, EventArgs e)
        {
            //Add Bet amount back to Gambler's cash
            //Clear the bet
            //Update the labels
            //Enable bet button
            //Disable clear bet button

            if (rdoGambler1.Checked)
            {
                gambler[0].Cash += gambler[0].MyBet.Amount;
                gambler[0].ClearBet();
                gambler[0].UpdateLabels();
                btnBet.Enabled = true;
                btnClearBet.Enabled = false;
            }
            else if (rdoGambler2.Checked)
            {
                gambler[1].Cash += gambler[1].MyBet.Amount;
                gambler[1].ClearBet();
                gambler[1].UpdateLabels();
                btnBet.Enabled = true;
                btnClearBet.Enabled = false;
            }
            else if (rdoGambler3.Checked)
            {
                gambler[2].Cash += gambler[2].MyBet.Amount;
                gambler[2].ClearBet();
                gambler[2].UpdateLabels();
                btnBet.Enabled = true;
                btnClearBet.Enabled = false;
            }
        }
    }
}
