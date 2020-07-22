using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchEngines.Classes;

namespace SearchEngines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        IHttpClientFactory _clientFactory;
        public SearchController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{query}")]
        public async Task<List<string>> Get(string query)
        {
            Debug.WriteLine("HERE");
            HttpClientAdaptor client = new HttpClientAdaptor(_clientFactory);

            var googleImages = Google.getGoogleResults(query, client);
            var ecosiaImages = Ecosia.getEcosiaResults(query, client);
            var bingImages = Bing.getBingResults(query, client);
            var yahooImages = Bing.getBingResults(query, client);

            Task.WaitAll(new Task<List<string>>[] { googleImages, ecosiaImages, bingImages, yahooImages });


            return googleImages.Result.Concat(ecosiaImages.Result).Concat(bingImages.Result).Concat(yahooImages.Result).ToList();
        }

        
    }
}