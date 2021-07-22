using PlayTennis.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PlayTennis.Services
{
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
