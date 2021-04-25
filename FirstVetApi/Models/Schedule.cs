

using System.Collections.Generic;
using System.Linq;

namespace FirstVetApi.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public TimeSpan WorkShift  { get; set; }
        public List<TimeSpan> Breaks { get; set; }
        public List<TimeSpan> WorkTime 
        { 
            get 
            {
                List<TimeSpan> result = new List<TimeSpan>();
                if (Breaks.Count == 0)
                {
                    result.Add(WorkShift);
                }
                else
                {
                    result.AddRange(ExtractPartialWorkShifts(WorkShift, Breaks));
                }
                return result;
            }  
        }

        private List<TimeSpan> ExtractPartialWorkShifts(TimeSpan workShift, List<TimeSpan> breaks)
        {
            List<TimeSpan> result = new List<TimeSpan>();
            result.Add(ExtractFirstPartialWorkShift(workShift, breaks));
            if (breaks.Count > 1)
                result.AddRange(ExtractMiddlePartialWorkShift(breaks));
            result.Add(ExtractLastPartialWorkShift(workShift, breaks));
            return result;
        }

        private List<TimeSpan> ExtractMiddlePartialWorkShift(List<TimeSpan> breaks)
        {
            List<TimeSpan> result = new List<TimeSpan>();
            List<TimeSpan>  orderedBreaks = breaks.OrderBy(b => b.Start).ToList();
            for (int i = 0; i < breaks.Count  - 1; i++)
            {
                result.Add(new TimeSpan()
                {
                    Start = orderedBreaks[i].End,
                    End = orderedBreaks[i + 1].Start
                });
            }
            return result;
        }

        private TimeSpan ExtractFirstPartialWorkShift(TimeSpan workShift, List<TimeSpan> breaks)
        {
            return new TimeSpan()
            {
                Start = workShift.Start,
                End = breaks.OrderBy(b => b.Start).FirstOrDefault().Start
            };
        }

        private TimeSpan ExtractLastPartialWorkShift(TimeSpan workShift, List<TimeSpan> breaks)
        {
            return new TimeSpan()
            {
                Start = breaks.OrderByDescending(b => b.Start).FirstOrDefault().End,
                End = workShift.End
            };
        }
    }
}
