using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using SearchEngines.Interfaces;

namespace SearchEngines.Classes
{
    public class Bing
    {
        public static async Task<List<string>> getBingResults(string query, IHttpClient client)
        {
            var results = await Utils.getImageResults($"https://www.bing.com/images/search?q={query}", client);

            return results;
        }

    }
}
