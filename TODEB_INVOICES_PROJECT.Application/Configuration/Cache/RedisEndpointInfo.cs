using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODEB_INVOICES_PROJECT.Application.Auth.Cache
{
     public class RedisEndpointInfo
    {
        public string EndPoint { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
