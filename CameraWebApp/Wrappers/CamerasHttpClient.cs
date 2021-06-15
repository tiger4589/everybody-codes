using CameraWebApp.Wrappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers
{
    public class CamerasHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public CamerasHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            return await _httpClient.GetAsync(uri).ConfigureAwait(true);
        }

        public async Task<HttpResponseMessage> PostAsync(string uri, HttpContent content)
        {
            return await _httpClient.PostAsync(uri, content).ConfigureAwait(true);
        }
    }
}
