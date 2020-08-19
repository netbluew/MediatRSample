using System;
using System.Threading;
using System.Threading.Tasks;
using FirstMediatR.CQRS.Models;
using FirstMediatR.Infrastructure;
using MediatR;
using FluentValidation;

namespace FirstMediatR.CQRS.Commands
{
    public class CreateCarCommand : IRequest<Car>
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Car>
    {
        private readonly ICarRepository repository;

        public CreateCarCommandHandler(ICarRepository repository)
        {
            this.repository = repository;
        }

        public Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var idx = repository.AddNewCar(request.Name, request.Company);
            return Task.FromResult<Car>(repository.GetCarByIdx(idx));
        }
    }

    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(command => command.Company).NotEmpty().MinimumLength(2).MaximumLength(10);
        }
    }
}
