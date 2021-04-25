
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstVetApi.Enums;
using FirstVetApi.Models;
using FirstVetApi.Utils;

namespace FirstVetApi.Services
{
    public class MeetingsService
    {
        // TODO: Move this into config
        private readonly int DURIATION_MEETING_IN_MINUTES = 15;
        SchedulesService _schedulesService;
        
        public MeetingsService(SchedulesService schedulesService)
        {
            _schedulesService = schedulesService;
        }

        public async Task<List<string>> Get(string state)
        {
            List<Meeting> meetings = await GetFunction(state).Invoke();
            return meetings.OrderBy(m => m.TimeSlot.Start)
                        .Select(m => m.ToString())
                        .ToList();
        }

        private Func<Task<List<Meeting>>> GetFunction(string state)
        {
            if (state == State.BOOKABLE)
            {
                return () => GetBookable();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private async Task<List<Meeting>> GetBookable()
        {
            List<Schedule> schedules = await _schedulesService.GetSchedules();
            List<Meeting> result = new List<Meeting>();
            schedules.ForEach(s => result.AddRange(DivideScheduleToMeetings(s, DURIATION_MEETING_IN_MINUTES)));
            return result;
        }

        private List<Meeting> DivideScheduleToMeetings(Schedule schedule, int duriationInMinutes)
        {
            List<Meeting> result = new List<Meeting>();
            List<Models.TimeSpan> timeSlots = TimeSpanUtils.Divide(schedule.WorkTime, duriationInMinutes);
            timeSlots.ForEach(t => result.Add(new Meeting()
                                                {
                                                    TimeSlot = t,
                                                    Veterinary = schedule.Employee
                                                }));
            return result;
        }
    }
}
