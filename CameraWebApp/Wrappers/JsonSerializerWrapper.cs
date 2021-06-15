using CameraWebApp.Wrappers.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers
{
    public class JsonSerializerWrapper : IJsonSerializerWrapper
    {
        public string SerializeObject<T>(T content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}
