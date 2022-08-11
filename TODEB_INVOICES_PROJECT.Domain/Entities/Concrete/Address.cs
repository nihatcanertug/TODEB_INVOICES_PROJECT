using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Domain.Entities.Interface;

namespace TODEB_INVOICES_PROJECT.Domain.Entities.Concrete
{
    public class Address : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string AddressInfo { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
