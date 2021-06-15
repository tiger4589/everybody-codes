using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers.Interfaces
{
    public interface IHttpClientWrapper
    {
        Task<string> CallPostApi<T>(string url, T content);
        Task<string> CallGetApi(string url);
    }
}
