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
using System.Net;
using System.Net.Sockets;


namespace КурсоваБД
{
    public partial class Dispatcher : Form
    {
        Socket socket;
        EndPoint epLocal, epRemote;

        public Dispatcher()
        {
            InitializeComponent();

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            textLocalIP.Text = getLocal();
            textFriendIP.Text = getLocal();
        }

        private string getLocal() 
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach(IPAddress ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    return ip.ToString();
                }
            }
            return "192.168.1.14";
        }

        private void messageCallBack(IAsyncResult async) 
        {
            try {
                int size = socket.EndReceiveFrom(async, ref epRemote);
                if (size > 0) {
                    byte[] receivedData = new byte[1464];
                    receivedData = (byte[])async.AsyncState;

                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    string receivedMessage = eEncoding.GetString(receivedData);
                    listBox1.Items.Add("Friend: " + receivedMessage);
                }
                byte[] buffer = new byte[1500];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(messageCallBack), buffer);
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Jobs_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            int i = random.Next(1, 4);
            if (i == 3)
            {
                label1.Text = "All drivers are on routes";
                button2.Visible = false;
             }
            else if (i == 1)
            {
                label1.Text = "One driver isn't on route. You can replace him from follow list";
                string query = "select idWorker,Name,Experience  from cursova.worker where Kind_of_work='Driver' order by Experience desc limit 2;";
                Func.SelectFunc(query, this.dataGridView1);
            }
            else if (i == 2)
            {
                label1.Text = "One driver isn't on route. You can replace him from follow list";
                string query = "select idWorker,Name,Experience from cursova.worker where Kind_of_work='Driver' order by Experience desc limit 5;";
                Func.SelectFunc(query, this.dataGridView1);
            }

         
            string query1 = "select Number from cursova.author;";
            Func.SelectFunc(query1, this.dataGridView2);

            string query2 = "select idTrolleybus from cursova.jenre;";
            Func.SelectFunc(query2, this.dataGridView3);
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        ///////tell about asign
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "We tell this driver about your choose";
            string query = "select Name,Email from cursova.worker where idWorker='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "';";
            Func.SelectFunc(query, this.dataGridView1);
        }


        /////asign
        private void button1_Click_1(object sender, EventArgs e)
        {
            string query = "update cursova.worker set Trolleybus_idTrolleybus='" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "', Trolleybus_Route_Number='" + dataGridView1.CurrentRow.Cells[5].Value.ToString() +
                "' where idWorker ='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "';";
            Func.AddFunc(query);
        }

        //////output all drivers
        private void button3_Click(object sender, EventArgs e)
        {
            string query = "select idWorker,Name,Experience,Email,Trolleybus_idTrolleybus,Trolleybus_Route_Number from cursova.worker where Kind_of_work='Driver';";
            Func.SelectFunc(query, this.dataGridView1);
            label1.Text = "All drivers";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(textLocalIP.Text), Convert.ToInt32(textLocalPort.Text));
                socket.Bind(epLocal);

                epRemote = new IPEndPoint(IPAddress.Parse(textFriendIP.Text), Convert.ToInt32(textFriendPort.Text));
                socket.Connect(epRemote);

                byte[] buffer = new byte[1500];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(messageCallBack), buffer);

                button4.Text = "Connected";
                button4.Enabled = false;
                button5.Enabled = true;
                textBox1.Focus();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            { 
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(textBox1.Text);

                socket.Send(msg);
                listBox1.Items.Add("You: " + textBox1.Text);
                textBox1.Clear();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
