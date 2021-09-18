using PokemonApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace PokemonApp.API
{
    public class PokemonProcessor
    {
        public static async Task<PokemonModel> LoadPokemon(string name)
        {
            string url = ApiHelper.ApiClient.BaseAddress.ToString().Replace("*", name).ToLower();

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PokemonModel activity = await response.Content.ReadAsAsync<PokemonModel>();

                    return activity;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
