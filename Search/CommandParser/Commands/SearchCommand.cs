using CameraShared.Entities;
using CommandLine;
using DataPersistence.Persistence.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Search.CommandParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.CommandParser.Commands
{
    [Verb("", HelpText = "Search for a camera by name")]
    public class SearchCommand : ICommand
    {
        [Option('n',"name",HelpText = "Search for a camera containing this name")]
        public string Name { get; set; }
        public void Execute(IServiceProvider provider)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("No name has been specified");
                return;
            }

            IDataRepository repo =  provider.GetRequiredService<IDataRepository>();
            List<Camera> cameras = repo.SearchCameraDevicesByName(Name);

            if (cameras == null || cameras.Count == 0)
            {
                Console.WriteLine($"No cameras found containing {Name}");
                return;
            }

            foreach (Camera camera in cameras)
            {
                Console.WriteLine($"{camera.Number} | {camera.Name} | {camera.Latitude} | {camera.Longitude}");
            }
        }
    }
}
