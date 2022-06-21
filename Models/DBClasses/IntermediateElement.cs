using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace XMLWebApiCore.Models.DBClasses
{
    public class IntermediateElement
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string? intermediateElement { get; set; }
        public string? ComponentClass { get; set; }
        public string? ComponentName { get; set; }
        public string? TagName { get; set; }

        [ForeignKey("ProcessLine")]

        [JsonIgnore]
        public int ProcessLineId { get; set; }
    }
}