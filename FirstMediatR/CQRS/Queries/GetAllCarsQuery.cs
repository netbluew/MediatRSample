using System;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using FirstMediatR.CQRS.Models;
using System.Threading.Tasks;
using System.Threading;
using FirstMediatR.Infrastructure;

namespace FirstMediatR.CQRS.Queries
{
    public class GetAllCarsQuery : IRequest<IEnumerable<Car>>
    {
    }

    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
    {
        private readonly ICarRepository repository;

        public GetAllCarsQueryHandler(ICarRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            return repository.GetAllCars();
        }
    }
}
