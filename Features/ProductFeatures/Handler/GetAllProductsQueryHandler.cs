using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSWithMediatRPattern.Context;
using CQRSWithMediatRPattern.Features.ProductFeatures.Queries;
using CQRSWithMediatRPattern.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatRPattern.Features.ProductFeatures.Handler
{
    public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationContext _context;
        public GetAllProductsQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = await _context.Products.ToListAsync();
            if (productList == null)
            {
                return null;
            }
            return productList.AsReadOnly();
        }
    }
}
