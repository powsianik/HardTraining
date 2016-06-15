using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardTrainingPoco.POCO.PlanModule
{
    public class Exercise
    {
        public Exercise()
        {
            this.TrainingDays = new HashSet<TrainingDay>();
        }

        [Key]
        public short Id { get; set; }
        
        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public short IdOfKind { get; set; }

        [ForeignKey("IdOfKind")]
        public KindOfExercise KindOfExercise { get; set; }

        public ICollection<TrainingDay> TrainingDays { get; set; } 
    }
}