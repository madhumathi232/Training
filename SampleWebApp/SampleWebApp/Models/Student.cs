using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Models
{
    public class Student
    {
        [Key]
      public int RollNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
