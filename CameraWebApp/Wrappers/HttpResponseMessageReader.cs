using CameraWebApp.Wrappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers
{
    public class HttpResponseMessageReader : IHttpResponseMessageReader
    {
        public async Task<string> ReadMessage(HttpResponseMessage response)
        {
            return await response.Content.ReadAsStringAsync().ConfigureAwait(true);
        }
    }
}
