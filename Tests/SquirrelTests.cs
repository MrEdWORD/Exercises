using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Race_Track_Simulator;

namespace Tests
{
    [TestClass]
    public class SquirrelTests
    {
        [TestMethod]
        public void Run_SquirrelWinsRace_ReturnsTrue()
        {
            //Arrange
            PictureBox myPictureBox = new PictureBox();
            Random randomizer = new Random();
            Squirrel[] squirrels = new Squirrel[4];
            squirrels[0] = new Squirrel() { Location = 0, RacetrackLength = 100, MyPictureBox = myPictureBox, Randomizer = randomizer };
            squirrels[1] = new Squirrel() { Location = 0, RacetrackLength = 100, MyPictureBox = myPictureBox, Randomizer = randomizer };
            squirrels[2] = new Squirrel() { Location = 0, RacetrackLength = 100, MyPictureBox = myPictureBox, Randomizer = randomizer };
            squirrels[3] = new Squirrel() { Location = 90, RacetrackLength = 100, MyPictureBox = myPictureBox, Randomizer = randomizer };
            /* TODO Get help on figuring out how to get form objects (e.g. picture box) that are
             * created at run-time in a unit test. For now, set those items to an arbitrary number */

            int expectedWinner = 3;

            //Act
            int actualWinner = 0;
            bool thereIsAWinner = false;
            while (!thereIsAWinner)
            {
                for (int squirrel = 0; squirrel < squirrels.Length; squirrel++)
                {
                    if (squirrels[squirrel].Run())
                    {
                        thereIsAWinner = true;
                        actualWinner = squirrel;
                        break;
                    }
                }
            }

            //Assert
            Assert.IsTrue(thereIsAWinner);
            Assert.AreEqual(expectedWinner, actualWinner);
        }

        [TestMethod]
        public void Run_SquirrelLosesRace_ReturnsFalse()
        {
            /* TODO Get feedback on this test. There's probably a better way to test this
             * besides just doing a single run, which will always return false on the first run
             * because the max distance a squirrel can randomly travel is 4 and they need to travel
             * a distance of 100 in this test to win.
             * */

            //Arrange
            PictureBox myPictureBox = new PictureBox();
            Random randomizer = new Random();
            Squirrel squirrel = new Squirrel { Location = 0, RacetrackLength = 100, MyPictureBox = myPictureBox, Randomizer = randomizer };

            //Act
            bool thereIsAWinner = squirrel.Run();

            //Assert
            Assert.IsFalse(thereIsAWinner);
        }

        [TestMethod]
        public void TakeStartingPosition()
        {
            //Arrange
            PictureBox myPictureBox = new PictureBox();
            Random randomizer = new Random();
            Squirrel squirrel = new Squirrel()
            {
                StartingPosition = 90,
                RacetrackLength = 100,
                MyPictureBox = myPictureBox,
                Randomizer = randomizer
            };

            myPictureBox.Location = new Point(50, 0); //Set the location to an arbitrary coordinate
            Point expectedLocation = new Point(90, 0);

            //Act
            squirrel.TakeStartingPosition();
            Point actualLocation = squirrel.MyPictureBox.Location;

            //Assert
            Assert.AreEqual(expectedLocation.X, actualLocation.X);
        }

    }
}
