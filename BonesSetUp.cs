using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoGame
{
    internal class BonesSetUp
    {
        public static List<string> BaseDeck = new List<string>(28)
                    {"[0:0]", "[0:1]", "[0:2]", "[0:3]", "[0:4]", "[0:5]", "[0:6]",
                    "[1:1]", "[1:2]", "[1:3]", "[1:4]", "[1:5]", "[1:6]",
                    "[2:2]", "[2:3]", "[2:4]", "[2:5]", "[2:6]",
                    "[3:3]", "[3:4]", "[3:5]", "[3:6]",
                    "[4:4]", "[4:5]", "[4:6]",
                    "[5:5]", "[5:6]",
                    "[6:6]"};


        static Random rnd = new Random(DateTime.Now.Millisecond);
        public static Stack<string> Shuffle()
        {
            List<string> temp = BaseDeck;
            Stack<string> ShuffledDeck = new Stack<string>(28);
            for (int i = 27; i >= 0; i--)
            {
                int random = rnd.Next(0, i + 1);
                ShuffledDeck.Push(temp[random]);
                temp.RemoveAt(random);
            }
            return ShuffledDeck;
        }
    }
}
