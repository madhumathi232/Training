using System.ComponentModel.DataAnnotations;

namespace TestingApp.Models
{
    public class MyDetails
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
    }
}
