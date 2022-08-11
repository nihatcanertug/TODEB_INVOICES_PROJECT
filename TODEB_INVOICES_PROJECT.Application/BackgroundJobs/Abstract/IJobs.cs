using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODEB_INVOICES_PROJECT.Application.BackgroundJobs.Abstract
{
    public interface IJobs
    {
        void DelayedJob(int userId, string userName,TimeSpan timeSpan);
        void FireAndForget(int userId, string userName);
        void ReccuringJob();
    }
}
