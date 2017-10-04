using DDD.EF.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.MediatR
{
    public class CreateProductCommand: IRequest<bool>
    {
        public string ProductName { get; private set; }
        public ProductGroup ProductGroup { get; private set; }

        public CreateProductCommand(ProductGroup productGroup, string productName)
        {
            ProductGroup = productGroup;
            ProductName = productName;
        }
    }
}
