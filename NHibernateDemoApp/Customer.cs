using System;
using System.Collections.Generic;
using System.Text;

namespace NHibernateDemoApp
{
    public class Customer
    {

        public Customer()
        {
            MemberSince = DateTime.UtcNow;
           // Orders = new HashedSet<Order>();
           Orders = new HashSet<Order>();
        }

        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual double AverageRating { get; set; }
        public virtual int Points { get; set; }

        public virtual bool HasGoldStatus { get; set; }
        public virtual DateTime MemberSince { get; set; }
        public virtual CustomerCreditRating CreditRating { get; set; }
       public virtual Location Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual void AddOrder(Order order)
        {
            Orders.Add(order);

        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat("{1}{2}({0})\r\n\tPoints: {3}\r\n\tHasGoldStatus:{4}\r\n\tMemberSince: {5} ({7})\r\n\tCreditRating: {6}\r\n\tAverageRating:{8}\r\n", Id, FirstName, LastName, Points, HasGoldStatus, MemberSince,
              CreditRating, MemberSince.Kind, AverageRating);
            result.AppendLine("\tOrders:");

            //foreach (var order in Orders)
            //{
            //    result.AppendLine("\t\t" + order);
            //}

            return result.ToString();
        }
    }

    public class Location
    {
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string Province { get; set; }
        public virtual string Country { get; set; }
    }

    public enum CustomerCreditRating
    {
        Excellent,
        VeryVeryGood,
        VeryGood,
        Good,
        Neutral,
        Poor,
        Terrible
    }
}
