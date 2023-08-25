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
        /// Cereals Methods
        /// </summary>
        private async void SaveCereals()
        {
            if(foodList == null)
            {
                foodList = await foodService.GetFoodListAsync();
            }

            if (foodFormModel.CerealsId !=null && foodFormModel.CerealsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == foodFormModel.CerealsId).FirstOrDefault(),
                    FoodAmount = foodFormModel.CerealsAmount
                };
                AddOrUpdateFood(newFood);
                foodFormModel.CerealsId = null;
                foodFormModel.CerealsAmount = 0;
            }
        }

        private void AddCereals()
        {
            if (foodFormModel.CerealsAmount < 0)
            {
                foodFormModel.CerealsAmount = 0;
            }
            else
            {
                foodFormModel.CerealsAmount ++;
            }
        }

        private void MinusCereals()
        {
            if (foodFormModel.CerealsAmount > 0)
            {
                foodFormModel.CerealsAmount --;
            }
            else
            {
                foodFormModel.CerealsAmount = 0;
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

            if (foodFormModel.FruitsId != null && foodFormModel.FruitsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == foodFormModel.FruitsId).FirstOrDefault(),
                    FoodAmount = foodFormModel.FruitsAmount
                };
                AddOrUpdateFood(newFood);
                foodFormModel.FruitsId = null;
                foodFormModel.FruitsAmount = 0;
            }
        }

        private void AddFruits()
        {
            if (foodFormModel.FruitsAmount < 0)
            {
                foodFormModel.FruitsAmount = 0;
            }
            else
            {
                foodFormModel.FruitsAmount ++;
            }
        }

        private void MinusFruits()
        {
            if (foodFormModel.FruitsAmount > 0)
            {
                foodFormModel.FruitsAmount --;
            }
            else
            {
                foodFormModel.FruitsAmount = 0;
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

            if (foodFormModel.MeatsId != null && foodFormModel.MeatsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == foodFormModel.MeatsId).FirstOrDefault(),
                    FoodAmount = foodFormModel.MeatsAmount
                };
                AddOrUpdateFood(newFood);
                foodFormModel.MeatsId = null;
                foodFormModel.MeatsAmount = 0;
            }
            else
            {
                foodFormModel.MeatsAmount = 0;
            }
        }

        private void AddMeats()
        {
            if (foodFormModel.MeatsAmount < 0)
            {
                foodFormModel.MeatsAmount = 0;
            }
            else
            {
                foodFormModel.MeatsAmount ++;
            }
        }

        private void MinusMeats()
        {
            if (foodFormModel.MeatsAmount > 0)
            {
                foodFormModel.MeatsAmount --;
            }
            else
            {
                foodFormModel.MeatsAmount = 0;
            }
        }

        /// <summary>
        /// Oils Methods
        /// </summary>
        private async void SaveOils()
        {
            if (foodList == null)
            {
                foodList = await foodService.GetFoodListAsync();
            }

            if (foodFormModel.OilsId != null && foodFormModel.OilsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == foodFormModel.OilsId).FirstOrDefault(),
                    FoodAmount = foodFormModel.OilsAmount
                };
                AddOrUpdateFood(newFood);
                foodFormModel.OilsId = null;
                foodFormModel.OilsAmount = 0;
            }
        }

        private void AddOils()
        {
            if (foodFormModel.OilsAmount < 0)
            {
                foodFormModel.OilsAmount = 0;
            }
            else
            {
                foodFormModel.OilsAmount ++;
            }
        }

        private void MinusOils()
        {
            if (foodFormModel.OilsAmount > 0)
            {
                foodFormModel.OilsAmount --;
            }
            else
            {
                foodFormModel.OilsAmount = 0;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        public void AddOrUpdateFood(SavedFood newFood)
        {
            var existingFood = savedFoodList.FirstOrDefault(f => f.FoodItem == newFood.FoodItem);
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
