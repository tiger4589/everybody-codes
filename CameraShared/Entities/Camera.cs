using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShared.Entities
{
    public class Camera
    {
        [Index(0)]
        public string Name { get; set; }
        [Index(1)]
        public double Latitude { get; set; }
        [Index(2)]
        public double Longitude { get; set; }

        public int Number { get; set; }
    }
}
