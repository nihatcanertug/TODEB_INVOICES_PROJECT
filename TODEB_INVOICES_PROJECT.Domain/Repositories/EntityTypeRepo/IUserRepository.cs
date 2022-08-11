using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Domain.Entities.Concrete;
using TODEB_INVOICES_PROJECT.Domain.Repositories.BaseRepo;

namespace TODEB_INVOICES_PROJECT.Domain.Repositories.EntityTypeRepo
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithPassword(string email);
        User GetUserWithPermission(string email);
    }
}
