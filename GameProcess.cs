using DominoGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoGame
{
    class GameProcess
    {
        int value_left = 0;             // Текущее левое доступное значение 
        int value_right = 0;            // Текущая правое доступное значение
        char side;                      // Сторона, в которую ставится кость
        byte vertPosition_left = 0;     // Определяет четную (0)/нечетную (1) позицию по вертикали (движение против часовой стрелки)
        byte vertPosition_right = 0;    // Определяет четную (0)/нечетную (1) позицию по вертикали (движение по часовой стрелке) 

        public void YourFirstMove(Players you, string domino, BoardSetUp field, Stack<string> pile)
        {
            string[] values = domino.Split(new char[] { '[', ':', ']' }, StringSplitOptions.RemoveEmptyEntries);// Хранение первого и второго значения доминошки
            value_left = int.Parse(values[0]);
            value_right = int.Parse(values[1]);
            field.SetDomino(domino);
            you.Hand.Remove(domino);            
        }
        public void EnemyFirstMove(Players pc, BoardSetUp field)
        {   
            Random rnd = new Random();
            int random = rnd.Next(0, pc.Hand.Count);
            string[] values = pc.Hand[random].Split(new char[] { '[', ':', ']' }, StringSplitOptions.RemoveEmptyEntries);
            value_left = int.Parse(values[0]);
            value_right = int.Parse(values[1]);
            if (pc.Hand[random]=="[0:0]") { 
                EnemyFirstMove(pc, field);
                return; }
            field.SetDomino(pc.Hand[random]);
            pc.Hand.RemoveAt(random);            
        }
        public bool CheckAvailability(List<string> hand)
        {
            bool isAvailable = false;

            if (hand.Count > 0)
            {
                for (int i = hand.Count - 1; i >= 0 && isAvailable == false; i--)
                {
                    string[] values = hand[i].Split(new char[] { '[', ':', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    if (int.Parse(values[0]) == value_left || int.Parse(values[0]) == value_right || int.Parse(values[1]) == value_left || int.Parse(values[1]) == value_right)
                    {
                        isAvailable = true;
                    }
                }
            }

            return isAvailable;
        }
        public int CheckHands(Players player1, Players player2, Stack<string> pile)
        {
            int i = 0;
            if (player1.Hand.Count == 0 || player2.Hand.Count == 0 )    // Конец игры
            {
                if (player1.Hand.Count == 0 && player1.who == 1)
                {
                    MessageBox.Show("You win");
                }
                else
                {
                    MessageBox.Show("PC wins");     

                }    
                i = 1;
                return i;
            }
            if ((!CheckAvailability(player1.Hand) && !CheckAvailability(player2.Hand) && pile.Count() == 0))
            {
                MessageBox.Show("Draw");
                i = 1;
                return i; 
            }          
            return i;
        }
        public bool CheckApprop(string domino) // Подходит ли выбранная костяшка
        {
            bool isAppropriate = false;

            string[] values = domino.Split(new char[] { '[', ':', ']' }, StringSplitOptions.RemoveEmptyEntries);
            if (int.Parse(values[0]) == value_left || int.Parse(values[0]) == value_right || int.Parse(values[1]) == value_left || int.Parse(values[1]) == value_right)
            {
                isAppropriate = true;
            }

            return isAppropriate;
        }
        public void ChangeValues(string domino, BoardSetUp field)
        {

            string[] values = domino.Split(new char[] { '[', ':', ']' }, StringSplitOptions.RemoveEmptyEntries);     // Хранение первого и второго значения доминошки

            // Если левый элемент кости равен текущей левой позиции
            if (int.Parse(values[0]) == value_left)
            {
                // Движение по верхней горизонтали
                if (field.horiz_left < 4)
                {
                    value_left = int.Parse(values[1]);
                    side = 'L';
                    domino = FlipDomino(domino);   
                    field.SetDomino(domino, side);
                }
                // Движение по вертикали
                else if ((field.horiz_left == 4 && field.vertic_left < 7) || field.horiz_left == 13)
                {
                    if (vertPosition_left == 0)     // позиция четная
                    {
                        value_left = int.Parse(values[1]);
                        side = 'L';
                        field.SetDomino(domino, side);
                        vertPosition_left++;
                    }
                    else     // позиция нечетная
                    {
                        value_left = int.Parse(values[1]);
                        side = 'L';
                        domino = FlipDomino(domino);   
                        field.SetDomino(domino, side);
                        vertPosition_left--;
                    }
                }
                // Движение по нижней горизонтали
                else if (field.vertic_left == 7 && field.horiz_left < 13)
                {
                    value_left = int.Parse(values[1]);
                    side = 'L';

                    field.SetDomino(domino, side);
                }
            }
            // Если левый элемент кости равен текущей правой позиции
            else if (int.Parse(values[0]) == value_right)
            {
                // Движение по верхней горизонтали
                if (field.horiz_right < 5)
                {
                    value_right = int.Parse(values[1]);
                    side = 'R';
                    field.SetDomino(domino, side);
                }
                // Движение по вертикали
                else if ((field.horiz_right == 5 && field.vertic_right < 7) || field.horiz_right == -4)
                {
                    if (vertPosition_right == 0)     // позиция четная
                    {
                        value_right = int.Parse(values[1]);
                        side = 'R';
                        domino = FlipDomino(domino);        
                        field.SetDomino(domino, side);
                        vertPosition_right++;
                    }
                    else     // позиция нечетная
                    {
                        value_right = int.Parse(values[1]);
                        side = 'R';
                        field.SetDomino(domino, side);
                        vertPosition_right--;
                    }
                }
                // Движение по нижней горизонтали
                else if (field.vertic_right == 7 && field.horiz_right > -4)
                {
                    value_right = int.Parse(values[1]);
                    side = 'R';
                    domino = FlipDomino(domino);        
                    field.SetDomino(domino, side);
                }
            }
            // Если правый элемент кости равен текущей левой позиции
            else if (int.Parse(values[1]) == value_left)
            {
                // Движение по верхней горизонтали
                if (field.horiz_left < 4)
                {
                    value_left = int.Parse(values[0]);
                    side = 'L';
                    field.SetDomino(domino, side);
                }
                //Движение по вертикали
                else if ((field.horiz_left == 4 && field.vertic_left < 7) || field.horiz_left == 13)
                {
                    if (vertPosition_left == 0)     // позиция четная
                    {
                        value_left = int.Parse(values[0]);
                        side = 'L';
                        domino = FlipDomino(domino);        
                        field.SetDomino(domino, side);
                        vertPosition_left++;
                    }
                    else     // позиция нечетная
                    {
                        value_left = int.Parse(values[0]);
                        side = 'L';
                        field.SetDomino(domino, side);
                        vertPosition_left--;
                    }
                }
                // Движение по нижней горизонтали
                else if (field.vertic_left == 7 && field.horiz_left < 13)
                {
                    value_left = int.Parse(values[0]);
                    side = 'L';
                    domino = FlipDomino(domino);       
                    field.SetDomino(domino, side);
                }
            }
            // Если правый элемент кости равен текущей правой позиции
            else if (int.Parse(values[1]) == value_right)
            {
                // Движение по верхней горизонтали
                if (field.horiz_right < 5)
                {
                    value_right = int.Parse(values[0]);
                    side = 'R';
                    domino = FlipDomino(domino);       
                    field.SetDomino(domino, side);
                }
                // Движение по вертикали
                else if ((field.horiz_right == 5 && field.vertic_right < 7) || field.horiz_right == -4)
                {
                    if (vertPosition_right == 0)     // позиция четная
                    {
                        value_right = int.Parse(values[0]);
                        side = 'R';

                        field.SetDomino(domino, side);

                        vertPosition_right++;
                    }
                    else     // позиция нечетная
                    {
                        value_right = int.Parse(values[0]);
                        side = 'R';
                        domino = FlipDomino(domino);        
                        field.SetDomino(domino, side);
                        vertPosition_right--;
                    }
                }
                // Движение по нижней горизонтали
                else if (field.vertic_right == 7 && field.horiz_right > -4)
                {
                    value_right = int.Parse(values[0]);
                    side = 'R';
                    field.SetDomino(domino, side);
                }
            }
        }
        string FlipDomino(string domino)            // Перевернуть костяшку
        {
            char[] domArr = new char[5];
            for (int i = 0; i < domino.Length; i++)
            {
                domArr[i] = domino[i];
            }
            char swap = domArr[3];
            domArr[3] = domArr[1];
            domArr[1] = swap;
            return new string(domArr);
        }

        public void Enemyturn(Players pc, Players you, BoardSetUp field, Stack<string> pile)
        {     
            if (CheckAvailability(pc.Hand))
            {
                for (int i = 0; i < pc.Hand.Count; i++)
                {
                    if (CheckApprop(pc.Hand[i]))
                    {
                        you.turns++;
                        ChangeValues(pc.Hand[i], field);
                            // Меняем текущие позиции и отправляем кость в метод установки на поле
                        pc.Hand.RemoveAt(i);                            // Удаляем используемую кость                           
                        return;
                    }
                }
            }
            else
            {
                if (pile.Count > 0)
                {
                    pc.Hand.Add(pile.Pop());
                    while (pile.Count > 0 && CheckApprop(pc.Hand[pc.Hand.Count - 1]) == false)
                    {
                        pc.Hand.Add(pile.Pop());                       
                    }
                    if (CheckApprop(pc.Hand[pc.Hand.Count - 1]))
                    {
                        Enemyturn(pc, you, field, pile);
                        you.turns++;
                    }
                } 
                
            }           
        }
    }
}
