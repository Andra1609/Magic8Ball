using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Interfaces
{
    [ExcludeFromCodeCoverage]
    public class IOutcome
    {
        public int ID { get; set; }
        public string Response { get; set; }
        public DateTime TimeAsked { get; set; }
    }
}
