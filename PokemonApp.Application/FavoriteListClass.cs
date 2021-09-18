using PokemonApp.Data;
using System;
using System.Collections.Generic;

namespace PokemonApp.Application
{
    public class FavoriteListClass
    {
        public static List<PokemonModel> ListOfFavorites { get; set; } = new List<PokemonModel>();
    }
}
