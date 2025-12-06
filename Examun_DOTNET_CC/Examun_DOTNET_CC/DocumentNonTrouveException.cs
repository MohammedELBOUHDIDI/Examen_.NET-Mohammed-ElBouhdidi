using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examun_DOTNET_CC
{
    public class DocumentNonTrouveException : Exception
    {
        public DocumentNonTrouveException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
