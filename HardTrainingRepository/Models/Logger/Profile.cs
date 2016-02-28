using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardTrainingRepository.Models.Logger
{
    public class Profile
    {
        public Profile()
        {
            
        }

        [Key]
        [Display(Name = "Id:")]
        public int Id { get; set; }

        [Display(Name = "User name:")]
        [MaxLength(32)]
        public string Name { get; set; }

        [Display(Name = "Date of creation:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime CreationDate { get; set; }

        [MaxLength(64)]
        public string Password { get; set; }

        /* 
         * Make from this a DataUser or something:
        public virtual User User { get; set; }
         */
    }
}