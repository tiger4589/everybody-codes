using CameraShared.Entities;
using CameraShared.Models;
using CameraWebApp.Wrappers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraWebApp.Pages
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly IJsonDeserializerWrapper _jsonDeserializerWrapper;
        private readonly IConfiguration _configuration;

        public string MapBoxApiToken = string.Empty;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientWrapper httpClientWrapper, IJsonDeserializerWrapper jsonDeserializerWrapper, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientWrapper = httpClientWrapper;
            _jsonDeserializerWrapper = jsonDeserializerWrapper;
            _configuration = configuration;
            MapBoxApiToken = configuration["Secret:ApiKey"];
        }

        public async Task<IActionResult> OnGet()
        {
            
            string apiUrl = _configuration["Api_Url"]; 
            string apiResponse = await _httpClientWrapper.CallGetApi(apiUrl).ConfigureAwait(true);
            CameraListApiResponse result = _jsonDeserializerWrapper.DeserializeApiCallResult(apiResponse);
            AllCameras = result.Cameras;
            PopulateListsAccordingToResult();
            return Page();
        }

        private void PopulateListsAccordingToResult()
        {
            foreach (Camera camera in AllCameras)
            {
                if (camera.Number%5 == 0 && camera.Number%3==0)
                {
                    Cameras3And5.Add(camera);
                    continue;
                }

                if (camera.Number % 5 == 0)
                {
                    Cameras5.Add(camera);
                    continue;
                }

                if (camera.Number % 3 == 0)
                {
                    Cameras3.Add(camera);
                    continue;
                }

                CamerasNone.Add(camera);
            }
        }

        public List<Camera> Cameras3And5 { get; set; } = new List<Camera>();
        public List<Camera> Cameras5 { get; set; } = new List<Camera>();
        public List<Camera> Cameras3 { get; set; } = new List<Camera>();
        public List<Camera> CamerasNone { get; set; } = new List<Camera>();

        public List<Camera> AllCameras { get; set; } = new List<Camera>();
    }
}
