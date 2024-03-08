using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SheinMagistracy.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Предмет")]
        [Required]
        public string SubjectName { get; set; }
        [DisplayName("Преподаватель")]
        [Required]
        public string Teacher { get; set; }
    }
}
