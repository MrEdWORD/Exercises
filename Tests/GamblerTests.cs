using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Race_Track_Simulator;
using System.Windows.Forms;


namespace Tests
{
    [TestClass]
    public class GamblerTests
    {
        //MethodUnderTest_Scenario_ExpectedResult
        [TestMethod]
        public void UpdateLabels_GamblerHasCashAndDoesntPlaceBet()
        {
            //Arrange
            string gamblersName = "Adam";
            Bet gamblersBet = null;
            int gamblersCash = 50;
            RadioButton gamblersRadioButton = new RadioButton();
            Label gamblersLabel = new Label();

            Gambler bettor = new Gambler()
            {
                Name = gamblersName,
                MyBet = gamblersBet,
                Cash = gamblersCash,
                MyRadioButton = gamblersRadioButton,
                MyLabel = gamblersLabel
            };

            string expectedRdoText = "Adam has 50 bucks";
            string expectedLblText = "Adam hasn't placed a bet";


            //Act
            bettor.UpdateLabels();
            string actualRdoText = bettor.MyRadioButton.Text;
            string actualLblText = bettor.MyLabel.Text;

            //Assert
            Assert.AreEqual(expectedRdoText, actualRdoText);
            Assert.AreEqual(expectedLblText, actualLblText);
        }

        [TestMethod]
        public void UpdateLabels_GamblerHasCashAndPlacesBet()
        {
            //Arrange
            string gamblersName = "Annie";
            Bet gamblersBet = null;
            int gamblersCash = 100;
            RadioButton gamblersRadioButton = new RadioButton();
            Label gamblersLabel = new Label();

            Gambler bettor = new Gambler()
            {
                Name = gamblersName,
                MyBet = gamblersBet,
                Cash = gamblersCash,
                MyRadioButton = gamblersRadioButton,
                MyLabel = gamblersLabel
            };

            int gamblerBetAmount = 50;
            int squirrel = 1;
            bettor.MyBet = new Bet()
            {
                Amount = gamblerBetAmount,
                Squirrel = squirrel,
                Bettor = bettor
            };

            string expectedRdoText = "Annie has 100 bucks";
            string expectedLblText = "Annie bets 50 bucks on squirrel #1";

            //Act
            bettor.UpdateLabels();
            string actualRdoText = bettor.MyRadioButton.Text;
            string actualLblText = bettor.MyLabel.Text;

            //Assert
            Assert.AreEqual(expectedRdoText, actualRdoText);
            Assert.AreEqual(expectedLblText, actualLblText);
        }

        [TestMethod]
        public void ClearBet_GamblersBetIsCleared()
        {
            //Arrange
            string gamblersName = "Michelle";
            Bet gamblersBet = null;
            int gamblersCash = 25;

            Gambler bettor = new Gambler()
            {
                Name = gamblersName,
                MyBet = gamblersBet,
                Cash = gamblersCash,
            };

            int gamblerBetAmount = 25;
            int squirrel = 1;
            bettor.MyBet = new Bet() { Amount = gamblerBetAmount, Squirrel = squirrel, Bettor = bettor };

            Bet expectedBet = null;

            //Act
            bettor.ClearBet();
            Bet actualBet = bettor.MyBet;

            //Assert
            Assert.AreEqual(expectedBet, actualBet);
        }

        [TestMethod]
        public void PlaceBet_BetIsLessThanGamblersCash_ReturnsTrue()
        {
            //Arrange
            string gamblersName = "Bob";
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

            //Act
            bool betIsLessThanGamblersCash = bettor.PlaceBet(20, 1);

            //Assert
            Assert.IsTrue(betIsLessThanGamblersCash);
        }

        [TestMethod]
        public void PlaceBet_BetIsEqualToGamblersCash_ReturnsTrue()
        {
            //Arrange
            string gamblersName = "Primus";
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

            //Act
            bool betIsEqualToGamblersCash = bettor.PlaceBet(25, 1);

            //Assert
            Assert.IsTrue(betIsEqualToGamblersCash);
        }

        [TestMethod]
        public void PlaceBet_BetIsLargerThanGamblersCash_ReturnsFalse()
        {
            //Arrange
            string gamblersName = "Jamie";
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

            //Act
            bool betIsLargerThanGamblersCash = bettor.PlaceBet(30, 1);

            //Assert
            Assert.IsFalse(betIsLargerThanGamblersCash);
        }

        [TestMethod]
        public void CollectBet_WhenGamblerWins()
        {
            //Arrange
            string gamblersName = "Cloud";
            int gamblersCash = 25;
            Bet gamblersBet = null;
            RadioButton gamblersRadioButton = new RadioButton();
            Label gamblersLabel = new Label();

            Gambler bettor = new Gambler()
            {
                Name = gamblersName,
                Cash = gamblersCash,
                MyBet = gamblersBet,
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
        public void CollectBet_WhenGamblerLoses()
        {
            //Arrange
            string gamblersName = "Cloud";
            int gamblersCash = 25;
            Bet gamblersBet = null;
            RadioButton gamblersRadioButton = new RadioButton();
            Label gamblersLabel = new Label();

            Gambler bettor = new Gambler()
            {
                Name = gamblersName,
                Cash = gamblersCash,
                MyBet = gamblersBet,
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
