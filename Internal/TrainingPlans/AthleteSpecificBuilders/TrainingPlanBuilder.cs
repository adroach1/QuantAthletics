using System;
using System.Collections.Generic;
using System.Linq;
using QA.Core.Analytics.PerformanceScoring;
using TrainingPlans.Generic;

namespace TrainingPlans.AthleteSpecific
{
    public class TrainingPlanBuilder
    {
        private GenericTrainingPlan _genericTrainingPlan;
        private List<GoalRaces> _goalRaces;
        private PerformanceScore _athletePerformanceScore;
        private double _athleteToPlanMaxAverageDistanceRatio;
        
        public TrainingPlan BuildTrainingPlan(GenericTrainingPlan genericTrainingPlan,PerformanceScore athletePerformanceScore  , IEnumerable<GoalRaces> goalRaces)
        {
            _genericTrainingPlan = genericTrainingPlan;
            _goalRaces = goalRaces.ToList();
            _athletePerformanceScore = athletePerformanceScore;
            _athleteToPlanMaxAverageDistanceRatio = athletePerformanceScore.AverageMaxDiscountedDistancePerWeek/ genericTrainingPlan.AverageMaxWeeklyMileage;
            var trainingPlan = BuildTrainingPlan(genericTrainingPlan);
            return trainingPlan;

        }

        private TrainingPlan BuildTrainingPlan(GenericTrainingPlan genericTrainingPlan)
        {
            var trainingPlan = new TrainingPlan();
            trainingPlan.AthleteId = _athletePerformanceScore.AthleteId;
            trainingPlan.Workouts = genericTrainingPlan.GenericWorkouts.Select(BuildWorkout).ToList();
            return trainingPlan;
        }

        private Workout BuildWorkout(GenericWorkout genericWorkout)
        {
            var workout = new Workout
            {
                Name = genericWorkout.WorkoutName,
                WorkoutSegments = genericWorkout.GenericWorkoutSegments.Select(BuildWorkoutSegment).ToList()
            };
            return workout;
        }

        private WorkoutSegment BuildWorkoutSegment(GenericWorkoutSegment genericWorkoutSegment)
        {
            var workoutSegment = new WorkoutSegment();
            workoutSegment.Id = genericWorkoutSegment.Id;
            workoutSegment.Distance = AdjustDistance(genericWorkoutSegment);
            workoutSegment.TrainingPace = genericWorkoutSegment.TrainingPace;
            workoutSegment.Speed = AdjustSpeed(genericWorkoutSegment);
            return workoutSegment;
        }

        private double AdjustDistance(GenericWorkoutSegment genericWorkoutSegment)
        {
            //should work, enhance to factor in fatigue
            return genericWorkoutSegment.Distance*_athleteToPlanMaxAverageDistanceRatio;
        }

        private double AdjustSpeed(GenericWorkoutSegment genericWorkoutSegment)
        {
            //clean this up
            //enhance performance scores to average various distance levels
            //enhance to factor in fatigue 
            var marathonPace = _athletePerformanceScore.PerformanceScoreItems.Single(psi => psi.RpsDistanceMeters == 42000);
            return marathonPace.RpsSpeed;
            switch (genericWorkoutSegment.TrainingPace)
            {
                case GenericTrainingPaces.Walk:
                    break;
                case GenericTrainingPaces.Jog:
                    break;
                case GenericTrainingPaces.Easy:
                    break;
                case GenericTrainingPaces.Medium:
                    break;
                case GenericTrainingPaces.Tempo:
                    break;
                case GenericTrainingPaces.Marathon:
                    break;
                case GenericTrainingPaces.HalfMarathon:
                    break;
                case GenericTrainingPaces.TenK:
                    break;
                case GenericTrainingPaces.FiveK:
                    break;
                case GenericTrainingPaces.Mile:
                    break;
                case GenericTrainingPaces.Sprint:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}