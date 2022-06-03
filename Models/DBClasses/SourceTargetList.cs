using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XMLWebApiCore.Models.DBClasses
{
    public class SourceTargetList
    {
        public string? FromId { get; set; }

        public string? ToId { get; set; }

        public bool IsSource { get; set; }

        public bool IsDestination { get; set; }
    }
}