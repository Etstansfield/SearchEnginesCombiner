using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace SearchEngines.Classes
{
    public class Google
    {
        public static async Task<List<string>> getGoogleResults(string query)
        {
            var results = await Utils.getImageResults($"https://www.google.com/search?q={query}r&tbm=isch");

            return results;
        } 
    }
}
