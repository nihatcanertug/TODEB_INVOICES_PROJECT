using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Domain.Entities.Concrete;
using TODEB_INVOICES_PROJECT.Domain.Repositories.EntityTypeRepo;
using TODEB_INVOICES_PROJECT.Infrastructure.Context;
using TODEB_INVOICES_PROJECT.Infrastructure.Repositories.BaseRepo;

namespace TODEB_INVOICES_PROJECT.Infrastructure.Repositories.EntityTypeRepo
{
    public class UserPermissionRepository : BaseRepository<UserPermission>, IUserPermissionRepository
    {
        public UserPermissionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
