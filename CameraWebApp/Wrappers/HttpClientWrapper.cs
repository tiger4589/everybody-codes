using CameraWebApp.Wrappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CameraWebApp.Wrappers
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly IJsonSerializerWrapper _serializerWrapper;
        private readonly IStringContentPreparer _stringContentPreparer;
        private readonly IHttpClient _httpClient;
        private readonly IHttpResponseMessageReader _messageReader;

        public HttpClientWrapper(IJsonSerializerWrapper serializerWrapper, IStringContentPreparer stringContentPreparer, IHttpClient httpClient, IHttpResponseMessageReader messageReader)
        {
            _serializerWrapper = serializerWrapper;
            _stringContentPreparer = stringContentPreparer;
            _httpClient = httpClient;
            _messageReader = messageReader;
        }

        public async Task<string> CallGetApi(string url)
        {
            using (var response = await _httpClient.GetAsync(url).ConfigureAwait(true))
            {
                string apiResponse = await _messageReader.ReadMessage(response).ConfigureAwait(true);
                return apiResponse;
            }
        }

        public async Task<string> CallPostApi<T>(string url, T content)
        {
            string serlizedObject = _serializerWrapper.SerializeObject<T>(content);
            StringContent stringContent = _stringContentPreparer.PrepareStringContent(serlizedObject, Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync(url, stringContent).ConfigureAwait(true))
            {
                string apiResponse = await _messageReader.ReadMessage(response).ConfigureAwait(true);
                return apiResponse;
            }
        }
    }
}
