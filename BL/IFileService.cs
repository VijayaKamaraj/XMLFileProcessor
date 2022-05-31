using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLWebApiCore.Models.Classes;

namespace XMLWebApiCore.BL
{
    public interface IFileService
    {
        bool CheckFileType(string path);
        bool Validate_XML(string path);

        PlantModel ProcessXMLFile(string path);

        bool AddEquipmentAndNozzleDetails(PlantModel plantModel);
 
        bool CheckRevisionNumber(string revision,string name);

    
    }
}
