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

namespace MainProject.Pages
{
    public partial class Recipes
    {
        bool isLoading = false;
        string? ingredientInput;
        string? apiKey;
        RestClient client = new RestClient(new RestClientOptions("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com")
        {
            MaxTimeout = -1,
        });

        List<Ingredient> ingredientsResult = new List<Ingredient>();
        List<Ingredient> ingredientsList = new List<Ingredient>();

        class Ingredient
        {
            [JsonProperty("name")]
            public string? IngredientName;
        }

        async Task Search()
        {
            isLoading = true;
            if(apiKey!=null)
            {
                if (ingredientInput != null)
                {
                    var request = new RestRequest($"/food/ingredients/autocomplete?query={ingredientInput}&number=15", Method.Get);
                    request.AddHeader("X-RapidAPI-Key", "bffaa60994mshad99b0c495fe234p1bbc5fjsn7179305ed32f");
                    request.AddHeader("X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com");
                    RestResponse response = await client.ExecuteAsync(request);
                    var content = response.Content;
                    if(content != null)
                    {
                        ingredientsResult = JsonConvert.DeserializeObject<List<Ingredient>>(content)?.ToList();
                    }
                }
            }
            isLoading = false;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            apiKey = configration["X-RapidAPI-Key"] ?? null;
        }

        void Add(Ingredient ingredient)
        {
            ingredientsResult.Remove(ingredient);
            ingredientsList.Add(ingredient);
        }
    }
}