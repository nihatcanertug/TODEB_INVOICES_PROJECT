﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODEB_INVOICES_PROJECT.Application.Helper
{
    public static class StringHelper
    {
        public static string CreateCacheKey(string userName, int userId)
        {
            return string.Concat(userName.Substring(0, 3), "_", userId);
        }
    }
}
