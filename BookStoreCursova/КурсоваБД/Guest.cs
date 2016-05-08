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

namespace КурсоваБД
{
    public partial class Guest : Form
    {
       // private int rowIndex = 0;

        public Guest(string who)
        {
            InitializeComponent();
          
            comboAllJenre();
            label1.Text = who;
        }

        void comboPrice() //price books in basket
        {

            int rez = 0;
            for (int index = 0; index < dataGridView1.Rows.Count-1; index++)
            {
                rez += int.Parse(dataGridView1[1, index].Value as string);
            }
            label8.Text = rez.ToString();
        }

        void comboWho() //kind of user
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select kind from bookstore.worker where workername='" + label1.Text.ToString() + "';";
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
                    label2.Text = s3;
                   
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        void comboImage(string path) //image of book to picturebox
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select image from bookstore.book where namebook ='" + path + "';";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
    
                    byte[] array = (byte[])(myreader["Image"]); //створення масиву байт

                    MemoryStream mystream = new MemoryStream(array); pictureBox1.Image = System.Drawing.Image.FromStream(mystream);
  
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        void comboAllJenre() //all jenres to combobox
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select distinct jenre from bookstore.book;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s4 = myreader.GetString("jenre");
                    comboBox2.Items.Add(s4);
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        void comboAuthors(string source) //name authors to label when book is clicked
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select A.authorname, B.jenre from bookstore.author as A   join  bookstore.book as B join bookstore.author_has_book as C on  C.idauthorH=A.idAuthor and C.idbookH=B.idBook and B.namebook='"
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
                    string s3 = myreader.GetString("authorname").ToString();
                    label3.Text += " " + s3 + ", ";
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        void comboDate(string source) //discountdate for book
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select discountdate from bookstore.book where namebook = '" + source + "' and discountdate is not null;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s4 = myreader.GetString("discountdate").ToString();
                    label10.Text += " " + s4;
                   
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }
     


        void comboJenre(string source) //jenre to label when book is clicked
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select price-price*discount/100,jenre from bookstore.book where namebook = '" + source + "';";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s4 = myreader.GetString("jenre").ToString();
                    label4.Text += " " + s4;
                    int s5 = myreader.GetInt32("price-price*discount/100");
                    label5.Text += " " + s5;
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }
     
        private void Guest_Load(object sender, EventArgs e)
        {
            comboWho();
            if (label2.Text.ToString() == "admin" || label2.Text.ToString() == "user" || label2.Text.ToString() == "saler") {button4.Visible = true; button2.Visible = true; button5.Visible = true; button6.Visible = true;}
            else { button4.Visible = false; button2.Visible = false; button5.Visible = false; button6.Visible = false;}


            //all books to datagrid
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select namebook from bookstore.book;";

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

        //button Знайти by book
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

        //all books to datagrid by jenre
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select namebook from bookstore.book where jenre='"
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

        //authors,jenre,image to labels when book in datagrid clicked
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            comboAuthors(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            comboJenre(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            comboImage(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            comboDate(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        //button Menu not for user
        private void button4_Click(object sender, EventArgs e)
        {
            Menu f1 = new Menu(label1.Text.ToString());
            f1.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Button Реєстрація/Ввійти
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login f1 = new Login();
            f1.ShowDialog();
        }

        //Add to Корзина 
        private void button2_Click_1(object sender, EventArgs e)
        {
           
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Назва";
            dataGridView1.Columns[1].Name = "Ціна";

            string[] row = new string[] { dataGridView2.CurrentRow.Cells[0].Value.ToString(), label5.Text.ToString() };
            dataGridView1.Rows.Add(row);

          

        }


        //all books to datagrid
        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select namebook from bookstore.book;";

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

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Enabled = false;
            comboBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = false;

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            pictureBox1.Visible = false;
           
            dataGridView1.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;


            comboPrice();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.Enabled = true;
            comboBox2.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            textBox1.Enabled = true;

            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            pictureBox1.Visible = true;
            
            dataGridView1.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e) //видалити з кошика + обрахувати нову вартість
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);

            int rez = 0;
            for (int index = 0; index < dataGridView1.Rows.Count - 1; index++)
            {
                rez += int.Parse(dataGridView1[1, index].Value as string);
            }
            label8.Text = rez.ToString(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            NewOrder f1 = new NewOrder(label1.Text.ToString(),label8.Text.ToString());
            f1.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       
       
    }
}
