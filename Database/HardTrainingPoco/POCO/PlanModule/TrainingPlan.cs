using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HardTrainingPoco.POCO.Logger;

namespace HardTrainingPoco.POCO.PlanModule
{
    public class TrainingPlan
    {
        public TrainingPlan()
        {
            
        }

        [Key]
        public short Id { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Purpose { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public short ProfileId { get; set; }

        public Profile Profile { get; set; }

        public virtual ICollection<TrainingDay> TrainingDays { get; private set; }
    }
}