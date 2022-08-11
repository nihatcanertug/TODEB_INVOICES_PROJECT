using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Domain.Entities.Concrete;
using TODEB_INVOICES_PROJECT.Infrastructure.Mapping.Abstract;

namespace TODEB_INVOICES_PROJECT.Infrastructure.Mapping.Concrete
{
    public class UserPermissionMap : BaseMap <UserPermission>
    {
        public override void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            base.Configure(builder);
        }
    }
}
