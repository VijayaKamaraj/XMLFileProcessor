using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace XMLWebApiCore.Models.DBClasses
{
    public class ProcessLine
    {
        [Key]
        public int Id { get; set; }
        public string? Source { get; set; }
        public string? SourceTagName { get; set; }
        public string? Target { get; set; }
        public string? TargetTagName { get; set; }

        public string? SourceEquipmentTagName { get; set; }
        public string? TargetEquipmentTagName { get; set; }

        [ForeignKey("DrawingDB")]

        [JsonIgnore]
        public int DrawingDBId { get; set; }

    }
}