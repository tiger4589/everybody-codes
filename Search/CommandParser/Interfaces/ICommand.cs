using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.CommandParser.Interfaces
{
    public interface ICommand
    {
        void Execute(IServiceProvider provider);
    }
}
