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
        bool showCompare = false;
        OtherUserDataViewModel? otherUserDataViewModel;

        CompareViewModel[]? GHGCompare = new CompareViewModel[]
        {
            new CompareViewModel{ Category = "Me", Amount = 24 },
            new CompareViewModel{ Category = "Average", Amount = 34 }
        };
        CompareViewModel[]? waterCompare;
        CompareViewModel[]? landCompare;
        CompareViewModel[]? eutrophyingCompare;

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

                if(otherUserDataViewModel!= null)
                {
                    GHGCompare = new CompareViewModel[]
                    {
                        new CompareViewModel{ Category = "Me", Amount = GHGSum },
                        new CompareViewModel{ Category = "Average", Amount = Math.Round(otherUserDataViewModel.AvgGHG, 2) }
                    };

                    waterCompare = new CompareViewModel[]
                    {
                        new CompareViewModel{ Category = "Me", Amount = WaterSum },
                        new CompareViewModel{ Category = "Average", Amount = Math.Round(otherUserDataViewModel.AvgWater, 2) }
                    };

                    landCompare = new CompareViewModel[]
                    {
                        new CompareViewModel{ Category = "Me", Amount = LandSum },
                        new CompareViewModel{ Category = "Average", Amount = Math.Round(otherUserDataViewModel.AvgLand, 2) }
                    };

                    eutrophyingCompare = new CompareViewModel[]
                    {
                        new CompareViewModel{ Category = "Me", Amount = EutrophyingSum },
                        new CompareViewModel{ Category = "Average", Amount = Math.Round(otherUserDataViewModel.AvgEutrophying, 2) }
                    };

                    showCompare = true;
                }

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
