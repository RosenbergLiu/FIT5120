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
    }
}
