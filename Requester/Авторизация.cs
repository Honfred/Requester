using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Requester
{
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bd bd = new Bd();

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string login = textBox1.Text.Trim();
                string pass = textBox2.Text.Trim();
                string MySqlreq = "SELECT Id_users FROM Users WHERE login = '" + login + "' AND password = md5('" + pass + "') LIMIT 1;";

                bd.openConnection();

                MySqlCommand command = new MySqlCommand(MySqlreq, bd.GetConnection());
                int id = 0;
                
                id = Convert.ToInt32(command.ExecuteScalar());
                
                
                
                if (id != 0)
                {
                    Главная главная = new Главная();
                    bd.closeConnection();
                    главная.Show();
                    this.Hide();
                }
                else { MessageBox.Show("Логин и/или пароль введены не правильно"); }
            }
        }
    }
}
