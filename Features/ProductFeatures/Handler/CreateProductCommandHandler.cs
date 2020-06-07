using CQRSWithMediatRPattern.Context;
using CQRSWithMediatRPattern.Features.ProductFeatures.Command;
using CQRSWithMediatRPattern.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace CQRSWithMediatRPattern.Features.ProductFeatures.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationContext _context;
        public CreateProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.Barcode = command.Barcode;
            product.Name = command.Name;
            product.BuyingPrice = command.BuyingPrice;
            product.Rate = command.Rate;
            product.Description = command.Description;
            _context.Products.Add(product);
            await _context.SaveChanges();
            return product.Id;
        }
    }
}
