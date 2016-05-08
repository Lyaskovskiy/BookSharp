using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Web;
using System.Net.Mail;

namespace КурсоваБД
{
    public partial class NewOrder : Form
    {
        public NewOrder(string person, string price)
        {
            InitializeComponent();
            label6.Text = person;
            label7.Text = price;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query11 = "insert into bookstore.history(historyworker,historyprice) values ('"
               + label6.Text.ToString() + "','" + label7.Text.ToString() + "');";
            Func.AddFunc(query11);
            
            
            MailMessage mail = new MailMessage("burevisnyk88@gmail.com", "burevisnyk88@gmail.com", "Купівля книг", "Дякуємо Вам вибір саме нашої книгарні. Ваше замовлення підтверджене. Очікуйте на книги в найближчі 2-3 дні.");
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("burevisnyk88@gmail.com", "pro100monoruma");
            client.EnableSsl = true;
            client.Send(mail);


            

            
        }

        private void NewOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
