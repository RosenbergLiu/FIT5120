using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RestSharp;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Collections.ObjectModel;
using MainProject.Data;

namespace MainProject.Pages
{
    public partial class Recipes
    {
        bool isLoading = false;
        string? apiKey;
        RestClient client;
        bool isSearching = false;

        List<RecipeModel> recipesResult = new List<RecipeModel>();
        List<RecipeDetailModel> recipesDetailedResult = new List<RecipeDetailModel>();
        List<Ingredient> ingredientsResult = new List<Ingredient>();
        List<Ingredient> ingredientsList = new List<Ingredient>();

        class Ingredient
        {
            [JsonProperty("name")]
            public string? IngredientName;
        }

        class SearchViewModel
        {
            public string? IngredientInput;
        }

        SearchViewModel searchViewModel = new SearchViewModel();

        async Task Search(SearchViewModel args)
        {
            isSearching = true;
            if(apiKey!=null)
            {
                if (args.IngredientInput != null)
                {
                    var request = new RestRequest($"/food/ingredients/autocomplete?query={args.IngredientInput}&number=15", Method.Get);
                    request.AddHeader("X-RapidAPI-Key", apiKey);
                    request.AddHeader("X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com");
                    RestResponse response = await client.ExecuteAsync(request);
                    var content = response.Content;
                    if(content != null)
                    {
                        ingredientsResult = JsonConvert.DeserializeObject<List<Ingredient>>(content)?.ToList();
                    }
                }
            }
            isSearching = false;
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            apiKey = configration["X-RapidAPI-Key"] ?? null;
            client = new RestClient(new RestClientOptions("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com")
            {
                MaxTimeout = -1,
            });
        }

        void Add(Ingredient ingredient)
        {
            ingredientsList.Add(ingredient);
            ingredientsResult = new List<Ingredient>();
            searchViewModel = new SearchViewModel();
        }

        void Delete(Ingredient ingredient)
        {
            ingredientsList.Remove(ingredient);
        }

        private async Task<List<RecipeModel>> GetRecipesListAsync()
        {
            if (apiKey != null)
            {
                string ingredients = string.Join("%2C", ingredientsList.Select(i => i.IngredientName).ToList());
                var request = new RestRequest($"/recipes/findByIngredients?ingredients={ingredients}&number=200&ignorePantry=true&ranking=1", Method.Get);
                request.AddHeader("X-RapidAPI-Key", apiKey);
                request.AddHeader("X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com");
                RestResponse response = await client.ExecuteAsync(request);
                var content = response.Content;
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<List<RecipeModel>>(content).ToList();
                }
            }
            return null;
        }

        private async Task GetImgAsync()
        {
            foreach(var item in recipesResult)
            {

            }
        }

        private async Task<List<RecipeDetailModel>> GetDetailsAsync()
        {
            if (apiKey != null)
            {
                string ids = string.Join("%2C", recipesResult.Select(i => i.Id).ToList());
                var request = new RestRequest($"https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/informationBulk?ids={ids}", Method.Get);
                request.AddHeader("X-RapidAPI-Key", apiKey);
                request.AddHeader("X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com");
                RestResponse response = await client.ExecuteAsync(request);
                var content = response.Content;
                if (content != null)
                {
                    return JsonConvert.DeserializeObject<List<RecipeDetailModel>>(content).ToList();
                }
            }

            return null;
        }

        public async Task SearchRecipesAsync()
        {
            if (ingredientsList != null)
            {
                isLoading = true;
                recipesResult = await GetRecipesListAsync();
                if (recipesResult != null)
                {
                    recipesDetailedResult = await GetDetailsAsync();
                }
                isLoading = false;
                StateHasChanged();
            }
        }
    }
}