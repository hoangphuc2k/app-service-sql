using System;
using System.Data.SqlClient;
using appVM.Models;

namespace appVM.Services
{
	public class ProductsService : IProductsService
    {
		private readonly IConfiguration configuration;

		public ProductsService(IConfiguration configuration) {
			this.configuration = configuration;
		}
		
		private SqlConnection getConnection()
		{
			return new SqlConnection(configuration.GetConnectionString("SqlConnectionString"));
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

