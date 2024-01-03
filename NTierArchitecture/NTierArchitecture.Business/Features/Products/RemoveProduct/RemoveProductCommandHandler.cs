using MediatR;
using NTierArchitecture.Entity.Repositories;

namespace NTierArchitecture.Business.Features.Products.RemoveProduct
{
    internal sealed class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var isProductExists = await _productRepository.GetByIdAsync(x => x.Id == request.id);

            if (isProductExists == null)
            {
                throw new ArgumentNullException("Böyle bir ürün bulunmamaktadır.");
            }

            _productRepository.Remove(isProductExists);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
