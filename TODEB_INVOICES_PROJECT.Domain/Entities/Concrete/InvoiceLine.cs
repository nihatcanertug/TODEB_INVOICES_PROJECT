using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Domain.Entities.Interface;

namespace TODEB_INVOICES_PROJECT.Domain.Entities.Concrete
{
    public class InvoiceLine : IBaseEntity
    {
        public int InvoiceLineID { get; set; }
        public string Description { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public decimal VatRatio { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
