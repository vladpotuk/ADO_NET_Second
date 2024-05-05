using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class WarehouseItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Supplier { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public DateTime SupplyDate { get; set; }
    }

    public class DBManager
    {
        public string ConnectionString = "Data Source=(local);Initial Catalog=Склад;Integrated Security=True";

        public DBManager() { }

        public List<WarehouseItem> SelectAllItems()
        {
            try
            {
                List<WarehouseItem> items = new List<WarehouseItem>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Товари", connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WarehouseItem item = new WarehouseItem();
                            item.ID = reader.GetInt32(0);
                            item.Name = reader.GetString(1);
                            item.Type = reader.GetString(2);
                            item.Supplier = reader.GetString(3);
                            item.Quantity = reader.GetInt32(4);
                            item.Cost = reader.GetDecimal(5);
                            item.SupplyDate = reader.GetDateTime(6);
                            items.Add(item);
                        }
                    }
                }
                return items;
            }
            catch (SqlException ex)
            {
                throw new Exception("Помилка при вибірці даних з бази даних: " + ex.Message);
            }
        }

        public List<string> SelectAllTypes()
        {
            try
            {
                List<string> types = new List<string>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT Тип_товару FROM Товари", connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            types.Add(reader.GetString(0));
                        }
                    }
                }
                return types;
            }
            catch (SqlException ex)
            {
                throw new Exception("Помилка при вибірці типів товарів з бази даних: " + ex.Message);
            }
        }

        public List<string> SelectAllSuppliers()
        {
            try
            {
                List<string> suppliers = new List<string>();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT Постачальник_товару FROM Товари", connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(reader.GetString(0));
                        }
                    }
                }
                return suppliers;
            }
            catch (SqlException ex)
            {
                throw new Exception("Помилка при вибірці постачальників з бази даних: " + ex.Message);
            }
        }

        public WarehouseItem SelectItemWithMaxQuantity()
        {
            try
            {
                WarehouseItem item = new WarehouseItem();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Товари ORDER BY Кількість DESC", connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item.ID = reader.GetInt32(0);
                            item.Name = reader.GetString(1);
                            item.Type = reader.GetString(2);
                            item.Supplier = reader.GetString(3);
                            item.Quantity = reader.GetInt32(4);
                            item.Cost = reader.GetDecimal(5);
                            item.SupplyDate = reader.GetDateTime(6);
                        }
                    }
                }
                return item;
            }
            catch (SqlException ex)
            {
                throw new Exception("Помилка при вибірці товару з максимальною кількістю з бази даних: " + ex.Message);
            }
        }

        public WarehouseItem SelectItemWithMinQuantity()
        {
            try
            {
                WarehouseItem item = new WarehouseItem();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Товари ORDER BY Кількість ASC", connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item.ID = reader.GetInt32(0);
                            item.Name = reader.GetString(1);
                            item.Type = reader.GetString(2);
                            item.Supplier = reader.GetString(3);
                            item.Quantity = reader.GetInt32(4);
                            item.Cost = reader.GetDecimal(5);
                            item.SupplyDate = reader.GetDateTime(6);
                        }
                    }
                }
                return item;
            }
            catch (SqlException ex)
            {
                throw new Exception("Помилка при вибірці товару з мінімальною кількістю з бази даних: " + ex.Message);
            }
        }

        public WarehouseItem SelectItemWithMinCost()
        {
            try
            {
                WarehouseItem item = new WarehouseItem();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Товари ORDER BY Собівартість ASC", connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item.ID = reader.GetInt32(0);
                            item.Name = reader.GetString(1);
                            item.Type = reader.GetString(2);
                            item.Supplier = reader.GetString(3);
                            item.Quantity = reader.GetInt32(4);
                            item.Cost = reader.GetDecimal(5);
                            item.SupplyDate = reader.GetDateTime(6);
                        }
                    }
                }
                return item;
            }
            catch (SqlException ex)
            {
                throw new Exception("Помилка при вибірці товару з мінімальною собівартістю з бази даних: " + ex.Message);
            }
        }

        public WarehouseItem SelectItemWithMaxCost()
        {
            try
            {
                WarehouseItem item = new WarehouseItem();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Товари ORDER BY Собівартість DESC", connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item.ID = reader.GetInt32(0);
                            item.Name = reader.GetString(1);
                            item.Type = reader.GetString(2);
                            item.Supplier = reader.GetString(3);
                            item.Quantity = reader.GetInt32(4);
                            item.Cost = reader.GetDecimal(5);
                            item.SupplyDate = reader.GetDateTime(6);
                        }
                    }
                }
                return item;
            }
            catch (SqlException ex)
            {
                throw new Exception("Помилка при вибірці товару з максимальною собівартістю з бази даних: " + ex.Message);
            }
        }

        
    }
}
