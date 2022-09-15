using System.ComponentModel.DataAnnotations;

namespace SampleTrainingApp.Models
{
    public class Inventory
    {
        [Key]
       public int ProdId { get; set; }
        public string ProdName { get; set; }
        public int price { get; set; }
    }
}
