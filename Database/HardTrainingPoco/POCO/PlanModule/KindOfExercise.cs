using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardTrainingPoco.POCO.PlanModule
{
    public class KindOfExercise
    {
        public KindOfExercise()
        {
            
        }

        [Key]
        public short Id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public virtual ICollection<Exercise> Excercise { get; private set; }
    }
}