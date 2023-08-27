namespace MainProject.Data
{
    public class SavedFood
    {
        public Food? FoodItem { get; set; }
        public int FoodAmount { get; set; }
        public double FoodGHG { get; set; }
        public double FoodWater { get; set; }
        public double FoodLand { get; set; }
        public double FoodEutrophying { get; set; }
    }
}
