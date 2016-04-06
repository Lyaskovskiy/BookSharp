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
    public partial class Guest : Form
    {
        public Guest()
        {
            InitializeComponent();
            comboAllBook();//вивід існуючих маршрутів
            comboAllJenre();
        }

        //існуючі маршрути в комбобоксі
        void comboAllBook()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select * from cursova.book;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
                {
                    connn.Open();
                    myreader = c.ExecuteReader();
                    while (myreader.Read())
                    {
                        string s3 = myreader.GetString("Name");
                        comboBox1.Items.Add(s3);
                    }
                }
            catch (Exception e)
                {
                    connn.Close();
                }
            }

        void comboAllJenre()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select distinct Jenre from cursova.book;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s4 = myreader.GetString("Jenre");
                    comboBox2.Items.Add(s4);
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }



        //вивід довжини при виборі маршруту
        void comboAuthors(string source)
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select A.NameAuthor, B.Jenre from cursova.author as A   join  cursova.book as B join cursova.author_has_book as C on  C.idA=A.idAuthor and C.idB=B.idBook and B.Name='"
            + source + "';";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("NameAuthor").ToString();
                    label3.Text += " " + s3 + ", ";
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        void comboJenre(string source)
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select Jenre,Price from cursova.book where Name='" + source + "';";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s4 = myreader.GetString("Jenre").ToString();
                    label4.Text += " " + s4;
                    string s5 = myreader.GetString("Price").ToString();
                    label5.Text += " " + s5;
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        //при зміні маршруту в комбобоксі - загрузка зупинок вибраного маршруту і пасажирообігу на них
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /*string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select A.NameAuthor,B.Jenre from cursova.author as A   join  cursova.book as B join cursova.author_has_book as C on  C.idA=A.idAuthor and C.idB=B.idBook and B.Name='"
            + comboBox1.Text.ToString() + "';";
           
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);

                MySqlDataAdapter myadapq = new MySqlDataAdapter();
                myadapq.SelectCommand = c;
                DataTable ds = new DataTable();
                myadapq.Fill(ds);
                BindingSource bbb = new BindingSource();

                bbb.DataSource = ds;
                dataGridView1.DataSource = bbb;
                myadapq.Update(ds);
                connn.Close();*/

              /*  label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                comboAuthors(comboBox1.Text.ToString());
                comboJenre(comboBox1.Text.ToString());
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;*/
        }

        //при загрузці форми - загрузка карти Тернополя
        private void Guest_Load(object sender, EventArgs e)
        {
            pictureBox1.Load("C:\\TBus\\Bogdan.jpg");
            dataGridView1.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("C:\\TBus\\laz.jpg");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("C:\\TBus\\umz-t2.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            comboAuthors(textBox1.Text.ToString());
            comboJenre(textBox1.Text.ToString());
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select Name from cursova.book where Jenre='"
            + comboBox2.Text.ToString() + "';";

            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);

            MySqlDataAdapter myadapq = new MySqlDataAdapter();
            myadapq.SelectCommand = c;
            DataTable ds = new DataTable();
            myadapq.Fill(ds);
            BindingSource bbb = new BindingSource();

            bbb.DataSource = ds;
            dataGridView2.DataSource = bbb;
            myadapq.Update(ds);
            connn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            comboAuthors(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            comboJenre(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        
    }
}
