using System.ComponentModel.DataAnnotations;

namespace CourseSystemEF.Logic.Entities
{ 
    public abstract class EntityObject
    {
        [Key]
        public int Id { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
