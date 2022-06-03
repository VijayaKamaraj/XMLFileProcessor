using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLWebApiCore.Models.Classes;
using XMLWebApiCore.Models.DBClasses;
namespace XMLWebApiCore.BL
{
    public interface IFileService
    {
        bool CheckFileType(string path);
        bool Validate_XML(string path);

        PlantModel ProcessXMLFile(string path);

        bool AddXmlFileDetails(PlantModel plantModel);

        bool CheckRevisionNumber(string revision, string name);

        List<SourceTargetList> CollectSourceTargetLists(PlantModel plantModel);

        void FindProcessLines(List<SourceTargetList> sourceTargetLists);
    }
}
