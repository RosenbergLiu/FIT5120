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

    public List<FoodWaste> FoodWastes { get; set; }
    public List<Product> Products { get; set; }

    public string? selectedGrocery = null;

    public IndexModel(ILogger<IndexModel> logger, FoodSaverContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task OnGetAsync()
    {
        FoodWastes = await _context.FoodWastes.ToListAsync();
        Random random = new Random();
        Products = await _context.Products.ToListAsync();
        Products = Products.OrderBy(x => random.Next()).Take(4).ToList();
    }

    public JsonResult OnPostRefreshProducts()
    {
        Products = _context.Products.ToList();
        return new JsonResult(Products);
    }
}