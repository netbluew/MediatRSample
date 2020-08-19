using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace FirstMediatR.CQRS.Pipepline
{
    public class PostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            Console.WriteLine($"PostProcessor - request:{request}, response:{response}");
        }
    }
}
