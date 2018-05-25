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
            gamblers[0] = new Gambler() { Name = "Joe", MyBet = null, Cash = 50 };//, MyLabel = gamblerLabel1, MyRadioButton = gamblerRadioButton1};
            gamblers[1] = new Gambler() { Name = "Susan", MyBet = null, Cash = 75 };
            gamblers[2] = new Gambler() { Name = "Michael", MyBet = null, Cash = 100 };

            Greyhound[] greyhounds = new Greyhound[4];
        }
    }
}
