using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using QA.Core.Model;

namespace QA.Core.Analytics.PerformanceScoring
{
    public class PerformanceScore
    {
        public Int64 AthleteId { get; set; }
        public DateTime Date { get; set; }
        public List<PerformanceScoreItem> PerformanceScoreItems { get; set; }

        public double AverageMaxDiscountedWorkloadPerWeek { get; set; }
        public double AverageMaxDiscountedDistancePerWeek { get; set; }
    }
}
