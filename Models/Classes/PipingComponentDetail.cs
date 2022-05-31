using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.Classes
{
   public class PipingComponentDetail
    {
        public string ID { get; set; }
        public string PersistentId { get; set; }
        public Extent Extent { get; set; }

        public string ComponentClass { get; set; }
    }
}
