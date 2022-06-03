using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace XMLWebApiCore.Models.DBClasses
{
    public class PipingNetworkSystemDB
    {
        public int Id { get; set; }

        public string? TagName { get; set; }

        public string? ComponentClass { get; set; }

        public double MinX { get; set; }

        public double MinY { get; set; }

        public double MaxX { get; set; }

        public double MaxY { get; set; }

        public string? PersistentId { get; set; }

        [ForeignKey("DrawingDB")]

        [JsonIgnore]
        public int DrawingDBId { get; set; }

        public List<PipingNetworkSegmentDB>? PipingNetworkSegments { get; set; }

    }
}