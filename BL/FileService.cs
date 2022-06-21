using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using XMLWebApiCore.Models.Classes;
using XMLWebApiCore.Models.DBClasses;

namespace XMLWebApiCore.BL
{
    public class FileService : IFileService
    {
        string folderPath = Path.Combine(Environment.CurrentDirectory, "Files");
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        PlantModel plantModel = new PlantModel();
        FileServiceContext _context;
        public FileService(FileServiceContext context) => _context = context;

        /// <summary>
        /// ProcessXMLFile
        /// </summary>
        /// <param name="path"></param>
        public PlantModel ProcessXMLFile(string path)
        {
            using (XmlTextReader reader = new XmlTextReader(path))
            {
                if (reader.Read())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(PlantModel));
                    plantModel = (PlantModel)serializer.Deserialize(reader);
                }
            }
            return plantModel;
        }

        /// <summary>
        /// Validate_XML
        /// </summary>
        /// <param name="path"></param>
        public bool Validate_XML(string path)
        {
            bool validationErrors = false;
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", folderPath + "\\ProteusSchema_3.3.3.xsd");
            XDocument document = XDocument.Load(path);
            document.Validate(schema, (o, validate) =>
            {
                validationErrors = true;
            });
            return validationErrors;
        }


        /// <summary>
        /// CheckFileType
        /// </summary>
        /// <param name="path"></param>
        public bool CheckFileType(string path)
        {
            bool result = path.EndsWith(".xml") ? (File.Exists(path) ? true : false) : false;
            return result;
        }


        /// <summary>
        /// AddXmlFileDetails
        /// </summary>
        /// <param name="plantModel"></param>
        public bool AddXmlFileDetails(PlantModel plantModel)
        {
            if (plantModel.Drawing != null)
            {
                DrawingDB drawing = AddDrawingDetail(plantModel);
                if (plantModel.InstrumentComponent != null)
                {
                    foreach (var instrumentComponent in plantModel.InstrumentComponent)
                    {
                        AddInstrumentComponent(drawing, instrumentComponent);
                    }
                }

                if (plantModel.Equipment != null)
                {
                    foreach (var equipment in plantModel.Equipment)
                    {
                        EquipmentDB equipments = AddEquipment(drawing, equipment);

                        foreach (var nozzle in equipment.Nozzle)
                        {
                            AddNozzles(equipments, nozzle);

                        }
                    }
                }

                var pipeConnectorDetails = (plantModel.PipingNetworkSystem).Where(x => x.PipingNetworkSegment != null).SelectMany(x => x.PipingNetworkSegment).Where(y => y.PipeConnectorSymbol != null).Select(x => x.PipeConnectorSymbol).ToList();
                if (pipeConnectorDetails != null)
                {
                    int inCount = 0;
                    int outCount = 0;
                    foreach (var pipeConnector in pipeConnectorDetails)
                    {
                        string componentclass = pipeConnector.ComponentClass;
                        string[] componentClassArr = componentclass.Split("-");

                        string connectorTagName;
                        if (componentClassArr[1] == "Out")
                        {
                            outCount = outCount + 1;
                            connectorTagName = componentclass + outCount;
                            AddPipeConnector(drawing, pipeConnector, connectorTagName);
                        }
                        if (componentClassArr[1] == "In")
                        {
                            inCount = inCount + 1;
                            connectorTagName = componentclass + inCount;
                            AddPipeConnector(drawing, pipeConnector, connectorTagName);
                        }


                    }
                }

                var processInstrumentDetails = (plantModel.PipingNetworkSystem).Where(x => x.PipingNetworkSegment != null)
                .SelectMany(x => x.PipingNetworkSegment).Where(y => y.ProcessInstrument != null)
                .Select(x => x.ProcessInstrument).ToList();

                if (processInstrumentDetails != null)
                {
                    foreach (var processInstrument in processInstrumentDetails)
                    {
                        AddProcessInstrument(drawing, processInstrument);
                    }
                }

                var pipingComponentDetails = (plantModel.PipingNetworkSystem).Where(x => x.PipingNetworkSegment != null)
                 .SelectMany(x => x.PipingNetworkSegment).Where(y => y.PipingComponent != null)
                 .SelectMany(x => x.PipingComponent).ToList();

                if (pipingComponentDetails != null)
                {
                    foreach (var pipingComponent in pipingComponentDetails)
                    {
                        AddPipingComponent(drawing, pipingComponent);
                    }
                }

                var propertyBreakDetails = (plantModel.PipingNetworkSystem).Where(x => x.PropertyBreak != null)
               .SelectMany(x => x.PropertyBreak).ToList();
                if (propertyBreakDetails != null)
                {
                    foreach (var PropertyBreak in propertyBreakDetails)
                    {
                        AddPropertyBreak(drawing, PropertyBreak);
                    }
                }

                if (plantModel.SignalLine != null)
                {
                    foreach (var signalLine in plantModel.SignalLine)
                    {
                        AddSignalLine(drawing, signalLine);

                    }
                }
                if (plantModel.PipingNetworkSystem != null)
                {
                    foreach (var pipingSystem in plantModel.PipingNetworkSystem)
                    {
                        PipingNetworkSystemDB pipingNetworkSystem = AddPipingNetworkSystem(drawing, pipingSystem);

                        foreach (var pipingSegment in pipingSystem.PipingNetworkSegment)
                        {
                            AddPipingNetworkSegment(pipingNetworkSystem, pipingSegment);
                        }
                    }
                }

                var sourceTargetList = CollectSourceTargetLists(plantModel);
                FindProcessLines(sourceTargetList, drawing);

            }

            return true;
        }


        /// <summary>
        /// AddPipingNetworkSegment
        /// </summary>
        /// <param name="pipingNetworkSystem"></param>
        /// <param name="pipingSegment"></param>
        private void AddPipingNetworkSegment(PipingNetworkSystemDB pipingNetworkSystem, PipingNetworkSegment pipingSegment)
        {
            PipingNetworkSegmentDB pipingNetworkSegment = new PipingNetworkSegmentDB();
            pipingNetworkSegment.PipingNetworkSystemDBId = pipingNetworkSystem.Id;
            pipingNetworkSegment.TagName = pipingSegment.TagName;
            pipingNetworkSegment.ComponentClass = pipingSegment.ComponentClass;
            pipingNetworkSegment.MaxX = pipingSegment.Extent.Max.X;
            pipingNetworkSegment.MaxY = pipingSegment.Extent.Max.Y;
            pipingNetworkSegment.MinX = pipingSegment.Extent.Min.X;
            pipingNetworkSegment.MinY = pipingSegment.Extent.Min.Y;
            pipingNetworkSegment.FromID = pipingSegment.Connection.FromID;
            pipingNetworkSegment.ToID = pipingSegment.Connection.ToID;
            _context.PipingNetworkSegments.Add(pipingNetworkSegment);
            _context.SaveChanges();
        }

        /// <summary>
        /// AddPipingNetworkSystem
        /// </summary>
        /// <param name="drawing"></param>
        /// <param name="pipingSystem"></param>
        private PipingNetworkSystemDB AddPipingNetworkSystem(DrawingDB drawing, PipingNetworkSystem pipingSystem)
        {
            PipingNetworkSystemDB pipingNetworkSystem = new PipingNetworkSystemDB();
            pipingNetworkSystem.DrawingDBId = drawing.Id;
            pipingNetworkSystem.TagName = pipingSystem.TagName;
            pipingNetworkSystem.ComponentClass = pipingSystem.ComponentClass;
            pipingNetworkSystem.MaxX = pipingSystem.Extent.Max.X;
            pipingNetworkSystem.MaxY = pipingSystem.Extent.Max.Y;
            pipingNetworkSystem.MinX = pipingSystem.Extent.Min.X;
            pipingNetworkSystem.MinY = pipingSystem.Extent.Min.Y;
            pipingNetworkSystem.PersistentId = pipingSystem.PersistentID.Identifier;
            _context.PipingNetworkSystems.Add(pipingNetworkSystem);
            _context.SaveChanges();
            return pipingNetworkSystem;
        }

        /// <summary>
        /// AddSignalLine
        /// </summary>
        /// <param name="drawing"></param>
        /// <param name="signalLine"></param>
        private void AddSignalLine(DrawingDB drawing, SignalLine signalLine)
        {
            SignalLineDB signalLines = new SignalLineDB();
            signalLines.DrawingDBId = drawing.Id;
            signalLines.ComponentClass = signalLine.ComponentClass;
            signalLines.ComponentName = signalLine.ComponentName;
            signalLines.PersistentId = signalLine.PersistentID.Identifier;
            signalLines.MaxX = signalLine.Extent.Max.X;
            signalLines.MaxY = signalLine.Extent.Max.Y;
            signalLines.MinX = signalLine.Extent.Min.X;
            signalLines.MinY = signalLine.Extent.Min.Y;
            signalLines.FromID = signalLine.Connection.FromID;
            signalLines.ToID = signalLine.Connection.ToID;
            _context.SignalLines.Add(signalLines);
            _context.SaveChanges();
        }

        /// <summary>
        /// AddProcessInstrument
        /// </summary>
        /// <param name="drawing"></param>
        /// <param name="processInstrument"></param>
        private void AddProcessInstrument(DrawingDB drawing, ProcessInstrument? processInstrument)
        {
            ProcessInstrumentDB instrumentProcess = new ProcessInstrumentDB();
            instrumentProcess.DrawingDBId = drawing.Id;
            instrumentProcess.TagName = processInstrument.TagName;
            instrumentProcess.ComponentClass = processInstrument.ComponentClass;
            instrumentProcess.ComponentName = processInstrument.ComponentName;
            instrumentProcess.StockNumber = processInstrument.StockNumber == null ? "NA" : processInstrument.StockNumber;
            instrumentProcess.PersistentId = processInstrument.PersistentID.Identifier;
            instrumentProcess.MaxX = processInstrument.Extent.Max.X;
            instrumentProcess.MaxY = processInstrument.Extent.Max.Y;
            instrumentProcess.MinX = processInstrument.Extent.Min.X;
            instrumentProcess.MinY = processInstrument.Extent.Min.Y;
            instrumentProcess.LocationX = processInstrument.Position.Location.X;
            instrumentProcess.LocationY = processInstrument.Position.Location.Y;
            _context.ProcessInstruments.Add(instrumentProcess);
            _context.SaveChanges();
        }

        /// <summary>
        /// AddProcessInstrument
        /// </summary>
        /// <param name="drawing"></param>
        /// <param name="pipingComponent"></param>
        private void AddPipingComponent(DrawingDB drawing, PipingComponent? pipingComponent)
        {
            PipingComponentDB pipingComponentDB = new PipingComponentDB();
            pipingComponentDB.DrawingDBId = drawing.Id;
            pipingComponentDB.ComponentClass = pipingComponent.ComponentClass;
            pipingComponentDB.ComponentName = pipingComponent.ComponentName;
            //pipingComponentDB.TagName = pipingComponent.TagName == null ? pipingComponent.ComponentClass + "_" + pipingComponent.ComponentName : pipingComponent.TagName;
            if (pipingComponent.TagName == null)
            {
                int count = 0;
                if (_context.PipingComponents.Any(x => x.ComponentClass == pipingComponent.ComponentClass && x.ComponentName == pipingComponent.ComponentName))
                {
                    var pipingList = _context.PipingComponents.Where(x => x.ComponentClass == pipingComponent.ComponentClass && x.ComponentName == pipingComponent.ComponentName).ToList();
                    int pipingId = pipingList.Max(x => x.Id);
                    var tagName = pipingList.First(x => x.Id == pipingId).TagName;
                    string tagNameCount = tagName.Substring(tagName.LastIndexOf("_") + 1);
                    int tagCount = int.Parse(tagNameCount) + 1;
                    pipingComponentDB.TagName = pipingComponent.ComponentClass + "_" + pipingComponent.ComponentName + "_" + tagCount;
                }
                else
                {
                    count += 1;
                    pipingComponentDB.TagName = pipingComponent.ComponentClass + "_" + pipingComponent.ComponentName + "_" + count;
                }
            }
            else
            {
                pipingComponentDB.TagName = pipingComponent.TagName;
            }
            pipingComponentDB.PersistentId = pipingComponent.PersistentID.Identifier;
            pipingComponentDB.MaxX = pipingComponent.Extent.Max.X;
            pipingComponentDB.MaxY = pipingComponent.Extent.Max.Y;
            pipingComponentDB.MinX = pipingComponent.Extent.Min.X;
            pipingComponentDB.MinY = pipingComponent.Extent.Min.Y;
            pipingComponentDB.LocationX = pipingComponent.Position.Location.X;
            pipingComponentDB.LocationY = pipingComponent.Position.Location.Y;
            _context.PipingComponents.Add(pipingComponentDB);
            _context.SaveChanges();

        }

        /// <summary>
        /// AddProcessInstrument
        /// </summary>
        /// <param name="drawing"></param>
        /// <param name="propertyBreak"></param>
        private void AddPropertyBreak(DrawingDB drawing, PropertyBreak? propertyBreak)
        {
            PropertyBreakDB propertyBreakDB = new PropertyBreakDB();
            propertyBreakDB.DrawingDBId = drawing.Id;
            propertyBreakDB.ComponentClass = propertyBreak.ComponentClass;
            propertyBreakDB.ComponentName = propertyBreak.ComponentName;
            //propertyBreakDB.TagName = propertyBreak.ComponentClass + "_" + propertyBreak.ComponentName;
            int count = 0;
            if (_context.PropertyBreaks.Any(x => x.ComponentClass == propertyBreak.ComponentClass && x.ComponentName == propertyBreak.ComponentName))
            {
                var propertyBreakList = _context.PropertyBreaks.Where(x => x.ComponentClass == propertyBreak.ComponentClass && x.ComponentName == propertyBreak.ComponentName).ToList();
                int propertyBreakId = propertyBreakList.Max(x => x.Id);
                var tagName = propertyBreakList.First(x => x.Id == propertyBreakId).TagName;
                string tagNameCount = tagName.Substring(tagName.LastIndexOf("_") + 1);
                int tagCount = int.Parse(tagNameCount) + 1;
                propertyBreakDB.TagName = propertyBreak.ComponentClass + "_" + propertyBreak.ComponentName + "_" + tagCount;
            }
            else
            {
                count += 1;
                propertyBreakDB.TagName = propertyBreak.ComponentClass + "_" + propertyBreak.ComponentName + "_" + count;
            }
            propertyBreakDB.PersistentId = propertyBreak.PersistentID.Identifier;
            propertyBreakDB.MaxX = propertyBreak.Extent.Max.X;
            propertyBreakDB.MaxY = propertyBreak.Extent.Max.Y;
            propertyBreakDB.MinX = propertyBreak.Extent.Min.X;
            propertyBreakDB.MinY = propertyBreak.Extent.Min.Y;
            propertyBreakDB.LocationX = propertyBreak.Position.Location.X;
            propertyBreakDB.LocationY = propertyBreak.Position.Location.Y;
            _context.PropertyBreaks.Add(propertyBreakDB);
            _context.SaveChanges();
        }

        /// <summary>
        /// AddPipeConnector
        /// </summary>
        /// <param name="drawing"></param>
        /// <param name="pipeConnector"></param>
        /// <param name="tagName"></param>
        private void AddPipeConnector(DrawingDB drawing, PipeConnectorSymbol? pipeConnector, string? tagName)
        {
            PipeConnectorSymbolDB pipeConnectorSymbol = new PipeConnectorSymbolDB();
            pipeConnectorSymbol.DrawingDBId = drawing.Id;
            pipeConnectorSymbol.ComponentClass = pipeConnector.ComponentClass;
            pipeConnectorSymbol.ComponentName = pipeConnector.ComponentName;
            pipeConnectorSymbol.PersistentId = pipeConnector.PersistentID.Identifier;
            pipeConnectorSymbol.MaxX = pipeConnector.Extent.Max.X;
            pipeConnectorSymbol.MaxY = pipeConnector.Extent.Max.Y;
            pipeConnectorSymbol.MinX = pipeConnector.Extent.Min.X;
            pipeConnectorSymbol.MinY = pipeConnector.Extent.Min.Y;
            pipeConnectorSymbol.LocationX = pipeConnector.Position.Location.X;
            pipeConnectorSymbol.LocationY = pipeConnector.Position.Location.Y;
            pipeConnectorSymbol.TagName = tagName;
            pipeConnectorSymbol.CrossPageDrawingName = pipeConnector.CrossPageConnection.DrawingName == null ? "NA" : pipeConnector.CrossPageConnection.DrawingName;
            pipeConnectorSymbol.CrossPageLinkLabel = pipeConnector.CrossPageConnection.LinkLabel == null ? "NA" : pipeConnector.CrossPageConnection.LinkLabel;
            _context.PipeConnectorSymbols.Add(pipeConnectorSymbol);
            _context.SaveChanges();
        }

        /// <summary>
        /// AddDrawingDetail
        /// </summary>
        /// <param name="plantModel"></param>
        private DrawingDB AddDrawingDetail(PlantModel plantModel)
        {
            DrawingDB drawing = new DrawingDB();
            drawing.Name = plantModel.Drawing.Name;
            drawing.Revision = plantModel.Drawing.Revision;
            drawing.MaxX = plantModel.Drawing.Extent.Max.X;
            drawing.MaxY = plantModel.Drawing.Extent.Max.Y;
            drawing.MinX = plantModel.Drawing.Extent.Min.X;
            drawing.MinY = plantModel.Drawing.Extent.Min.Y;
            _context.Drawings.Add(drawing);
            _context.SaveChanges();
            return drawing;
        }

        /// <summary>
        /// AddNozzles
        /// </summary>
        /// <param name="equipments"></param>
        /// <param name="nozzle"></param>
        private void AddNozzles(EquipmentDB equipments, Nozzle nozzle)
        {
            NozzleDB nozzles = new NozzleDB();
            nozzles.EquipmentDBId = equipments.Id;
            nozzles.TagName = nozzle.TagName;
            nozzles.ComponentClass = nozzle.ComponentClass;
            nozzles.ComponentName = nozzle.ComponentName;
            nozzles.LocationX = nozzle.Position.Location.X;
            nozzles.LocationY = nozzle.Position.Location.Y;
            nozzles.MaxX = nozzle.Extent.Max.X;
            nozzles.MaxY = nozzle.Extent.Max.Y;
            nozzles.MinX = nozzle.Extent.Min.X;
            nozzles.MinY = nozzle.Extent.Min.Y;
            nozzles.PersistentId = nozzle.PersistentID.Identifier;
            _context.Nozzles.Add(nozzles);
            _context.SaveChanges();
        }

        /// <summary>
        /// AddEquipment
        /// </summary>
        /// <param name="drawing"></param>
        /// <param name="equipment"></param>
        private EquipmentDB AddEquipment(DrawingDB drawing, Equipment equipment)
        {
            EquipmentDB equipments = new EquipmentDB();
            equipments.DrawingDBId = drawing.Id;
            equipments.ComponentClass = equipment.ComponentClass;
            equipments.TagName = equipment.TagName;
            equipments.ComponentName = equipment.ComponentName;
            equipments.LocationX = equipment.Position.Location.X;
            equipments.LocationY = equipment.Position.Location.Y;
            equipments.MaxX = equipment.Extent.Max.X;
            equipments.MaxY = equipment.Extent.Max.Y;
            equipments.MinX = equipment.Extent.Min.X;
            equipments.MinY = equipment.Extent.Min.Y;
            _context.Equipments.Add(equipments);
            _context.SaveChanges();
            return equipments;
        }

        /// <summary>
        /// AddInstrumentComponent
        /// </summary>
        /// <param name="drawing"></param>
        /// <param name="instrumentComponent"></param>
        private void AddInstrumentComponent(DrawingDB drawing, InstrumentComponent instrumentComponent)
        {
            InstrumentComponentDB instrumentComponents = new InstrumentComponentDB();
            instrumentComponents.DrawingDBId = drawing.Id;
            instrumentComponents.TagName = instrumentComponent.TagName;
            instrumentComponents.ComponentClass = instrumentComponent.ComponentClass;
            instrumentComponents.ComponentName = instrumentComponent.ComponentName;
            instrumentComponents.StockNumber = instrumentComponent.StockNumber == null ? "NA" : instrumentComponent.StockNumber;
            instrumentComponents.PersistentId = instrumentComponent.PersistentID.Identifier;
            instrumentComponents.MaxX = instrumentComponent.Extent.Max.X;
            instrumentComponents.MaxY = instrumentComponent.Extent.Max.Y;
            instrumentComponents.MinX = instrumentComponent.Extent.Min.X;
            instrumentComponents.MinY = instrumentComponent.Extent.Min.Y;
            instrumentComponents.LocationX = instrumentComponent.Position.Location.X;
            instrumentComponents.LocationY = instrumentComponent.Position.Location.Y;
            _context.InstrumentComponents.Add(instrumentComponents);
            _context.SaveChanges();
        }

        /// <summary>
        /// CheckRevisionNumber
        /// </summary>
        /// <param name="revision"></param>
        /// <param name="name"></param>
        public bool CheckRevisionNumber(string revision, string name)
        {
            bool result = false;
            var drawing = _context.Drawings.FirstOrDefault(x => x.Revision == revision || x.Name == name);
            if (drawing != null)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// CollectSourceTargetLists
        /// </summary>
        /// <param name="plantModel"></param>
        public List<SourceTargetList> CollectSourceTargetLists(PlantModel plantModel)
        {
            List<SourceTargetList> sourceTargetLists = new List<SourceTargetList>();
            for (int i = 0; i < plantModel.PipingNetworkSystem.Count(); i++)
            {
                PipingNetworkSystem pipingNetworkSystem = plantModel.PipingNetworkSystem[i];

                for (int j = 0; j < pipingNetworkSystem.PipingNetworkSegment.Count(); j++)
                {
                    var isSource = false;
                    var isDestination = false;
                    var name = string.Empty;
                    Extent extent = new Extent();

                    PipingNetworkSegment pipingNetworkSegment = pipingNetworkSystem.PipingNetworkSegment[j];
                    SourceTargetList processLine = new SourceTargetList();
                    string fromId = pipingNetworkSegment.Connection.FromID;
                    string toId = pipingNetworkSegment.Connection.ToID;
                    if (fromId != null)
                    {
                        if (toId == null)
                        {
                            graph[fromId] = new List<string> { };
                        }
                        else
                        {
                            if (!graph.ContainsKey(fromId))
                            {
                                graph[fromId] = new List<string> { toId };
                            }
                            else
                            {
                                graph[fromId].Add(toId);

                            }
                        }
                        var nozzleLists = CollectNozzleDetails();
                        var pipeConnectorDetails = CollectPipeConnectorDetails();

                        if ((nozzleLists != null || pipeConnectorDetails != null))
                        {
                            if (nozzleLists.Any(x => x.PersistentId == fromId) || pipeConnectorDetails.Any(x => x.PersistentId == fromId))
                            {
                                isSource = true;
                            }
                            if (nozzleLists.Any(x => x.PersistentId == toId) || pipeConnectorDetails.Any(x => x.PersistentId == toId))
                            {

                                isDestination = true;

                            }
                        }
                    }
                    var sourceTargetList = new SourceTargetList()
                    {
                        FromId = fromId,
                        ToId = toId,
                        IsSource = isSource,
                        IsDestination = isDestination,

                    };
                    sourceTargetLists.Add(sourceTargetList);

                }


            }
            return sourceTargetLists;
        }

        /// <summary>
        /// CollectNozzleDetails
        /// </summary>
        private List<NozzleSymbol> CollectNozzleDetails()
        {

            //var nozzleLists = (plantModel.Equipment).SelectMany(x => x.Nozzle)
            //.Select(y => new NozzleSymbol { ID = y.ID, TagName = y.TagName, PersistentId = y.PersistentID.Identifier }).ToList();
            //return nozzleLists;
            var nozzleList = new List<NozzleSymbol>();
            foreach (var equipment in plantModel.Equipment)


            {
                foreach (var nozzle in equipment.Nozzle)
                {
                    NozzleSymbol nozzleSymbol = new NozzleSymbol();
                    nozzleSymbol.ID = nozzle.ID;
                    nozzleSymbol.PersistentId = nozzle.PersistentID.Identifier;
                    nozzleSymbol.EquipmentTagName = equipment.TagName;
                    nozzleSymbol.TagName = nozzle.TagName;
                    nozzleList.Add(nozzleSymbol);

                }

            }
            return nozzleList;
        }

        /// <summary>
        /// CollectPipeConnectorDetails
        /// </summary>
        private List<PipeConnectorDetail> CollectPipeConnectorDetails()
        {
            var pipeConnectorDetails = plantModel.PipingNetworkSystem.Where(x => x.PipingNetworkSegment != null)
                 .SelectMany(x => x.PipingNetworkSegment)
                 .Where(y => y.PipeConnectorSymbol != null)
                 .Select(x => x.PipeConnectorSymbol)
                 .Select(x => new PipeConnectorDetail { ID = x.ID, ComponentClass = x.ComponentClass, PersistentId = x.PersistentID.Identifier })
                 .ToList();
            return pipeConnectorDetails;
        }

        /// <summary>
        /// FindProcessLines
        /// </summary>
        /// <param name="sourceTargetLists"></param>
        /// <param name="drawing"></param>
        public void FindProcessLines(List<SourceTargetList> sourceTargetLists, DrawingDB drawing)
        {
            var sourceList = sourceTargetLists.Where(x => x.IsSource == true).ToList();
            var targetList = sourceTargetLists.Where(x => x.IsDestination == true).ToList();
            using (StreamWriter sw = new StreamWriter("C:\\ProcessLine\\processLineOutput.txt"))
            {
                foreach (var source in sourceList)
                {
                    foreach (var destination in targetList)
                    {
                        Findpaths(graph, source.FromId, destination.ToId, drawing);
                    }
                }
            }

        }

        /// <summary>
        /// Findpaths
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="drawing"></param>
        private void Findpaths(Dictionary<string, List<string>> graph, string source, string destination, DrawingDB drawing)
        {
            Queue<List<string>> queue = new Queue<List<string>>();
            List<string> path = new List<string>();
            path.Add(source);
            queue.Enqueue(path);
            while (queue.Count != 0)
            {
                path = queue.Dequeue();
                string last = path[path.Count - 1];


                if (last == destination)
                {
                    PrintPath(path, drawing);
                }


                List<string> lastNode = new List<string>();
                if (graph.ContainsKey(last))
                {
                    lastNode = graph[last];
                }

                for (int i = 0; i < lastNode.Count; i++)
                {
                    if (IsNotVisited(lastNode[i], path))
                    {
                        List<string> newpath = new List<string>(path);
                        newpath.Add(lastNode[i]);
                        queue.Enqueue(newpath);
                    }
                }
            }
        }

        /// <summary>
        /// IsNotVisited
        /// </summary>
        /// <param name="element"></param>
        /// <param name="path"></param>
        private bool IsNotVisited(string element, List<string> path)
        {
            var result = false;
            int size = path.Count;
            for (int i = 0; i < size; i++)
                if (path[i] != element)
                    result = true;
            return result;
        }

        /// <summary>
        /// PrintPath
        /// </summary>
        /// <param name="path"></param>
        /// <param name="drawing"></param>
        private void PrintPath(List<string> path, DrawingDB drawing)
        {
            string first = path.First();
            string last = path.Last();
            ProcessLine processLine = new ProcessLine();

            IntermediateSymbol sourceSymbol = GetIntermediateDetails(first, out IntermediateSymbol source);
            processLine.Source = sourceSymbol.PersistentId;
            processLine.SourceTagName = sourceSymbol.ComponentClass;
            bool isSourceTagAvailable = _context.PipeConnectorSymbols.Any(x => x.PersistentId == sourceSymbol.PersistentId);
            if (isSourceTagAvailable == true)
            {
                sourceSymbol.TagName = _context.PipeConnectorSymbols.First(x => x.PersistentId == sourceSymbol.PersistentId).TagName;

            }
            processLine.SourceEquipmentTagName = sourceSymbol.TagName;

            IntermediateSymbol targetSymbol = GetIntermediateDetails(last, out IntermediateSymbol target);
            processLine.Target = targetSymbol.PersistentId;
            bool isTargetTagAvailable = _context.PipeConnectorSymbols.Any(x => x.PersistentId == targetSymbol.PersistentId);
            if (isTargetTagAvailable == true)
            {
                targetSymbol.TagName = _context.PipeConnectorSymbols.First(x => x.PersistentId == targetSymbol.PersistentId).TagName;

            }
            processLine.TargetTagName = targetSymbol.ComponentClass;
            processLine.TargetEquipmentTagName = targetSymbol.TagName;
            bool isSourceAndDestinationAvailable = _context.ProcessLines.Any(x => x.Source == first && x.Target == last);
            int processLineCount = 0;
            if (isSourceAndDestinationAvailable)
            {
                var processLineList = _context.ProcessLines.Where(x => x.Source == first && x.Target == last).ToList();
                int processId = processLineList.Max(x => x.Id);
                var name = processLineList.First(x => x.Id == processId).ProcessLineName;
                string processLineNameCount = name.Substring(name.LastIndexOf("_") + 1);
                int nameCount = int.Parse(processLineNameCount) + 1;
                processLine.ProcessLineName = sourceSymbol.PersistentId + "_" + targetSymbol.PersistentId + "_" + nameCount;
            }
            else
            {
                processLineCount += 1;
                processLine.ProcessLineName = sourceSymbol.PersistentId + "_" + targetSymbol.PersistentId + "_" + processLineCount;
            }
            processLine.DrawingDBId = drawing.Id;
            _context.ProcessLines.Add(processLine);
            _context.SaveChanges();

            foreach (var intermediateElement in path)
            {
                if (intermediateElement != first && intermediateElement != last)
                {
                    IntermediateSymbol intermediateSymbol = GetIntermediateDetails(intermediateElement, out IntermediateSymbol element);
                    IntermediateElement intermediate = new IntermediateElement();
                    intermediate.ProcessLineId = processLine.Id;
                    intermediate.intermediateElement = intermediateSymbol.PersistentId;
                    intermediate.ComponentClass = intermediateSymbol.ComponentClass;
                    if (_context.PipingComponents.Any(x => x.PersistentId == intermediateSymbol.PersistentId))
                    {
                        intermediate.TagName = _context.PipingComponents.First(x => x.PersistentId == intermediateSymbol.PersistentId).TagName;
                    }
                    if (_context.PropertyBreaks.Any(x => x.PersistentId == intermediateSymbol.PersistentId))
                    {
                        intermediate.TagName = _context.PropertyBreaks.First(x => x.PersistentId == intermediateSymbol.PersistentId).TagName;
                    }

                    if (_context.ProcessInstruments.Any(x => x.PersistentId == intermediateSymbol.PersistentId))
                    {
                        intermediate.TagName = _context.ProcessInstruments.First(x => x.PersistentId == intermediateSymbol.PersistentId).TagName;
                    }

                    intermediate.ComponentName = intermediateSymbol.ComponentName;
                    _context.IntermediateElements.Add(intermediate);
                    _context.SaveChanges();

                }
            }

        }

        /// <summary>
        /// GetIntermediateDetails
        /// </summary>
        private IntermediateSymbol GetIntermediateDetails(string Id, out IntermediateSymbol intermediateSymbol)
        {
            bool result = false;
            var intermediateSymbols = CollectIntermediateSymbols();
            intermediateSymbol = new IntermediateSymbol();
            var nozzleList = CollectNozzleDetails();
            var pipeConnectorDetails = CollectPipeConnectorDetails();

            if (intermediateSymbols.pipingComponentDetails.Any(x => x.PersistentId == Id))
            {
                result = true;
                intermediateSymbol.ID = intermediateSymbols.pipingComponentDetails.First(x => x.PersistentId == Id).ID;
                intermediateSymbol.PersistentId = intermediateSymbols.pipingComponentDetails.First(x => x.PersistentId == Id).PersistentId;
                intermediateSymbol.ComponentClass = intermediateSymbols.pipingComponentDetails.First(x => x.PersistentId == Id).ComponentClass;
                intermediateSymbol.ComponentName = intermediateSymbols.pipingComponentDetails.First(x => x.PersistentId == Id).ComponentName;
                intermediateSymbol.TagName = intermediateSymbols.pipingComponentDetails.First(x => x.PersistentId == Id).TagName;


            }

            if (result == false && intermediateSymbols.processInstrumentDetails.Any(x => x.PersistentId == Id))
            {
                result = true;
                intermediateSymbol.ID = intermediateSymbols.processInstrumentDetails.First(x => x.PersistentId == Id).ID;
                intermediateSymbol.PersistentId = intermediateSymbols.processInstrumentDetails.First(x => x.PersistentId == Id).PersistentId;
                intermediateSymbol.ComponentClass = intermediateSymbols.processInstrumentDetails.First(x => x.PersistentId == Id).ComponentClass;
                intermediateSymbol.ComponentName = intermediateSymbols.processInstrumentDetails.First(x => x.PersistentId == Id).ComponentName;
                intermediateSymbol.TagName = intermediateSymbols.processInstrumentDetails.First(x => x.PersistentId == Id).TagName;

            }


            if (result == false && intermediateSymbols.propertyBreakDetails.Any(x => x.PersistentId == Id))
            {
                result = true;
                intermediateSymbol.ID = intermediateSymbols.propertyBreakDetails.First(x => x.PersistentId == Id).ID;
                intermediateSymbol.PersistentId = intermediateSymbols.propertyBreakDetails.First(x => x.PersistentId == Id).PersistentId;
                intermediateSymbol.ComponentClass = intermediateSymbols.propertyBreakDetails.First(x => x.PersistentId == Id).ComponentClass;
                intermediateSymbol.ComponentName = intermediateSymbols.propertyBreakDetails.First(x => x.PersistentId == Id).ComponentName;

            }

            if (result == false && nozzleList.Any(x => x.PersistentId == Id))
            {
                result = true;
                intermediateSymbol.ID = nozzleList.First(x => x.PersistentId == Id).ID;
                intermediateSymbol.PersistentId = nozzleList.First(x => x.PersistentId == Id).PersistentId;
                intermediateSymbol.ComponentClass = nozzleList.First(x => x.PersistentId == Id).TagName;
                intermediateSymbol.TagName = nozzleList.First(x => x.PersistentId == Id).EquipmentTagName;
            }

            if (result == false && pipeConnectorDetails.Any(x => x.PersistentId == Id))
            {
                result = true;
                intermediateSymbol.ID = pipeConnectorDetails.First(x => x.PersistentId == Id).ID;
                intermediateSymbol.PersistentId = pipeConnectorDetails.First(x => x.PersistentId == Id).PersistentId;
                intermediateSymbol.ComponentClass = pipeConnectorDetails.First(x => x.PersistentId == Id).ComponentClass;
            }


            return intermediateSymbol;

        }

        /// <summary>
        /// CollectIntermediateSymbols
        /// </summary>
        private CollectedSymbol CollectIntermediateSymbols()
        {
            CollectedSymbol symbol = new CollectedSymbol();
            var pipingcomponentDetail = new List<PipingComponentDetail>();
            var pipingNetworkSegmentList = plantModel.PipingNetworkSystem.Where(x => x.PipingNetworkSegment != null).ToList().SelectMany(y => y.PipingNetworkSegment).ToList();
            var pipinComponentList = pipingNetworkSegmentList.Where(pip => pip.PipingComponent != null).ToList().SelectMany(p => p.PipingComponent).ToList();
            pipinComponentList.ForEach(piping =>
            {
                pipingcomponentDetail.Add(new PipingComponentDetail { TagName = piping.TagName, ComponentClass = piping.ComponentClass, PersistentId = piping.PersistentID.Identifier, ComponentName = piping.ComponentName });
            });

            symbol.pipingComponentDetails = pipingcomponentDetail;

            symbol.processInstrumentDetails = (plantModel.PipingNetworkSystem).Where(x => x.PipingNetworkSegment != null)
                .SelectMany(x => x.PipingNetworkSegment).Where(y => y.ProcessInstrument != null)
                .Select(x => x.ProcessInstrument)
                .Select(x => new ProcessInstrumentDetail { TagName = x.TagName, ComponentClass = x.ComponentClass, PersistentId = x.PersistentID.Identifier, ComponentName = x.ComponentName }).ToList();

            symbol.propertyBreakDetails = (plantModel.PipingNetworkSystem).Where(x => x.PropertyBreak != null)
             .SelectMany(x => x.PropertyBreak)
             .Select(x => new PropertyBreakDetail { ComponentClass = x.ComponentClass, PersistentId = x.PersistentID.Identifier, ComponentName = x.ComponentName }).ToList();
            return symbol;
        }

    }
}