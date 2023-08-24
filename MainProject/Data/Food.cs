using System.ComponentModel.DataAnnotations;

namespace MainProject.Data
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int CategoryId { get; set; }
        public double GHG { get; set; }
        public double WaterUtilsed { get; set; }
    }
}
