using Radzen.Blazor.Rendering;
using Radzen.Blazor;
using Radzen;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using MainProject.Data;
using Newtonsoft.Json;

namespace MainProject.Pages
{
    public partial class Index
    {
        bool seeOthers = false;
        OtherUserDataViewModel? otherUserDataViewModel = new OtherUserDataViewModel();

        public async Task ShowConfirmedAsync()
        {
            seeOthers = await DialogService.Confirm(
                "Seeing other people's data would collect your food waste data.", 
                "Data collection notice", 
                new ConfirmOptions() { OkButtonText = "I acknowledge", CancelButtonText = "I refuse" }
                ) ?? false;

            StateHasChanged();

            if (seeOthers) {
                isLoading = true;
                otherUserDataViewModel = await foodService.GetUserDataRecords();
                isLoading = false;
                StateHasChanged();
                await UploadUserData();
            }
        }

        public async Task UploadUserData()
        {
            string ip = HttpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "null";
            notificationService.Notify(NotificationSeverity.Info, "IP", ip);

            UserDataRecord newRecord = new UserDataRecord()
            {
                RecordDate = DateTime.Now,
                IpHash = GetHashString(ip),
                RecordGHG = GHGSum,
                RecordWater = WaterSum,
                RecordLand = LandSum,
                RecordEutrophying = EutrophyingSum
            };

            await foodService.UploadUserRecord(newRecord);
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }
}
