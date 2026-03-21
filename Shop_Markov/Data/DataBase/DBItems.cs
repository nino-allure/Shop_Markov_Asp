using MySql.Data.MySqlClient;
using Shop_Markov.Common;
using Shop_Markov.Data.Interfaces;
using Shop_Markov.Data.Mocks;
using Shop_Markov.Data.Mocks.Models;
using Shop_Markov.Data.Models;
using System.Collections.Generic;
using System.Data;

namespace Shop_Markov.Data.DataBase
{
    public class DBItems : IItems
    {
        public IEnumerable<Categories> Categories = new DBCategory().AllCategories;

        public IEnumerable<Items> AllItems
        {
            get
            {
                List<Items> items = new List<Items>();
                MySqlConnection MySqlConnection = Connection.MySqlOpen();
                MySqlDataReader ItemsData = Connection.MySqlQuery("SELECT * FROM Shop.Items ORDER BY `Name`;", MySqlConnection);
                while (ItemsData.Read())
                {
                    items.Add(new Items()
                    {
                        Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                        Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                        Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                        Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                        Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                        Category = ItemsData.IsDBNull(5) ? null : Categories.Where(x => x.Id == ItemsData.GetInt32(5)).FirstOrDefault()
                    });
                }
                MySqlConnection.Close();
                return items;
            }
        }

        public int Add(Items Item)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery(
            $"INSERT INTO `Items` (`Name`, `Description`, `Img`, `Price`, `CategoryId`) VALUES ('{Item.Name}', '{Item.Description}', '{Item.Img}', '{Item.Price}', '{Item.Category.Id}');",
            MySqlConnection);
            MySqlConnection.Close();

            int IdItem = -1;
            MySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReaderItem = Connection.MySqlQuery(
                $"SELECT `id` FROM `items` WHERE `Name` = '{Item.Name}' AND `Description` =  '{Item.Description}' AND `Price` = '{Item.Price}' AND `CategoryId` = '{Item.Category.Id}';",
                MySqlConnection);
            if (mySqlDataReaderItem.HasRows)
            {
                mySqlDataReaderItem.Read();
                IdItem = mySqlDataReaderItem.GetInt32(0);
            }
            MySqlConnection.Close();
            return IdItem;
        }

        public bool Change(Items item)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();

            string query = @"
                UPDATE `Items` 
                SET `Name` = @Name, 
                    `Description` = @Description, 
                    `Img` = @Img, 
                    `Price` = @Price, 
                    `CategoryId` = @CategoryId 
                WHERE `Id` = @Id";

            MySqlCommand command = new MySqlCommand(query, mySqlConnection);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Parameters.AddWithValue("@Img", item.Img);
            command.Parameters.AddWithValue("@Price", item.Price);
            command.Parameters.AddWithValue("@CategoryId", item.Category.Id);
            command.Parameters.AddWithValue("@Id", item.Id);

            int rowsAffected = command.ExecuteNonQuery();
            mySqlConnection.Close();

            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();

            string query = "DELETE FROM `Items` WHERE `Id` = @Id";

            MySqlCommand command = new MySqlCommand(query, mySqlConnection);
            command.Parameters.AddWithValue("@Id", id);

            int rowsAffected = command.ExecuteNonQuery();
            mySqlConnection.Close();

            return rowsAffected > 0;
        }

        public Items GetItemById(int id)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();

            string query = @"
                SELECT i.*, c.Id as CategoryId, c.Name as CategoryName 
                FROM `Items` i
                INNER JOIN `Categories` c ON i.CategoryId = c.Id
                WHERE i.Id = @Id";

            MySqlCommand command = new MySqlCommand(query, mySqlConnection);
            command.Parameters.AddWithValue("@Id", id);

            MySqlDataReader reader = command.ExecuteReader();
            Items item = null;

            if (reader.Read())
            {
                item = new Items
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Description = reader.GetString("Description"),
                    Img = reader.GetString("Img"),
                    Price = reader.GetInt32("Price"),
                    Category = new Categories
                    {
                        Id = reader.GetInt32("CategoryId"),
                        Name = reader.GetString("CategoryName")
                    }
                };
            }

            reader.Close();
            mySqlConnection.Close();

            return item;
        }
    }
}