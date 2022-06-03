using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.DBClasses
{
    public class NozzleSymbol
    {
        public string? ID { get; set; }
        public string? TagName { get; set; }
        public string? PersistentId { get; set; }

        public string? EquipmentTagName { get; set; }
    }
}