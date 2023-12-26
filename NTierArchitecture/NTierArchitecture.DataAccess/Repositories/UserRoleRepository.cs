using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entity.Models;
using NTierArchitecture.Entity.Repositories;

namespace NTierArchitecture.DataAccess.Repositories
{
    internal sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
