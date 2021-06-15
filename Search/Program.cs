using CommandLine;
using DataPersistence.Persistence.Interfaces;
using DataPersistence.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using Search.CommandParser.Commands;
using Search.CommandParser.Interfaces;
using System;

namespace Search
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        private static IServiceProvider BuildServiceProvider() => new ServiceCollection()
            .AddTransient<IDataRepository, DataRepository>()
            .AddTransient<INameParser, NameParser>()
            .BuildServiceProvider();

        static void Main(string[] args)
        {
            _serviceProvider = BuildServiceProvider();
            Parser.Default.ParseArguments<SearchCommand>(args).WithParsed<SearchCommand>(c => c.Execute(_serviceProvider));
        }
    }
}
