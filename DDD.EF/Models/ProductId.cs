using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EF.Models
{
    public class ProductId
    {
        private readonly int _id;

        protected ProductId()
        {
        }

        protected ProductId(int id)
        {
            if (id <= 0)
                throw new ArgumentException(nameof(id));

            _id = id;
        }

        public static ProductId Create(int id)
        {
            return new ProductId(id);
        }

        public int Id => _id;

        public static implicit operator int(ProductId productId)
        {
            return productId._id;
        }

        public static implicit operator ProductId(int id)
        {
            return Create(id);
        }
    }
}
