using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace DbLibrary
{
    public class OrderRepository<T> : IRepository<T> where T : OrderEntity
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
            var query = "INSERT INTO dbo.Orders " +
                        "(status, created_date, updated_date, product_id) " +
                        $"VALUES ({item.Status}, '{item.CreatedDate}', '{item.UpdatedDate}', {item.ProductId})";

            ExecuteQuery(query);
        }

        public T SelectItemById(int itemId)
        {
            var query = "SELECT * FROM dbo.Orders " +
                        $"WHERE order_id = {itemId}";

            var sqlConnection = new SqlConnection(_connString);
            sqlConnection.Open();
            var command = new SqlCommand(query, sqlConnection);

            var dataReader = command.ExecuteReader();
            OrderEntity order = null;

            if (dataReader.Read())
            {
                order = new OrderEntity()
                {
                    OrderId = (int)dataReader[0],
                    Status = Convert.ToInt32(dataReader[1]),
                    CreatedDate = Convert.ToDateTime(dataReader[2].ToString()),
                    UpdatedDate = Convert.ToDateTime(dataReader[3]),
                    ProductId = Convert.ToInt32(dataReader[4])
                };
            }

            sqlConnection.Close();

            return (T)order;
        }

        public List<T> SelectAll()
        {
            var query = "SELECT * " +
                        "FROM dbo.Orders";

            var sqlConnection = new SqlConnection(_connString);
            var command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            var ordersList = new List<T>();

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
                        reader[4].ToString()
                    };

                    var product = ConvertToEntities(item);
                    ordersList.Add((T)product);
                }
            }

            return ordersList;
        }

        private static T ConvertToEntities(string[] inputList)
        {
            var order = new OrderEntity()
            {
                OrderId = inputList[0] == null ? 0 : Convert.ToInt32(inputList[0]),
                Status = inputList[1] == null || inputList[1] == string.Empty ? 0 : Convert.ToInt32(inputList[1]),
                CreatedDate = Convert.ToDateTime(inputList[2]),
                UpdatedDate = Convert.ToDateTime(inputList[3]),
                ProductId = Convert.ToInt32(inputList[4])
            };

            return (T)order;
        }

        public void UpdateItem(T item)
        {
            var query = "UPDATE dbo.Orders " +
                        $"SET status = {item.Status}, updated_date = '{item.UpdatedDate}', product_id = {item.ProductId} " +
                        $"WHERE order_id = {item.OrderId}";

            ExecuteQuery(query);
        }

        public void DeleteItem(int itemId)
        {
            var query = "DELETE FROM dbo.Orders " +
                        $"WHERE order_id = {itemId}";

            ExecuteQuery(query);
        }
    }
}
