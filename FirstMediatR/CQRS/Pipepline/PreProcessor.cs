using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace FirstMediatR.CQRS.Pipepline
{
    public class PreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"PreProcessor - request : {request}");
        }
    }
}
