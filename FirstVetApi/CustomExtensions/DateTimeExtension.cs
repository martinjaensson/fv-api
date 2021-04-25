using System;

namespace FirstVetApi.CustomExtensions
{
    public static class DateTimeExtension
    {
        public static DateTime AddTime(this DateTime dateTime, string timeString)
        {
            DateTime time = DateTime.Parse(timeString, System.Globalization.CultureInfo.CurrentCulture);
            DateTime dateAndTime = dateTime.AddHours(time.Hour).AddMinutes(time.Minute).AddSeconds(time.Second);
            return dateAndTime;
        }
    }
}
