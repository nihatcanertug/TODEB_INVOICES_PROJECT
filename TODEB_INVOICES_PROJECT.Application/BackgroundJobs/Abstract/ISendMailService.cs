using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODEB_INVOICES_PROJECT.Application.BackgroundJobs.Abstract
{
    public interface ISendMailService
    {
        void SendMail(int userId, string name);
    }
}
