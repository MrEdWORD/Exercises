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
        public string Name; //The gambler's name
        public Bet MyBet; //An instance of Bet() that has a gambler's bet
        public int Cash; //How much cash the gambler has

        //These fields are the gambler's GUI controls on the form
        public RadioButton MyRadioButton; //My RadioButton
        public Label MyLabel; //My Label -- we will set this to reference one of the on the form, which will allow us to change the label's text

        public void UpdateLabels()
        {
            //Set my label to my bet's description, and the label on my
            //radio button to show my cash ("Joe has 43 bucks")
        }

        public void ClearBet()
        {
            //Reset my bet so it's zero
        }

        public bool PlaceBet(int Amount, int Squirrel)
        {
            //Place a new bet and store it in my bet field
            //Return true if the gambler had enough money to bet
        }

        public void Collect(int Winner)
        {
            //Ask my bet to pay out -- use the Bet object
        }
    }
}
