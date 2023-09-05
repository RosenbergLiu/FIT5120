using MainProject.Data;
using MainProject.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Configuration;

namespace MainProject.Pages
{
    public partial class Iteration2
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await InitialWasteYearVis();
            await InitialFormAsync();
            InitialMapAsync();
        }
    }
}
