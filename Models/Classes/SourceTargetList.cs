using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
    public class SourceTargetList
    {
        public string FromId { get; set; }

        public string ToId { get; set; }

        //public string Name { get; set; }

       // public bool IsEquipment { get; set; }

        //public bool IsConnector { get; set; }

        public bool IsSource { get; set; }

        public bool IsDestination { get; set; }
        public string Id { get; set; }
        //public Extent Extent { get; set; }
    }
}
