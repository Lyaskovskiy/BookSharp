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

namespace КурсоваБД
{
    public partial class Menu : Form
    {
        public Menu(string str)
        {
            InitializeComponent();
            label1.Text = str;
        }

        //з форми Login передається імя користувача і в заледності від імені виводиться персональні дані, деякі з них можна змінити 
        void comboWho()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select kind,experience,password,email from bookstore.worker where workername='"+label1.Text.ToString()+"';";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("kind");
                    label8.Text = s3; 
                    string s5 = myreader.GetString("password");
                    textBox2.Text = s5;
                    string s6 = myreader.GetString("email");
                    textBox3.Text = s6;
      
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }


        private void Menu_Load(object sender, EventArgs e)
        {
            comboWho();
            if (label8.Text.ToString() == "manager") { button2.Enabled = false; button3.Enabled = false; button5.Visible = false; }
            if (label8.Text.ToString() == "Dispatcher") { button1.Enabled = false; button3.Enabled = false; button5.Visible = false; }
            if (label8.Text.ToString() == "Mechanic") { button2.Enabled = false; button1.Enabled = false; button5.Visible = false; }
            if (label8.Text.ToString() == "driver" || label8.Text.ToString() == "") { button1.Enabled = false; button2.Enabled = false; button3.Enabled = false; button5.Visible = false; }
            if (label8.Text.ToString() == "admin") {  }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seller f3 = new Seller();
            f3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Talking f2 = new Talking();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Managment f1 = new Managment();
            f1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string query2 = "update bookstore.worker set password='"
         + textBox2.Text.ToString() + "',email='" + textBox3.Text.ToString() + "' where workername='" + label1.Text.ToString() + "';";
            Func.AddFunc(query2);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
                string strAdm = "admin"; 
                NewUser f3 = new NewUser(strAdm);
                f3.ShowDialog();
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Administrator f3 = new Administrator();
            f3.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
