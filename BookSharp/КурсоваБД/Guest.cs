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
            combo();//вивід існуючих маршрутів
        }

        //існуючі маршрути в комбобоксі
        void combo()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select * from cursova.author;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
                {
                    connn.Open();
                    myreader = c.ExecuteReader();
                    while (myreader.Read())
                    {
                        string s3 = myreader.GetString("Number");
                        comboBox1.Items.Add(s3);
                    }
                }
            catch (Exception e)
                {
                    connn.Close();
                }
            }

        //вивід довжини при виборі маршруту
        void comboLen()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select Len from cursova.author where Number='" + comboBox1.Text + "';";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetInt32("Len").ToString();
                    textBox1.Text = "Lenght of the route: " + s3;
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
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select A.Stops_Name,B.Number_of_passenger from cursova.author_has_book as  A join   cursova.book  as B  on  A.Stops_Name=B.Name   and   Route_Number='"
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
                connn.Close();

                comboLen();
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
    }
}
