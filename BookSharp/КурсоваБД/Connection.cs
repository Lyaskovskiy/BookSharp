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
   public class Connection : IDisposable
    {
        static public MySqlTransaction tran; //оголошення змінної транзакцї
       
        //оголошення з'єднання з стрічкою з'єднання(джерело, порт, імя користувача, пароль)
        static public MySqlConnection connn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=ttt"); 
       
        public void Dispose()
        {
           connn.Dispose();
        }
        public void Open()
        {
            connn.Open();
        }
        public void Close()
        {
            connn.Close();
        }
    }


   class Func : Connection
   {
       static public void AddFunc(string s1)
       {
           try
           {
               connn.Open();  //відкриття конекшена
               tran = connn.BeginTransaction();   //створення транзакції

               MySqlCommand cmd = new MySqlCommand(s1, connn);   //створення команди

               cmd.Transaction = tran;  //транзакція

               cmd.ExecuteNonQuery();  //виконання команди

               tran.Commit(); //підтвердження транзакції
               connn.Close();  //закриття зєднання
              // MessageBox.Show("Saved");    //повідомлення про успішне виконання

           }
               //прехоплення помилки, закриття зєднання, відміна транзакції
           catch (MySql.Data.MySqlClient.MySqlException ex) { MessageBox.Show("Така книга вже зареєстрована"); connn.Close(); tran.Rollback();
           }
      }


       static public void ImageFunc(string s1, string s2)  //стрічка запиту і шлях до фото на компютера
       {
           byte[] array = null;  //створення масиву байтів для запису
           FileStream fstream = new FileStream(s2, FileMode.Open, FileAccess.Read);  //створення потоку зчитування файла-фото
           BinaryReader br = new BinaryReader(fstream);  //потік для зчитування байтів
           array = br.ReadBytes((int)fstream.Length);  //запис в масив байтів фото

           using (MySqlCommand c = new MySqlCommand(s1, connn))
           {
               MySqlDataReader myreader;
               connn.Open();

               c.Parameters.Add(new MySqlParameter("@IMG", array));  //параметри вставки - змінна для фото, масив
               myreader = c.ExecuteReader();

               connn.Close();
               myreader.Close();
           }
       }


       static public void SelectFunc(string s1, DataGridView table)
       {
           try
           {
               using (MySqlCommand c = new MySqlCommand(s1, connn))
               {
                   MySqlDataAdapter myadapq = new MySqlDataAdapter(); //створення адаптера для реалізації виводу
                   myadapq.SelectCommand = c;  //визначення адаптером команди
                   DataTable ds = new DataTable();  //створення обєкту таблиці
                   myadapq.Fill(ds);  //виконання
                   BindingSource bbb = new BindingSource();  //створення джерела для результатів

                   bbb.DataSource = ds;  //передавання таблиці
                   table.DataSource = bbb;  //вивід в dataGridView таблиці
                   myadapq.Update(ds);  

                   connn.Close();
                   myadapq.Dispose();
               }
           }
           catch (Exception ex) { MessageBox.Show("You duplicate route"); connn.Close(); }
       }
   }
}
