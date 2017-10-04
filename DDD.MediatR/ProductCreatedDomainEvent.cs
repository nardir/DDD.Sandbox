using DDD.EF.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.MediatR
{
    public class ProductCreatedDomainEvent: INotification
    {
        public Product Product { get; private set; }

        public ProductCreatedDomainEvent(Product product)
        {
            Product = product;
        }
    }
}
