using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace XMLWebApiCore.Models.DBClasses
{
    public class SignalLineDB
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string? ComponentClass { get; set; }

        public string? ComponentName { get; set; }

        public string? PersistentId { get; set; }
        public double MinX { get; set; }

        public double MinY { get; set; }

        public double MaxX { get; set; }

        public double MaxY { get; set; }

        [ForeignKey("DrawingDB")]

        [JsonIgnore]
        public int DrawingDBId { get; set; }

        public string? FromID { get; set; }

        public string? ToID { get; set; }
    }
}