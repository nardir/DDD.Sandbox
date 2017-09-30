using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EF.Models
{
    public class Product
    {
        //public int Id { get; private set; }

        private int _Id;
        private ProductId _productId;

        public int Id {
            get
            {
                return _Id;
            }

            private set
            {
                _Id = value;

                _productId = ProductId.Create(_Id);
            }
        }
        //public ProductId ProductId => Id == default(int) ? null : ProductId.Create(Id);
        public ProductId ProductId => _productId;

        public string Name { get; private set; }
        public decimal? ListPrice { get; private set; }

        public DateTime DateCreated { get; private set; }

        public string Description { get; private set; }

        public ProductGroup ProductGroup { get; private set; }

        protected Product()
        {
        }

        protected Product(ProductGroup productGroup, string name, decimal? listPrice, string description): this()
        {
            if (productGroup == null)
                throw new ArgumentNullException(nameof(productGroup));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            ProductGroup = productGroup;
            Name = name;
            ListPrice = listPrice;
            DateCreated = DateTime.Now;
            Description = description;
        }

        public static Product Create(ProductGroup productGroup, string name, decimal? listPrice, string description)
        {
            return new Product(productGroup, name, listPrice, description);
        }
    }
}