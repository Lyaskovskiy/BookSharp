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
            string query = "select Name, Kind_of_work,Experience,Email from cursovaBD.worker where Name like '%" + textBox1.Text.ToString() + "%';";
            Func.SelectFunc(query, dataGridView1);
        }

        //вивід всіх працівників 
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "select Name, Kind_of_work,Experience,Email from cursovaBD.worker where Kind_of_work='Driver' or Kind_of_work='Mechanic' or Kind_of_work='Manager' or Kind_of_work='Dispatcher';";
            Func.SelectFunc(query, dataGridView1);
        }

        //видалення вибраного працівника
        private void button3_Click(object sender, EventArgs e)
        {
            string query2 = "delete from cursovaBD.worker where Name='"
                       + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "';";
            Func.AddFunc(query2);
        }

        private void Administrator_Load(object sender, EventArgs e)
        {

        }
    }
}
