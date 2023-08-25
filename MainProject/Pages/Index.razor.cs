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

        void DeleteItem(SavedFood item)
        {
            savedFoodList.Remove(item);
            StateHasChanged();
        }
    }
}
