using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MaterialSkin.Controls;

namespace WindowsFormsApp1
{
    public partial class Auth : MaterialForm
    {
        public Auth()
        {
            InitializeComponent();
            
            textBox2.Text = "Password";
            textBox1.Text = "Login";
        }
        private void user_login(object sender, EventArgs e)
        {
            if (textBox1.Text == "Login")
            {
                textBox1.Text = "";
            }
        }

        private void user_password(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            String loginUser = textBox1.Text;
            String passwordUser = textBox2.Text;
            BD bd = new BD();
            

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            
            MySqlCommand command= new MySqlCommand($"SELECT * FROM `registr` WHERE `Login` = @login AND `password` = @password",bd.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBox2.Text;

            adapter.SelectCommand= command;
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                MessageBox.Show($"Вы автоизированы: {loginUser}");
                Index index = new Index();
                this.Hide();
                index.Show();  

                
            }
            else
            {
                MessageBox.Show("Вы не найдены");
            }
        }

        private void Auth_Load(object sender, EventArgs e)
        {

        }
    }
}
