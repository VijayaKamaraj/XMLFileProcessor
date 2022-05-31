using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class Symbol
    {
        public string FromId { get; set; }

        public string ToId { get; set; }

        public string ComponentClass { get; set; }

        public string ID { get; set; }

        public string PersistentId { get; set; }

        public bool IsSource { get; set; }

        public bool IsDestination { get; set; }

        public Extent Extent { get; set; }
    }
}
