using MainProject.Data;
using NuGet.Packaging;

namespace MainProject.Pages
{
    public partial class Iteration2
    {
        IEnumerable<FoodWaste>? foodWasteList;
        bool foodWasteVisReady = false;

        public async Task InitialWasteYearVis()
        {
            foodWasteList = await foodService.GetFoodWasteDataAsync();
            if(foodWasteList != null)
            {
                foodWasteVisReady = true;
            }
        }
    }
}
