using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardTrainingPoco.POCO.PlanModule
{
    public class DayOfWeek
    {
        public DayOfWeek()
        {
            this.TrainingDays = new HashSet<TrainingDay>();
        } 

        [Key]
        public short Id { get; set; }

        [MaxLength(16)]
        public string Name { get; set; }

        public virtual ICollection<TrainingDay> TrainingDays { get; private set; }
    }
}