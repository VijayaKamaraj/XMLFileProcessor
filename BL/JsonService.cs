using XMLWebApiCore.Models.DBClasses;
using Newtonsoft.Json;

namespace XMLWebApiCore.BL
{
    public class JsonService : IJsonService
    {
        FileServiceContext _context;
        public JsonService(FileServiceContext context) => _context = context;

        /// <summary>
        /// CreateJson
        /// </summary>
        /// <param name="name"></param>
        public string CreateJson(string name)
        {
            string json;
            var drawing = _context.Drawings.Where(x => x.Name == name).FirstOrDefault();
            if (drawing != null)
            {
                DrawingDB drawingList = new DrawingDB();
                drawingList.Id = drawing.Id;
                drawingList.Name = drawing.Name;
                drawingList.Revision = drawing.Revision;
                drawingList.MaxX = drawing.MaxX;
                drawingList.MaxY = drawing.MaxY;
                drawingList.MinX = drawing.MinX;
                drawingList.MinY = drawing.MinY;

                List<EquipmentDB> equipments = new List<EquipmentDB>();
                equipments = _context.Equipments.Where(x => x.DrawingDBId == drawing.Id).ToList();
                foreach (var equipment in equipments)
                {
                    List<NozzleDB> nozzles = _context.Nozzles.Where(x => x.EquipmentDBId == equipment.Id).ToList();
                    equipment.Nozzles = nozzles;
                }
                drawingList.Equipments = equipments;

                var instrumentComponents = _context.InstrumentComponents.Where(x => x.DrawingDBId == drawing.Id).ToList();
                drawingList.InstrumentComponents = instrumentComponents;

                var pipeConnectorSymbol = _context.PipeConnectorSymbols.Where(x => x.DrawingDBId == drawing.Id).ToList();
                drawingList.PipeConnectorSymbols = pipeConnectorSymbol;

                var processInstrument = _context.ProcessInstruments.Where(x => x.DrawingDBId == drawing.Id).ToList();
                drawingList.ProcessInstruments = processInstrument;

                var signalLines = _context.SignalLines.Where(x => x.DrawingDBId == drawing.Id).ToList();
                drawingList.SignalLines = signalLines;

                var pipingSystems = _context.PipingNetworkSystems.Where(x => x.DrawingDBId == drawing.Id).ToList();
                foreach (var pipingSystem in pipingSystems)
                {
                    var pipingNetworkSegments = _context.PipingNetworkSegments.Where(x => x.PipingNetworkSystemDBId == pipingSystem.Id).ToList();
                    pipingSystem.PipingNetworkSegments = pipingNetworkSegments;
                }
                drawingList.PipingNetworkSystems = pipingSystems;

                var processLines = _context.ProcessLines.Where(x => x.DrawingDBId == drawing.Id).ToList();
                foreach (var processLine in processLines)
                {
                    var intermediateElements = _context.IntermediateElements.Where(x => x.ProcessLineId == processLine.Id).ToList();
                    processLine.IntermediateElements = intermediateElements;

                }
                drawingList.ProcessLines = processLines;

                json = JsonConvert.SerializeObject(drawingList, Formatting.Indented);
                return json;
            }
            return string.Empty;
        }
    }
}