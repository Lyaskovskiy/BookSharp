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

namespace КурсоваБД
{
    public partial class Seller : Form
    {
        public Seller()
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
            string s2 = "select * from bookstore.book;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("namebook");
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
            string s2 = "select distinct authorname from bookstore.author;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("authorname");
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
            string s2 = "select distinct authorname from bookstore.author;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("authorname");
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
            string s2 = "select distinct authorname from bookstore.author;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("authorname");
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
            string s2 = "select distinct authorname from bookstore.author;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("authorname");
                    comboBox5.Items.Add(s3);
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

    
      
        private void Manager_Load(object sender, EventArgs e)
        {

        }

        //новий маршрут
        private void button1_Click(object sender, EventArgs e)
        {
           
            string queryBook = "insert into bookstore.book(namebook,jenre,price,image,discountdate) values ('"
                + comboBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "',@IMG, '" + dateTimePicker1.Text + "');";
            Func.ImageFunc(queryBook, label3.Text.ToString());
      

            if (radioButton1.Checked == true) {
                string query11 = "insert into bookstore.author(authorname) value ('"
                + comboBox2.Text.ToString() + "');";
                Func.AddFunc(query11);

               string query21 = "insert into bookstore.author_has_book(idauthorH,idbookH) values ((select max(idauthor) from bookstore.author where authorname ='" 
                + comboBox2.Text.ToString() + "'), (select max(idbook) from bookstore.book where namebook ='"
                + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query21);
            }

            if (radioButton2.Checked == true)
            {
                string query11 = "insert into bookstore.author(authorname) value ('"
                + comboBox2.Text.ToString() + "');";
                Func.AddFunc(query11);

                string query21 = "insert into bookstore.author_has_book(idauthorH,idbookH) values ((select max(idauthor) from bookstore.author where authorname ='"
                    + comboBox2.Text.ToString() + "'), (select max(idbook) from bookstore.book where namebook ='"
                    + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query21);

                //////////////////////////////
                string query12 = "insert into bookstore.author(authorname) value ('"
                + comboBox3.Text.ToString() + "');";
                Func.AddFunc(query12);

                string query22 = "insert into bookstore.author_has_book(idauthorH,idbookH) values ((select max(idauthor) from bookstore.author where authorname ='"
             + comboBox3.Text.ToString() + "'), (select max(idbook) from bookstore.book where namebook ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query22);
            }

            if (radioButton3.Checked == true)
            {
                string query11 = "insert into bookstore.author(authorname) value ('"
                + comboBox2.Text.ToString() + "');";
                Func.AddFunc(query11);

                string query21 = "insert into bookstore.author_has_book(idauthorH,idbookH) values ((select max(idauthor) from bookstore.author where authorname ='"
                    + comboBox2.Text.ToString() + "'), (select max(idbook) from bookstore.book where namebook ='"
                    + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query21);

                //////////////////////////////
                string query12 = "insert into bookstore.author(authorname) value ('"
                + comboBox3.Text.ToString() + "');";
                Func.AddFunc(query12);

                string query22 = "insert into bookstore.author_has_book(idauthorH,idbookH) values ((select max(idauthor) from bookstore.author where authorname ='"
             + comboBox3.Text.ToString() + "'), (select max(idbook) from bookstore.book where namebook ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query22);

                /////////////////////////////
                string query13 = "insert into bookstore.author(authorname) value ('"
                + comboBox4.Text.ToString() + "');";
                Func.AddFunc(query13);

                string query23 = "insert into bookstore.author_has_book(idauthorH,idbookH) values ((select max(idauthor) from bookstore.author where authorname ='"
             + comboBox4.Text.ToString() + "'), (select max(idbook) from bookstore.book where namebook ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query23);
            }

            if (radioButton4.Checked == true)
            {
                string query11 = "insert into bookstore.author(authorname) value ('"
                + comboBox2.Text.ToString() + "');";
                Func.AddFunc(query11);

                string query21 = "insert into bookstore.author_has_book(idauthorH,idbookH) values ((select max(idauthor) from bookstore.author where authorname ='"
                    + comboBox2.Text.ToString() + "'), (select max(idbook) from bookstore.book where namebook ='"
                    + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query21);

                //////////////////////////////
                string query12 = "insert into bookstore.author(authorname) value ('"
                + comboBox3.Text.ToString() + "');";
                Func.AddFunc(query12);

                string query22 = "insert into bookstore.author_has_book(idauthorH,idbookH) values ((select max(idauthor) from bookstore.author where authorname ='"
             + comboBox3.Text.ToString() + "'), (select max(idbook) from bookstore.book where namebook ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query22);

                /////////////////////////////
                string query13 = "insert into bookstore.author(authorname) value ('"
                + comboBox4.Text.ToString() + "');";
                Func.AddFunc(query13);

                string query23 = "insert into bookstore.author_has_book(idauthorH,idbookH) values ((select max(idauthor) from bookstore.author where authorname ='"
             + comboBox4.Text.ToString() + "'), (select max(idbook) from bookstore.book where namebook ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query23);

                /////////////////////////////
                string query14 = "insert into bookstore.author(authorname) value ('"
                + comboBox5.Text.ToString() + "');";
                Func.AddFunc(query14);

                string query24 = "insert into bookstore.author_has_book(idauthorH,idbookH) values ((select max(idauthor) from bookstore.author where authorname ='"
             + comboBox5.Text.ToString() + "'), (select max(idbook) from bookstore.book where namebook ='"
             + comboBox1.Text.ToString() + "'));";
                Func.AddFunc(query24);
            } 
            

          

        }
        
        
       

       //видалення маршруту
        private void button4_Click(object sender, EventArgs e)
        {
            string query1 = "delete from bookstore.book where namebook='"
           + comboBox1.Text.ToString() + "';";
            Func.AddFunc(query1);
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
            string s2 = "select idbook from bookstore.book where namebook='"
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
                    string s3 = myreader.GetInt32("idbook").ToString();
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
            string s2 = "select idauthor from bookstore.author where authorname='"
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
                    string s3 = myreader.GetInt32("idauthor").ToString();
                    label9.Text = s3;
                }
            }
            catch (Exception)
            {
                connn.Close();
            }

            
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();  //діалогове вікно
            foto.Filter = "JPG Files(*.jpg)|*.jpg| PNG Files(*.png)|*.png";  //фільтр можливих малюнків
            foto.Title = "Select Trolleybus picture";  //просто назва
            if (foto.ShowDialog() == DialogResult.OK)  //якщо фото загрузилося
            {
                string picture = foto.FileName.ToString();  //шлях до файла
                label3.Text = picture;  //шлях до файлу в текстбокс для подальшої вставки в БД
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
        }

       
    }
}
