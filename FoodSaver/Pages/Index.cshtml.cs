using FoodSaver.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace FoodSaver.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly FoodSaverContext _context;
    private readonly IConfiguration _configuration;

    [BindProperty]
    public List<FoodWaste> FoodWastes { get; set; }

    [BindProperty]
    public List<Product> Products { get; set; }

    public string? selectedGrocery = null;

    public IndexModel(ILogger<IndexModel> logger, FoodSaverContext context, IConfiguration configuration)
    {
        _logger = logger;
        _context = context;
        _configuration = configuration;
    }

    public async Task OnGetAsync()
    {
        FoodWastes = await _context.FoodWastes.ToListAsync();
        Random random = new Random();
        Products = await _context.Products.ToListAsync();
    }

    public JsonResult OnPostRefreshProducts()
    {
        Products = _context.Products.ToList();
        return new JsonResult(Products);
    }
}