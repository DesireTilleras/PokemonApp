using System;

namespace PokemonApp.Data
{
    public class PokemonModel
    {
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        public string ImageURL = "/Pokemon images/*.png";
        public bool isFavorite { get; set; }
    }
}
