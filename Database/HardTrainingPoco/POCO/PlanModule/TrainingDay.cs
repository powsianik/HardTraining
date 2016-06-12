using System;
using System.ComponentModel.DataAnnotations;

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

        public TrainingPlan TrainingPlan { get; set; }
    }
}