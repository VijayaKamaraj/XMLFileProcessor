using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class ProcessLine
    {
        public string Source { get; set; }

        public string Destination { get; set; }

        public string Name { get; set; }

        public string ToId { get; set; }

        public string FromId { get; set; }
    }
}
