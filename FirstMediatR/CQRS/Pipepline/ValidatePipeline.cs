using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;

namespace FirstMediatR.CQRS.Pipepline
{
    public class ValidatePipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        IValidatorFactory validatorFactory;

        public ValidatePipeline(IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            var validator = validatorFactory.GetValidator(request.GetType());
            if (validator != null)
            {
                var context = new ValidationContext<TRequest>(request);
                var validateResult = validator.Validate(context);

                if(validateResult.IsValid == false)
                {
                    throw new ValidationException(validateResult.Errors);
                }
            }
            else
            {
                Console.WriteLine($"ValidatePipeline request:{request}");
            }
            
            var response = await next();
            return response;
        }
    }
}
