using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using ControlAguaPotable.Model;

namespace ControlAguaPotable.Controller
{
    internal class InventoryController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        private DataTable _inventoryDataTable = new DataTable();

        public DataTable ReadInventoryTableFromDb()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Inventory";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                {
                    adapter.Fill(_inventoryDataTable);
                }
            }
            
            return _inventoryDataTable;
        }

        public void InsertNewItemToDb(string description, int stock, decimal unitaryPrice)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                Inventory newItem = new Inventory
                {
                    Description = description,
                    Stock = stock,
                    UnitaryPrice = unitaryPrice
                };

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        
                        string query = "INSERT INTO Inventory (description, stock, unitaryPrice) VALUES (@description, @stock, @unitaryPrice)";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@description", newItem.Description);
                            cmd.Parameters.AddWithValue("@stock", newItem.Stock);
                            cmd.Parameters.AddWithValue("@unitaryPrice", newItem.UnitaryPrice);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        _inventoryDataTable.Clear();
                    }

                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        public void UpdateItemFromDb(int id, string description, int stock, decimal unitaryPrice)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                Inventory updateItem = new Inventory
                {
                    Description = description,
                    Stock = stock,
                    UnitaryPrice = unitaryPrice
                };

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        
                        string query = "UPDATE Inventory SET description = @description, stock = @stock, unitaryPrice = @unitaryPrice WHERE id = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@description", updateItem.Description);
                            cmd.Parameters.AddWithValue("@stock", updateItem.Stock);
                            cmd.Parameters.AddWithValue("@unitaryPrice", updateItem.UnitaryPrice);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }

                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void DeleteItemFromDb(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "DELETE FROM Inventory WHERE id = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }

                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }

    
}
