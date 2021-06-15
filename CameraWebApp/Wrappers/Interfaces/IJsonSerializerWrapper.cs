using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers.Interfaces
{
    public interface IJsonSerializerWrapper
    {
        string SerializeObject<T>(T content);
    }
}
