using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagePersonDetails.Utilities
{
    public static class Helper
    {
        public static bool IsNullOrEmpty(string valToCheck)
        {
            if ((valToCheck == null) || (valToCheck.Trim().Length == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}