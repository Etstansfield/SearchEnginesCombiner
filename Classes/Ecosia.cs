
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using SearchEngines.Interfaces;

namespace SearchEngines.Classes
{
    public class Ecosia
    {
        public static async Task<List<string>> getEcosiaResults(string query, IHttpClient client)
        {

            var results = await Utils.getImageResults($"https://www.ecosia.org/images?q={query}", client);

            return results;
        }

    }
}
