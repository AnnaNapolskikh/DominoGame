using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoGame
{
    class Players
    {
        public int minValue = 12;                // Максимальное значение костяшки в руке
        public bool isDouble = false;                 // Наличие дубля (кроме пустой кости)
        public List<string> Hand = new List<string>();  // Рука игрока 
        public int who = 0;
        public int turns = 0;
        public Players(Stack<string> pile)
        {
            for (int i = 0; i < 7; i++)
            {
                Hand.Add(pile.Pop());

                string[] values = Hand[i].Split(new char[] { '[', ':', ']' }, StringSplitOptions.RemoveEmptyEntries);    // Массив со значениями хвоста и головы костяшки   
                if (values[0] == values[1] && values[0] != "0")
                {
                    isDouble = true;
                }
            }
            FindMin();
        }

        void FindMin()      // Находит максимальное значение среди костей 
        {
            if (isDouble == true)
            {
                for (int i = 0; i < Hand.Count; i++)
                {
                    string[] values = Hand[i].Split(new char[] { '[', ':', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values[0] == values[1])
                    {
                        if (byte.Parse(values[0]) + byte.Parse(values[1]) < minValue)
                        {
                            minValue = byte.Parse(values[0]) + byte.Parse(values[1]);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Hand.Count; i++)
                {
                    string[] values = Hand[i].Split(new char[] { '[', ':', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    if (byte.Parse(values[0]) + byte.Parse(values[1]) < minValue)
                    {
                        minValue = byte.Parse(values[0]) + byte.Parse(values[1]);
                    }
                }
            }
        }

        public static int FindMin(Players you)       // Статическая перегрузка метода, используемая при равных макс. значениях у игроков                             
        {
            int _minValue = 0;

            for (int i = 0; i < you.Hand.Count; i++)
            {
                string[] values = you.Hand[i].Split(new char[] { '[', ':', ']' }, StringSplitOptions.RemoveEmptyEntries);

                if (byte.Parse(values[0]) + byte.Parse(values[1]) != you.minValue)
                {
                    if (byte.Parse(values[0]) + byte.Parse(values[1]) < _minValue)
                    {
                        _minValue = byte.Parse(values[0]) + byte.Parse(values[1]);
                    }
                }
            }

            return _minValue;
        }

    }
}
