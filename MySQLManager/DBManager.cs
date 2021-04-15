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
        private static MySqlConnection connection;



        /// <summary>
        /// Fonction qui se charge d'établir la connection à la base de données locale
        /// </summary>
        /// <param name="databaseName">Nom de la base de données</param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        static public void ConnectToDB(string server, string databaseName,
                                                           string userName,
                                                           string password)
        {
            string connectionString = $"server={server};port=3306;database={databaseName};user={userName};password={password};";

            MySqlConnection connection = new MySqlConnection(connectionString);

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

        static public void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }

            Console.WriteLine("Connection fermée");
        }



    }
}
