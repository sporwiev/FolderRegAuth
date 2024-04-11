
using System;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X500;
using MySqlX.XDevAPI.Common;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MaterialSkin.Controls;

namespace WindowsFormsApp1
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm    {
        
        public Form1()
        {
            
            InitializeComponent();
            textBox1.Text = "Login";
            textBox2.Text = "E-mail / Phone";
            textBox3.Text = "Password";
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public static Random rnd = new Random();
        public int rnd1 = rnd.Next(10000);
        MaterialSkin.Controls.MaterialButton button = new MaterialSkin.Controls.MaterialButton();
        
        public void email()
        {
            
           
            try
            {

                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("AtMory@yandex.ru"); // Адрес отправителя
                mail.To.Add(new MailAddress(textBox2.Text)); // Адрес получателя
                mail.Subject = "Подтверждение почты";
                mail.Body = $"Код {rnd1}";

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.yandex.ru";
                client.Port = 587; // Обратите внимание что порт 587
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("AtMory@yandex.ru", "jjnmowyxvqygzaff"); // Ваши логин и пароль
                client.Send(mail);
           
                button.Location = new Point(285, 258);
                button.FlatStyle = FlatStyle.Flat;
                button.ForeColor = Color.White;
                button.Size = new Size(120, 20);
                button.Text = "Verfi";
                button.BackColor = Color.Black;
                button.Click += new EventHandler(ButtonOnClick);
                this.Controls.Add(button);




            }
            catch
            {
                MessageBox.Show("не отправилось");
            }

        }
        private string GeneratePass()
        {
            string iPass = "";
            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Z", "b", "c", "d", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "A", "E", "U", "Y", "a", "e", "i", "o", "u", "y" };
            Random rnd = new Random();
            for (int i = 0; i < 50; i = i + 1)
            {
                iPass = iPass + arr[rnd.Next(0, 57)];
            }
            return iPass;
        }
        private void ButtonOnClick(object sender,EventArgs e)
        {
            if(textBox4.Text == rnd1.ToString())
            {
                
          
                
                
                
                
                MessageBox.Show("код правильный");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("AtMory@yandex.ru"); // Адрес отправителя
               
                mail.To.Add(new MailAddress(textBox2.Text)); // Адрес получателя
                mail.IsBodyHtml= true;
                mail.Subject = "Регистрация";
                String htmlstring = $@"<html lang=""en"">
                <body>
                <div id = 'fr'>
                Поздравляю вы зарегистрировались на нашей платформе игра<br />
                    Логин  : {textBox1.Text}<br /> 
                    Пароль : {textBox3.Text}<br />
                    Токен  : {GeneratePass()}
                    </div>
                </body>
                </html>";
                mail.Body = htmlstring;

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.yandex.ru";
                client.Port = 587; // Обратите внимание что порт 587
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("AtMory@yandex.ru", "jjnmowyxvqygzaff"); // Ваши логин и пароль
                client.Send(mail);
                Auth auth = new Auth();
                Form1 form1 = new Form1();
                auth.Show();
            
                
            }
            else
            {
                MaterialSkin.Controls.MaterialMessageBox.Show("код неверный");
               
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor= Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
        }
        

        private void user_name(object sender, EventArgs e)
        {

            
        }

        private void user_phone__email(object sender, EventArgs e)
        {
            if (textBox2.Text == "E-mail / Phone")
            {
                textBox2.Text = "";
            }
        }

        private void user__password(object sender, EventArgs e)
        {
           
            if (textBox3.Text == "Password")
            {
                textBox3.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


       

        private void user__login(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter login")
            {
                textBox1.Text = "";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            BD bd = new BD();


            MySqlCommand command = new MySqlCommand($"INSERT INTO `registr` (`Login`, `Phone/e-mail`, `password`) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')", bd.getConnection());

            bd.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MaterialMessageBox.Show("Sucsessfill");
               
                email();
            }
            else
            {
                MessageBox.Show("Error");
            }
            bd.closeConnection();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Auth auth = new Auth();
            auth.Show();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
  
}
