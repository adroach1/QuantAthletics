using System;
using System.Collections.Generic;

namespace QA.Core.Analytics.PerformanceScoring
{
    public class PerformanceScoreDistanceBucketRepo
    {
        public IEnumerable<DistanceBucket> GetAll()
        {
            yield return new DistanceBucket(1, 100, 400, "400M");
            yield return new DistanceBucket(2, 400, 1600, "Mile");
            yield return new DistanceBucket(3, 1600, 5000,"5K");
            yield return new DistanceBucket(4, 5000, 10000, "10K");
            yield return new DistanceBucket(5, 10000, 21000, "HM");
            yield return new DistanceBucket(6, 21000, 42000, "M");
            //yield return new DistanceBucket(7, 42000, 100000, "Ultra");
        }

        public IEnumerable<KeyValuePair<double,TimeSpan>> GetWorldRecords()
        {
            yield return new KeyValuePair<double, TimeSpan>(400,new TimeSpan(0,0,43));
            yield return new KeyValuePair<double, TimeSpan>(1600, new TimeSpan(0, 3, 43));
            yield return new KeyValuePair<double, TimeSpan>(5000, new TimeSpan(0, 12, 27));
            yield return new KeyValuePair<double, TimeSpan>(10000, new TimeSpan(0, 26, 17));
            yield return new KeyValuePair<double, TimeSpan>(21000, new TimeSpan(0, 58, 23));
            yield return new KeyValuePair<double, TimeSpan>(42000, new TimeSpan(2, 02, 57));
            //yield return new KeyValuePair<double, TimeSpan>(100000, new TimeSpan(6, 13, 33));
        }
    }
}