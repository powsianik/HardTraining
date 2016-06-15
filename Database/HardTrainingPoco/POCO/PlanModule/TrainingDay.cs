using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardTrainingPoco.POCO.PlanModule
{
    public class TrainingDay
    {
        public TrainingDay()
        {
        }

        [Key]
        public short id { get; set; }

        public short IdOfPlan { get; set; }

        public short IdOfDayOfWeek { get; set; }

        [ForeignKey("IdOfPlan")]
        public TrainingPlan TrainingPlan { get; set; }

        [ForeignKey("IdOfDayOfWeek")]
        public DayOfWeek DayOfWeek { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; } 
    }
}