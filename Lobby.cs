using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace DominoGame
{
    public partial class Lobby : Form
    {
        public Lobby()
        {
            InitializeComponent();

            topname.Text = "";
            DataBase db = new DataBase();
            string toplist = "SELECT name,turns FROM `history` ORDER BY turns ASC LIMIT 10";
            MySqlCommand command = new MySqlCommand(toplist, db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            int i = 1;
            while (reader.Read()) {

                topname.Text += i +": " + reader[0].ToString() + "\n";
                toptime.Text += reader[1].ToString()+"\n";
                i++;
            }
            reader.Close();
            db.closeConnection();               
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (name.Text != "")
            {
                Hide();
                Board newForm = new Board(name.Text);                
                newForm.ShowDialog();
                Close();

            }
            else return;
        }

    }
}
