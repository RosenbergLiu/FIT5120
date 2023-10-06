using System.ComponentModel.DataAnnotations;
namespace FoodSaver.Data
{
    public class Product
    {
        [Key]
        public string Name { get; set; }
        public string Url { get; set; }
        public string Qty { get; set; }
    }
}
