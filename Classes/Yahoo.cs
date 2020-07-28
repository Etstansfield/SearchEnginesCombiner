using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using SearchEngines.Interfaces;

namespace SearchEngines.Classes
{
    public class Yahoo
    {
        public static async Task<List<string>> getYahooResults(string query, IHttpClient client)
        {
            var results = await Utils.getImageResults($"https://uk.images.search.yahoo.com/search/images?p={query}&guccounter=1", client);
            Debug.WriteLine($"Brought back {results.Count} results");
            return results;
        }

    }
}
