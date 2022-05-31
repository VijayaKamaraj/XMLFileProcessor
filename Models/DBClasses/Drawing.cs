using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace XMLWebApiCore.Models.DBClasses
{
    public class Drawing
    {
        [Key]
        public int Id { get; set; }
    
        public string Name {get;set; }

        public string Revision { get; set; }

        public double MinX { get; set; }

        public double MinY { get; set; }

        public double MaxX { get; set; }

        public double MaxY { get; set; }

    
         public List<Equipment> Equipments { get; set; }

         public List<InstrumentComponent> InstrumentComponents {get;set;}

        public List<PipeConnectorSymbol> PipeConnectorSymbols {get;set;}
    }
}

