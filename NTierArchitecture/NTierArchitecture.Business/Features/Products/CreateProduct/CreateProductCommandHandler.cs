using MediatR;
using NTierArchitecture.Entity.Models;
using NTierArchitecture.Entity.Repositories;

namespace NTierArchitecture.Business.Features.Products.CreateProduct
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var isProductExists = await _productRepository.AnyAsync(x => x.Name == request.Name,cancellationToken);

            if (isProductExists)
            {
                throw new ArgumentException("Bu üründen daha önce kayıt edilmiştir.");
            }

            Product product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CategoryId = request.CategoryId
            };

            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
