using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlans.AthleteSpecific
{
    public class Athlete
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double DistanceAbility { get; set; }
        public double SpeedAbility { get; set; }
    }

    public class TrainingPlan
    {
        public int Id { get; set; }
        public long AthleteId { get; set; }
        public List<Workout> Workouts { get; set; } 
    }
}
