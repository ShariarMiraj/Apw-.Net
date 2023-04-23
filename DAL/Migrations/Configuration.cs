namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.PcBuildContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.PcBuildContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            for (int i =1; i <=5; i++) 
            {
                context.Sellers.AddOrUpdate(new Models.Seller
                {
                    Name =Guid.NewGuid().ToString().Substring(0,10),
                    Sname="Seller-"+i,
                    Password= Guid.NewGuid().ToString().Substring(0, 10),
                    PhoneNumber= Guid.NewGuid().ToString().Substring(0, 10),
                    Email= Guid.NewGuid().ToString().Substring(0, 10),
                    NidNumber= Guid.NewGuid().ToString().Substring(0, 10),

                });
            }
            Random random = new Random();
            for (int i= 1; i <=10; i++)
            {
                context.Products.AddOrUpdate(new Models.Product
                {
                    Id =i,
                    ProductName= Guid.NewGuid().ToString().Substring(0, 10),
                    ProdcutQuantity= Guid.NewGuid().ToString().Substring(0, 10),
                    ProductCategory= Guid.NewGuid().ToString().Substring(0, 10),
                    ProductPrice= Guid.NewGuid().ToString().Substring(0, 5),
                    SelleingBy="Seller-"+random.Next(1,6),
                });
            }

            for (int i= 1 ; i <=50 ; i++)
            {
                context.Orders.AddOrUpdate(new Models.Order
                {
                    Id =i,
                    OrderDate= DateTime.Now,
                    OrderType="Laptop",
                    OrderQuantity= Guid.NewGuid().ToString().Substring(0, 10),
                    Location= Guid.NewGuid().ToString().Substring(0, 10),
                    SelleBy="Seller-" + random.Next(1,6),
                    ProductId=random.Next(1,11),
                });
            }
        }
    }
}
