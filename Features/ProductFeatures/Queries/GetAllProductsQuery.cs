using CQRSWithMediatRPattern.Models;
using MediatR;
using System.Collections.Generic;

namespace CQRSWithMediatRPattern.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
      
    }
}
