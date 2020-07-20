using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchEngines.Classes;

namespace SearchEngines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{query}")]
        public async Task<List<string>> Get(string query)
        {

            var googleImages = Google.getGoogleResults(query);
            var ecosiaImages = Ecosia.getEcosiaResults(query);
            var bingImages = Bing.getBingResults(query);
            var yahooImages = Bing.getBingResults(query);

            Task.WaitAll(new Task<List<string>>[] { googleImages, ecosiaImages, bingImages, yahooImages });


            return googleImages.Result.Concat(ecosiaImages.Result).Concat(bingImages.Result).Concat(yahooImages.Result).ToList();
        }

        
    }
}