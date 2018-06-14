using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Race_Track_Simulator;
using System.Windows.Forms;

namespace Tests
{
    [TestClass]
    public class BetTests
    {
        [TestMethod]
        public void GetDescription_WhenBetIsGreaterThanZero_Integration_ReturnsPlacedBetString()
        {
            /* TODO Get feedback on the best way to test a class that is only instantiated through another class.
             * A bet is created when a Gambler instantiates it. Does that mean I should test the Bet class
             * by first creating a Gambler object that calls the Bet method, or do I just test the methods
             * directly from the Bet class without any Gambler object? I'm assuming to test it like the way
             * it's implemented, which in this case means I should create a Gambler object first.
             * */

            //Arrange
            string gamblersName = "Gabby";
            int gamblersCash = 50;
            RadioButton gamblersRadioButton = new RadioButton();
            Label gamblersLabel = new Label();

            Gambler bettor = new Gambler()
            {
                Name = gamblersName,
                Cash = gamblersCash,
                MyRadioButton = gamblersRadioButton,
                MyLabel = gamblersLabel
            };

            string expectedDescription = "Gabby bets 20 bucks on squirrel #1";

            //Act
            bool betIsLessThanGamblersCash = bettor.PlaceBet(20, 1);
            string actualDescription = bettor.MyLabel.Text;

            //Assert
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [TestMethod]
        public void GetDescription_WhenBetIsEqualToZero_Integration_ReturnsNoPlacedBetString()
        {
            //Arrange
            string gamblersName = "G-Man";
            int gamblersCash = 50;
            RadioButton gamblersRadioButton = new RadioButton();
            Label gamblersLabel = new Label();

            Gambler bettor = new Gambler()
            {
                Name = gamblersName,
                Cash = gamblersCash,
                MyRadioButton = gamblersRadioButton,
                MyLabel = gamblersLabel
            };

            string expectedDescription = "G-Man hasn't placed a bet";

            //Act
            bool betIsLessThanGamblersCash = bettor.PlaceBet(0, 1);
            string actualDescription = bettor.MyLabel.Text;

            //Assert
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [TestMethod]
        public void Payout_WhenThereIsAWinner_Integration_ReturnsPositiveAmount()
        {
            /* TODO Get feedback on the best way to test a class that is only instantiated through another class.
             * Following the same assumption to test it like it's implemented (from Gambler), then this test
             * and the ReturnsNegativeAmount are copy/pastes of the GamblerTest\CollectBet tests.
            * */

            //Arrange
            string gamblersName = "Barney";
            int gamblersCash = 25;
            RadioButton gamblersRadioButton = new RadioButton();
            Label gamblersLabel = new Label();

            Gambler bettor = new Gambler()
            {
                Name = gamblersName,
                Cash = gamblersCash,
                MyRadioButton = gamblersRadioButton,
                MyLabel = gamblersLabel
            };

            int betAmount = 20;
            int chosenSquirrel = 1;
            bettor.MyBet = new Bet() { Amount = betAmount, Squirrel = chosenSquirrel, Bettor = bettor };

            int expectedCash = 45;

            //Act
            bettor.Collect(chosenSquirrel);
            int actualCash = bettor.Cash;

            //Assert
            Assert.AreEqual(expectedCash, actualCash);
        }

        [TestMethod]
        public void Payout_WhenThereIsAWinner_Functional_ReturnsPositiveAmount()
        {
            /* TODO Get feedback on the best way to test a class that is only instantiated through another class.
             * This test only relies on the Bet class.
            * */

            //Arrange
            Bet someBet = new Bet()
            {
                Amount = 50,
                Squirrel = 1,
            };

            int cash = 50;
            int winner = 1;
            int expectedPayOutAmount = 50;
            int expectedCash = 100;

            //Act
            int actualPayoutAmount = someBet.PayOut(winner);
            cash += actualPayoutAmount;

            //Assert
            Assert.AreEqual(expectedPayOutAmount, actualPayoutAmount);
            Assert.AreEqual(expectedCash, cash);
        }


        public void Payout_WhenThereIsNotAWinner_Integration_ReturnsNegativeAmount()
        {
            //Arrange
            string gamblersName = "Otis";
            int gamblersCash = 25;
            RadioButton gamblersRadioButton = new RadioButton();
            Label gamblersLabel = new Label();

            Gambler bettor = new Gambler()
            {
                Name = gamblersName,
                Cash = gamblersCash,
                MyRadioButton = gamblersRadioButton,
                MyLabel = gamblersLabel
            };

            int betAmount = 20;
            int chosenSquirrel = 1;
            bettor.MyBet = new Bet() { Amount = betAmount, Squirrel = chosenSquirrel, Bettor = bettor };

            int expectedCash = 5;

            //Act
            bettor.Collect(2);
            int actualCash = bettor.Cash;

            //Assert
            Assert.AreEqual(expectedCash, actualCash);
        }
    }
}
