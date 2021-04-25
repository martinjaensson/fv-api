
using System;

namespace FirstVetApi.Dto
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndTime { get; set; }
        public string StartBreak { get; set; }
        public string EndBreak { get; set; }
        public string StartBreak2 { get; set; }
        public string EndBreak2 { get; set; }
        public string StartBreak3 { get; set; }
        public string EndBreak3 { get; set; }
        public string StartBreak4 { get; set; }
        public string EndBreak4 { get; set; }

    }
}
