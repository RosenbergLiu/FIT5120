using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodSaver.Data;

namespace FoodSaver.Pages.WasteOverTime
{
    public class WasteOverTimeModel : PageModel
    {
        private readonly FoodSaver.Data.FoodSaverContext _context;

        public WasteOverTimeModel(FoodSaver.Data.FoodSaverContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FoodWasteModel FoodWasteModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FoodWasteModel == null || FoodWasteModel == null)
            {
                return Page();
            }

            _context.FoodWasteModel.Add(FoodWasteModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
