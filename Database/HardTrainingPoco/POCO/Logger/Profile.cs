using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HardTrainingPoco.POCO.PlanModule;
using HardTrainingPoco.POCO.UserDataModule;

namespace HardTrainingPoco.POCO.Logger
{
    public class Profile
    {
        public Profile()
        {
            this.UserBasicData = new HashSet<UserData>();
        }

        [Key]
        [Display(Name = "Id:")]
        public short Id { get; set; }

        [Display(Name = "User name:")]
        [MaxLength(32)]
        public string Name { get; set; }

        [Display(Name = "Date of creation:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime CreationDate { get; set; }

        [MaxLength(64)]
        public string Password { get; set; }

        public virtual ICollection<UserData> UserBasicData { get; private set; }

        public virtual ICollection<TrainingPlan> TrainingPlans { get; private set; } 
    }
}