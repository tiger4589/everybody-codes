using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers.Interfaces
{
    public interface IHttpResponseMessageReader
    {
        Task<string> ReadMessage(HttpResponseMessage response);
    }
}
