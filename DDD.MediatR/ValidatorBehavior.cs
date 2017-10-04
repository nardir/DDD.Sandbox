using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.MediatR
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;
        //public ValidatorBehavior(IValidator<TRequest>[] validators) => _validators = validators;
        //public ValidatorBehavior(IValidator<TRequest> validator)
        //{
        //    _validators = new IValidator<TRequest>[1];

        //    _validators[0] = validator;

        //}

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators.ToArray();
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                //throw new OrderingDomainException(
                //    $"Command Validation Errors for type {typeof(TRequest).Name}", new ValidationException("Validation exception", failures));

                throw new Exception($"Command Validation Errors for type {typeof(TRequest).Name}", new ValidationException("Validation exception", failures));
            }

            var response = await next();
            return response;
        }
    }
}
