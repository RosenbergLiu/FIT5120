using MainProject.Data;
using Radzen;
using Radzen.Blazor;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
        private async void SaveVegetables()
        {
            if(foodList == null)
            {
                foodList = await foodService.GetFoodListAsync();
            }

            if (foodFormModel.VegetablesAmount < 0)
            {
                foodFormModel.VegetablesAmount = 0;
            }

            if (foodFormModel.VegetablesId !=null && foodFormModel.VegetablesAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodId = foodFormModel.VegetablesId,
                    FoodName = foodList.Where(f => f.FoodId == foodFormModel.VegetablesId).Select(f => f.FoodName).FirstOrDefault(),
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
        private async void SaveFruits()
        {
            if (foodList == null)
            {
                foodList = await foodService.GetFoodListAsync();
            }

            if (foodFormModel.FruitsAmount < 0)
            {
                foodFormModel.FruitsAmount = 0;
            }

            if (foodFormModel.FruitsId != null && foodFormModel.FruitsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodId = foodFormModel.FruitsId,
                    FoodName = foodList.Where(f => f.FoodId == foodFormModel.FruitsId).Select(f => f.FoodName).FirstOrDefault(),
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
        private async void SaveMeats()
        {
            if (foodList == null)
            {
                foodList = await foodService.GetFoodListAsync();
            }

            if (foodFormModel.MeatsAmount < 0)
            {
                foodFormModel.MeatsAmount = 0;
            }

            if (foodFormModel.MeatsId != null && foodFormModel.MeatsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodId = foodFormModel.MeatsId,
                    FoodName = foodList.Where(f => f.FoodId == foodFormModel.MeatsId).Select(f => f.FoodName).FirstOrDefault(),
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
        private async void SaveOthers()
        {
            if (foodList == null)
            {
                foodList = await foodService.GetFoodListAsync();
            }

            if (foodFormModel.OthersAmount < 0)
            {
                foodFormModel.OthersAmount = 0;
            }

            if (foodFormModel.OthersId != null && foodFormModel.OthersAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodId = foodFormModel.OthersId,
                    FoodName = foodList.Where(f => f.FoodId == foodFormModel.OthersId).Select(f => f.FoodName).FirstOrDefault(),
                    FoodAmount = foodFormModel.OthersAmount
                };
                AddOrUpdateFood(newFood);
                foodFormModel.OthersId = null;
                foodFormModel.OthersAmount = 0;
            }
        }

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
