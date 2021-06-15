using CameraShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers.Interfaces
{
    public interface IJsonDeserializerWrapper
    {
        CameraListApiResponse DeserializeApiCallResult(string apiResponse);
    }
}
