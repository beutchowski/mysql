using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace MySQLManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = "sql11.freemysqlhosting.net";
            int port = 3306;
            string databaseName = "sql11405918";
            string userName = "sql11405918";
            string password = "wCI1VVPfKg";


            DBManager.ConnectToDB(server, port, databaseName, userName, password);
            DBManager.GetConnection();
            try
            {
                DBManager.CreateTable();

                DBManager.CloseConnection(DBManager.connection);

            }   
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

    // Préparation de la commande SQL à envoyer
    //MySqlCommand cmd = connection.CreateCommand();

    //string nomDuContact = "C%";

    //// Construction de la requête de sorte à éviter le SQL-Injection
    //cmd.CommandText = "SELECT * FROM contact WHERE CONT_Nom LIKE @nom;";
    //cmd.Parameters.AddWithValue("@nom", nomDuContact);

    //// Envoi de la commande et récupération du lecteur de résultat
    //MySqlDataReader reader = cmd.ExecuteReader();

    //// Lecture, ligne par ligne du résultat de la requête
    //while (reader.Read())
    //{
    //    Console.WriteLine("{0} {1}", reader["CONT_Prenom"], reader["CONT_Nom"]);
    //}

    //reader.Close();

    //// Création d'une requête qui retourne un scalaire plutôt qu'une liste
    //// d'enregistrements.
    //MySqlCommand cmdCount = connection.CreateCommand();
    //cmdCount.CommandText = "SELECT COUNT(*) FROM contact WHERE CONT_Nom LIKE @nom;";
    //cmdCount.Parameters.AddWithValue("@nom", nomDuContact);

    //int count = Convert.ToInt32(cmdCount.ExecuteScalar());
    //Console.WriteLine("Nombre de contacts : {0}", count);


        }
    }
}
