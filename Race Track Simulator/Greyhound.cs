using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race_Track_Simulator
{
    //These objects will control things on the form - updates the location of the PictureBox.
    class Greyhound
    {
        public int StartingPosition; //Where my PictureBox starts
        public int RacetrackLength; //How long the racetrack is
        public PictureBox MyPictureBox = null; //My PictureBox object -- this FIELD lets us REFERENCE the PictureBox control on the form
        public int Location = 0; //My Location on the racetrack
        public Random Randomizer; //An instance of Random

        public bool Run()
        {
            //Move forward either 1, 2, 3, or 4 spaces at random
            //Update the position of my PictureBox ont he form
            //Return true if I won the race
        }

        public void TakeStartingPosition()
        {
            //Reset my location to the start line
        }
    }
}
