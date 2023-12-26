using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entity.Models;
using NTierArchitecture.Entity.Repositories;

namespace NTierArchitecture.DataAccess.Repositories
{
    internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
