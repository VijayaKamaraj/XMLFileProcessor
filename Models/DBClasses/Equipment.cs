using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XMLWebApiCore.Models.DBClasses
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        public string TagName { get; set; }

        public string ComponentClass { get; set; }

        public string ComponentName { get; set; }

        public double MinX { get; set; }

        public double MinY { get; set; }

        public double MaxX { get; set; }

        public double MaxY { get; set; }

        public double LocationX { get; set; }

        public double LocationY { get; set; }

        
         [ForeignKey("Drawing")]
         public int DrawingId {get;set;}

      public  List<Nozzle> Nozzles {get;set;}

    }
        
}