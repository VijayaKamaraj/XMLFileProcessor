using XMLWebApiCore.Models.Classes;
namespace XMLWebApiCore.BL
{
    public interface IFileService
    {
        bool CheckFileType(string path);
        bool Validate_XML(string path);
        PlantModel ProcessXMLFile(string path);
        bool AddXmlFileDetails(PlantModel plantModel);
        bool CheckRevisionNumber(string revision, string name);
    }
}
