using Microsoft.AspNetCore.Mvc;
using XMLWebApiCore.BL;
using XMLWebApiCore.Models.Classes;
namespace XMLWebApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XmlFileServiceController : ControllerBase
    {
        IFileService _fileService;
        IJsonService _jsonService;
        public XmlFileServiceController(IFileService fileService, IJsonService jsonService)
        {
            _fileService = fileService;
            _jsonService = jsonService;
        }

        /// <summary>
        /// AddXmlDataByFile
        /// </summary>
        /// <param name="filePath"></param>
        [HttpPost]
        public IActionResult AddXmlDataByFile(string filePath)
        {
            bool isFileExist = _fileService.CheckFileType(filePath);
            bool isValidated = (isFileExist == true) ? (!_fileService.Validate_XML(filePath) ? true : false) : false;
            if (isValidated)
            {
                PlantModel plantModel = _fileService.ProcessXMLFile(filePath);
                var revision = plantModel.Drawing.Revision;
                var name = plantModel.Drawing.Name;
                bool isRevisionNoExist = (name != null) ? _fileService.CheckRevisionNumber(revision, name) : false;
                if (!isRevisionNoExist)
                {
                    _fileService.AddXmlFileDetails(plantModel);
                    string drawingId = _jsonService.getDrawingDetail(name);
                    return Ok(drawingId);
                }
                else
                {
                    return NotFound(new { message = "File Already Exist" });
                }

            }
            return NotFound(new { message = "Invalid File" });
        }

        /// <summary>
        /// GetDetails
        /// </summary>
        /// <param name="drawingId"></param>
        /// <param name="element"></param>

        [HttpGet]
        public IActionResult GetDetails(int drawingId, string element)
        {
            bool result = false;
            if (element == "Equipment")
            {
                result = true;
                string equipmentList = _jsonService.getEquipmentDetail(drawingId);
                return Ok(equipmentList);
            }

            if (result == false && element == "Connector")
            {
                result = true;
                string connectorList = _jsonService.getPipeConnectorDetail(drawingId);
                return Ok(connectorList);
            }

            if (result == false && element == "ProcessInstrument")
            {
                result = true;
                string processInstrumentList = _jsonService.getProcessInstrumentDetail(drawingId);
                return Ok(processInstrumentList);
            }

            if (result == false && element == "PropertyBreak")
            {
                result = true;
                string propertyBreakList = _jsonService.getPropertyBreakDetail(drawingId);
                return Ok(propertyBreakList);
            }

            if (result == false && element == "SignalLine")
            {
                result = true;
                string signalLineList = _jsonService.getSignalLineDetail(drawingId);
                return Ok(signalLineList);
            }

            if (result == false && element == "InstrumentComponent")
            {
                result = true;
                string instrumentComponentList = _jsonService.getInstrumentComponentDetail(drawingId);
                return Ok(instrumentComponentList);
            }

            if (result == false && element == "PipingComponent")
            {
                result = true;
                string pipingComponentList = _jsonService.getPipingComponentDetail(drawingId);
                return Ok(pipingComponentList);
            }

            if (result == false && element == "Nozzle")
            {
                result = true;
                string nozzleList = _jsonService.getNozzleDetail(drawingId);
                return Ok(nozzleList);
            }

            if (result == false && element == "ProcessLine")
            {
                result = true;
                string processLineList = _jsonService.getProcessLineDetail(drawingId);
                return Ok(processLineList);
            }

            if (result == false && element == "IntermediateElement")
            {
                result = true;
                string intermediateList = _jsonService.getIntermediateDetail(drawingId);
                return Ok(intermediateList);
            }

            if (result == false && element == "All")
            {
                result = true;
                string getAllList = _jsonService.GetAllDetails(drawingId);
                return Ok(getAllList);
            }
            return NotFound();
        }
    }
}