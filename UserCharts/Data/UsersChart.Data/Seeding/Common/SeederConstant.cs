namespace UsersChart.Data.Seeding.Common;

public static class SeederConstant
{
    public static class User
    {
        public static readonly string[] FirstNames
            = { "John", "Gringo", "Mark", "Lisa", "Maria", "Sonya", "Philip", "Jose", "Lorenzo", "George", "Justin" };

        public static readonly string[] LastNames
            = { "Johnson", "Lamas", "Jackson", "Brown", "Mason", "Rodriguez", "Roberts", "Thomas", "Rose", "McDonalds" };

        public static readonly string[] EmailDomains
            = { "hotmail.com", "gmail.com", "live.com" };

        public const int UsersCount = 100;
    }

    public static class TimeLog
    {
        public const int MinWorkingMinutes = 25;
        
        public const int MaxWorkingMinutes = 480;

        public const int MinNumberEntries = 1;
        
        public const int MaxNumberEntries = 21;
    }
}