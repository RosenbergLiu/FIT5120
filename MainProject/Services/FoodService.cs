using MainProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Radzen;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace MainProject.Services
{
    public class FoodService
    {
        private readonly MainProjectContext _context;

        public FoodService(MainProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> GetFoodListAsync() {
            return await _context.Foods.ToListAsync();
        }

        public async Task UploadUserRecord(UserDataRecord newRecord)
        {
            await _context.UserDataRecords.AddAsync(newRecord);
            await _context.SaveChangesAsync();
        }

        public async Task<OtherUserDataViewModel?> GetUserDataRecords()
        {
            var otherUserDataList = await _context.UserDataRecords.ToListAsync();
            if(otherUserDataList.Count > 0)
            {
                return new OtherUserDataViewModel
                {
                    AvgGHG = otherUserDataList.Average(o => o.RecordGHG),
                    AvgWater = otherUserDataList.Average(o => o.RecordWater),
                    AvgLand = otherUserDataList.Average(o => o.RecordLand),
                    AvgEutrophying = otherUserDataList.Average(o => o.RecordEutrophying)
                };
            }
            else
            {
                OtherUserDataViewModel results = new OtherUserDataViewModel();
                return results;
            }
        }

        public async Task<IEnumerable<FoodWaste>> GetFoodWasteDataAsync()
        {
            return await _context.FoodWastes.ToListAsync();

        }
    }
}
