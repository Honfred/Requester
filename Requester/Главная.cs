
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Requester
{
    public partial class Главная : Form
    {
        public string Login;
        Bd bd = new Bd();
        public string Naimenovanie;
        public string Opisanie;
        public string Nazvanie;
        public string Razmer;
        public string Pol;
        public int Count;
        public int Nomer;

        public Главная()
        {
            InitializeComponent();
            bd.openConnection();


        }

        private void Главная_Load(object sender, EventArgs e)
        {
            Materials();
            INfo();
            Clothes();
        }
        public void Materials()
        {
            try
            {
                string Sqlreq = "SELECT o.Id_order, o.Name, o.Description, c.Name, c.Size, c.Attribute, o.Count, o.DateTime, " +
                "o.Status FROM Orders AS o, Catalog AS c WHERE o.Id_clothes = c.Id_clothes AND o.Id_user = '" + Info.L + "'";

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand(Sqlreq, bd.GetConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);

                dataGridView1.DataSource = table;

                dataGridView1.Columns[0].HeaderText = "Заявка";
                dataGridView1.Columns[1].HeaderText = "Наименование заявки";
                dataGridView1.Columns[2].HeaderText = "Описание";
                dataGridView1.Columns[3].HeaderText = "Название вещи";
                dataGridView1.Columns[4].HeaderText = "Размер";
                dataGridView1.Columns[5].HeaderText = "М/Ж";
                dataGridView1.Columns[6].HeaderText = "Количество";
                dataGridView1.Columns[7].HeaderText = "Дата и время";
                dataGridView1.Columns[8].HeaderText = "Статус";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void INfo()


        {
            string Sqlreq = $"select u.Fio, d.Name from Users as u, Divisions as d where u.Id_division = d.Id_division and u.Id_users = {Info.L}";
            SqlCommand command = new SqlCommand(Sqlreq, bd.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                label1.Text = reader[0].ToString();
                label2.Text = reader[1].ToString();

            }
            reader.Close();
        }

        public void AddRecord()
        {
            try
            {
                string Sqlreq = $"insert into Orders (Name, Description, Id_clothes, Count, Id_user, DateTime, Status) " +
                    $"values ('{textBox1.Text}','{textBox2.Text}'," +
                    $"(select Id_clothes from Catalog where Name = '{comboBox5.Text}' and Size = '{comboBox3.Text}' and Attribute = '{comboBox6.Text}')," +
                    $"'{numericUpDown1.Value}', " +
                    $"{Info.L},GETDATE(),'В ожидании');";
                SqlCommand command = new SqlCommand(Sqlreq, bd.GetConnection());
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Такой вещи нет!", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clothes()

        {
            string Sqlreq = "select Name from Catalog distinc group by Name";
            SqlCommand command = new SqlCommand(Sqlreq, bd.GetConnection());
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox5.Items.Add(String.Format("{0}", reader[0]));
            }
            reader.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Materials();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Sqlreq = $" update Orders set Name ='{textBox1.Text}', Description = '{textBox2.Text}', Id_clothes = (select Id_clothes from Catalog where Name = '{comboBox5.Text}' and Size = '{comboBox3.Text}' and Attribute = '{comboBox6.Text}'), Count = '{numericUpDown1.Value}', DateTime = GETDATE() where Id_order = {Nomer};";
                SqlCommand command = new SqlCommand(Sqlreq, bd.GetConnection());
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Такой вещи нет!", "Ошбика", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Materials();
            button2.Visible = true;
            button4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            comboBox5.Visible = false;
            numericUpDown1.Visible = false;
            comboBox3.Visible = false;
            comboBox6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            comboBox5.Visible = true;
            numericUpDown1.Visible = true;
            button2.Visible = false;
            button4.Visible = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            comboBox6.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddRecord();
            Materials();
            button2.Visible = true;
            button4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            comboBox5.Visible = false;
            numericUpDown1.Visible = false;
            comboBox3.Visible = false;
            comboBox6.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int row, id;
                row = dataGridView1.SelectedCells[0].RowIndex;
                id = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value.ToString());
                string query = "SELECT o.Id_order, o.Name, o.Description, c.Name, c.Size, c.Attribute, o.Count, o.DateTime, " +
                "o.Status FROM Orders AS o, Catalog AS c WHERE o.Id_clothes = c.Id_clothes AND o.Id_user = '" + Info.L + "' and o.Id_order = '" + id + "'";
                SqlCommand command = new SqlCommand(query, bd.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Naimenovanie = reader[1].ToString();
                    Opisanie = reader[2].ToString();
                    Nazvanie = reader[3].ToString();
                    Razmer = reader[4].ToString();
                    Pol = reader[5].ToString();
                    Count = Convert.ToInt32(reader[6]);
                    Nomer = Convert.ToInt32(reader[0]);

                }
                reader.Close();
                textBox1.Visible = true;
                textBox1.Text = Naimenovanie;
                textBox2.Visible = true;
                textBox2.Text = Opisanie;
                comboBox5.Visible = true;
                comboBox5.Text = Nazvanie;
                numericUpDown1.Visible = true;
                numericUpDown1.Value = Count;
                comboBox3.Visible = true;
                comboBox3.Text = Razmer;
                comboBox6.Visible = true;
                comboBox6.Text = Pol;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Авторизация авторизация = (Авторизация)this.Owner;
            авторизация.Show();
            this.Hide();
        }


    }

}



