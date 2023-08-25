using MainProject.Data;
using MainProject.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Configuration;

namespace MainProject.Pages
{
    public partial class Index
    {
        string googleMapApi = "";
        string googleMapSrc = "";
        string googleMapZoom = "9";

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            googleMapApi = configuration["GoogleMapAPI"] ?? "";
            googleMapSrc = $"https://www.google.com/maps/embed/v1/search?key={googleMapApi}&q=foodbank+in+Melbourne&zoom={googleMapZoom}";
            await InitialFormAsync();
        }

        void DeleteItem(SavedFood item)
        {
            savedFoodList.Remove(item);
            StateHasChanged();
        }
    }
}
