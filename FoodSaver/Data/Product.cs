using System.ComponentModel.DataAnnotations;
namespace FoodSaver.Data
{
    public class Product
    {
        [Key]
        public string Name { get; set; }

        public string Url { get; set; }

        public string Qty { get; set; }

        public double Water {  get; set; }

        public double Land { get; set; }

        public double GHG { get; set; }

        public double Eut { get; set; }
    }
}
