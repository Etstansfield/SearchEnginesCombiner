using SearchEngines.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchEngines.Classes
{
    // Code From: https://stackoverflow.com/questions/36425008/mocking-httpclient-in-unit-tests
    /// <summary>
    /// HTTP Client adaptor wraps a <see cref="System.Net.Http.HttpClient"/> 
    /// that contains a reference to <see cref="ConfigurableMessageHandler"/>
    /// </summary>
    public class HttpClientAdaptor : IHttpClient
    {
        HttpClient httpClient;

        public HttpClientAdaptor(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        //...other code

        /// <summary>
        ///  Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="uri">The Uri the request is sent to</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<string> GetAsync(string uri)
        {
            var result = default(string);
            //Try to get content as T
            try
            {
                //send request and get the response
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
                //if there is content in response to deserialize
                if (response.Content.Headers.ContentLength.GetValueOrDefault() > 0)
                {
                    //get the content
                    string responseBodyAsText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    //desrialize it
                    result = responseBodyAsText;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return result;
        }

        //...other code
    }
}
