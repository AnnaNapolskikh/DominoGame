using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoGame
{
    static class Turn
    {
        static public void WhoIsFirst(Players you, Players pc)
        {

            if (you.isDouble == true && pc.isDouble == true)
            {
                if (you.minValue < pc.minValue)
                {
                    you.who = 2;
                    pc.who = 0;
                }
                else
                {
                    you.who = 1;
                    pc.who = 3;
                }
            }
            else if (you.isDouble == true || pc.isDouble == true)
            {
                if (you.isDouble == true)
                {
                    you.who = 2;
                    pc.who = 0;
                }
                else
                {
                    you.who = 1;
                    pc.who = 3;
                }
            }
            else
            {
                if (you.minValue < pc.minValue)
                {
                    you.who = 2;
                    pc.who = 0;
                }
                else if (you.minValue > pc.minValue)
                {
                    you.who = 1;
                    pc.who = 3;
                }
                else if (you.minValue == pc.minValue)
                {
                    while (you.minValue == pc.minValue)
                    {
                        you.minValue = Players.FindMin(you);
                        pc.minValue = Players.FindMin(pc);
                    }

                    if (you.minValue < pc.minValue)
                    {
                        you.who = 2;
                        pc.who = 0;
                    }
                    else
                    {
                        you.who = 1;
                        pc.who = 3;
                    }
                }
            }
        }
    }
}
