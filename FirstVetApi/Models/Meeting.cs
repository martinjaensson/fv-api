
namespace FirstVetApi.Models
{
    public class Meeting
    {
        public Employee Veterinary { get; set; }
        public TimeSpan TimeSlot { get; set; }

        public override string ToString()
        {
            return $"{TimeSlot.Start.ToString("yyyy-MM-dd HH:mm")} - {TimeSlot.End.ToString("HH:mm")} {Veterinary.Name}";
        }
    }
}
