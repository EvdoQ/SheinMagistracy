using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace SheinMagistracy.Models.ViewModel
{
    public class ExerciseVM
    {
        public Exercise Exercise { get; set; }
        public IEnumerable<SelectListItem> SubjectSelectList {  get; set; } 
    }
}
