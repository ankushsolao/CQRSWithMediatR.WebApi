using MediatR;

namespace CQRSWithMediatRPattern.Features.ProductFeatures.Command
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }      
    }
}
