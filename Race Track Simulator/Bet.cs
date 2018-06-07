using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_Track_Simulator
{
    class Bet
    {
        public int Amount;
        public int Squirrel;
        public Gambler Bettor;

        public string GetDescription()
        {
            //Updates the bet UI to display what a gambler has/hasn't bet

            if (Amount != 0)
            {
                return Bettor.Name + " bets " + Amount + " bucks on squirrel #" + Squirrel;
            }
            else
            {
                return Bettor.Name + " hasn't placed a bet";
            }
        }

        public int PayOut(int winner)
        {
            //Pays or collects the bet amount that a gambler placed

            if (winner == Squirrel)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }
    }
}
