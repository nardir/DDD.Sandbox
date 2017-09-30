using DDD.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EF.Models
{
    public class ProductCategory: Entity<int>
    {
        public string Name { get; private set; }

        public override int Identity
        {
            get => base.Identity;

            protected set
            {
                base.Identity = value;

                //Create ProductCategoryId valueobject
            }
        }
        protected ProductCategory()
        {
        }

        protected ProductCategory(string name)
        {
            Name = name;
        }

        public static ProductCategory Create(string name)
        {
            return new ProductCategory(name);
        }
    }
}
