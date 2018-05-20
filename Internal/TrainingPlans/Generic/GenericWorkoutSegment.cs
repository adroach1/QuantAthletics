namespace TrainingPlans.Generic
{
    public class GenericWorkoutSegment
    {
        public int Id { get; set; }
        public string WorkoutSegmentName { get; set; }
        public double Distance { get; set; }
        public GenericTrainingPaces TrainingPace { get; set; }
        public int Repetitions { get; set; }
        
    }

}