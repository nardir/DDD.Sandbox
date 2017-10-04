using DDD.EF.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.MediatR
{
    public class CreateProductCommandHandler : IAsyncRequestHandler<CreateProductCommand, bool>
    {
        IMediator _mediator;
        public CreateProductCommandHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateProductCommand message)
        {
            var product = Product.Create(message.ProductGroup, message.ProductName, null, message.ProductName);

            var productCreatedDomainEvent = new ProductCreatedDomainEvent(product);

            await _mediator.Publish(productCreatedDomainEvent);

            //return await Task.FromResult(true);
            return true;
        }
    }
}
