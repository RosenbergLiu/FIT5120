using MainProject.Data;
using MainProject.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace MainProject.Pages
{
    public partial class Index
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await InitialFormAsync();
        }

        public async Task OnSubmit(FoodFormModel args)
        {

        }

        void DeleteItem(SavedFood item)
        {
            // Logic to delete the item from savedFoodList
            savedFoodList.Remove(item);
            // You may also need to call any database or service to make the deletion persistent

            // Refresh the grid or necessary components
            StateHasChanged();
        }
    }
}
