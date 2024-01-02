using MediatR;
using NTierArchitecture.Entity.Models;
using NTierArchitecture.Entity.Repositories;

namespace NTierArchitecture.Business.Features.Categories.RemoveCategory
{
    internal sealed class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(x => x.Id == request.id);

            if (category == null)
            {
                throw new ArgumentNullException("Kategori bulunmamaktadır");
            }

            _categoryRepository.Remove(category);
            await _unitOfWork.SaveChangesAsync();
        }
    }
   
}
