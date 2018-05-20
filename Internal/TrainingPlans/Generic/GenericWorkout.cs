using System.Collections.Generic;

namespace TrainingPlans.Generic
{
    public class GenericWorkout
    {
        public int Id { get; set; }
        public string WorkoutName { get; set; }
        public int DayIntoTrainingPlan { get; set; }
        public List<GenericWorkoutSegment> GenericWorkoutSegments { get; set; }
    }
}