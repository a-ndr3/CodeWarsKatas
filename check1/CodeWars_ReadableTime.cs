using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_ReadableTime
    {
        public static string GetReadableTime(int seconds)
        {
            var time = TimeSpan.FromSeconds(seconds);

            string formatted = string.Format("{0}:{1}:{2}",
                 time.Duration().Days < 5 ? String.Format("{0:00}", (int)time.TotalHours) : "99",
                     time.Duration().Minutes > 0 ? time.Minutes : "00",
                        time.Duration().Seconds > 0 ? time.Seconds : "00");


            return formatted;

            //return $"{seconds / 3600}:{seconds % 3600 / 60}:{seconds % 60}";
        }
    }
}
