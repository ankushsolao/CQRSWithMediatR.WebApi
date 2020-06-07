using CQRSWithMediatRPattern.Context;
using CQRSWithMediatRPattern.Features.ProductFeatures.Queries;
using CQRSWithMediatRPattern.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSWithMediatRPattern.Features.ProductFeatures.Handler
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IApplicationContext _context;
        public GetProductByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(a => a.Id == query.Id).FirstOrDefault();
            if (product == null) return null;
            return product;
        }
    }
}
