using CameraShared.Models;
using CameraWebApp.Wrappers.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers
{
    public class JsonDeserializerWrapper : IJsonDeserializerWrapper
    {
        public CameraListApiResponse DeserializeApiCallResult(string apiResponse)
        {
            return JsonConvert.DeserializeObject<CameraListApiResponse>(apiResponse);
        }
    }
}
