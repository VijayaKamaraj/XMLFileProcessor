using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class FinalOutput
    {

        public string Source { get; set; }

        public string Destination { get; set; }

        public List<Symbol> IntermediateSymbols { get; set; }
    }
}
