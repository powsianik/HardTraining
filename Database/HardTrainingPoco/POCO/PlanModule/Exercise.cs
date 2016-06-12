using System.ComponentModel.DataAnnotations;

namespace HardTrainingPoco.POCO.PlanModule
{
    public class Exercise
    {
        public Exercise()
        {
            
        }

        [Key]
        public short Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public short IdOfKind { get; set; }

        public KindOfExercise KindOfExcExercise { get; set; }
    }
}