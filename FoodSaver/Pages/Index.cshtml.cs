using FoodSaver.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodSaver.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly FoodSaverContext _context;

    public List<FoodWaste> FoodWastes { get; set; }

    public IndexModel(ILogger<IndexModel> logger, FoodSaverContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task OnGetAsync()
    {
        FoodWastes = await _context.FoodWastes.ToListAsync();
    }


    public string? selectedGrocery = null;
}