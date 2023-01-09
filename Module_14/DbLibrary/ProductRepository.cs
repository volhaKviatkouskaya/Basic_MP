using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DbLibrary
{
    public class ProductRepository<T> : IRepository<T> where T : ProductEntity
    {
        private readonly string _connString = Properties.Settings.Default.OrderConnectionString;

        private void ExecuteQuery(string query)
        {
            var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();
            var command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void CreateItem(T item)
        {
            var query = "INSERT INTO dbo.Products " +
                        "(name, description, weight, height, width, length) " +
                        $"VALUES ('{item.Name}', '{item.Description}', {item.Weight}, {item.Height}, {item.Width}, {item.Length})";

            ExecuteQuery(query);
        }

        public T SelectItemById(int itemId)
        {
            var query = "SELECT * FROM dbo.Products " +
                        $"WHERE product_id = {itemId}";

            var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();
            var command = new SqlCommand(query, sqlConnection);

            var dataReader = command.ExecuteReader();
            ProductEntity product = null;

            if (dataReader.Read())
            {
                product = new ProductEntity()
                {
                    ProductId = (int)dataReader[0],
                    Name = dataReader[1].ToString(),
                    Description = dataReader[2].ToString(),
                    Height = (int)dataReader[3],
                    Weight = (int)dataReader[4],
                    Length = (int)dataReader[5],
                    Width = (int)dataReader[6],
                };
            }

            sqlConnection.Close();

            return (T)product;
        }

        public List<T> SelectAll()
        {
            var query = "SELECT * " +
                        "FROM dbo.Products";

            var sqlConnection = new SqlConnection(_connString);
            var command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            var productsList = new List<T>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString()
                    };

                    var product = ConvertToEntities(item);
                    productsList.Add((T)product);
                }
            }

            return productsList;
        }

        private static T ConvertToEntities(string[] inputList)
        {
            var product = new ProductEntity()
            {
                ProductId = inputList[0] == null ? 0 : Convert.ToInt32(inputList[0]),
                Name = inputList[1],
                Description = inputList[2],
                Height = inputList[3] == null || inputList[3] == string.Empty ? 0 : Convert.ToInt32(inputList[3]),
                Weight = inputList[4] == null || inputList[4] == string.Empty ? 0 : Convert.ToInt32(inputList[4]),
                Length = inputList[5] == null || inputList[5] == string.Empty ? 0 : Convert.ToInt32(inputList[5]),
                Width = inputList[6] == null || inputList[6] == string.Empty ? 0 : Convert.ToInt32(inputList[6]),
            };

            return (T)product;
        }

        public void UpdateItem(T item)
        {
            var query = "UPDATE dbo.Products " +
                        $"SET name = '{item.Name}', description = '{item.Description}', weight = {item.Weight}," +
                        $" height = {item.Height}, width = {item.Width}, length = {item.Length}" +
                        $"WHERE product_id = {item.ProductId}";

            ExecuteQuery(query);
        }

        public void DeleteItem(int itemId)
        {
            var query = "DELETE FROM dbo.Products " +
                        $"WHERE product_id = {itemId}";

            ExecuteQuery(query);
        }
    }
}
