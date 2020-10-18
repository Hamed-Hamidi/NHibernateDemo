using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemoApp
{
   public class Product

    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ISet<Order> Orders { get; set; }

    }
}
