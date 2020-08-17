using System;
using System.Threading;
using System.Threading.Tasks;
using FirstMediatR.CQRS.Models;
using FirstMediatR.Infrastructure;
using MediatR;

namespace FirstMediatR.CQRS.Queries
{
    public class GetCarQuery : IRequest<Car>
    {
        public string Name { get; private set; }

        public GetCarQuery(string name)
        {
            Name = name;
        }
    }

    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, Car>
    {
        private readonly ICarRepository repository;

        public GetCarQueryHandler(ICarRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Car> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            return this.repository.GetCarByName(request.Name);
        }
    }
}
