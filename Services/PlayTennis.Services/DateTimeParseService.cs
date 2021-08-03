namespace PlayTennis.Services
{
    using System;
    using System.Globalization;

    using PlayTennis.Common;

    public class DateTimeParseService : IDateTimeParseService
    {
        public DateTime ConvertStrings(string date, string time)
        {
            string dateString = date + " " + time;
            string format = GlobalConstants.DateTimeFormats.DateTimeFormat;

            DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            return dateTime;
        }
    }
}
