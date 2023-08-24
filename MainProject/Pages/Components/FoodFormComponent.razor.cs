using MainProject.Data;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace MainProject.Pages.Components
{
    public partial class FoodFormComponent
    {
        [Inject]
        protected NotificationService notificationService { get; set; }

        FoodFormModel foodFormModel = new FoodFormModel()
        {
            VegetableId = null,
            VegetableAmount = 0,
            MeatId = null,
            MeatAmount = 0,
            FruitsId = null,
            FruitsAmount = 0,
            OtherId = null,
            OtherAmount = 0
        };

        private IEnumerable<Food>? foodList;
        private IEnumerable<Food>? vegetablesList;
        private IEnumerable<Food>? fruitsList;
        private IEnumerable<Food>? meatList;
        private IEnumerable<Food>? otherList;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            foodList = await foodService.GetFoodListAsync();
            vegetablesList = foodList.Where(f => f.CategoryId == 1);
            fruitsList = foodList.Where(f => f.CategoryId == 2);
            meatList = foodList.Where(f => f.CategoryId == 3);
            otherList = foodList.Where(f => f.CategoryId == 4);

            var ip = HttpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            notificationService.Notify(NotificationSeverity.Info, ip);
        }

        public async Task OnSubmit(FoodFormModel args)
        {

        }

        private void AddVegetable()
        {
            foodFormModel.VegetableAmount++;
        }

        private void MinusVegetable()
        {
            if(foodFormModel.VegetableAmount > 0)
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
            if(foodFormModel.FruitsAmount > 0)
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
