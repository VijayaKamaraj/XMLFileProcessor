using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace XMLWebApiCore.Models.DBClasses
{
    public class PipingNetworkSegmentDB
    {
        public int Id { get; set; }

        public string? TagName { get; set; }

        public string? ComponentClass { get; set; }

        public double MinX { get; set; }

        public double MinY { get; set; }

        public double MaxX { get; set; }

        public double MaxY { get; set; }

        public string? FromID { get; set; }

        public string? ToID { get; set; }

        [JsonIgnore]
        [ForeignKey("PipingNetworkSystemDB")]
        public int PipingNetworkSystemDBId { get; set; }

    }
}