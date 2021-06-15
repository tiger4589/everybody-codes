using CameraShared.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using DataPersistence.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Persistence.Services
{
    public class DataRepository : IDataRepository
    {
        private readonly INameParser _nameParser;
        private readonly CsvConfiguration _config;

        public DataRepository(INameParser nameParser)
        {
            _nameParser = nameParser;
           _config  = new CsvConfiguration(CultureInfo.InvariantCulture)
             {
                 HeaderValidated = null,
                 MissingFieldFound = null,
                 Delimiter = ";",
                 ReadingExceptionOccurred = MyReadingExceptionOccurred
             };
        }

        public List<Camera> GetCameraDevices()
        {
            List<Camera> result = new List<Camera>();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(path, "Data", "cameras-defb.csv");
            using (var reader = new StreamReader(fullPath))
            {
                using (var csv = new CsvReader(reader, _config))
                {
                    foreach (Camera camera in csv.GetRecords<Camera>())
                    {
                        camera.Number = _nameParser.ParseNumber(camera.Name);
                        if (camera.Number == -1)
                        {
                            continue;
                        }

                        result.Add(camera);
                    }

                    return result;
                }
            }
        }

        public List<Camera> SearchCameraDevicesByName(string cameraName)
        {

            List<Camera> result = new List<Camera>();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(path, "Data", "cameras-defb.csv");
            using (var reader = new StreamReader(fullPath))
            {
                using (var csv = new CsvReader(reader, _config))
                {
                    foreach (Camera camera in csv.GetRecords<Camera>())
                    {
                        if (!camera.Name.Contains(cameraName))
                        {
                            continue;
                        }

                        camera.Number = _nameParser.ParseNumber(camera.Name);
                        if (camera.Number == -1)
                        {
                            continue;
                        }

                        result.Add(camera);
                    }

                    return result;
                }
            }
        }

        private bool MyReadingExceptionOccurred(ReadingExceptionOccurredArgs args)
        {
            //In a more real scenario, probably just log the error here, with all the data.. and return true to re-throw the error to stop execution.
            //Or just log the error and continue with good data
            Debug.WriteLine("Ingored some data for being corrupted");
            return false;
        }
    }
}
