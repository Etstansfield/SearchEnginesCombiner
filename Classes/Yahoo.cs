using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace SearchEngines.Classes
{
    public class Yahoo
    {
        public static async Task<List<string>> getYahooResults(string query)
        {
            var results = await Utils.getImageResults($"https://uk.images.search.yahoo.com/search/images?p={query}");

            return results;
        }

    }
}
