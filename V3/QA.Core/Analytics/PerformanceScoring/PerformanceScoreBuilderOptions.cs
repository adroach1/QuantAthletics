using System.Collections.Generic;

namespace QA.Core.Analytics.PerformanceScoring
{
    public class PerformanceScoreBuilderOptions
    {
        public IEnumerable<double> TopRatioOfActivitiesToUse { get; set; } = new[] {.1, .25, .5, .75};
        //public double TopRatioOfActivitiesToUse { get; set; } = .1;
        public int NumberWorkoutWeeksToUse { get; set; } = 4;
        public int DiscountedWorkloadWeeks { get; set; } = 24;
    }
}