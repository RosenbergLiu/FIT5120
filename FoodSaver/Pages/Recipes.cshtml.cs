using FoodSaver.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FoodSaver.Pages
{
    public class RecipesModel : PageModel
    {

        public string ApiKey { get; set; }
        public void OnGet()
        {
            ApiKey = "bffaa60994mshad99b0c495fe234p1bbc5fjsn7179305ed32f";
        }

        public void OnPost()
        {
        }
    }
}
