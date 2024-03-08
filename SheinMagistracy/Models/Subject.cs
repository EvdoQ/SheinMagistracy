using System.ComponentModel.DataAnnotations;

namespace SheinMagistracy.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Teacher { get; set; }
    }
}
