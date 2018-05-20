using System.Collections.Generic;

namespace TrainingPlans.AthleteSpecific
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WorkoutSegment> WorkoutSegments { get; set; } 
    }
}