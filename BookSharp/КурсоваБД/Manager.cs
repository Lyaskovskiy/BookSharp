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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
            combo();//вивід існуючих маршрутів
        }


        //випадаючий комбобокс для вибору маршруту 
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
                    label3.Text = s3;
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        //вивід пасажирообігу на маршруті
        void comboPass1()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            try
            {
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand();
            connn.Open();
            c.Connection = connn;
            c.CommandType = CommandType.StoredProcedure;  //вказання типу команди - процедура
            c.CommandText = "cursova.pass";  //команда - виконати процедуру pass
            c.Parameters.AddWithValue("R", comboBox1.Text); //параметри які передаються в процедуру - вхідний(№маршруту з тектбоксу)
            c.Parameters.Add("param1", MySqlDbType.Int32).Direction = ParameterDirection.Output;  //аналогічно параметр який виводиться - змінна param1
            c.ExecuteNonQuery();  //оброблення команди
            label5.Text = c.Parameters["param1"].Value.ToString();  //приймання результатів команди
            label5.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                
            }
        }
      
        private void Manager_Load(object sender, EventArgs e)
        {

        }

        //новий маршрут
        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "insert into cursova.author(Number,Len) values ('"
                + comboBox1.Text.ToString() + "','" + 0.ToString() + "');";
            Func.AddFunc(query1);
        }
        
        
        //insert stop
        private void button6_Click(object sender, EventArgs e)
        {
            string query2 = "insert into cursova.author_has_book(Route_Number,Stops_Name) values ('"
            + comboBox1.Text.ToString() + "','" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "');";
            Func.AddFunc(query2);

            string query3 = "insert into cursova.book(Name,Number_of_passenger) values ('"
            + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "');";
            Func.AddFunc(query3);
        }

       //видалення маршруту
        private void button4_Click(object sender, EventArgs e)
        {
            string query1 = "delete from cursova.author_has_book where Route_Number='"
           + comboBox1.Text.ToString() + "';";
            Func.AddFunc(query1);
        }

        //вивід маршруту(зупинки і пасажирообіг)
        private void button5_Click(object sender, EventArgs e)
        {
            string query = "select A.Stops_Name,B.Number_of_passenger,B.idS from cursova.author_has_book as  A join   cursova.book  as B  on  A.Stops_Name=B.Name   and   Route_Number='"
            + comboBox1.Text.ToString() + "';";
            Func.SelectFunc(query, dataGridView1);

            label3.Text = "Lenght";
            label3.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        //update stops
        private void button2_Click(object sender, EventArgs e)
        {
            string query1 = "update cursova.book set Name='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "',Number_of_passenger='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'where idS='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "';";
            Func.AddFunc(query1);
        }


        //delete stops
        private void button3_Click(object sender, EventArgs e)
        {
            string query2 = "delete from cursova.book where Name='"
                       + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'and Number_of_passenger='"+dataGridView1.CurrentRow.Cells[1].Value.ToString()+"';";
            Func.AddFunc(query2);
        }


        //update lenght of the route
        private void button7_Click(object sender, EventArgs e)
        {
            string query1 = "update cursova.author set Len='" + textBox2.Text.ToString() + "'where Number='" + comboBox1.Text.ToString() + "';";
            Func.AddFunc(query1);
        }


        //при зміні вибору маршруту - вивід зупинок і пасажирообігу
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select A.Stops_Name,B.Number_of_passenger,B.idS from cursova.author_has_book as  A join   cursova.book  as B  on  A.Stops_Name=B.Name   and   Route_Number='"
          + comboBox1.Text.ToString() + "';";
            Func.SelectFunc(query, dataGridView1);
            
            //вивід довжини вибраного маршруту
            comboLen();
            comboPass1();
           
            label4.Visible = true;
            label3.Visible = true;
        }
    }
}
