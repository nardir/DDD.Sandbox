using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EF.Models
{
    public class ProductGroup
    {
        public string Name { get; private set; }

        protected ProductGroup()
        {
        }

        protected ProductGroup(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            Name = name;
        }

        public static ProductGroup Create(string name)
        {
            return new ProductGroup(name);
        }
    }
}
