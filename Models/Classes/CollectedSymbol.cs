using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class CollectedSymbol
    {
        public List<PipingComponentDetail> pipingComponentDetails { get; set; }
        public List<ProcessInstrumentDetail> processInstrumentDetails { get; set; }
        public List<PropertyBreakDetail> propertyBreakDetails { get; set; }

    }
}