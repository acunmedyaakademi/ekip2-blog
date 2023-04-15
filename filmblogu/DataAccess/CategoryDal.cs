﻿
using filmblog.Models;
using System.Data.SqlClient;

namespace BlogAppADO.DataAccess
{
    public class CategoryDal
    {
        public string connectionString = ConnectionString.ConnectionValue;

        public List<Category> GetAll()
        {
            var categoryList = new List<Category>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT ID, Name, is_active FROM Categories", connection);
                var reader = command.ExecuteReader();


                while (reader.Read())
                {
                    var categoryItem = new Category();
                    categoryItem.Id = reader.GetInt32(0);
                    categoryItem.Name = reader.GetString(1);
                    categoryItem.Is_Active= reader.GetBoolean(2);

                    categoryList.Add(categoryItem);
                }
            }
            return categoryList;
        }

        public Category GetCategoryWithId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Categories WHERE ID = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                reader.Read();
                var categoryItem = new Category();
                categoryItem.Id = reader.GetInt32(0);
                categoryItem.Name = reader.GetString(1);
                categoryItem.Is_Active = reader.GetBoolean(2);

                return categoryItem;
            }
        }
    }
}
