using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_Track_Simulator
{
    class Bet
    {
        public int Amount; //The amount of cash that was bet
        public int Squirrel; //The number of the squirrel the bet is on
        public Gambler Bettor; //The guy who placed the bet

        public string GetDescription()
        {
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
