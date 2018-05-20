using TrainingPlans.Generic;

namespace TrainingPlans.AthleteSpecific
{
    public class WorkoutSegment
    {
        public int Id { get; set; }
        public string WorkoutSegmentName { get; set; }
        public double Distance { get; set; }
        public double Speed { get; set; }
        public GenericTrainingPaces TrainingPace { get; set; }
    }
}