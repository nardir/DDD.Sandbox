using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.MediatR
{
    public class ProductCreatedDomainEventHandler2 : IAsyncNotificationHandler<ProductCreatedDomainEvent>
    {
        public Task Handle(ProductCreatedDomainEvent notification)
        {
            var product = notification.Product;

            return Task.FromResult<object>(null);
        }
    }
}
