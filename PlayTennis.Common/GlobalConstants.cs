namespace PlayTennis.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "PlayTennis";

        public const string AdministratorRoleName = "Administrator";

        public static class DateTimeFormats
        {
            public const string DateFormat = "dd-MM-yyyy";

            public const string TimeFormat = "HH:mm";

            public const string DateTimeFormat = "dd-MM-yyyy HH:mm";
        }

        public static class DataValidations
        {
            public const int ClubNameMaxLenght = 30;

            public const int ClubAddressMaxLenght = 30;

            public const int PlayerFirstNameMaxLenght = 10;

            public const int PlayerLastNameMaxLenght = 10;

            public const int TrainerFirstNameMaxLenght = 10;

            public const int TrainerLastNameMaxLenght = 10;

            public const int PhoneNumberMaxLenght = 10;
        }

        public static class AccountsSeeding
        {
            public const string Password = "123456";

            public const string AdminEmail = "admin@admin.com";
        }
    }
}
