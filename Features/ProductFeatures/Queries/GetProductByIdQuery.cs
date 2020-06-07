using CQRSWithMediatRPattern.Models;
using MediatR;

namespace CQRSWithMediatRPattern.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }       
    }
}
