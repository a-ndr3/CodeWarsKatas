using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_HumanReadableTime
    {
        public static string FormatDuration(int seconds)
        {
            if (seconds == 0) return "now";
            var res = new StringBuilder();
            var tmp = seconds;
            
            var y = tmp / 31536000;
            tmp %= 31536000;
            
            var d = tmp / 86400;
            tmp %= 86400;
            var h = tmp / 3600;
            tmp %= 3600;
            var m = tmp / 60;
            tmp %= 60;
            var s = tmp;



            if (y > 0) res.Append(y + " year" + (y > 1 ? "s" : "") + ", ");
            if (d > 0) res.Append(d + " day"  + (d > 1 ? "s" : "") + ", ");
            if (h > 0) res.Append(h + " hour" + (h > 1 ? "s" : "") + ", ");
            if (m > 0) res.Append(m + " minute" + (m > 1 ? "s" : "") + ", ");
            if (s > 0) res.Append(s + " second" + (s > 1 ? "s" : ""));

            var str = res.ToString().TrimEnd(',', ' ');
            var index = str.LastIndexOf(',');
            
            if (index != -1)
            {
                str = str.Remove(index, 1);
                str = str.Insert(index, " and");
            }
            return str;
        }
    }
}
