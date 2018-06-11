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
    partial class Form1 : Form
    {
        Gambler[] gamblers = new Gambler[3];
        Squirrel[] squirrels = new Squirrel[4];
        Random randomizer = new Random(); //Ensures all of the Squirrel objects share a Random object to avoid an issue where all of the squirrels generate the same sequence of random numbers
        //TODO Add tests to project

        public Form1()
        {
            InitializeComponent();

            //Instantiate Gambler objects and update their labels on the form to shower user their cash/bet info
            gamblers[0] = new Gambler() { Name = "Drey", MyBet = null, Cash = 50, MyLabel = lblBetsGambler1, MyRadioButton = rdoGambler1 };
            gamblers[1] = new Gambler() { Name = "Megan", MyBet = null, Cash = 100, MyLabel = lblBetsGambler2, MyRadioButton = rdoGambler2 };
            gamblers[2] = new Gambler() { Name = "Kat", MyBet = null, Cash = 125, MyLabel = lblBetsGambler3, MyRadioButton = rdoGambler3 };

            //Instantiate Squirrel objects
            //Note: the specific values below for StartingPosition (19) and RacetrackLength (-91) provide a more visually appealing location of the squirrel image in the UI
            squirrels[0] = new Squirrel() { StartingPosition = 19, RacetrackLength = (pictureBoxRaceTrack.Width - 91), MyPictureBox = pictureBoxRacer1, Randomizer = randomizer };
            squirrels[1] = new Squirrel() { StartingPosition = 19, RacetrackLength = (pictureBoxRaceTrack.Width - 91), MyPictureBox = pictureBoxRacer2, Randomizer = randomizer };
            squirrels[2] = new Squirrel() { StartingPosition = 19, RacetrackLength = (pictureBoxRaceTrack.Width - 91), MyPictureBox = pictureBoxRacer3, Randomizer = randomizer };
            squirrels[3] = new Squirrel() { StartingPosition = 19, RacetrackLength = (pictureBoxRaceTrack.Width - 91), MyPictureBox = pictureBoxRacer4, Randomizer = randomizer };

            UpdateSquirrelAndGamblerUI();
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            StartRace();
            UpdateSquirrelAndGamblerUI();
        }

        private void StartRace()
        {
            //Race until one of the squirrels crosses the finish line

            bool thereIsAWinner = false;
            while (!thereIsAWinner)
            {
                btnRace.Enabled = false;

                for (int squirrel = 0; squirrel < squirrels.Length; squirrel++)
                {
                    Application.DoEvents(); //TODO DoEvents is evil. Replace with multithreading approach.
                    if (squirrels[squirrel].Run())
                    {
                        MessageBox.Show("We have a winner - squirrel #" + (squirrel + 1) + "!");
                        CollectRaceWinnings(squirrel);
                        thereIsAWinner = true;
                        btnRace.Enabled = true;
                        break;
                    }
                }
            }
        }

        private void CollectRaceWinnings(int squirrel)
        {
            //Collect earnings/loss from the gamblers based on their bets

            foreach (Gambler gambler in gamblers)
            {
                gambler.Collect(squirrel + 1);
            }
        }

        private void UpdateSquirrelAndGamblerUI()
        {
            //Resets squirrel image to front of race line and gambler's cash/bet information
            //TODO Opportunity to refactor code in Form.cs, Gambler.cs, Bet.cs, and Squirrel.cs that have UI update functionality

            lblMinBet.Text = String.Format("Minimum bet: ${0}", numUpDownBet.Minimum.ToString());

            foreach (Squirrel squirrel in squirrels)
            {
                squirrel.TakeStartingPosition();
            }

            foreach (Gambler gambler in gamblers)
            {
                gambler.ClearBet();
                gambler.UpdateLabels();
            }
        }

        private void Bet(Gambler gambler, int betAmount, int chosenSquirrel)
        {
            //Places bet if the gambler has enough cash available

            if (gambler.PlaceBet(betAmount, chosenSquirrel))
            {
                btnBet.Enabled = false;
                btnClearBet.Enabled = true;
            }
            else
            {
                btnBet.Enabled = true;
                btnClearBet.Enabled = false;
                MessageBox.Show(gambler.Name + " does not have enough cash to make that bet!");
            }
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            //Places bet for a given gambler and updates the UI appropriately
            
            int betAmount = (int)numUpDownBet.Value;
            int chosenSquirrel = (int)numUpDownSquirrel.Value;

            if (rdoGambler1.Checked)
            {
                Bet(gamblers[0], betAmount, chosenSquirrel);
                UpdateRaceButton();
            }

            else if (rdoGambler2.Checked)
            {
                Bet(gamblers[1], betAmount, chosenSquirrel);
                UpdateRaceButton();
            }

            else if (rdoGambler3.Checked)
            {
                Bet(gamblers[2], betAmount, chosenSquirrel);
                UpdateRaceButton();
            }
        }

        private void UpdateRaceButton()
        {
            //Enable the race button only if all players have placed a bet

            if (gamblers[0].MyBet != null & gamblers[1].MyBet != null & gamblers[2].MyBet != null)
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
            UpdateBetUI(gamblers[0]);
            UpdateRaceButton();
        }

        private void rdoGambler2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBetUI(gamblers[1]);
            UpdateRaceButton();
        }

        private void rdoGambler3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBetUI(gamblers[2]);
            UpdateRaceButton();
        }

        private void UpdateBetUI(Gambler gambler)
        {
            //Render the Gambler's name and show or hide the Bet and Clear Bet buttons

            lblSelectedGambler.Text = gambler.Name;
            if (gambler.MyBet == null)
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
            //Clears a gambler's bet by giving back the cash, clearing the bet object, and updating UI

            if (rdoGambler1.Checked)
            {
                gamblers[0].ClearBet();
                gamblers[0].UpdateLabels();
                btnBet.Enabled = true;
                btnClearBet.Enabled = false;
            }
            else if (rdoGambler2.Checked)
            {
                gamblers[1].ClearBet();
                gamblers[1].UpdateLabels();
                btnBet.Enabled = true;
                btnClearBet.Enabled = false;
            }
            else if (rdoGambler3.Checked)
            {
                gamblers[2].ClearBet();
                gamblers[2].UpdateLabels();
                btnBet.Enabled = true;
                btnClearBet.Enabled = false;
            }

            UpdateRaceButton();
        }
    }
}
