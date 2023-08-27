using MainProject.Data;

namespace MainProject.Pages
{
    public partial class Index
    {
        double GHGSum;
        double WaterSum;
        double LandSum;
        double EutrophyingSum;

        void CalculateWasteSum()
        {
            GHGSum = Math.Round(savedFoodList.Sum(sf => sf.FoodGHG), 2);
            WaterSum = Math.Round(savedFoodList.Sum(sf => sf.FoodWater), 2);
            LandSum = Math.Round(savedFoodList.Sum(sf => sf.FoodLand), 2);
            EutrophyingSum = Math.Round(savedFoodList.Sum(sf => sf.FoodEutrophying), 2); 
        }
    }
}
