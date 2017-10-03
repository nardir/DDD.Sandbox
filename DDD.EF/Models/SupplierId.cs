using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EF.Models
{
    public class SupplierId
    {
        public int Identity { get; private set; }

        protected SupplierId() { }

        protected SupplierId(int identity)
        {
            if (identity <= 0)
                throw new ArgumentException(nameof(identity));

            Identity = identity;
        }

        public static SupplierId Create(int identity)
        {
            return new SupplierId(identity);
        }
    }
}
