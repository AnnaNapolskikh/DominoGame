using DominoGame;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DominoGame
{
    public partial class Board : Form
    {

        List<Button> buttonsYou = new List<Button>();
        List<Button> buttonsPC = new List<Button>();
        int btn_num =0;
        Stack<string> pile = BonesSetUp.Shuffle();
        BoardSetUp gamefield = new BoardSetUp();
        GameProcess newGame = new GameProcess();
        string yourname;
        public Board(string name)
        {
            yourname = name;
            InitializeComponent();
            Hands();
            field.BringToFront();

        }


        public void Hands()
        {
            bazar.Enabled = false;
            Players pc = new Players(pile); pc.who = 0;    // Создаем руку компьютера
            Players you = new Players(pile); you.who = 2;   // Создаем руку игрока
            Turn.WhoIsFirst(you, pc);
            CreateButtons(pc, you); 
            if (pc.who == 3) { 
                newGame.EnemyFirstMove(pc, gamefield);
                pc.who = 0;
                CreateButtons(pc, you);
                if (!newGame.CheckAvailability(you.Hand))
                {
                    bazar.Enabled = true;
                }              
            }
            CreateButtons(you, pc);   
            DisplayField();
            bazar.Click += (sender, EventArgs) => { TakeFromBazar(you, pc); };
        }


        private void ButtonOnClick(object sender, EventArgs eventArgs, Players you, Players pc)
        {
            if (you.who == 2)
            {
                if (((Button)sender).Text=="[0:0]"){
                    MessageBox.Show("You can't place this bone");
                    return; 
                }
                newGame.YourFirstMove(you,((Button)sender).Text, gamefield, pile);
                this.Controls.Remove(((Button)sender));
                DisplayField();
                EnemyMoves(pc, you);
                you.who = 1;
                you.turns++;
                return;
            }
            if (newGame.CheckApprop(((Button)sender).Text))
            {
                newGame.ChangeValues(((Button)sender).Text, gamefield);
                you.turns++;
                you.Hand.Remove(((Button)sender).Text);
                this.Controls.Remove(((Button)sender));
                EnemyMoves(pc, you);
                if (!newGame.CheckAvailability(you.Hand))
                {
                    bazar.Enabled = true;
                }
                else bazar.Enabled = false;
                if (pile.Count() == 0 && !newGame.CheckAvailability(you.Hand)) { 
                    while (!newGame.CheckAvailability(you.Hand) && newGame.CheckAvailability(pc.Hand)) {
                        EnemyMoves(pc,you);
                    }
                }
                return;
            }
            else MessageBox.Show("You can't place this bone");

        }
        private void bazar_Click(object sender, EventArgs e){}

        private void TakeFromBazar(Players you, Players pc)
        {
            if (pile.Count() > 0 && !newGame.CheckAvailability(you.Hand))
            {
                you.Hand.Add(pile.Pop());
                you.turns++;
                CreateButtons(you, pc);
            }
            if (newGame.CheckAvailability(you.Hand)) 
                bazar.Enabled = false;       
            if (pile.Count()==0 && !newGame.CheckAvailability(you.Hand))
            {
                bazar.Enabled = false;
                EnemyMoves(pc, you);
            }
        }
         internal void DisplayField()   // Отобразить игровое поле
        {
            field.Text = "";
            string[,] fieldArr = BoardSetUp.Field;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    field.Text += fieldArr[i, j] + "\t";
                }
                field.Text += "\r\n";
            }            
        }

        private void EnemyMoves(Players pc, Players you)
        {
            CreateButtons(you, pc);
            DisplayField();
            int temp = newGame.CheckHands(you, pc, pile);
            if (temp == 1)
            {
                EndGame(you.turns, temp);
                return;
            }
            if (!newGame.CheckAvailability(you.Hand) && pile.Count() != 0)
            {
                bazar.Enabled = true;
            }
            else bazar.Enabled = false;
            newGame.Enemyturn(pc, you, gamefield, pile);
            temp = newGame.CheckHands(you, pc, pile);
            CreateButtons(pc, you);
            DisplayField();            
            if (temp == 1)
            {                temp = 0;
                EndGame(you.turns, temp);

                return;
            }
            if (!newGame.CheckAvailability(you.Hand))
            {
                bazar.Enabled = true;
            }
            else bazar.Enabled = false;

        }
        private void CreateButtons(Players player, Players nextPl) {

            if (player.who == 1 || player.who == 2)
            { 
                RemoveButtonsYou(); 
            }
            else     
                RemoveButtonsPC();
            int left = 30;
            int top = 70;
            List<string> updatedHand = player.Hand;         
            for (int j = 0; j < updatedHand.Count(); j++)
            {   if (j == 7 || j == 14)
                {
                    left = 30;
                    top += 50;
                }
                   
                Button button = new Button();
                button.Left = left;
                button.Width = 75;
                button.Height =40;
                button.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.Click += (sender, EventArgs) => { ButtonOnClick(sender, EventArgs, player, nextPl); };
                left += button.Width + 10;
                button.Name = "btn" + btn_num;
                button.Text = updatedHand[j];
                button.BackColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.MouseOverBackColor = BackColor;
                button.FlatAppearance.BorderSize = 0;
                this.Controls.Add(button);
                
                if (player.who == 1 || player.who == 2  )
                {
                    button.Top = 603 + top - 70;
                    buttonsYou.Add(button);                
                }
                else
                {
                    //button.Text = "";
                    button.Enabled = false;
                    button.Top = top;
                    buttonsPC.Add(button);
                }               
                bazarC.Text = "" + pile.Count();
                btn_num++;
                
            }
        }
        private void RemoveButtonsYou()
        {
            foreach (Button button in buttonsYou)
            {
                this.Controls.Remove(button);
            }
        }
        private void RemoveButtonsPC()
        {
            foreach (Button button in buttonsPC)
            {
                this.Controls.Remove(button);
            }
        }
        private void EndGame(int turns, int temp)
        {
            this.Hide();
            BoardSetUp.Field = new string[8, 10]       // Кости распологаются по периметру 
            {
                { "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        " },
                { "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        " },
                { "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        " },
                { "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        " },
                { "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        " },
                { "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        " },
                { "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        " },
                { "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        ", "        " }
            };
            BonesSetUp.BaseDeck = new List<string>(28)
                    {"[0:0]", "[0:1]", "[0:2]", "[0:3]", "[0:4]", "[0:5]", "[0:6]",
                    "[1:1]", "[1:2]", "[1:3]", "[1:4]", "[1:5]", "[1:6]",
                    "[2:2]", "[2:3]", "[2:4]", "[2:5]", "[2:6]",
                    "[3:3]", "[3:4]", "[3:5]", "[3:6]",
                    "[4:4]", "[4:5]", "[4:6]",
                    "[5:5]", "[5:6]",
                    "[6:6]"};
           
            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("INSERT INTO `history`(`name`, `turns`) VALUES (@name, @turns)", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = yourname;
            command.Parameters.Add("@turns", MySqlDbType.VarChar).Value = turns;
            db.openConnection();
            if (temp == 1)
                command.ExecuteNonQuery();
            db.closeConnection();
            this.Close();            
            Form lobby = new Lobby();        
            lobby.ShowDialog();           
        }
    }
}
