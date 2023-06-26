using System;

namespace MS.Address.CrossCutting
{
    public interface IDateTimeNowProvider
    {
        DateTime CurrentDate { get; }
        DateTime CurrentDateTime { get; }
        TimeSpan CurrentTimeSpan { get; }
        DayOfWeek CurrentDayOfWeek { get; }
        bool IsHigherThanToday(DateTime dateTime, TimeSpan? timeSpan = null);
    }
}
