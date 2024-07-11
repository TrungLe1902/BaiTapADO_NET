using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace QLSP_ADO_NET
{
    public class SQLDBHelper 
    {
        // Lấy danh sách tất cả sản phẩm
        public static List<QLProducts> GetQLSPMayTinhs()
        {
            var list = new List<QLProducts>();
            try
            {
                //Bước 1: Mở connectionString đến SqlSever
                var conn = ConnectSQLSeverDB.GetSqlConnection();

                //Bước 2: Dùng SqlCommand để gọi storeproceduce 
                var cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Bước 3: Sẽ dùng SqlReader để thực hiện lấy dữ liệu trong database
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var product = new QLProducts
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("Id")),
                        CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        CPU = reader.GetString(reader.GetOrdinal("CPU")),
                        ScreenSize = reader.GetString(reader.GetOrdinal("ScreenSize")),
                        RAM = reader.GetString(reader.GetOrdinal("RAM")),
                        Price = reader.GetInt32(reader.GetOrdinal("Price"))
                    };

                    list.Add(product);
                }  
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return list;
        }

        // Thêm danh mục mới
        public static void AddCategory(string categoryName)
        {
            try
            {
                var conn = ConnectSQLSeverDB.GetSqlConnection();
                var cmd = new SqlCommand("AddCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Thêm sản phẩm mới
        public static void AddProduct(QLProducts product)
        {
            try
            {
                var conn = ConnectSQLSeverDB.GetSqlConnection();
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

             
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@CPU", product.CPU);
                cmd.Parameters.AddWithValue("@ScreenSize", product.ScreenSize);
                cmd.Parameters.AddWithValue("@RAM", product.RAM);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
         
        public static void AddCategory(QLCategory category)
        {
            try
            {
                var conn = ConnectSQLSeverDB.GetSqlConnection();
                var cmd = new SqlCommand("AddCategory", conn);
                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);

                cmd.ExecuteNonQuery ();
                conn.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Sửa thông tin sản phẩm
        public static void UpdateProduct(QLProducts product)
        {
            try
            {
                var conn = ConnectSQLSeverDB.GetSqlConnection();
                var cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", product.ID);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@CPU", product.CPU);
                cmd.Parameters.AddWithValue("@ScreenSize", product.ScreenSize);
                cmd.Parameters.AddWithValue("@RAM", product.RAM);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Xóa sản phẩm
        public static void DeleteProduct(int productId)
        {
            try
            {
                var conn = ConnectSQLSeverDB.GetSqlConnection();
                var cmd = new SqlCommand("DeleteProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", productId);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


    }
}
