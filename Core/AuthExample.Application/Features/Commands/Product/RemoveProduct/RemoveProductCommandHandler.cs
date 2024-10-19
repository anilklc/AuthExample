using AuthExample.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        private readonly IProductWriteRepository _ProductWriteRepository;

        public RemoveProductCommandHandler(IProductWriteRepository ProductWriteRepository)
        {
            _ProductWriteRepository = ProductWriteRepository;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _ProductWriteRepository.RemoveAsync(request.Id);
            await _ProductWriteRepository.SaveAsync();
            return new();
        }
    }
}
