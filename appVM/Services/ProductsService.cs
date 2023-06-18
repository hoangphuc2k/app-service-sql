using System;
using System.Data.SqlClient;
using appVM.Models;
using Microsoft.FeatureManagement;

namespace appVM.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IConfiguration configuration;
        private readonly IFeatureManager featureManager;

        public ProductsService(IConfiguration configuration, IFeatureManager featureManager)
        {
            this.configuration = configuration;
            this.featureManager = featureManager;
        }

        public async Task<bool> isBeta() {
            return await this.featureManager.IsEnabledAsync("beta");
        }

        private SqlConnection getConnection()
        {
            return new SqlConnection(configuration["SqlConnectionString"]);
        }

        public List<Products> getProducts()
        {
            SqlConnection sqlConnection = getConnection();

            List<Products> products = new List<Products>();

            String query = "SELECT productId,productName,quantity FROM Products";

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products product = new Products()
                    {
                        productId = reader.GetInt32(0),
                        productName = reader.GetString(1),
                        quantity = reader.GetInt32(2),
                    };

                    products.Add(product);
                }
            }

            sqlConnection.Close();

            return products;

        }
    }
}

