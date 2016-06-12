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

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Exercise> Excercise { get; private set; }
    }
}