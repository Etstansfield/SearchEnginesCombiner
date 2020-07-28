using SearchEngines.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace SearchEngines.Classes
{
    public class Utils
    {

        public static async Task<List<string>> getImageResults(string url, IHttpClient client)
        {
            string finalResult = "";
            try
            {
                var results = await client.GetAsync(url);
                // Debug.WriteLine(results);
                finalResult = results;
            }
            catch (HttpRequestException err)
            {
                Debug.WriteLine("Http Error: " + err);
            }

            // Debug.WriteLine(finalResult);
            // TODO - error handling

            return parseImgs(finalResult);
        }
        public static List<string> parseImgs(string rawHtml)
        {
            List<string> imgs = new List<string> { };

            // go over the html and find all of the img tags
            // Debug.WriteLine(rawHtml);

            Regex imgRgx = new Regex(@"(<img([^>]+)>)");
            MatchCollection matches = imgRgx.Matches(rawHtml);

            string pattern = @"<img.*?src=""(?<url>http.*?)"".*?>";
            string pattern2 = @"<img.*?src='(?<url>http.*?)'.*?>";
            Regex rx = new Regex(pattern);
            Regex rx2 = new Regex(pattern2);


            foreach (Match match in matches)
            {
                // Debug.WriteLine($"Match: {match}");
                // Now we need to go over and grab the src of all of these - make sure they start with http - these are the external imgs
                // Match srcMatch = srcRgx.Match(match.ToString());
                // Debug.WriteLine($"Src: {srcMatch}");

                foreach (Match m in rx.Matches(match.ToString()))
                {
                    // Debug.WriteLine("Tag: " + m.Value);
                    // Debug.WriteLine("URL: " + m.Groups["url"].Value);
                    // Debug.WriteLine("");
                    imgs.Add(m.Groups["url"].Value);
                }

                foreach (Match m in rx2.Matches(match.ToString()))
                {
                    // Debug.WriteLine("Tag: " + m.Value);
                    // Debug.WriteLine("URL: " + m.Groups["url"].Value);
                    // Debug.WriteLine("");
                    imgs.Add(m.Groups["url"].Value);
                }
            }

            return imgs.Distinct().ToList();    // remove duplicate values picked up (especially from yahoo who have data-src in their images for some reason)
        }
    }
}
