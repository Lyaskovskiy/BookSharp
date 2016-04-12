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
    public partial class Mechanic : Form
    {
        public Mechanic()
        {
            InitializeComponent();
            timer1.Start();
            comboDate(); //вивід наступної дати техогляду

            password.PasswordChar = '*';
        }

        //функція підрахунку кількості тролейбусів з технічним станом "Bad"
        void comboCount()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";  //стрічка зєднання
            string s2 = "select count(idTrolleybus) from cursova.jenre where Stan ='Bad';";  //запит
            MySqlConnection connn = new MySqlConnection(s1);  //початок зєднання
            MySqlCommand c = new MySqlCommand(s2, connn);  //MySQL команда-ініціалізація
            MySqlDataReader myreader;  //myreader для виконання команди
            try
            {
                connn.Open();  //початок зєднання
                myreader = c.ExecuteReader();  //посилає команду в конекш з початком виконання myreader
                while (myreader.Read()) //поки myreader зчитує команду
                {
                    string s3 = myreader.GetInt32("count(idTrolleybus)").ToString(); //підрахунок кількості поганих тролейбусів
                    label2.Text = s3;
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }


        //функція виводу наступної дати технічного огляду
        void comboDate()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select Date_view from cursova.jenre where Date_view > '" + textBox2.Text + "' group by Date_view limit 1;";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetDateTime("Date_view").ToString();
                    textBox3.Text = s3;
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }


        //вивід фото і нотаток про технічний стан тролейбуса при вибраному рядку з dataGridView
        void comboPhoto()
        {
            string s1 = "datasource=localhost;port=3306;username=root;password=ttt";
            string s2 = "select Photo,Notes from cursova.jenre where idTrolleybus ='"+ dataGridView1.CurrentRow.Cells[0].Value.ToString() +"';";
            MySqlConnection connn = new MySqlConnection(s1);
            MySqlCommand c = new MySqlCommand(s2, connn);
            MySqlDataReader myreader;
            try
            {
                connn.Open();
                myreader = c.ExecuteReader();
                while (myreader.Read())
                {
                    string s3 = myreader.GetString("Notes");
                    textBox4.Text = s3;
                    byte[] array = (byte[])(myreader["Photo"]); //створення масиву байт
                    if (array == null) pictureBox1.Load("C:\\DB\\que.png"); //вивід знака питання
                    else { MemoryStream mystream = new MemoryStream(array); pictureBox1.Image = System.Drawing.Image.FromStream(mystream); }  //потік з виведенням фото
                }
            }
            catch (Exception e)
            {
                connn.Close();
            }
        }

        
        private void Mechanic_Load(object sender, EventArgs e)
        {
            pictureBox1.Load("C:\\TBus\\umz-t2.jpg");

            //виклик функції перевірки чи є тролейбуси з незадовільним станом.Якщо є - попередження про їх кількість
            comboCount();
            int c =int.Parse(label2.Text);
            if (c != 0) { MessageBox.Show("!WARNING!\nThere are "+c+" trolleybuses, which are bad!\nReview your table."); }
           
            //вивід всіх тролейбусів в DataGridView
            string query1 = "select idTrolleybus,Name,Type,Number_of_doors,Year,Garanty,Date_view,Serial_number,Stan from cursova.jenre;";
            Func.SelectFunc(query1, this.dataGridView1);   
  
            //вивід поламаних тролейбусів
            string query2 = "select idTrolleybus,Name,Date_view from cursova.jenre where Stan='Bad';";
            Func.SelectFunc(query2, this.dataGridView2); 
        }


         //загрузка фото тролейбуса з комп'ютера
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();  //діалогове вікно
            foto.Filter = "JPG Files(*.jpg)|*.jpg| PNG Files(*.png)|*.png";  //фільтр можливих малюнків
            foto.Title = "Select Trolleybus picture";  //просто назва
            if (foto.ShowDialog() == DialogResult.OK)  //якщо фото загрузилося
            {
                string picture = foto.FileName.ToString();  //шлях до файла
                textBox1.Text = picture;  //шлях до файлу в текстбокс для подальшої вставки в БД
                pictureBox1.ImageLocation = picture; //вивід фото в pictureBox
            }
        }

        //insert new trolleybus
        private void button3_Click_1(object sender, EventArgs e)
        {
            string query2 = "insert into cursova.jenre(Name,Type,Number_of_doors,Year,Garanty,Date_view,Serial_number,Stan,Photo) values ('"
          + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "','" +
          dataGridView1.CurrentRow.Cells[3].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "','" +
          dataGridView1.CurrentRow.Cells[5].Value.ToString() + "','" + dateTimePicker1.Text + "','" +
          dataGridView1.CurrentRow.Cells[7].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[8].Value.ToString() + "',@IMG);";
            Func.ImageFunc(query2, textBox1.Text.ToString());
           // this.Refresh();
        }
        
         //update trolleybus
        private void button4_Click_1(object sender, EventArgs e)
        {
            string query2 = "update cursova.jenre set Name='"
          + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "',Type='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "',Number_of_doors='" +
          dataGridView1.CurrentRow.Cells[3].Value.ToString() + "',Year='" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "',Garanty='" +
          dataGridView1.CurrentRow.Cells[5].Value.ToString() + "',Date_view='" + dateTimePicker1.Text + "',Serial_number='" +
          dataGridView1.CurrentRow.Cells[7].Value.ToString() + "',Stan='" + dataGridView1.CurrentRow.Cells[8].Value.ToString() + "',Notes='" + textBox4.Text.ToString() + "' where idTRolleybus='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "';";
            Func.AddFunc(query2);
           // this.Refresh();
        }

        //delete trolleybus
        private void button5_Click_1(object sender, EventArgs e)
        {
            string query2 = "delete from cursova.jenre where idTrolleybus='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "';";
            Func.AddFunc(query2);
           // this.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //вивід фото тролейбуса і нотаток про технічний стан при натисненні на відповідний рядок в gataGridView
            comboPhoto();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            textBox2.Text = time.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void send_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage(from.Text, to.Text, subject.Text, body.Text);
            mail.Attachments.Add(new Attachment(attach.Text));
            SmtpClient client = new SmtpClient(smtp.Text);
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(username.Text, password.Text);
            client.EnableSsl = true;
            client.Send(mail);
            MessageBox.Show("Email sent", "Success", MessageBoxButtons.OK);
        }

        private void attachBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog dl = new OpenFileDialog();
            if (dl.ShowDialog() == DialogResult.OK)
            {
                string picPath = dl.FileName.ToString();
                attach.Text = picPath;
            }
        }
    }
}
