using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HardTrainingPoco.POCO.Logger;

namespace HardTrainingPoco.Models.UserDataModule
{
    public class UserBasicData
    {
        public UserBasicData()
        {
            
        }

        [Key]
        [Display(Name = "Id:")]
        public short Id { get; set; }

        public short ProfileId { get; set; }

        public short Age { get; set; }

        public short Height { get; set; }

        public short Weight { get; set; }

        public short Neck { get; set; }

        public short Arm { get; set; }

        public short ForeArm { get; set; }

        public short Wrist { get; set; }

        public short Chest { get; set; }

        public short Waist { get; set; }

        public short Hips { get; set; }

        public short Thigh { get; set; }

        public short Ankle { get; set; }

        [DataType(DataType.Date)]
        public DateTime MeasureDate { get; set; }

        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }
    }
}