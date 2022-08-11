using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Domain.Entities.Interface;
using TODEB_INVOICES_PROJECT.Domain.Enums;

namespace TODEB_INVOICES_PROJECT.Domain.Entities.Concrete
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }       
        public UserRole Role { get; set; }
        public UserPassword Password { get; set; }
        public ICollection<UserPermission> Permissions { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

    }
}
