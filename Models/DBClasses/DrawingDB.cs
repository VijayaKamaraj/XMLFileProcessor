using System.ComponentModel.DataAnnotations;

namespace XMLWebApiCore.Models.DBClasses
{
    public class DrawingDB
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Revision { get; set; }

        public double MinX { get; set; }

        public double MinY { get; set; }

        public double MaxX { get; set; }

        public double MaxY { get; set; }


        public List<EquipmentDB>? Equipments { get; set; }

        public List<InstrumentComponentDB>? InstrumentComponents { get; set; }

        public List<PipeConnectorSymbolDB>? PipeConnectorSymbols { get; set; }

        public List<ProcessInstrumentDB>? ProcessInstruments { get; set; }

        public List<SignalLineDB>? SignalLines { get; set; }

        public List<PipingNetworkSystemDB>? PipingNetworkSystems { get; set; }

        public List<ProcessLine>? ProcessLines { get; set; }
    }
}

