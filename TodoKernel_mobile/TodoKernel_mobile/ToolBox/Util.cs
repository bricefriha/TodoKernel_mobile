using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TodoKernel_mobile.ToolBox
{
    class Util
    {
        /// <summary>
        /// Detect if the parameter iis an email
        /// </summary>
        /// <param name="email">potential email</param>
        /// <returns></returns>
        public static bool DetectEmail(string email)
        {
            const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
            else return false;
        }
    }
}
