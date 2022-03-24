using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AdoNet
{
    public class UserRepository : IRepository<User>
    {
        string connectionString = "Server=.; Database=OnlineShop; Trusted_Connection=True; MultipleActiveResultSets=true";

        public void Insert(User item)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var insert = "INSERT INTO Users(Id, Name, Age) VALUES(@Id, @Name, @Age)";
                db.Execute(insert, item);
            }
        }

        public List<User> Read()
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        public void Update(User item)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var update = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(update, item);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                var delete = "DELETE FROM Users WHERE Id = @id";
                db.Execute(delete, new { id });
            }
        }
    }
}
