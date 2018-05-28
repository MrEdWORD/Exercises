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
        public Form1()
        {
            InitializeComponent();

            Gambler[] gamblers = new Gambler[3];
            gamblers[0] = new Gambler() { Name = "Megs", MyBet = null, Cash = 50, MyLabel = lblBetsGambler1, MyRadioButton = rdoGambler1 };
            gamblers[1] = new Gambler() { Name = "Drey", MyBet = null, Cash = 75, MyLabel = lblBetsGambler2, MyRadioButton = rdoGambler2 };
            gamblers[2] = new Gambler() { Name = "Kat", MyBet = null, Cash = 100, MyLabel = lblBetsGambler3, MyRadioButton = rdoGambler3 };

            Squirrel[] squirrels = new Squirrel[4];
            Random randomizer = new Random(); //Ensures all of the Squirrel objects share a Random object to avoid an issue where all of the squirrels generate the same sequence of random numbers
            squirrels[0] = new Squirrel() { StartingPosition = 0, RacetrackLength = pictureBoxRaceTrack.Width, MyPictureBox = pictureBoxRacer1, Randomizer = randomizer };
            squirrels[1] = new Squirrel() { StartingPosition = 0, RacetrackLength = pictureBoxRaceTrack.Width, MyPictureBox = pictureBoxRacer2, Randomizer = randomizer };
            squirrels[2] = new Squirrel() { StartingPosition = 0, RacetrackLength = pictureBoxRaceTrack.Width, MyPictureBox = pictureBoxRacer3, Randomizer = randomizer };
            squirrels[3] = new Squirrel() { StartingPosition = 0, RacetrackLength = pictureBoxRaceTrack.Width, MyPictureBox = pictureBoxRacer4, Randomizer = randomizer };


        }
    }
}
