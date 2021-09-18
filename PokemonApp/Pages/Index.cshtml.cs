using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PokemonApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonApp.API;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PokemonApp.Application;

namespace PokemonApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public PokemonModel Pokemon { get; set; }

        [BindProperty]
        public string SetName { get; set; }      

        
        public SelectList listOfPokemonNames = new SelectList(ListAllPokemonsClass.stringListEnum);      
        

        public List<PokemonModel> FavoritesList = FavoriteListClass.ListOfFavorites;

        public List<PokemonModel> AllPokemons = ListAllPokemonsClass.ListOfAllPokemons;


        public async Task StartUp()
        {

            foreach (var pokemon in ListAllPokemonsClass.stringListEnum)
            {
                Pokemon = await PokemonProcessor.LoadPokemon(pokemon.ToLower());

                Pokemon.ImageURL = Pokemon.ImageURL.Replace("*", pokemon).ToLower();

                AllPokemons.Add(Pokemon);
            }
        }

        public void OnGet()
        {
         
        }

        public void OnPostShow()
        {
            var name = SetName.ToLower();
            Pokemon = AllPokemons.Where(x => x.name == name).FirstOrDefault();        
         
        }
        public void OnPostAddToFavorite(string name)
        {
            SetName = name;

            Pokemon = AllPokemons.Where(x => x.name == SetName).FirstOrDefault();

            Pokemon.isFavorite = true;

            string stringFavorites = HttpContext.Session.GetString("Favorites");           

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                FavoritesList = JsonConvert.DeserializeObject<List<PokemonModel>>(stringFavorites);
            }

            FavoritesList.Add(Pokemon);

            stringFavorites = JsonConvert.SerializeObject(FavoritesList);
            HttpContext.Session.SetString("Favorites", stringFavorites);

            RedirectToPage("Index");
        }
    }
}

