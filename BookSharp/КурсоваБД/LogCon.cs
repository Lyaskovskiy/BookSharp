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
            using (MySqlCommand c = new MySqlCommand("select * from cursova.Worker where Name = '" + s1 + "'and Password='" + s2 + "';", connn))
            {
                try
                {
                    if ((s1 == "Guest" || s1 == "") && s2 == "") {Guest f5=new Guest(); f5.ShowDialog(); }
                    else
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
                            
                            Menu f4 = new Menu(s1);
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
                    }
                }
                catch (Exception e)
                {
                     connn.Close();
                     MessageBox.Show("Main^"+e.Message);
                }
            
            }
        }


       static public void AddUser(string kind, string name, string password, string experience, string email)
       {

           try
           {

               connn.Open();

               tran = connn.BeginTransaction();
               MySqlCommand c = new MySqlCommand("insert into cursova.Worker(Kind_of_work,Name,Password,Experience,Email) values ('"
                       + kind + "','" + name + "','" + password + "','" + experience + "','" + email + "');", connn);
               c.Transaction = tran;
               c.ExecuteNonQuery();
              
               tran.Commit();
               MessageBox.Show("Saved");
               connn.Close();
           }
           catch (Exception ex)
           {
               tran.Rollback();
               // connn.Close();
               MessageBox.Show("You duplicate person or incorrect data");
           }

       }
    }
}
