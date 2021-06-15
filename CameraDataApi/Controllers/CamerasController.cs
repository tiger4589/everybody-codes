using CameraShared.Entities;
using CameraShared.Models;
using DataPersistence.Persistence.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamerasController : ControllerBase
    {
        private readonly IDataRepository _repository;

        public CamerasController(IDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetCameras()
        {
            try
            {
                List<Camera> cameras = _repository.GetCameraDevices();
                return Ok(new CameraListApiResponse
                {
                    Cameras = cameras
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
