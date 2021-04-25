
using System;
using System.Collections.Generic;

namespace FirstVetApi.Utils
{
    public static class TimeSpanUtils
    {
        public static List<Models.TimeSpan> Divide(List<Models.TimeSpan> timeSpans, int duriationInMinutes)
        {
            List<Models.TimeSpan> result = new List<Models.TimeSpan>();
            timeSpans.ForEach(t => result.AddRange(Divide(t, duriationInMinutes)));
            return result;
        }

        public static List<Models.TimeSpan> Divide(Models.TimeSpan timeSpan, int duriationInMinutes)
        {
            List<Models.TimeSpan> result = new List<Models.TimeSpan>();
            DateTime currentStartTime = timeSpan.Start;
            while (currentStartTime.AddMinutes(duriationInMinutes).CompareTo(timeSpan.End) <= 0)
            {
                DateTime End = currentStartTime.AddMinutes(duriationInMinutes);
                result.Add(new Models.TimeSpan()
                {
                    Start = currentStartTime,
                    End = End
                });
                currentStartTime = End;
            }
            return result;
        }
    }
}
