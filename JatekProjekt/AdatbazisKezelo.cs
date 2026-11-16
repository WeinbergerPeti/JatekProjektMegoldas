using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{

    public class AdatbazisKezelo
    {
        private readonly string connectionString;


        public AdatbazisKezelo()
        {

            this.connectionString = "server=localhost;port=3306;user=root;password=;database=JatekDB";// Irjuk meg a connectionstringet a megfelelő adatbázisra hivatkozva
        }

   
        /// Beolvassa az összes karaktert az adatbázisból egy List<Karakter>-be.
       
        public List<Karakter> AdatokBetoltese()
        {
            var karakterek = new List<Karakter>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "select * from karakterek";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            //Id, Nev, Osztaly, Szint, Arany, Szerver
                            Karakter karakter = new Karakter(
                                    //Convert.ToInt32(reader["Id"]),
                                    //reader["Nev"].ToString(),
                                    //reader["Osztaly"].ToString(),
                                    //Convert.ToInt32(reader["Szint"]),
                                    //Convert.ToInt32(reader["Arany"]),
                                    //reader["Szerver"].ToString()
                                    reader.GetInt32("Id"),
                                    reader.GetString("Nev"),
                                    reader.GetString("Osztaly"),
                                    reader.GetInt32("Szint"),
                                    reader.GetInt32("Arany"),
                                    reader.GetString("Szerver")
                                );

                            karakterek.Add(karakter);
                        }
                    }
                }
            }

            return karakterek;
        }
    }
}
