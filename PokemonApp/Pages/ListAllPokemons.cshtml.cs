using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonApp.Application;
using PokemonApp.Data;

namespace PokemonApp.UI.Pages
{
    public class ListAllPokemonsModel : PageModel
    {
        public List<PokemonModel> AllPokemons = ListAllPokemonsClass.ListOfAllPokemons;
        public void OnGet()
        {

        }
    }
}
