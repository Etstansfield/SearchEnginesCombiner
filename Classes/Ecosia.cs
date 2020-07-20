
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace SearchEngines.Classes
{
    public class Ecosia
    {
        public static async Task<List<string>> getEcosiaResults(string query)
        {

            var results = await Utils.getImageResults($"https://www.ecosia.org/images?q={query}");

            return results;
        }

    }
}
