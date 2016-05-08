using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace КурсоваБД
{
    class LogCon:Connection
    {
       static public void Enter(string s1,string s2)
        {
            using (MySqlCommand c = new MySqlCommand("select * from bookstore.worker where workername = '" + s1 + "'and password='" + s2 + "';", connn))
            {
                try
                {

                        MySqlDataReader myreader;
                        connn.Open();
                        myreader = c.ExecuteReader();  //команда в myreader

                        int count = 0;
                        while (myreader.Read())  //поки виконання myreader
                        {
                            count += 1;    //змінна яка рахує кількість спроб ввійти
                        }
                        if (count == 1)    //якщо користувач ввійшов за першим разом, тобто ввів правильний нікнейм і пароль 
                        {
                            connn.Close();
                            myreader.Close();
                            c.Connection.Close();
                            c.Dispose();
                            
                            Guest f4 = new Guest(s1);
                            f4.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Password or nickname failed");
                            connn.Close();
                            myreader.Close();
                            c.Connection.Close();
                            Connection.connn.Dispose();
                        }
                    //}
                }
                catch (Exception e)
                {
                     
                     MessageBox.Show("Продовжити?"+e.ToString());
                     connn.Close();
                     //tran.Rollback();
                     Seller f3 = new Seller();
                     f3.ShowDialog();
                }
            
            }
        }


       static public void AddUser(string kind, string name, string password, string age, string email)
       {

           try
           {

               connn.Open();

               tran = connn.BeginTransaction();
               MySqlCommand c = new MySqlCommand("insert into bookstore.worker(kind,workername,password,ageworker,email) values ('"
                       + kind + "','" + name + "','" + password + "','" + age + "','" + email + "');", connn);
               c.Transaction = tran;
               c.ExecuteNonQuery();
              
               tran.Commit();
               MessageBox.Show("Збережено");
               connn.Close();
           }
           catch (Exception ex)
           {
               tran.Rollback();
               // connn.Close();
               MessageBox.Show("");
           }

       }
    }
}
