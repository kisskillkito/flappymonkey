using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace kursova4
{
    class dBase
    {
        private static string connString = @"Data Source=DESKTOP-80E1B37\MSSQLSERVER01;Initial Catalog=baza;Integrated Security=True";

        public static DataTable Query(string query)
        {
            SqlConnection connect = new SqlConnection(connString);
            DataTable result = new DataTable();
            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand(@"get dateformat dmy " + query, connect);
                SqlCommand myCommand = new SqlCommand(query.ToString(), connect);
                SqlDataReader reader = command.ExecuteReader();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connect.State != ConnectionState.Closed)
                    connect.Close();
            }
            return result;
        }


        public int GetPersonalData(string query, string data)
        {
            int temp = 0;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format(query);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;

                                if (data.ToString() == (string)reader[i])
                                {
                                    temp = 1;
                                }
                                else
                                {
                                    temp = 0;
                                }
                                i++;
                            }
                        }
                    }
                    connection.Close();
                    return temp;
                }
                catch (Exception e)
                {
                    string Exc = String.Format("Connection Error \n more info:\n {0}", e.ToString());
                    MessageBox.Show(Exc);
                    return temp;
                }
            }
        }

        public int GetId(string query, string data)
        {
            int temp = 0;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format(query);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;

                                if (Convert.ToInt32(data.ToString()) == (int)reader[i])
                                {
                                    temp = 1;
                                }
                                else
                                {
                                    temp = 0;
                                }
                                i++;
                            }
                        }
                    }
                    connection.Close();
                    return temp;
                }
                catch (Exception e)
                {
                    string Exc = String.Format("Connection Error \n more info:\n {0}", e.ToString());
                    MessageBox.Show(Exc);
                    return temp;
                }
            }
        }
        public string GetFio(string query)
        {
            string temp = "0";
            using (SqlConnection connection = new SqlConnection(connString))
            {

                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(query);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            temp = reader[0].ToString();
                        }
                    }
                }
                connection.Close();
                return temp;
            }
        }


        public static void AddSoul(string fam, string name, string polis)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO pacient(fam, name, polis)  VALUES(@fam, @name, @polis)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("fam", fam));
                        command.Parameters.Add(new SqlParameter("name", name));

                        command.Parameters.Add(new SqlParameter("polis", polis));
                 

                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка!!!!");
                }
                connection.Close();
            }
        }
        public static void AddSoul2(string fam, string name, string polis, string spec, string anamez, string vrem, object date, string day)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO pacient(fam, name, polis, spec, anamez, vrem, date,day)  VALUES(@fam, @name, @polis, @spec, @anamez, @vrem, @date,@day)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("fam", fam));
                        command.Parameters.Add(new SqlParameter("name", name));

                        command.Parameters.Add(new SqlParameter("polis", polis));
                        command.Parameters.Add(new SqlParameter("spec", spec));
                        command.Parameters.Add(new SqlParameter("anamez", anamez));
                        command.Parameters.Add(new SqlParameter("date", date));
                        command.Parameters.Add(new SqlParameter("vrem", vrem));
                        command.Parameters.Add(new SqlParameter("day", day));


                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка!!!!");
                }
                connection.Close();
            }
        }
        public static void AddSoul1(string fam, string name, string polis, object date, string vrem, string spec, string anamez, string diagnoz)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO pacient(fam, name, polis, date, vrem, spec, anamez, diagnoz)  VALUES(@fam, @name, @polis, @date, @vrem, @spec, @anamez,@diagnoz)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("fam", fam));
                        command.Parameters.Add(new SqlParameter("name", name));

                        command.Parameters.Add(new SqlParameter("polis", polis));
                        command.Parameters.Add(new SqlParameter("date", date));
                        command.Parameters.Add(new SqlParameter("vrem", vrem));
                        command.Parameters.Add(new SqlParameter("spec", spec));
                        command.Parameters.Add(new SqlParameter("anamez", anamez));
                        command.Parameters.Add(new SqlParameter("diagnoz", diagnoz));


                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка!!!!");
                }
                connection.Close();
            }
        }
       
        public static void ChtecSoul(string id, string zaslugi, string grehi)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE Soul SET status=@status, zaslugi=@zaslugi, grehi=@grehi WHERE id=@id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("id", Convert.ToInt32(id)));
                        command.Parameters.Add(new SqlParameter("status", 2));
                        command.Parameters.Add(new SqlParameter("zaslugi", zaslugi));
                        command.Parameters.Add(new SqlParameter("grehi", grehi));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Count not insert.");
                }
                connection.Close();
            }
        }

        public static void PointPluse(string login)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE Sotrud SET point=point+1 WHERE login=@login", connection))
                    {
                        command.Parameters.Add(new SqlParameter("login", login));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Count not insert.");
                }
                connection.Close();
            }
        }

        public static void Delete(string name)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM Develop WHERE name = @name", connection))
                    {
                        command.Parameters.Add(new SqlParameter("name", name));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Count not insert.");
                }
                connection.Close();
            }
        }

        public static void Ochered(int id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("Select ochered FROM Soul WHERE id = @id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("ochered", id));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Count not insert.");
                }
                connection.Close();
            }
        }

        public static void Delete2(string FIO)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM Сотрудники WHERE FIO = @FIO", connection))
                    {
                        command.Parameters.Add(new SqlParameter("FIO", FIO));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Count not insert.");
                }
                connection.Close();
            }
        }

        public static void ChangeUser(string login, string pass)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE Autorz SET login = @login, pass = @pass WHERE login = @login)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("login", login));
                        command.Parameters.Add(new SqlParameter("pass", pass));
                      
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Count not insert.");
                }
                connection.Close();
            }
        }
        public static void spravka (int id, string anamez, string diagnoz)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE pacient SET anamez = @anamez, diagnoz = @diagnoz  WHERE id = @id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("id", id));
                        command.Parameters.Add(new SqlParameter("anamez", anamez));
                        command.Parameters.Add(new SqlParameter("diagnoz", diagnoz));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }
        public static void dopdiagno(int id, object date, string vrem)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE pacient SET date = @date, vrem = @vrem  WHERE id = @id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("id", id));
                        command.Parameters.Add(new SqlParameter("date", date));
                        command.Parameters.Add(new SqlParameter("vrem", vrem));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }

    }
}
