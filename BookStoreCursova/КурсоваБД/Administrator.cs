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
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

        //пошук працівника за введиним ім'ям 
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "")
            {
                string query = "select workername,kind,experience,ageworker,email from bookstore.worker where kind='';";
                Func.SelectFunc(query, dataGridView1);

                MySqlConnection connn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=ttt");
                MySqlCommand comand = new MySqlCommand("select * from bookstore.worker where kind='';", connn);
                MySqlDataReader myreader;
                try
                {
                    connn.Open();
                    myreader = comand.ExecuteReader();

                    while (myreader.Read())
                    {
                        this.chart1.Series["Age"].Points.AddXY(myreader.GetString("workername"), myreader.GetInt32("ageworker"));
                       // this.chart1.Series["Experience"].Points.AddXY(myreader.GetString("workername"), myreader.GetInt32("experience"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                string query1 = "select workername,kind,experience,ageworker,email from bookstore.worker where workername like '%" + textBox1.Text.ToString() + "%';";
                Func.SelectFunc(query1, dataGridView1);
            }
        }

        //вивід всіх працівників 
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "select workername,kind,experience,ageworker,email from bookstore.worker";
            Func.SelectFunc(query, dataGridView1);

          

            
        
        }

        //видалення вибраного працівника
        private void button3_Click(object sender, EventArgs e)
        {
            string query2 = "delete from bookstore.worker where workername='"
                       + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "';";
            Func.AddFunc(query2);
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            string query = "select workername,kind,experience,ageworker,email from bookstore.worker where kind='';";
            Func.SelectFunc(query, dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query1 = "update bookstore.worker set kind='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "',experience='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'where workername='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "';";
            Func.AddFunc(query1);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
