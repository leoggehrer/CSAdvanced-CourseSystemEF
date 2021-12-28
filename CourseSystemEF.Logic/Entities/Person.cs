using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSystemEF.Logic.Entities
{
    public abstract class Person : EntityObject
    {
        [Required]
        [MaxLength(64)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(64)]
        public string Lastname { get; set; }
        [NotMapped]
        public string Fullname => $"{Lastname} {Firstname}";
    }
}
