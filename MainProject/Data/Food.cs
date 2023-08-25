using System.ComponentModel.DataAnnotations;

namespace MainProject.Data
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        public required string FoodName { get; set; }
        public int CategoryId { get; set; }
        public double GHG { get; set; }
        public double Water { get; set; }
        public double Land { get; set; }
        public double Eutrophying { get; set; }
    }
}
