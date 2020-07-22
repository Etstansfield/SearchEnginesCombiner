using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using SearchEngines.Interfaces;

namespace SearchEngines.Classes
{
    public class Google
    {
        public static async Task<List<string>> getGoogleResults(string query, IHttpClient client)
        {
            Debug.WriteLine("Here");
            var results = await Utils.getImageResults($"https://www.google.com/search?q={query}r&tbm=isch", client);

            return results;
        } 
    }
}
