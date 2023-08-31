using Radzen.Blazor.Rendering;
using Radzen.Blazor;
using Radzen;

namespace MainProject.Pages
{
    public partial class Index
    {
        bool seeOthers = false;

        public async Task ShowConfirmedAsync()
        {
            seeOthers = await DialogService.Confirm(
                "Seeing other people's data would collect your food waste data.", 
                "Data collection notice", 
                new ConfirmOptions() { OkButtonText = "I achknowleged", CancelButtonText = "I refuse" }
                ) ?? false;

            if(seeOthers) {
                isLoading = true;
                await UploadUserData();
            }
        }

        public async Task UploadUserData()
        {
            string? ip = HttpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            {
                notificationService.Notify(NotificationSeverity.Info, "IP", ip);
            }
        }
    }
}
