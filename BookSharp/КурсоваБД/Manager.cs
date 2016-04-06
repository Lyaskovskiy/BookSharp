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
            combo1();//вивід існуючих книг
            combo2();//вивід існуючих авторів
            combo3();//вивід існуючих авторів
            combo4();//вивід існуючих авторів
            combo5();//вивід існуючих авторів

        }


        //випадаючий комбобокс для вибору книги 
        void combo1()
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


        //випадаючий комбобокс для вибору автора 
        void combo2()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select distinct NameAuthor from cursova.author;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("NameAuthor");
                    comboBox2.Items.Add(s3);
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        void combo3()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select distinct NameAuthor from cursova.author;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("NameAuthor");
                    comboBox3.Items.Add(s3);
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        void combo4()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select distinct NameAuthor from cursova.author;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("NameAuthor");
                    comboBox4.Items.Add(s3);
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        void combo5()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select distinct NameAuthor from cursova.author;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("NameAuthor");
                    comboBox5.Items.Add(s3);
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

     /*   //вивід довжини при виборі маршруту
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
        }*/
      
        private void Manager_Load(object sender, EventArgs e)
        {

        }

        //новий маршрут
        private void button1_Click(object sender, EventArgs e)
        {
            
            string queryBook = "insert into cursova.book(Name,Jenre) values ('"
                + comboBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "');";
            Func.AddFunc(queryBook);
            

            if (radioButton1.Checked == true) {
                string query11 = "insert into cursova.author(NameAuthor) value ('"
                + comboBox2.Text.ToString() + "');";
                Func.AddFunc(query11);

            string query21 = "insert into cursova.author_has_book(idA,idB) values ((select max(idAuthor) from cursova.author where NameAuthor ='" 
                + comboBox2.Text.ToString() + "'), (select max(idBook) from cursova.book where Name ='"
                + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query21);
            }

            if (radioButton2.Checked == true)
            {
                string query11 = "insert into cursova.author(NameAuthor) value ('"
                + comboBox2.Text.ToString() + "');";
                Func.AddFunc(query11);

                string query21 = "insert into cursova.author_has_book(idA,idB) values ((select max(idAuthor) from cursova.author where NameAuthor ='"
                    + comboBox2.Text.ToString() + "'), (select max(idBook) from cursova.book where Name ='"
                    + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query21);

                //////////////////////////////
                string query12 = "insert into cursova.author(NameAuthor) value ('"
                + comboBox3.Text.ToString() + "');";
                Func.AddFunc(query12);

                string query22 = "insert into cursova.author_has_book(idA,idB) values ((select max(idAuthor) from cursova.author where NameAuthor ='"
             + comboBox3.Text.ToString() + "'), (select max(idBook) from cursova.book where Name ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query22);
            }

            if (radioButton3.Checked == true)
            {
                string query11 = "insert into cursova.author(NameAuthor) value ('"
                + comboBox2.Text.ToString() + "');";
                Func.AddFunc(query11);

                string query21 = "insert into cursova.author_has_book(idA,idB) values ((select max(idAuthor) from cursova.author where NameAuthor ='"
                    + comboBox2.Text.ToString() + "'), (select max(idBook) from cursova.book where Name ='"
                    + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query21);

                //////////////////////////////
                string query12 = "insert into cursova.author(NameAuthor) value ('"
                + comboBox3.Text.ToString() + "');";
                Func.AddFunc(query12);

                string query22 = "insert into cursova.author_has_book(idA,idB) values ((select max(idAuthor) from cursova.author where NameAuthor ='"
             + comboBox3.Text.ToString() + "'), (select max(idBook) from cursova.book where Name ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query22);

                /////////////////////////////
                string query13 = "insert into cursova.author(NameAuthor) value ('"
                + comboBox4.Text.ToString() + "');";
                Func.AddFunc(query13);

                string query23 = "insert into cursova.author_has_book(idA,idB) values ((select max(idAuthor) from cursova.author where NameAuthor ='"
             + comboBox4.Text.ToString() + "'), (select max(idBook) from cursova.book where Name ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query23);
            }

            if (radioButton4.Checked == true)
            {
                string query11 = "insert into cursova.author(NameAuthor) value ('"
                + comboBox2.Text.ToString() + "');";
                Func.AddFunc(query11);

                string query21 = "insert into cursova.author_has_book(idA,idB) values ((select max(idAuthor) from cursova.author where NameAuthor ='"
                    + comboBox2.Text.ToString() + "'), (select max(idBook) from cursova.book where Name ='"
                    + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query21);

                //////////////////////////////
                string query12 = "insert into cursova.author(NameAuthor) value ('"
                + comboBox3.Text.ToString() + "');";
                Func.AddFunc(query12);

                string query22 = "insert into cursova.author_has_book(idA,idB) values ((select max(idAuthor) from cursova.author where NameAuthor ='"
             + comboBox3.Text.ToString() + "'), (select max(idBook) from cursova.book where Name ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query22);

                /////////////////////////////
                string query13 = "insert into cursova.author(NameAuthor) value ('"
                + comboBox4.Text.ToString() + "');";
                Func.AddFunc(query13);

                string query23 = "insert into cursova.author_has_book(idA,idB) values ((select max(idAuthor) from cursova.author where NameAuthor ='"
             + comboBox4.Text.ToString() + "'), (select max(idBook) from cursova.book where Name ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query23);

                /////////////////////////////
                string query14 = "insert into cursova.author(NameAuthor) value ('"
                + comboBox5.Text.ToString() + "');";
                Func.AddFunc(query14);

                string query24 = "insert into cursova.author_has_book(idA,idB) values ((select max(idAuthor) from cursova.author where NameAuthor ='"
             + comboBox5.Text.ToString() + "'), (select max(idBook) from cursova.book where Name ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query24);
            } 
            

          

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
            string query1 = "delete from cursova.book where Name='"
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
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select idBook from cursova.book where Name='"
            + comboBox1.Text.ToString() + "';";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetInt32("idBook").ToString();
                    label7.Text = s3;
                }
            }
            catch (Exception)
            {
                connn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select idAuthor from cursova.author where NameAuthor='"
            + comboBox2.Text.ToString() + "';";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetInt32("idAuthor").ToString();
                    label9.Text = s3;
                }
            }
            catch (Exception)
            {
                connn.Close();
            }

            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
        }
    }
}
