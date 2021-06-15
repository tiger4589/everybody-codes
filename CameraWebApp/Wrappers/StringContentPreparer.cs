using CameraWebApp.Wrappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers
{
    public class StringContentPreparer : IStringContentPreparer
    {
        public StringContent PrepareStringContent(string content, Encoding encoding, string mediaType)
        {
            StringContent stringContent = new StringContent(content, encoding, mediaType);
            return stringContent;
        }
    }
}
