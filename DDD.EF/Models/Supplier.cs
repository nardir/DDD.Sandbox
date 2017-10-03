using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EF.Models
{
    public class Supplier
    {
        private int _Id;
        private int Id
        {
            get => _Id;

            set
            {
                _Id = value;

                //Create supplierID VO
                SupplierId = SupplierId.Create(_Id);
            }
        }

        public SupplierId SupplierId { get; private set; }

        public string Name { get; private set; }

        protected Supplier() { }

        protected Supplier(string name)
        {
            Name = name;
        }

        public static Supplier Create(string name)
        {
            return new Supplier(name);
        }
    }
}
