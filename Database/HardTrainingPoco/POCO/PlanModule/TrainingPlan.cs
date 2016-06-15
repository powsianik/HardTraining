using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HardTrainingPoco.POCO.Logger;

namespace HardTrainingPoco.POCO.PlanModule
{
    public class TrainingPlan
    {
        public TrainingPlan()
        {
            this.TrainingDays = new HashSet<TrainingDay>();
        }

        [Key]
        public short Id { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Purpose { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public short IdOfProfile { get; set; }

        [ForeignKey("IdOfProfile")]
        public Profile Profile { get; set; }

        public virtual ICollection<TrainingDay> TrainingDays { get; private set; }
    }
}