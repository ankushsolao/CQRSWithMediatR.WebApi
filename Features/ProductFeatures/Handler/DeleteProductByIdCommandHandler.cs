using CQRSWithMediatRPattern.Features.ProductFeatures.Command;
using CQRSWithMediatRPattern.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSWithMediatRPattern.Features.ProductFeatures.Handler
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
    {
        private readonly IApplicationContext _context;
        public DeleteProductByIdCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (product == null) return default;
            _context.Products.Remove(product);
            await _context.SaveChanges();
            return product.Id;
        }
    }
}
