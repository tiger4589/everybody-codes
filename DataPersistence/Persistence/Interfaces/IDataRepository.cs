using CameraShared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Persistence.Interfaces
{
    public interface IDataRepository
    {
        List<Camera> GetCameraDevices();
        List<Camera> SearchCameraDevicesByName(string cameraName);
    }
}
