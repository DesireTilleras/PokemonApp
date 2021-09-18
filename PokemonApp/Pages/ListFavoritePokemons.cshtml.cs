using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PokemonApp.Application;
using PokemonApp.Data;

namespace PokemonApp.UI.Pages
{
    public class ListFavoritePokemonsModel : PageModel
    {
        public List<PokemonModel> CookiePokemons { get; set; } = new List<PokemonModel>();
        public void OnGet()
        {
            string stringPokemons = HttpContext.Session.GetString("Favorites");

            if (!String.IsNullOrEmpty(stringPokemons))
            {
                CookiePokemons = JsonConvert.DeserializeObject<List<PokemonModel>>(stringPokemons);
            }
        }
        public IActionResult OnPostDelete(string name)
        {

            string stringFavorites = HttpContext.Session.GetString("Favorites");

            List<PokemonModel> favorites = new List<PokemonModel>();

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                favorites = JsonConvert.DeserializeObject<List<PokemonModel>>(stringFavorites);
            }

            var onePokemon = favorites.Where(x => x.name == name).FirstOrDefault();

            var pokemon = ListAllPokemonsClass.ListOfAllPokemons.Where(x => x.name == name).FirstOrDefault();

            pokemon.isFavorite = false;

            favorites.Remove(onePokemon);

            stringFavorites = JsonConvert.SerializeObject(favorites);
            HttpContext.Session.SetString("Favorites", stringFavorites);

            return RedirectToPage("Index");
        }
    }
}
