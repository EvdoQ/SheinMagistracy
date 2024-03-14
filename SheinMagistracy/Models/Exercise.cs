using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SheinMagistracy.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Задача")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Изображение")]
        public string Image { get; set; }

        [DisplayName("Дедлайн")]
        public DateTime Deadline { get; set; }
        [Required]
        [DisplayName("Дата выдачи")]
        public DateTime IssueDate { get; set; }

        [Display(Name = "Предмет")]
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}
