using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race_Track_Simulator
{
    class Gambler
    {
        public string Name;
        public Bet MyBet; //An instance of Bet() that has a gambler's bet
        public int Cash;

        //These fields are the gambler's GUI controls on the form
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + "has " + Cash + " bucks";
            if (MyBet == null)
            {
                MyLabel.Text = Name + " hasn't placed a bet";
            }            
        }

        public void ClearBet()
        {
            //Reset my bet so it's zero
        }

        public bool PlaceBet(int amount, int squirrel)
        {
            //Place a new bet and store it in MyBet field
            MyBet = new Bet() { Amount = amount, Squirrel = squirrel, Bettor = this };

            //Return true if the gambler had enough money to bet
            if (MyBet.Amount <= Cash)
            {
                MyLabel.Text = Name + " bets " + amount + "bucks on squirrel# " + squirrel;
                return true;
            }
            return false;
        }

        public void Collect(int winner)
        {
            //Ask my bet to pay out -- use the Bet object
        }
    }
}
