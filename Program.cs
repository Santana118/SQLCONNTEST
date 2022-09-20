using System;
using System.Data.SqlClient;
using SQLCONNTEST.Models;

namespace SQLCONNTEST
{
    class Program
    {
        SqlConnection conn;
        string connectionString =
                "Data Source=WINDOWS-PC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=TokoKelontong;User ID=WINDOWS-PC\\Santana;Password=mateyize49;";
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("DATABASE TokoKelontong version 0.0.1 alpha");
            Customer customer = new Customer();
            while (true)
            {
                
                Console.WriteLine(" ");
                Console.WriteLine("What you want to do ? ");
                Console.WriteLine("1. Show All Customer List ");
                Console.WriteLine("2. Add new Customer ");
                Console.WriteLine("3. Update Customer ");
                Console.WriteLine("4. Update Customer ");
                Console.WriteLine("0. Exit application ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Exiting application ....");
                        return;
                    case "1":
                        //Console.WriteLine("Chosing Option 1");
                        program.showAllCustomer();
                        break;
                    case "2":
                        Console.WriteLine("Insert new customer name :");
                        customer.Name = Console.ReadLine();
                        program.addCustomer(customer);
                        break;
                    case "3":
                        Console.WriteLine("Enter customer ID :");
                        customer.Id = Console.ReadLine();
                        Console.WriteLine("Enter customer Name :");
                        customer.Name = Console.ReadLine();                  
                        program.updateCustomer(customer);
                        break;
                    default:
                        Console.WriteLine("Unrecognized User input");
                        break;
                }
            }
            
        }
        void showAllCustomer()
        {
            string query = "SELECT * FROM Customer;";
            

            conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine("Show All Customer List");
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " - " + sqlDataReader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        void addCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();

                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@name";
                sqlParameter.Value = customer.Name;

                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Customer " +
                        "VALUES (@name)";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        void updateCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();

                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@name";
                sqlParameter.Value = customer.Name;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@id";
                sqlParameter2.Value = customer.Id;

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter2);

                try
                {
                    sqlCommand.CommandText = "UPDATE Customer " +
                        "SET nama = @name WHERE id = @id;";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        void deleteCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();

                SqlCommand sqlCommand = conn.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = customer.Id;

                sqlCommand.Parameters.Add(sqlParameter);

                try
                {
                    sqlCommand.CommandText = "DELETE FROM Customer " +
                        "WHERE id = @id;";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
    
}
