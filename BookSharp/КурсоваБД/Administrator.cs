using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (textBox1.Text.ToString() == "") {
                string query = "select Name,Kind_of_work,Experience,Email from cursova.worker where Kind_of_work='';";
                Func.SelectFunc(query, dataGridView1);
            }
            string query1 = "select Name,Kind_of_work,Experience,Email from cursova.worker where Name like '%" + textBox1.Text.ToString() + "%';";
            Func.SelectFunc(query1, dataGridView1);
        }

        //вивід всіх працівників 
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "select Name,Kind_of_work,Experience,Email from cursova.worker where Kind_of_work='driver' or Kind_of_work='manager';";
            Func.SelectFunc(query, dataGridView1);
        }

        //видалення вибраного працівника
        private void button3_Click(object sender, EventArgs e)
        {
            string query2 = "delete from cursova.worker where Name='"
                       + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "';";
            Func.AddFunc(query2);
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            string query = "select Name,Kind_of_work,Experience,Email from cursova.worker where Kind_of_work='';";
            Func.SelectFunc(query, dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query1 = "update cursova.worker set Kind_of_work='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "',Experience='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'where Name='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "';";
            Func.AddFunc(query1);
        }
    }
}
