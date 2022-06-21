using XMLWebApiCore.Models.DBClasses;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace XMLWebApiCore.BL
{
    public class JsonService : IJsonService
    {

        private IConfiguration configuration;
        string storedProcedureName;
        FileServiceContext _context;
        public JsonService(FileServiceContext context, IConfiguration iconfig)
        {
            _context = context;
            configuration = iconfig;
        }

        /// <summary>
        /// getDrawingDetail
        /// </summary>
        /// <param name="name"></param>
        public string getDrawingDetail(string name)
        {
            var drawing = _context.Drawings.Where(x => x.Name == name).FirstOrDefault();
            if (drawing != null)
            {
                DrawingNumber drawingNumber = new DrawingNumber();
                drawingNumber.DrawingId = drawing.Id;
                string json = JsonConvert.SerializeObject(drawingNumber, Formatting.Indented);
                return json;
            }
            return string.Empty;
        }

        /// <summary>
        /// getEquipmentDetail
        /// </summary>
        /// <param name="drawingId"></param>
        public string getEquipmentDetail(int drawingId)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            List<EquipmentDB> equipmentList = new List<EquipmentDB>();
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                con.Open();
                storedProcedureName = "GetEquipmentList";
                SqlDataReader sqlDataReader = ReadData(drawingId, con, storedProcedureName);
                while (sqlDataReader.Read())
                {
                    EquipmentDB equipmentDB = new EquipmentDB();
                    equipmentDB.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    equipmentDB.ComponentClass = sqlDataReader["ComponentClass"].ToString();
                    equipmentDB.TagName = sqlDataReader["TagName"].ToString();
                    equipmentDB.ComponentName = sqlDataReader["ComponentName"].ToString();
                    equipmentDB.MinX = Convert.ToDouble(sqlDataReader["MinX"]);
                    equipmentDB.MaxX = Convert.ToDouble(sqlDataReader["MaxX"]);
                    equipmentDB.MinY = Convert.ToDouble(sqlDataReader["MinY"]);
                    equipmentDB.MaxY = Convert.ToDouble(sqlDataReader["MaxY"]);
                    equipmentDB.LocationX = Convert.ToDouble(sqlDataReader["LocationX"]);
                    equipmentDB.LocationY = Convert.ToDouble(sqlDataReader["LocationY"]);
                    equipmentList.Add(equipmentDB);
                }
                sqlDataReader.Close();
                foreach (var equipment in equipmentList)
                {
                    List<NozzleDB> nozzles = new List<NozzleDB>();
                    SqlCommand cmd1 = new SqlCommand("GetNozzleListByEquipmentId", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@equipmentId", equipment.Id);
                    SqlDataReader dataReader = cmd1.ExecuteReader();
                    while (dataReader.Read())
                    {
                        NozzleDB nozzle = new NozzleDB();
                        nozzle.ComponentClass = dataReader["ComponentClass"].ToString();
                        nozzle.TagName = dataReader["TagName"].ToString();
                        nozzle.ComponentName = dataReader["ComponentName"].ToString();
                        nozzle.MinX = Convert.ToDouble(dataReader["MinX"]);
                        nozzle.MaxX = Convert.ToDouble(dataReader["MaxX"]);
                        nozzle.MinY = Convert.ToDouble(dataReader["MinY"]);
                        nozzle.MaxY = Convert.ToDouble(dataReader["MaxY"]);
                        nozzle.LocationX = Convert.ToDouble(dataReader["LocationX"]);
                        nozzle.LocationY = Convert.ToDouble(dataReader["LocationY"]);
                        nozzle.PersistentId = dataReader["PersistentId"].ToString();
                        nozzles.Add(nozzle);
                    }
                    equipment.Nozzles = nozzles;
                    dataReader.Close();
                }
            }
            string json = JsonConvert.SerializeObject(equipmentList, Formatting.Indented);
            return json;
        }

        /// <summary>
        /// getPipeConnectorDetail
        /// </summary>
        /// <param name="drawingId"></param>
        public string getPipeConnectorDetail(int drawingId)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            List<PipeConnectorSymbolDB> connectorList = new List<PipeConnectorSymbolDB>();
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                con.Open();
                storedProcedureName = "GetConnectorList";
                SqlDataReader sqlDataReader = ReadData(drawingId, con, storedProcedureName);
                while (sqlDataReader.Read())
                {
                    PipeConnectorSymbolDB pipeConnectorDB = new PipeConnectorSymbolDB();
                    pipeConnectorDB.ComponentClass = sqlDataReader["ComponentClass"].ToString();
                    pipeConnectorDB.TagName = sqlDataReader["TagName"].ToString();
                    pipeConnectorDB.ComponentName = sqlDataReader["ComponentName"].ToString();
                    pipeConnectorDB.MinX = Convert.ToDouble(sqlDataReader["MinX"]);
                    pipeConnectorDB.MaxX = Convert.ToDouble(sqlDataReader["MaxX"]);
                    pipeConnectorDB.MinY = Convert.ToDouble(sqlDataReader["MinY"]);
                    pipeConnectorDB.MaxY = Convert.ToDouble(sqlDataReader["MaxY"]);
                    pipeConnectorDB.LocationX = Convert.ToDouble(sqlDataReader["LocationX"]);
                    pipeConnectorDB.LocationY = Convert.ToDouble(sqlDataReader["LocationY"]);
                    pipeConnectorDB.PersistentId = sqlDataReader["PersistentId"].ToString();
                    pipeConnectorDB.CrossPageDrawingName = sqlDataReader["CrossPageDrawingName"].ToString();
                    pipeConnectorDB.CrossPageLinkLabel = sqlDataReader["CrossPageLinkLabel"].ToString();
                    connectorList.Add(pipeConnectorDB);
                }
            }
            string json = JsonConvert.SerializeObject(connectorList, Formatting.Indented);
            return json;
        }

        /// <summary>
        /// getProcessInstrumentDetail
        /// </summary>
        /// <param name="drawingId"></param>
        public string getProcessInstrumentDetail(int drawingId)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            List<ProcessInstrumentDB> processInstrumentList = new List<ProcessInstrumentDB>();
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                con.Open();
                storedProcedureName = "GetProcessInstrumentList";
                SqlDataReader sqlDataReader = ReadData(drawingId, con, storedProcedureName);
                while (sqlDataReader.Read())
                {
                    ProcessInstrumentDB processInstrument = new ProcessInstrumentDB();
                    processInstrument.ComponentClass = sqlDataReader["ComponentClass"].ToString();
                    processInstrument.TagName = sqlDataReader["TagName"].ToString();
                    processInstrument.StockNumber = sqlDataReader["StockNumber"].ToString();
                    processInstrument.ComponentName = sqlDataReader["ComponentName"].ToString();
                    processInstrument.MinX = Convert.ToDouble(sqlDataReader["MinX"]);
                    processInstrument.MaxX = Convert.ToDouble(sqlDataReader["MaxX"]);
                    processInstrument.MinY = Convert.ToDouble(sqlDataReader["MinY"]);
                    processInstrument.MaxY = Convert.ToDouble(sqlDataReader["MaxY"]);
                    processInstrument.LocationX = Convert.ToDouble(sqlDataReader["LocationX"]);
                    processInstrument.LocationY = Convert.ToDouble(sqlDataReader["LocationY"]);
                    processInstrument.PersistentId = sqlDataReader["PersistentId"].ToString();
                    processInstrumentList.Add(processInstrument);
                }
            }
            string json = JsonConvert.SerializeObject(processInstrumentList, Formatting.Indented);
            return json;
        }

        /// <summary>
        /// getPropertyBreakDetail
        /// </summary>
        /// <param name="drawingId"></param>
        public string getPropertyBreakDetail(int drawingId)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            List<PropertyBreakDB> propertyBreakList = new List<PropertyBreakDB>();
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                con.Open();
                storedProcedureName = "GetPropertyBreakList";
                SqlDataReader sqlDataReader = ReadData(drawingId, con, storedProcedureName);
                while (sqlDataReader.Read())
                {
                    PropertyBreakDB propertyBreak = new PropertyBreakDB();
                    propertyBreak.ComponentClass = sqlDataReader["ComponentClass"].ToString();
                    propertyBreak.TagName = sqlDataReader["TagName"].ToString();
                    propertyBreak.ComponentName = sqlDataReader["ComponentName"].ToString();
                    propertyBreak.MinX = Convert.ToDouble(sqlDataReader["MinX"]);
                    propertyBreak.MaxX = Convert.ToDouble(sqlDataReader["MaxX"]);
                    propertyBreak.MinY = Convert.ToDouble(sqlDataReader["MinY"]);
                    propertyBreak.MaxY = Convert.ToDouble(sqlDataReader["MaxY"]);
                    propertyBreak.PersistentId = sqlDataReader["PersistentId"].ToString();
                    propertyBreak.LocationX = Convert.ToDouble(sqlDataReader["LocationX"]);
                    propertyBreak.LocationY = Convert.ToDouble(sqlDataReader["LocationY"]);
                    propertyBreakList.Add(propertyBreak);
                }
            }

            string json = JsonConvert.SerializeObject(propertyBreakList, Formatting.Indented);
            return json;
        }

        /// <summary>
        /// getSignalLineDetail
        /// </summary>
        /// <param name="drawingId"></param>
        public string getSignalLineDetail(int drawingId)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            List<SignalLineDB> signalLineList = new List<SignalLineDB>();
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                con.Open();
                storedProcedureName = "GetSignalLineList";
                SqlDataReader sqlDataReader = ReadData(drawingId, con, storedProcedureName);
                while (sqlDataReader.Read())
                {
                    SignalLineDB signalLineDB = new SignalLineDB();
                    signalLineDB.ComponentClass = sqlDataReader["ComponentClass"].ToString();
                    signalLineDB.ComponentName = sqlDataReader["ComponentName"].ToString();
                    signalLineDB.PersistentId = sqlDataReader["PersistentId"].ToString();
                    signalLineDB.FromID = sqlDataReader["FromID"].ToString();
                    signalLineDB.ToID = sqlDataReader["ToID"].ToString();
                    signalLineDB.MinX = Convert.ToDouble(sqlDataReader["MinX"]);
                    signalLineDB.MaxX = Convert.ToDouble(sqlDataReader["MaxX"]);
                    signalLineDB.MinY = Convert.ToDouble(sqlDataReader["MinY"]);
                    signalLineDB.MaxY = Convert.ToDouble(sqlDataReader["MaxY"]);
                    signalLineList.Add(signalLineDB);
                }
            }

            string json = JsonConvert.SerializeObject(signalLineList, Formatting.Indented);
            return json;
        }

        /// <summary>
        /// getInstrumentComponentDetail
        /// </summary>
        /// <param name="drawingId"></param>
        public string getInstrumentComponentDetail(int drawingId)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            List<InstrumentComponentDB> instrumentComponentList = new List<InstrumentComponentDB>();
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                con.Open();
                storedProcedureName = "GetInstrumentComponentList";
                SqlDataReader sqlDataReader = ReadData(drawingId, con, storedProcedureName);
                while (sqlDataReader.Read())
                {
                    InstrumentComponentDB instrumentComponent = new InstrumentComponentDB();
                    instrumentComponent.ComponentClass = sqlDataReader["ComponentClass"].ToString();
                    instrumentComponent.PersistentId = sqlDataReader["PersistentId"].ToString();
                    instrumentComponent.StockNumber = sqlDataReader["StockNumber"].ToString();
                    instrumentComponent.TagName = sqlDataReader["TagName"].ToString();
                    instrumentComponent.ComponentName = sqlDataReader["ComponentName"].ToString();
                    instrumentComponent.MinX = Convert.ToDouble(sqlDataReader["MinX"]);
                    instrumentComponent.MaxX = Convert.ToDouble(sqlDataReader["MaxX"]);
                    instrumentComponent.MinY = Convert.ToDouble(sqlDataReader["MinY"]);
                    instrumentComponent.MaxY = Convert.ToDouble(sqlDataReader["MaxY"]);
                    instrumentComponent.LocationX = Convert.ToDouble(sqlDataReader["LocationX"]);
                    instrumentComponent.LocationY = Convert.ToDouble(sqlDataReader["LocationY"]);
                    instrumentComponentList.Add(instrumentComponent);
                }
            }

            string json = JsonConvert.SerializeObject(instrumentComponentList, Formatting.Indented);
            return json;
        }

        /// <summary>
        /// getPipingComponentDetail
        /// </summary>
        /// <param name="drawingId"></param>
        public string getPipingComponentDetail(int drawingId)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            List<PipingComponentDB> pipingComponents = new List<PipingComponentDB>();
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                con.Open();
                storedProcedureName = "GetPipingComponentList";
                SqlDataReader sqlDataReader = ReadData(drawingId, con, storedProcedureName);
                while (sqlDataReader.Read())
                {
                    PipingComponentDB pipingComponent = new PipingComponentDB();
                    pipingComponent.ComponentClass = sqlDataReader["ComponentClass"].ToString();
                    pipingComponent.TagName = sqlDataReader["TagName"].ToString();
                    pipingComponent.ComponentName = sqlDataReader["ComponentName"].ToString();
                    pipingComponent.MinX = Convert.ToDouble(sqlDataReader["MinX"]);
                    pipingComponent.MaxX = Convert.ToDouble(sqlDataReader["MaxX"]);
                    pipingComponent.MinY = Convert.ToDouble(sqlDataReader["MinY"]);
                    pipingComponent.MaxY = Convert.ToDouble(sqlDataReader["MaxY"]);
                    pipingComponent.LocationX = Convert.ToDouble(sqlDataReader["LocationX"]);
                    pipingComponent.LocationY = Convert.ToDouble(sqlDataReader["LocationY"]);
                    pipingComponent.PersistentId = sqlDataReader["PersistentId"].ToString();
                    pipingComponents.Add(pipingComponent);
                }
            }

            string json = JsonConvert.SerializeObject(pipingComponents, Formatting.Indented);
            return json;
        }

        /// <summary>
        /// getNozzleDetail
        /// </summary>
        /// <param name="drawingId"></param>
        public string getNozzleDetail(int drawingId)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            List<NozzleDB> nozzleList = new List<NozzleDB>();
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                con.Open();
                storedProcedureName = "GetNozzleList";
                SqlDataReader sqlDataReader = ReadData(drawingId, con, storedProcedureName);
                while (sqlDataReader.Read())
                {
                    NozzleDB nozzle = new NozzleDB();
                    nozzle.ComponentClass = sqlDataReader["ComponentClass"].ToString();
                    nozzle.TagName = sqlDataReader["TagName"].ToString();
                    nozzle.ComponentName = sqlDataReader["ComponentName"].ToString();
                    nozzle.MinX = Convert.ToDouble(sqlDataReader["MinX"]);
                    nozzle.MaxX = Convert.ToDouble(sqlDataReader["MaxX"]);
                    nozzle.MinY = Convert.ToDouble(sqlDataReader["MinY"]);
                    nozzle.MaxY = Convert.ToDouble(sqlDataReader["MaxY"]);
                    nozzle.LocationX = Convert.ToDouble(sqlDataReader["LocationX"]);
                    nozzle.LocationY = Convert.ToDouble(sqlDataReader["LocationY"]);
                    nozzle.PersistentId = sqlDataReader["PersistentId"].ToString();
                    nozzleList.Add(nozzle);
                }
            }
            string json = JsonConvert.SerializeObject(nozzleList, Formatting.Indented);
            return json;
        }

        /// <summary>
        /// getProcessLineDetail
        /// </summary>
        /// <param name="drawingId"></param>
        public string getProcessLineDetail(int drawingId)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            List<ProcessLine> processLines = new List<ProcessLine>();
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                con.Open();
                storedProcedureName = "GetProcessLineList";
                SqlDataReader sqlDataReader = ReadData(drawingId, con, storedProcedureName);
                while (sqlDataReader.Read())
                {
                    ProcessLine processLine = new ProcessLine();
                    processLine.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    processLine.ProcessLineName = sqlDataReader["ProcessLineName"].ToString();
                    processLine.Source = sqlDataReader["Source"].ToString();
                    processLine.SourceTagName = sqlDataReader["SourceTagName"].ToString();
                    processLine.SourceEquipmentTagName = sqlDataReader["SourceEquipmentTagName"].ToString();
                    processLine.Target = sqlDataReader["Target"].ToString();
                    processLine.TargetTagName = sqlDataReader["TargetTagName"].ToString();
                    processLine.TargetEquipmentTagName = sqlDataReader["TargetEquipmentTagName"].ToString();
                    processLines.Add(processLine);
                }
                sqlDataReader.Close();
                foreach (var processLine in processLines)
                {
                    List<IntermediateElement> intermediateElements = new List<IntermediateElement>();
                    SqlCommand cmd1 = new SqlCommand("GetInterMediateListByProcessId", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@processLineId", processLine.Id);
                    SqlDataReader dataReader = cmd1.ExecuteReader();
                    //SqlDataReader dataReader = ReadData(drawingId, con, storedProcedureName);

                    while (dataReader.Read())
                    {
                        IntermediateElement intermediateSymbol = new IntermediateElement();
                        intermediateSymbol.intermediateElement = dataReader["intermediateElement"].ToString();
                        intermediateSymbol.ComponentClass = dataReader["ComponentClass"].ToString();
                        intermediateSymbol.ComponentName = dataReader["ComponentName"].ToString();
                        intermediateSymbol.TagName = dataReader["TagName"].ToString();
                        intermediateElements.Add(intermediateSymbol);
                    }
                    processLine.IntermediateElements = intermediateElements;
                    dataReader.Close();
                }

            }

            string json = JsonConvert.SerializeObject(processLines, Formatting.Indented);
            return json;
        }

        /// <summary>
        /// ReadData
        /// </summary>
        /// <param name="drawingId"></param>
        /// <param name="con"></param>
        /// <param name="storedProcedureName"></param>
        private static SqlDataReader ReadData(int drawingId, SqlConnection con, string storedProcedureName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedureName;
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@drawingId",
                Value = drawingId
            });
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            return sqlDataReader;
        }

        /// <summary>
        /// getIntermediateDetail
        /// </summary>
        /// <param name="drawingId"></param>
        public string getIntermediateDetail(int drawingId)
        {
            string dbConn = configuration.GetSection("ConnectionStrings").GetSection("SqlServer").Value;
            List<IntermediateElement> intermediateElements = new List<IntermediateElement>();
            using (SqlConnection con = new SqlConnection(dbConn))
            {
                con.Open();
                storedProcedureName = "GetIntermediateList";
                SqlDataReader sqlDataReader = ReadData(drawingId, con, storedProcedureName);
                while (sqlDataReader.Read())
                {
                    IntermediateElement intermediateSymbol = new IntermediateElement();
                    intermediateSymbol.intermediateElement = sqlDataReader["intermediateElement"].ToString();
                    intermediateSymbol.ComponentClass = sqlDataReader["ComponentClass"].ToString();
                    intermediateSymbol.ComponentName = sqlDataReader["ComponentName"].ToString();
                    intermediateSymbol.TagName = sqlDataReader["TagName"].ToString();
                    intermediateElements.Add(intermediateSymbol);
                }
            }

            string json = JsonConvert.SerializeObject(intermediateElements, Formatting.Indented);
            return json;
        }

        /// <summary>
        /// GetAllDetails
        /// </summary>
        /// <param name="drawingId"></param>
        public string GetAllDetails(int drawingId)
        {
            var drawing = _context.Drawings.Where(x => x.Id == drawingId).FirstOrDefault();
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

                var pipingComponents = _context.PipingComponents.Where(x => x.DrawingDBId == drawing.Id).ToList();
                drawingList.PipingComponents = pipingComponents;

                var propertyBreaks = _context.PropertyBreaks.Where(x => x.DrawingDBId == drawing.Id).ToList();
                drawingList.PropertyBreaks = propertyBreaks;

                string json = JsonConvert.SerializeObject(drawingList, Formatting.Indented);
                return json;
            }
            return string.Empty;
        }
    }
}

