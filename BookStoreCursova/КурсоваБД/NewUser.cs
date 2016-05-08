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
    public partial class NewUser : Form
    {
        public NewUser(string strAdm)
        {
            InitializeComponent();
            label5.Text = strAdm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogCon.AddUser(this.textBox1.Text.ToString(), this.textBox2.Text.ToString(), this.textBox3.Text.ToString(), this.textBox4.Text.ToString(), this.textBox6.Text.ToString());
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            if (label5.Text.ToString() == "admin") {
                textBox1.Enabled = true;
                textBox4.Enabled = true;
            };
        }    
    }
}
