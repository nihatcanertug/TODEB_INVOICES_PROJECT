using System;


namespace TODEB_INVOICES_PROJECT.Application.Auth
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
