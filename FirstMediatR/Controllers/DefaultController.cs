using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMediatR.CQRS.Commands;
using FirstMediatR.CQRS.Models;
using FirstMediatR.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstMediatR.Controllers
{
    [Route("api/[controller]")]
    public class DefaultController : Controller
    {
        private readonly IMediator mediator;

        public DefaultController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // request uri :  /api/default/Avante
        [HttpGet]
        public Task<IEnumerable<Car>> Index()
        {
            return mediator.Send(new GetAllCarsQuery());
        }

        // request uri : /api/default/Avante
        [HttpGet("{name}")]
        public Task<Car> GetCar([FromRoute] string name)
        {
            return mediator.Send(new GetCarQuery(name));
        }

        [HttpPost]
        public Task<Car> Index([FromBody] CreateCarCommand command)
        {
            return mediator.Send(command);
        }
    }
}
