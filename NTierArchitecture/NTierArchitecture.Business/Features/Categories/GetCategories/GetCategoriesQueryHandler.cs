using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entity.Models;
using NTierArchitecture.Entity.Repositories;

namespace NTierArchitecture.Business.Features.Categories.GetCategories
{
    internal sealed class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll().OrderBy(x => x.Name).ToListAsync(cancellationToken);
        }
    }
}
