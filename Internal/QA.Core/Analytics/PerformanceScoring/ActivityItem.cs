using System;
using System.Runtime.CompilerServices;

namespace QA.Core.Analytics.PerformanceScoring
{
    public struct ActivityItem
    {
        public ActivityItem(long id, DateTime startDateTime, double distance, double duration)
        {
            StartDateTime = startDateTime;
            Distance = distance;
            Duration = duration;
            Id = id;
        }

        public ActivityItem(DateTime startDateTime, double distance, double duration)
        {
            StartDateTime = startDateTime;
            Distance = distance;
            Duration = duration;
            Id = 0;
        }



        public long Id { get; private set; }
        public DateTime Date => StartDateTime.Date;
        public DateTime StartDateTime { get; private set; }
        public double Distance { get; private set; }
        public double Duration { get; private set; }
        public double Speed => Distance/Duration;
    }
}