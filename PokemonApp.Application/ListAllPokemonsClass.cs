using PokemonApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Application
{
   public class ListAllPokemonsClass
    {
        public static List<PokemonModel> ListOfAllPokemons { get; set; } = new List<PokemonModel>();

        public static List<string> stringListEnum = Enum.GetNames<PokemonNames>().ToList();
    }
}
