using MainProject.Data;
using MainProject.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MainProject.Pages
{
    public partial class Index
    {
        FoodFormViewModel FoodFormViewModel = new FoodFormViewModel();

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

            if (FoodFormViewModel.CerealsId !=null && FoodFormViewModel.CerealsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == FoodFormViewModel.CerealsId).FirstOrDefault(),
                    FoodAmount = FoodFormViewModel.CerealsAmount
                };
                newFood = CalculateWaste(newFood);
                AddOrUpdateFood(newFood);
                FoodFormViewModel.CerealsId = null;
                FoodFormViewModel.CerealsAmount = 0;
                CalculateWasteSum();
                UpdateVisualization();
            }
        }

        private void AddCereals()
        {
            if (FoodFormViewModel.CerealsAmount < 0)
            {
                FoodFormViewModel.CerealsAmount = 0;
            }
            else
            {
                FoodFormViewModel.CerealsAmount ++;
            }
        }

        private void MinusCereals()
        {
            if (FoodFormViewModel.CerealsAmount > 0)
            {
                FoodFormViewModel.CerealsAmount --;
            }
            else
            {
                FoodFormViewModel.CerealsAmount = 0;
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

            if (FoodFormViewModel.FruitsId != null && FoodFormViewModel.FruitsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == FoodFormViewModel.FruitsId).FirstOrDefault(),
                    FoodAmount = FoodFormViewModel.FruitsAmount
                };
                newFood = CalculateWaste(newFood);
                AddOrUpdateFood(newFood);
                FoodFormViewModel.FruitsId = null;
                FoodFormViewModel.FruitsAmount = 0;
                CalculateWasteSum();
                UpdateVisualization();
            }
        }

        private void AddFruits()
        {
            if (FoodFormViewModel.FruitsAmount < 0)
            {
                FoodFormViewModel.FruitsAmount = 0;
            }
            else
            {
                FoodFormViewModel.FruitsAmount ++;
            }
        }

        private void MinusFruits()
        {
            if (FoodFormViewModel.FruitsAmount > 0)
            {
                FoodFormViewModel.FruitsAmount --;
            }
            else
            {
                FoodFormViewModel.FruitsAmount = 0;
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

            if (FoodFormViewModel.MeatsId != null && FoodFormViewModel.MeatsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == FoodFormViewModel.MeatsId).FirstOrDefault(),
                    FoodAmount = FoodFormViewModel.MeatsAmount
                };
                newFood = CalculateWaste(newFood);
                AddOrUpdateFood(newFood);
                FoodFormViewModel.MeatsId = null;
                FoodFormViewModel.MeatsAmount = 0;
                CalculateWasteSum();
                UpdateVisualization();
            }
            else
            {
                FoodFormViewModel.MeatsAmount = 0;
            }
        }

        private void AddMeats()
        {
            if (FoodFormViewModel.MeatsAmount < 0)
            {
                FoodFormViewModel.MeatsAmount = 0;
            }
            else
            {
                FoodFormViewModel.MeatsAmount ++;
            }
        }

        private void MinusMeats()
        {
            if (FoodFormViewModel.MeatsAmount > 0)
            {
                FoodFormViewModel.MeatsAmount --;
            }
            else
            {
                FoodFormViewModel.MeatsAmount = 0;
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

            if (FoodFormViewModel.OilsId != null && FoodFormViewModel.OilsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == FoodFormViewModel.OilsId).FirstOrDefault(),
                    FoodAmount = FoodFormViewModel.OilsAmount,
                };
                newFood = CalculateWaste(newFood);
                AddOrUpdateFood(newFood);
                FoodFormViewModel.OilsId = null;
                FoodFormViewModel.OilsAmount = 0;
                CalculateWasteSum();
                UpdateVisualization();
            }
        }

        private void AddOils()
        {
            if (FoodFormViewModel.OilsAmount < 0)
            {
                FoodFormViewModel.OilsAmount = 0;
            }
            else
            {
                FoodFormViewModel.OilsAmount ++;
            }
        }

        private void MinusOils()
        {
            if (FoodFormViewModel.OilsAmount > 0)
            {
                FoodFormViewModel.OilsAmount --;
            }
            else
            {
                FoodFormViewModel.OilsAmount = 0;
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

        public SavedFood CalculateWaste(SavedFood food)
        {
            if(food.FoodItem != null)
            {
                food.FoodName = food.FoodItem.FoodName;
                food.FoodGHG = Math.Round(food.FoodItem.GHG * food.FoodAmount, 2);
                food.FoodLand = Math.Round(food.FoodItem.Land * food.FoodAmount, 2);
                food.FoodWater = Math.Round(food.FoodItem.Water * food.FoodAmount, 2);
                food.FoodEutrophying = Math.Round(food.FoodItem.Eutrophying * food.FoodAmount, 2);
            }

            return food;
        }

        void DeleteItem(SavedFood item)
        {
            savedFoodList.Remove(item);
            StateHasChanged();
        }
    }
}
