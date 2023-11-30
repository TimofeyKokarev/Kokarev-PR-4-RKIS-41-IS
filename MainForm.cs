using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kokarev_PR4.UsersСlasses;

namespace Kokarev_PR4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxSubject.Text) ||
                string.IsNullOrWhiteSpace(textBoxBody.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            string smtp = "smtp.mail.ru";
            StringPair fromInfo = new StringPair("timofey.kokarev@mail.ru", "Кокарев Тимофей Алексеевич 41 ИС");
            string password = "1vqiLRZ4is5hTqem76Cn";

            StringPair toInfo = new StringPair(textBoxEmail.Text,textBoxName.Text);
            string subject = textBoxSubject.Text;
            string body = $"{DateTime.Now} \n" +
                          $"{Dns.GetHostName()} \n" +
                          $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                          $"{textBoxBody.Text}";
            InfoEmailSending info = new InfoEmailSending (smtp,fromInfo, password, toInfo, subject, body);
            SendingEmail sendingEmail = new SendingEmail(info);
            sendingEmail.Send();

            MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Text="";
            }



        }
    }
}
