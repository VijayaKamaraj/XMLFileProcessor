using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMLWebApiCore.Models.DBClasses
{
    public class InstrumentComponent
    {
        [Key]
        public int Id { get; set; }

        public string TagName { get; set; }

        public string ComponentClass { get; set; }

        public string ComponentName { get; set; }

        public string StockNumber{get;set;}

        public double MinX { get; set; }

        public double MinY { get; set; }

        public double MaxX { get; set; }

        public double MaxY { get; set; }

        public double LocationX { get; set; }

        public double LocationY { get; set; }

        public string PersistentId {get;set;}

        
         [ForeignKey("Drawing")]

         [JsonIgnore]
         public int DrawingId {get;set;}


    }
}