using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngines.Interfaces
{
    // Based on code Copied From: https://stackoverflow.com/questions/36425008/mocking-httpclient-in-unit-tests
    public interface IHttpClient
    {
        System.Threading.Tasks.Task<string> GetAsync(string uri);
    }
}
