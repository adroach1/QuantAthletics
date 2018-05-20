using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingPlans.Generic
{
    public class GenericTrainingPlan
    {
        public List<GenericWorkout> GenericWorkouts { get; set; }

        public double AverageMaxWeeklyMileage { get; set; }
        private double ComputeAverageMaxWeeklyMileage(int numberOfWeeksToUseInMax)
        {
            var weekGroups = GenericWorkouts.GroupBy(gw => new { WeekInPlan = gw.DayIntoTrainingPlan /7, });
            var weekDistances = weekGroups.Select(g => g.Sum(gw => gw.GenericWorkoutSegments.Sum(gws => gws.Distance)));
            var topDistanceWeeks = weekDistances.OrderByDescending(i=>i).Take(numberOfWeeksToUseInMax);
            return topDistanceWeeks.Average();
        }
    }
}
