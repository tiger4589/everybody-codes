using DataPersistence.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Persistence.Services
{
    public class NameParser : INameParser
    {
        public int ParseNumber(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return -1;
            }

            string[] allLine = name.Split(' ');
            string partContainingNumber = allLine[0];
            string[] numberParts = partContainingNumber.Split('-');

            if (numberParts.Length < 3)
            {
                return -1;
            }

            int result;
            bool isOk = int.TryParse(numberParts[2], out result);

            if (!isOk)
            {
                return -1;
            }

            return result;
        }
    }
}
