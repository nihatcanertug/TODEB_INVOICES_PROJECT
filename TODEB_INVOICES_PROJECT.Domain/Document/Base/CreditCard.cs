

namespace TODEB_INVOICES_PROJECT.Domain.Document.Base
{
    public class CreditCard:DocumentBaseEntity
    {
        public string CustomerName { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
    }
}
