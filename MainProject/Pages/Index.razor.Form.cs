using MainProject.Data;
using System.Collections.ObjectModel;

namespace MainProject.Pages
{
    public partial class Index
    {
        FoodFormModel foodFormModel = new FoodFormModel();

        ObservableCollection<SavedFood> savedFoodList = new ObservableCollection<SavedFood>();

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

        /// <summary>
        /// Vegetables Methods
        /// </summary>
        private void SaveVegetables()
        {
            if(foodFormModel.VegetablesId !=null && foodFormModel.VegetablesAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodId = foodFormModel.VegetablesId,
                    FoodAmount = foodFormModel.VegetablesAmount
                };
                AddOrUpdateFood(newFood);
                foodFormModel.VegetablesId = null;
                foodFormModel.VegetablesAmount = 0;
            }
        }

        private void AddVegetables()
        {
            foodFormModel.VegetablesAmount++;
        }

        private void MinusVegetables()
        {
            if (foodFormModel.VegetablesAmount > 0)
            {
                foodFormModel.VegetablesAmount--;
            }
        }

        /// <summary>
        /// Fruits Methods
        /// </summary>
        private void SaveFruits()
        {
            if (foodFormModel.FruitsId != null && foodFormModel.FruitsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodId = foodFormModel.FruitsId,
                    FoodAmount = foodFormModel.FruitsAmount
                };
                AddOrUpdateFood(newFood);
                foodFormModel.FruitsId = null;
                foodFormModel.FruitsAmount = 0;
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

        /// <summary>
        /// Meats Methods
        /// </summary>
        private void SaveMeats()
        {
            if (foodFormModel.MeatsId != null && foodFormModel.MeatsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodId = foodFormModel.MeatsId,
                    FoodAmount = foodFormModel.MeatsAmount
                };
                AddOrUpdateFood(newFood);
                foodFormModel.MeatsId = null;
                foodFormModel.MeatsAmount = 0;
            }
        }
        private void AddMeats()
        {
            foodFormModel.MeatsAmount++;
        }

        private void MinusMeats()
        {
            if (foodFormModel.MeatsAmount > 0)
            {
                foodFormModel.MeatsAmount--;
            }
        }

        /// <summary>
        /// Others Methods
        /// </summary>
        private void AddOthers()
        {
            foodFormModel.OthersAmount++;
        }

        private void MinusOthers()
        {
            if (foodFormModel.OthersAmount > 0)
            {
                foodFormModel.OthersAmount--;
            }
        }

        ////////////////////////
        public void AddOrUpdateFood(SavedFood newFood)
        {
            var existingFood = savedFoodList.FirstOrDefault(f => f.FoodId == newFood.FoodId);
            if (existingFood != null)
            {
                existingFood.FoodAmount += newFood.FoodAmount;
            }
            else
            {
                savedFoodList.Add(newFood);
            }
        }
    }
}
