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
        static string login;
        string password;
        public Авторизация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bd bd = new Bd();
            Info info = new Info();
            Главная главная = new Главная();

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                login = textBox1.Text.Trim();

                password = textBox2.Text.Trim();
                string MySqlreq = "SELECT Id_users FROM Users WHERE login = '" + login + "' AND password = md5('" + password + "') LIMIT 1;";

                bd.openConnection();

                MySqlCommand command = new MySqlCommand(MySqlreq, bd.GetConnection());
                int id = 0;
                id = Convert.ToInt32(command.ExecuteScalar());



                if (id != 0)
                {
                    string Sqlreq = "SELECT u.Fio, d.Name FROM Users AS u, Divisions AS d WHERE u.Id_division = d.Id_division and u.Login = '" + login + "'";

                    using (MySqlCommand command1 = new MySqlCommand(Sqlreq, bd.GetConnection()))
                    {

                        MySqlDataReader oku = command1.ExecuteReader();
                        while (oku.Read())
                        {
                            главная.label1.Text = oku["Fio"].ToString();
                            главная.label2.Text = oku["Name"].ToString();
                        }
                        главная.Setlogin(login);
                        
                        bd.closeConnection();
                        главная.Show();
                        this.Hide();
                    }
                }

                else { MessageBox.Show("Логин и/или пароль введены не правильно"); }

            }
        }
    }
}
