using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

using System;
using System.Linq;
using System.Reflection;
using NHibernate;
using System.Web;
using NHibernate.Linq;
using NHibernate.Loader.Custom;

namespace NHibernateDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using (ISession session = OpenSession())  
            {
                //session.Save(new Student() { ID = 1,FirstMidName = "rrr", LastName = "uu" });

                //  var st = session.Query<Student>();
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                  session.Save(CreateCustomer());
                  session.Save(CreateProduct());





                      var customer =session.Query<Customer>().FirstOrDefault();
                      var pro = session.Query<Product>().FirstOrDefault();
                     // customer.LastName = "hamed";
                    //session.Update(customer);

                // session.Save(CreateOrder(customer , pro));
               var  order= session.Query<Order>();

                  //var customer = session.Get<Customer>(new Guid("a4a72674-d223-4366-898f-ac530089c3d1"));

                //  session.Delete(customer);

                   transaction.Commit();   //  Commit the changes to the database

                }

              
            }



        }


        private static Customer CreateCustomer()
        {

            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Points = 100,
                HasGoldStatus = true,
                MemberSince = new DateTime(2012, 1, 1),
                CreditRating = CustomerCreditRating.Good,
                AverageRating = 42.42424242,
                Address = new Location() { City = "teh", Country = "ir", Province = "teh", Street = "hh" }
            };

            var order1 = new Order
            {
                Ordered = DateTime.Now
            };

            customer.AddOrder(order1);
            var order2 = new Order
            {
                Ordered = DateTime.Now.AddDays(-1),
                Shipped = DateTime.Now,
                ShipTo = new Location() { City = "teh", Country = "ir", Province = "teh", Street = "hh" }
            };

             //customer.AddOrder(order2);
            return customer;
        }


        private static Customer UpdateCustomer(string name , Guid id)
        {

            var customer = new Customer
            {
                Id = id,
                FirstName = name,
                LastName = "Doe",
                Points = 100,
                HasGoldStatus = true,
                MemberSince = new DateTime(2012, 1, 1),
                CreditRating = CustomerCreditRating.Good,
                AverageRating = 42.42424242,
                Address = new Location() { City = "teh", Country = "ir", Province = "teh", Street = "hh" }
            };

            var order1 = new Order
            {
                Ordered = DateTime.Now
            };

           // customer.AddOrder(order1);
            var order2 = new Order
            {
                Ordered = DateTime.Now.AddDays(-1),
                Shipped = DateTime.Now,
                ShipTo = new Location() { City = "teh", Country = "ir", Province = "teh", Street = "hh" }
            };

            //customer.AddOrder(order2);
            return customer;
        }

        //private static Order CreateOrder(Customer fkIdCustomer , Product pro)
        //{
        //    return new Order() { Id = Guid.NewGuid(),Customer  = fkIdCustomer,Product = pro,Ordered = DateTime.Now, ShipTo = new Location() { City = "teh", Country = "ir", Province = "teh", Street = "hh" }, Shipped = null };
        //}


        private static Product CreateProduct()
        {
            return new Product() { Name = "ygyg"};
        }

        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = @"C:\Users\hhost\source\repos\NHibernateDemoApp\NHibernateDemoApp\hibernate.cfg.xml";
            configuration.Configure(configurationPath);

            var bookConfigurationFile = @"C:\Users\hhost\source\repos\NHibernateDemoApp\NHibernateDemoApp\Student.hbm.xml";

            var customerConfigurationFile = @"C:\Users\hhost\source\repos\NHibernateDemoApp\NHibernateDemoApp\customer.hbm.xml";

            var orderConfigurationFile = @"C:\Users\hhost\source\repos\NHibernateDemoApp\NHibernateDemoApp\Order.hbm.xml";
            var proConfigurationFile = @"C:\Users\hhost\source\repos\NHibernateDemoApp\NHibernateDemoApp\Product.hbm.xml";

            configuration.AddFile(bookConfigurationFile);
            configuration.AddFile(customerConfigurationFile);
            configuration.AddFile(orderConfigurationFile);
            configuration.AddFile(proConfigurationFile);

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
