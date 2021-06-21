using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZakatApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ic_number { get; set; }
        public int Zakat_type { get; set; }
        public double Deduct_amt{ get; set; }
        public int District_code { get; set; }
        private readonly string connString = @"server=localhost;user id=root;password=;database=zakatpahang;";
        
        MySqlCommand command;
        public List<User> FetchAll()
        {
            List<User> list = new List<User>();

            
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                string query = "SELECT * FROM zakatpahang.users";
                command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.Id = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.Ic_number = reader.GetString(2);
                        user.Zakat_type = reader.GetInt32(3);
                        user.Deduct_amt = reader.GetDouble(4);
                        user.District_code = reader.GetInt32(5);
                        list.Add(user);
                    }
                }
            }

            return list;
        }
        public void Insert(List<Dictionary<string, string>> users)
        {
      
            using (MySqlConnection connection = new MySqlConnection(connString))
            {

                    foreach (Dictionary<string, string> user in users)
                    {
                        connection.Open();
                        string query = "INSERT INTO zakatpahang.users " +
                                        "(name, ic_number, zakat_type, deduct_amt, district_code)" +
                                        "VALUES(\""+ user["name"] + "\", " + user["ic_number"] + ", "
                                        +user["zakat_type"] + 
                                        ", " + Convert.ToDouble(user["deduct_amt"])/100 + ", " + 
                                        user["district_code"] + ")";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                    
                    }
            

            }
        }
    }
}