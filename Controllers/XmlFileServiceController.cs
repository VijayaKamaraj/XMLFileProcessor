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
        /// CreateJson
        /// </summary>
        /// <param name="name"></param>
        [HttpGet]
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
                //var sourceTargetList = _fileService.CollectSourceTargetLists(plantModel);
                //_fileService.FindProcessLines(sourceTargetList);
                // if (!isRevisionNoExist)
                // {
                _fileService.AddXmlFileDetails(plantModel);
                string json = _jsonService.CreateJson(name);
                //var sourceTargetList = _fileService.CollectSourceTargetLists(plantModel);
                //_fileService.FindProcessLines(sourceTargetList);
                return Ok(json);
                // }
                // else
                // {
                //     return NotFound(new { message = "File Already Exist" });
                // }

            }
            return NotFound(new { message = "Invalid File" });
        }

    }
}