using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers.Interfaces
{
    public interface IStringContentPreparer
    {
        StringContent PrepareStringContent(string content, Encoding encoding, string mediaType);
    }
}
