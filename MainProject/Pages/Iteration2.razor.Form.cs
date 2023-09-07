using MainProject.Data;
using MainProject.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MainProject.Pages
{
    public partial class Iteration2
    {
        FoodFormViewModel foodFormViewModel = new FoodFormViewModel();

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

            if (foodFormViewModel.CerealsId !=null && foodFormViewModel.CerealsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == foodFormViewModel.CerealsId).FirstOrDefault(),
                    FoodAmount = foodFormViewModel.CerealsAmount
                };
                newFood = CalculateWaste(newFood);
                AddOrUpdateFood(newFood);
                foodFormViewModel.CerealsId = null;
                foodFormViewModel.CerealsAmount = 0;
                CalculateWasteSum();
                UpdateVisualization();
                UpdateCompare();
            }
        }

        private void AddCereals()
        {
            if (foodFormViewModel.CerealsAmount < 0)
            {
                foodFormViewModel.CerealsAmount = 0;
            }
            else
            {
                foodFormViewModel.CerealsAmount ++;
            }
        }

        private void MinusCereals()
        {
            if (foodFormViewModel.CerealsAmount > 0)
            {
                foodFormViewModel.CerealsAmount --;
            }
            else
            {
                foodFormViewModel.CerealsAmount = 0;
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

            if (foodFormViewModel.FruitsId != null && foodFormViewModel.FruitsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == foodFormViewModel.FruitsId).FirstOrDefault(),
                    FoodAmount = foodFormViewModel.FruitsAmount
                };
                newFood = CalculateWaste(newFood);
                AddOrUpdateFood(newFood);
                foodFormViewModel.FruitsId = null;
                foodFormViewModel.FruitsAmount = 0;
                CalculateWasteSum();
                UpdateVisualization();
                UpdateCompare();
            }
        }

        private void AddFruits()
        {
            if (foodFormViewModel.FruitsAmount < 0)
            {
                foodFormViewModel.FruitsAmount = 0;
            }
            else
            {
                foodFormViewModel.FruitsAmount ++;
            }
        }

        private void MinusFruits()
        {
            if (foodFormViewModel.FruitsAmount > 0)
            {
                foodFormViewModel.FruitsAmount --;
            }
            else
            {
                foodFormViewModel.FruitsAmount = 0;
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

            if (foodFormViewModel.MeatsId != null && foodFormViewModel.MeatsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == foodFormViewModel.MeatsId).FirstOrDefault(),
                    FoodAmount = foodFormViewModel.MeatsAmount
                };
                newFood = CalculateWaste(newFood);
                AddOrUpdateFood(newFood);
                foodFormViewModel.MeatsId = null;
                foodFormViewModel.MeatsAmount = 0;
                CalculateWasteSum();
                UpdateVisualization();
                UpdateCompare();
            }
            else
            {
                foodFormViewModel.MeatsAmount = 0;
            }
        }

        private void AddMeats()
        {
            if (foodFormViewModel.MeatsAmount < 0)
            {
                foodFormViewModel.MeatsAmount = 0;
            }
            else
            {
                foodFormViewModel.MeatsAmount ++;
            }
        }

        private void MinusMeats()
        {
            if (foodFormViewModel.MeatsAmount > 0)
            {
                foodFormViewModel.MeatsAmount --;
            }
            else
            {
                foodFormViewModel.MeatsAmount = 0;
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

            if (foodFormViewModel.OilsId != null && foodFormViewModel.OilsAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodItem = foodList.Where(f => f.FoodId == foodFormViewModel.OilsId).FirstOrDefault(),
                    FoodAmount = foodFormViewModel.OilsAmount,
                };
                newFood = CalculateWaste(newFood);
                AddOrUpdateFood(newFood);
                foodFormViewModel.OilsId = null;
                foodFormViewModel.OilsAmount = 0;
                CalculateWasteSum();
                UpdateVisualization();
                UpdateCompare();
            }
        }

        private void AddOils()
        {
            if (foodFormViewModel.OilsAmount < 0)
            {
                foodFormViewModel.OilsAmount = 0;
            }
            else
            {
                foodFormViewModel.OilsAmount ++;
            }
        }

        private void MinusOils()
        {
            if (foodFormViewModel.OilsAmount > 0)
            {
                foodFormViewModel.OilsAmount --;
            }
            else
            {
                foodFormViewModel.OilsAmount = 0;
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
            CalculateWasteSum();
            UpdateVisualization();
            UpdateCompare();
            StateHasChanged();
        }

        void UpdateCompare()
        {
            if(GHGCompare != null)
            {
                foreach(var item in GHGCompare)
                {
                    if(item.Category == "Me")
                    {
                        item.Amount = GHGSum;
                    }
                }
            }

            if (waterCompare != null)
            {
                foreach (var item in waterCompare)
                {
                    if (item.Category == "Me")
                    {
                        item.Amount = WaterSum;
                    }
                }
            }

            if (landCompare != null)
            {
                foreach (var item in landCompare)
                {
                    if (item.Category == "Me")
                    {
                        item.Amount = LandSum;
                    }
                }
            }

            if (eutrophyingCompare != null)
            {
                foreach (var item in eutrophyingCompare)
                {
                    if (item.Category == "Me")
                    {
                        item.Amount = EutrophyingSum;
                    }
                }
            }
        }
    }
}
