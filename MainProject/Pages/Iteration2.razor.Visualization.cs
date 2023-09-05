using MainProject.Data;

namespace MainProject.Pages
{
    public partial class Iteration2
    {
        double GHGSum;
        double WaterSum;
        double LandSum;
        double EutrophyingSum;

        public SavedFood[]? GHGVis;
        public SavedFood[]? waterVis;
        public SavedFood[]? landVis;
        public SavedFood[]? eutrophyingVis;

        void CalculateWasteSum()
        {
            GHGSum = Math.Round(savedFoodList.Sum(sf => sf.FoodGHG), 2);
            WaterSum = Math.Round(savedFoodList.Sum(sf => sf.FoodWater), 2);
            LandSum = Math.Round(savedFoodList.Sum(sf => sf.FoodLand), 2);
            EutrophyingSum = Math.Round(savedFoodList.Sum(sf => sf.FoodEutrophying), 2); 
        }

        public void UpdateVisualization()
        {
            GHGVis = savedFoodList.OrderByDescending(s => s.FoodGHG).ToArray();
            waterVis = savedFoodList.OrderByDescending(s => s.FoodWater).ToArray();
            landVis = savedFoodList.OrderByDescending(s => s.FoodLand).ToArray();
            eutrophyingVis = savedFoodList.OrderByDescending(s => s.FoodEutrophying).ToArray();
        }
    }
}
