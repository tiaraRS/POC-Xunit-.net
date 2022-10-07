using System.ComponentModel.DataAnnotations;

namespace backend1.Data.Entity
{
    public class ChildEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? ChildName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
