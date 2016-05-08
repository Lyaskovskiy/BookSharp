using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

using System.Web;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;

namespace КурсоваБД
{
    public partial class Managment : Form
    {
        public Managment()
        {
            InitializeComponent();
            timer1.Start();

            password.PasswordChar = '*';
        }
  
        

        
        
        
        private void Mechanic_Load(object sender, EventArgs e)
        {
            string query = "select * from bookstore.history;";
            Func.SelectFunc(query, dataGridView1);

            MySqlConnection connn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=ttt");
            MySqlCommand comand = new MySqlCommand("select * from bookstore.history;", connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = comand.ExecuteReader();

                while (myreader.Read())
                {
                    this.chart1.Series["Name"].Points.AddXY(myreader.GetString("historyworker"), myreader.GetInt32("historyprice"));
                    this.chart1.Series["Price"].Points.AddXY(myreader.GetString("historyworker"), myreader.GetInt32("historyprice"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


       

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            textBox2.Text = time.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void send_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage(from.Text, to.Text, subject.Text, body.Text);
            mail.Attachments.Add(new Attachment(attach.Text));
            SmtpClient client = new SmtpClient(smtp.Text);
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(username.Text, password.Text);
            client.EnableSsl = true;
            client.Send(mail);
            MessageBox.Show("Email sent", "Success", MessageBoxButtons.OK);
        }

        private void attachBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog dl = new OpenFileDialog();
            if (dl.ShowDialog() == DialogResult.OK)
            {
                string picPath = dl.FileName.ToString();
                attach.Text = picPath;
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            string query11 = "insert into bookstore.change(person1,person2,person3,begindate,enddate) values ('"
              + comboBox6.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" +
              dateTimePicker4.Text + "','" + dateTimePicker3.Text + "');";
            Func.AddFunc(query11);
        }
    }
}
