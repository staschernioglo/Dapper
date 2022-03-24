using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AdoNet
{
    public class ProductRepository : IRepository<Product>
    {

        string connectionString = "Server=.; Database=OnlineShop; Trusted_Connection=True; MultipleActiveResultSets=true";

        public void Insert(Product item)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var insert = "INSERT INTO Products(Id, Name, Price) VALUES(@Id, @Name, @Price)";
                db.Execute(insert, item);
            }
        }

        public List<Product> Read()
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Product>("SELECT * FROM Products").ToList();
            }
        }

        public void Update(Product item)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var update = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";
                db.Execute(update, item);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var delete = "DELETE FROM Products WHERE Id = @id";
                db.Execute(delete, new { id });
            }
        }
    }
}
