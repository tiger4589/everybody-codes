using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers.Interfaces
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> PostAsync(string uri, HttpContent content);
        Task<HttpResponseMessage> GetAsync(string uri);
    }
}
