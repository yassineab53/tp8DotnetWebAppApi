using System;

using Microsoft.Data.SqlClient;
using AppWeb1.Models;
using System.Data;
using System.Collections.Generic;

namespace AppWeb1.Repositories
{
    public class ProduitRepository
    {
        private string conn;

        public ProduitRepository(string connectionString)
        {
            conn = connectionString;
        }

        public List<ProduitModel> GetAllProducts()
        {
            var produits = new List<ProduitModel>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                string cmd = "SELECT id, libelle, prix FROM Produits";

                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produits.Add(new ProduitModel
                            {
                                Id = reader.GetInt32(0),
                                libelle = reader.GetString(1),
                                prix = (float)reader.GetDouble(2)
                            });
                        }
                    }
                }
            }

            return produits;
        }

        public void AddProduct(string libelle, float prix)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string cmd = "INSERT INTO Produits (libelle, prix) VALUES (@Libelle, @Prix)";

                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    command.Parameters.AddWithValue("@Libelle", libelle);
                    command.Parameters.AddWithValue("@Prix", prix);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(int id, string libelle, float prix)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "UPDATE Produits SET libelle = @Libelle, prix = @Prix WHERE id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Libelle", libelle);
                    command.Parameters.AddWithValue("@Prix", prix);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public void DeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "DELETE FROM Produits WHERE id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
    }
}