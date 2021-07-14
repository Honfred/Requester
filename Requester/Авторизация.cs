
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Requester
{
    public partial class Авторизация : Form
    {
        static string login;
        string password;
        Bd bd = new Bd();

        public Авторизация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Главная главная = new Главная { Owner = this };

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                login = textBox1.Text.Trim();

                password = textBox2.Text.Trim();
                string Sqlreq = "SELECT Id_users FROM Users WHERE login = '" + login + "' AND Password = ('" + password + "');";

                bd.openConnection();

                SqlCommand command = new SqlCommand(Sqlreq, bd.GetConnection());
                int id = 0;
                id = Convert.ToInt32(command.ExecuteScalar());



                if (id != 0)
                {

                    Info.L = id;
                    bd.closeConnection();
                    главная.Show();
                    this.Hide();
                    textBox2.Text = "";

                }

                else { MessageBox.Show("Логин и/или пароль введены не правильно"); }

            }
        }
    }
}
