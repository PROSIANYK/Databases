using System;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace LR_3
{
    class Program
    {
       
        static void Main(string[] args)
        {
           Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Console.WriteLine("Openning Connection...");

                conn.Open();

                Console.WriteLine("Connection successful!");
                QueryClient(conn);
                QueryCars(conn);
                QueryOrder(conn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            Console.Read();
                   
        }
       private static void QueryClient(MySqlConnection conn)
        {
            string id, name, address, phone, account;
            string sql = "Select client_id, name_client, address, phone_number, current_account from client;";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using(DbDataReader reader = cmd.ExecuteReader())
            {
                if(reader.HasRows)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Таблиця Клієнти: ");
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        id = reader["client_id"].ToString();
                        name = reader["name_client"].ToString();
                        address = reader["address"].ToString();
                        phone = reader["phone_number"].ToString();
                        account = reader["current_account"].ToString();
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(" Код: " + id + " Клієнт: " + name + " Адреса: " + address
                            + " Номер телефону: " + phone + " Рахунок: " + account);
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------");
                    }

                }
            }
        }
        private static void QueryCars(MySqlConnection conn)
        {
            string id, brand, model, company, price;
            string sql = "Select cars_id, brand_name, model_name, company, model_price from cars;";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Таблиця Автомобілі: ");
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        id = reader["cars_id"].ToString();
                        brand = reader["brand_name"].ToString();
                        model = reader["model_name"].ToString();
                        company = reader["company"].ToString();
                        price = reader["model_price"].ToString();
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(" Код: " + id + " Бранд автомобіля: " + brand + " Модель: " + model
                            + " Компанія: " + company + " Ціна: " + price);
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                    }

                }
            }

        }
   
        private static void QueryOrder(MySqlConnection conn)
        {
            string id, date1, cid, mid, amount, date2;
            string sql = "select order_id, date_of_completion, client_id, model_id, amount, delivery_date from mydb.order;";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Таблиця Замовлення : ");
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        id = reader["order_id"].ToString();
                        date1 = reader["date_of_completion"].ToString();
                        cid = reader["client_id"].ToString();
                        mid = reader["model_id"].ToString();
                        amount = reader["amount"].ToString();
                        date2 = reader["delivery_date"].ToString();
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(" Код Замовлення: " + id + " Дата замовлення: " + date1 + " Код клієнта: " + cid
                            + " Код моделі: " + mid + " Кількість: " + amount + " Дата отримання: " + date2);
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    }

                }
            }

        }
    }
}
