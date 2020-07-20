using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace SearchEngines.Classes
{
    public class Bing
    {
        public static async Task<List<string>> getBingResults(string query)
        {
            var results = await Utils.getImageResults($"https://www.bing.com/images/search?q={query}");

            return results;
        }

    }
}
