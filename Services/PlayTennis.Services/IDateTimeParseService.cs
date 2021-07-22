using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTennis.Services
{
    public interface IDateTimeParseService
    {
        DateTime ConvertStrings(string date, string time);
    }
}
