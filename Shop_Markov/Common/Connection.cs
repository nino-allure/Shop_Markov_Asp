using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Shop_Markov.Common
{
    public class Connection
    {
        readonly static string ConnectionData = "Server=127.0.0.1;port=3306;Database=Shop;Uid=root;Pwd=;";

        public static MySqlConnection MySqlOpen()
        {
            MySqlConnection NewMySqlConnection = new MySqlConnection(ConnectionData);
            NewMySqlConnection.Open();

            return NewMySqlConnection;
        }

        public static MySqlDataReader MySqlQuery(string Query, MySqlConnection Connection)
        {
            MySqlCommand NewMySqlCommand = new MySqlCommand(Query, Connection);
            return NewMySqlCommand.ExecuteReader();
        }

        public static void MySqlClose(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}