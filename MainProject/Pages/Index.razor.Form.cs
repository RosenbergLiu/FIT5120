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
        /// Vegetable Methods
        /// </summary>
        private void SaveVegetable()
        {
            if(foodFormModel.VegetableId !=null && foodFormModel.VegetableAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodId = foodFormModel.VegetableId,
                    FoodAmount = foodFormModel.VegetableAmount
                };
                AddOrUpdateFood(newFood);
                foodFormModel.VegetableId = null;
                foodFormModel.VegetableAmount = 0;
            }
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
        /// Meat Methods
        /// </summary>
        private void SaveMeat()
        {
            if (foodFormModel.MeatId != null && foodFormModel.MeatAmount > 0)
            {
                SavedFood newFood = new SavedFood()
                {
                    FoodId = foodFormModel.MeatId,
                    FoodAmount = foodFormModel.MeatAmount
                };
                AddOrUpdateFood(newFood);
                foodFormModel.MeatId = null;
                foodFormModel.MeatAmount = 0;
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

        /// <summary>
        /// Other Methods
        /// </summary>
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
