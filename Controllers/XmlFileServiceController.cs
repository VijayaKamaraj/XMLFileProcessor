using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XMLWebApiCore.BL;
using XMLWebApiCore.Models.Classes;
using Newtonsoft.Json;
using XMLWebApiCore.Models.DBClasses;

namespace XMLWebApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XmlFileServiceController:ControllerBase
    {
        IFileService _fileService;
        IJsonService _jsonService;

        public XmlFileServiceController(IFileService fileService,IJsonService jsonService)
        {
            _fileService = fileService;
            _jsonService=jsonService;
        }

        [HttpGet]
        public IActionResult GetFileName(string fileName)
        {
            bool isFileExist = _fileService.CheckFileType(fileName);
            string path=Path.Combine(Environment.CurrentDirectory, "Files",fileName);
            bool isValidated = (isFileExist == true) ? (!_fileService.Validate_XML(path) ? true : false) : false;
            if(isValidated)
            {
                PlantModel plantModel =  _fileService.ProcessXMLFile(path);
                var revision=plantModel.Drawing.Revision;
                var name=plantModel.Drawing.Name;         
               
                bool isRevisionNoExist= (name!=null)? _fileService.CheckRevisionNumber(revision,name):false; 
                if(!isRevisionNoExist)
                {
                    _fileService.AddEquipmentAndNozzleDetails(plantModel);
                    string json=_jsonService.CreateJson(name);                  
                    return Ok(json);
                }
                else
                {
                    return NotFound(new { message = "File Already Exist" });
                }
               
            }
           return NotFound(new { message = "Invalid File" });
        }




    }
}