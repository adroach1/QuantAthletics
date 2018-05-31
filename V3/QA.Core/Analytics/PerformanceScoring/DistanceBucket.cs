using System;

namespace QA.Core.Analytics.PerformanceScoring
{
    public class DistanceBucket
    {
        public DistanceBucket(long id, double minDistance, double distance, string name)
        {
            Id = id;
            MinDistance = minDistance;
            Distance = distance;
            Name = name;
        }
        public long Id { get; set; }
        public double MinDistance { get; set; }
        public double Distance { get; set; }
        public string Name { get; set; }                                                                                                                  



    }
}