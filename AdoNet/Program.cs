using System;
using System.Data.SqlClient;
using Dapper;

namespace AdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.; Database=OnlineShop; Trusted_Connection=True; MultipleActiveResultSets=true";
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Execute("CREATE TABLE Users ([Id] INT PRIMARY KEY, " +
                    "[Name] NVARCHAR(100) NULL, [Age] INT NULL)");

                db.Execute("CREATE TABLE Products ( [Id] INT PRIMARY KEY, " +
                    "[Name] NVARCHAR(100) NULL, [Price] INT NULL)");

                db.Execute("INSERT INTO Users(Id, Name, Age) VALUES (1, 'James', 20), (2, 'Alex', 25)," +
                    "(3, 'John', 18), (4, 'Peter', 30), (5, 'Jason', 23)");

                db.Execute("INSERT INTO Products(Id, Name, Price) VALUES (1, 'Mouse', 300), (2, 'Keyboard', 500)," +
                    "(3, 'Headphones', 650), (4, 'Backpack', 400)");
            }

            var userRepo = new UserRepository();

            var paul = new User() { Id = 6, Name = "Paul", Age = 28 };
            var alex = new User() { Id = 2, Name = "Alex", Age = 33 };

            userRepo.Insert(paul);
            userRepo.Update(alex);
            userRepo.Delete(1);

            var productRepo = new ProductRepository();

            var iPhoneX = new Product() { Id = 5, Name = "iPhone X", Price = 10000 };
            var mouse = new Product() { Id = 1, Name = "Mouse Bluetooth", Price = 400 };

            productRepo.Insert(iPhoneX);
            productRepo.Update(mouse);
            productRepo.Delete(4);

            var users = userRepo.Read();
            var products = productRepo.Read();

            foreach (var a in users)
                Console.WriteLine(a);

            Console.WriteLine();

            foreach (var p in products)
                Console.WriteLine(p);

        }
    }
}
