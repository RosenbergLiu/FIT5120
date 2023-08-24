using MainProject.Data;

namespace MainProject.Pages
{
    public partial class Index
    {
        FoodFormModel foodFormModel = new FoodFormModel();

        List<SavedFood> savedFoodList = new List<SavedFood>;

        IEnumerable<Food>? foodList;
        IEnumerable<Food>? vegetablesList;
        IEnumerable<Food>? fruitsList;
        IEnumerable<Food>? meatList;
        IEnumerable<Food>? otherList;

        async Task InitialFormAsync()
        {
            foodList = await foodService.GetFoodListAsync();
            vegetablesList = foodList.Where(f => f.CategoryId == 1);
            fruitsList = foodList.Where(f => f.CategoryId == 2);
            meatList = foodList.Where(f => f.CategoryId == 3);
            otherList = foodList.Where(f => f.CategoryId == 4);

            var ip = HttpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        }

        private async Task SaveVegetable()
        {
            var foodId = foodFormModel.VegetableId;
            var foodAmount = foodFormModel.VegetableAmount;
            foodFormModel.VegetableId = null;
            foodFormModel.VegetableAmount = 0;
        }

        private void AddVegetable()
        {
            foodFormModel.VegetableAmount++;
        }

        private void MinusVegetable()
        {
            if (foodFormModel.VegetableAmount > 0)
            {
                foodFormModel.VegetableAmount--;
            }
        }

        private void AddFruits()
        {
            foodFormModel.FruitsAmount++;
        }

        private void MinusFruits()
        {
            if (foodFormModel.FruitsAmount > 0)
            {
                foodFormModel.FruitsAmount--;
            }
        }

        private void AddMeat()
        {
            foodFormModel.MeatAmount++;
        }

        private void MinusMeat()
        {
            if (foodFormModel.MeatAmount > 0)
            {
                foodFormModel.MeatAmount--;
            }
        }

        private void AddOther()
        {
            foodFormModel.OtherAmount++;
        }

        private void MinusOther()
        {
            if (foodFormModel.OtherAmount > 0)
            {
                foodFormModel.OtherAmount--;
            }
        }
    }
}
