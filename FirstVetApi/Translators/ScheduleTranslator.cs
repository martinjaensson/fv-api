using System.Collections.Generic;
using FirstVetApi.CustomExtensions;
using FirstVetApi.Dto;
using FirstVetApi.Models;

namespace FirstVetApi.Translators
{
    public class ScheduleTranslator
    {
        public static Schedule ToModel(ScheduleDto scheduleDto)
        {
            if (scheduleDto == null)
                return null;

            return new Schedule() {
                Id = scheduleDto.ScheduleId,
                Employee = new Employee() { Id = scheduleDto.EmployeeId, Name = scheduleDto.EmployeeName },
                WorkShift =  new TimeSpan() { Start = scheduleDto.StartDate.AddTime(scheduleDto.StartTime), 
                                              End = scheduleDto.EndDate.AddTime(scheduleDto.EndTime) },
                Breaks = ExtractBreaks(scheduleDto)
            };
        }

        private static List<TimeSpan> ExtractBreaks(ScheduleDto scheduleDto)
        {
            // TODO: Fix logic when startdate and enddate are on different dates
            List<TimeSpan> result = new List<TimeSpan>();
            TimeSpan break1 = ExtractBreak(scheduleDto.StartDate, scheduleDto.EndDate, scheduleDto.StartBreak, scheduleDto.EndBreak); ;
            if (break1 != null)
                result.Add(break1);

            TimeSpan break2 = ExtractBreak(scheduleDto.StartDate, scheduleDto.EndDate, scheduleDto.StartBreak2, scheduleDto.EndBreak2); ;
            if (break2 != null)
                result.Add(break2);

            TimeSpan break3 = ExtractBreak(scheduleDto.StartDate, scheduleDto.EndDate, scheduleDto.StartBreak3, scheduleDto.EndBreak3); ;
            if (break3 != null)
                result.Add(break3);

            TimeSpan break4 = ExtractBreak(scheduleDto.StartDate, scheduleDto.EndDate, scheduleDto.StartBreak4, scheduleDto.EndBreak4); ;
            if (break4 != null)
                result.Add(break4);


            return result;
        }

        private static TimeSpan ExtractBreak(System.DateTime startDate, System.DateTime endDate, string startBreak, string endBreak)
        {
            System.DateTime start = startDate.AddTime(startBreak);
            System.DateTime end = startDate.AddTime(endBreak);
            if (start == end)
                return null;
            else
                return new TimeSpan()
                {
                    Start = start,
                    End = end
                }; 
        }
    }
}
