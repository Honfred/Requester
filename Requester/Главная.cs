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
    public partial class Главная : Form
    {
        public string Login;
        public Главная()
        {
            InitializeComponent();
            Bd bd = new Bd();
            
            string Sqlreq = "SELECT o.Id_order, o.Name, o.Description, c.Name, c.Size, c.Attribute, o.Count, o.DateTime, o.Status FROM Orders AS o, Catalog AS c WHERE o.Id_clothes = c.Id_clothes AND o.login = '" + this.Login + "'";
            MessageBox.Show(Sqlreq);
        }

        private void Главная_Load(object sender, EventArgs e)
        {
            
        }

        public string Setlogin(string login) 
        {
            this.Login = login;
            return this.Login;
        }
    }
}

        
    
