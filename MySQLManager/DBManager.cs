using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySQLManager
{
    class DBManager
    {
        public static MySqlConnection connection;



        /// <summary>
        /// Fonction qui se charge d'établir la connection à la base de données
        /// </summary>
        /// <param name="databaseName">Nom de la base de données</param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        static public void ConnectToDB(string server, int port, string databaseName,
                                                           string userName,
                                                           string password)
        {
            string connectionString = $"server={server};port={port};database={databaseName};user={userName};password={password};";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Connexion établie");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public MySqlConnection GetConnection()
        {
            return connection;
        }

        /// <summary>
        /// Termine la connexion à la base de données
        /// </summary>
        /// <param name="connection"></param>
        static public void CloseConnection(MySqlConnection connection)
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
            Console.WriteLine("Connection fermée");
        }

        /// <summary>
        /// Créer une table pour stocker des données dont la langue de saisie est le français (é, à, etc.)
        /// Deux colonnes sont créées, un id et une première colonne
        /// </summary>
        static public void CreateTable()
        {
            MySqlCommand Create_table = new MySqlCommand(@"
            CREATE TABLE `TABLE1` 
            (id INT NOT NULL AUTO_INCREMENT,
            colonne1 VARCHAR(15) NOT NULL, 
            PRIMARY KEY (id)) COLLATE='utf8_roman_ci';", connection); 
            //Ou peut-être 'utf8_general_ci', à voir comment la table gère les accents en français...
            Create_table.ExecuteNonQuery();
        }



    }
}
