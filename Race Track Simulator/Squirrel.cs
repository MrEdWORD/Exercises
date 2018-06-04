using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Race_Track_Simulator
{
    //Squirrel object will control things on the form by updating the location of the PictureBox.
    class Squirrel
    {
        public int StartingPosition; //Where the squirrel's PictureBox starts
        public int RacetrackLength;
        public PictureBox MyPictureBox = null; //Reference to the picturebox control on the form
        public int Location; //Location of the squirrel on race track
        public Random Randomizer; //An instance of Random

        public bool Run()
        {
            //Move forward either 1, 2, 3, or 4 spaces at random
            int distance = Randomizer.Next(5);
            Location += distance;

            //Update the position of my PictureBox on the form
            Point p = MyPictureBox.Location; //Get current location of picture
            p.X += distance; //Add the randomly generated distance to X coordinate
            MyPictureBox.Location = p; //Update the picture box location on the form

            //Return true if I won the race
            if (Location >= RacetrackLength)
            {
                return true;
            }
            return false;
        }

        public void TakeStartingPosition()
        {
            //Reset location to the start line
            Point p = MyPictureBox.Location;
            p.X = StartingPosition;
            MyPictureBox.Location = p;
            Location = StartingPosition;
        }
    }
}
