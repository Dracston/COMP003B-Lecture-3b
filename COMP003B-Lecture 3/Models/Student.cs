//TODO: add data annotations library
using System.ComponentModel.DataAnnotations;
namespace COMP003B_Lecture_3.Models
{
    public class Student
    {
        //TODO: data in square brackets are data annotations
        [Required]
        //TODO: Below is an example of property
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
            [Required]
            [Range(0,120)]
        public string Age { get; set; }
    }
}
