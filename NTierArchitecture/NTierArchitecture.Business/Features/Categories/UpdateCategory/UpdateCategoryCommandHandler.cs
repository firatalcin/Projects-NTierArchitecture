using MediatR;
using NTierArchitecture.Entity.Models;
using NTierArchitecture.Entity.Repositories;

namespace NTierArchitecture.Business.Features.Categories.UpdateCategory
{
    internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(p => p.Id == request.id, cancellationToken);

            if (category == null)
            {
                throw new ArgumentException("Kategori Bulunamadı");
            }

            if(category.Name != request.Name)
            {
                var isCategoryNameExists = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

                if (isCategoryNameExists)
                {
                    throw new ArgumentException("Bu kategori daha önce oluşturulmuştur");
                }

                category.Name = request.Name;

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
