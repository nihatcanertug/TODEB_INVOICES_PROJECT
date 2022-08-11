using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Domain.Entities.Interface;
using TODEB_INVOICES_PROJECT.Domain.Enums;

namespace TODEB_INVOICES_PROJECT.Domain.Entities.Concrete
{
    public class Invoice : IBaseEntity
    {
        public int InvoiceID { get; set; }
        public int InvoiceNumber { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

    }
}
