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
            string s2 = "select Kind_of_work,Experience,Password,Email,Trolleybus_idTrolleybus,Trolleybus_Route_Number from cursova.Worker where Name='"+label1.Text.ToString()+"';";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("Kind_of_work");
                    label8.Text = s3; 
                    string s4 = myreader.GetInt32("Experience").ToString();
                    textBox1.Text = s4;
                    string s5 = myreader.GetString("Password");
                    textBox2.Text = s5;
                    string s6 = myreader.GetString("Email");
                    textBox3.Text = s6;
                    string s7 = myreader.GetInt32("Trolleybus_idTrolleybus").ToString();
                    textBox4.Text = s7;
                    string s8 = myreader.GetInt32("Trolleybus_Route_Number").ToString();
                    textBox5.Text = s8;
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
            if (label8.Text.ToString() == "Manager") { button2.Enabled = false; button3.Enabled = false; textBox4.Visible = false; textBox5.Visible = false; linkLabel1.Visible = false; button5.Visible = false; }
            if (label8.Text.ToString() == "Dispatcher") { button1.Enabled = false; button3.Enabled = false; textBox4.Visible = false; textBox5.Visible = false; linkLabel1.Visible = false; button5.Visible = false; }
            if (label8.Text.ToString() == "Mechanic") { button2.Enabled = false; button1.Enabled = false; textBox4.Visible = false; textBox5.Visible = false; linkLabel1.Visible = false; button5.Visible = false; }
            if (label8.Text.ToString() == "Driver") { button1.Enabled = false; button2.Enabled = false; button3.Enabled = false; linkLabel1.Visible = false; button5.Visible = false; }
            if (label8.Text.ToString() == "Administrator") { textBox4.Visible = false; textBox5.Visible = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager f3 = new Manager();
            f3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispatcher f2 = new Dispatcher();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mechanic f1 = new Mechanic();
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
            string query2 = "update cursova.Worker set Password='"
         + textBox2.Text.ToString() + "',Email='" + textBox3.Text.ToString() + "' where Name='" + label1.Text.ToString() + "';";
            Func.AddFunc(query2);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewUser f3 = new NewUser();
            f3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Administrator f3 = new Administrator();
            f3.ShowDialog();
        }
    }
}
