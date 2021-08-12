namespace PlayTennis.Services
{
    using System;

    public interface IDateTimeParseService
    {
        DateTime ConvertStrings(string date, string time);
    }
}
