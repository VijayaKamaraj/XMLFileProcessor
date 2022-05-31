using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMLWebApiCore.Models.DBClasses;
using Newtonsoft.Json;

namespace XMLWebApiCore.BL
{
    public class JsonService:IJsonService
    {
         FileServiceContext _context;
         public JsonService(FileServiceContext context)=>_context=context;
        public string CreateJson(string name)
         {
            //List<Drawing> drawings=new List<Drawing>();
            var drawing=_context.Drawings.Where(x=>x.Name==name).FirstOrDefault();
            
                 Drawing drawingList =new Drawing();
                 drawingList.Id=drawing.Id;
                 drawingList.Name=drawing.Name;
                 drawingList.Revision=drawing.Revision;
                 drawingList.MaxX=drawing.MaxX;
                 drawingList.MaxY=drawing.MaxY;
                 drawingList.MinX=drawing.MinX;
                 drawingList.MinY=drawing.MinY;
                 List<Equipment> equipments=new List<Equipment>();
                 equipments=_context.Equipments.Where(x=>x.DrawingId==drawing.Id).ToList();
                 foreach(var equipment in equipments)
                 {
                     List<Nozzle> nozzles=_context.Nozzles.Where(x=>x.EquipmentId==equipment.Id).ToList();
                     equipment.Nozzles=nozzles;
                 }
                 drawingList.Equipments=equipments;
                 var instrumentComponents=_context.InstrumentComponents.Where(x=>x.DrawingId==drawing.Id).ToList();
                 drawingList.InstrumentComponents=instrumentComponents;
                  var pipeConnectorSymbol=_context.PipeConnectorSymbols.Where(x=>x.DrawingId==drawing.Id).ToList();
                 drawingList.PipeConnectorSymbols=pipeConnectorSymbol;

            string json = JsonConvert.SerializeObject(drawingList, Formatting.Indented);
            return json;
         }
    }
}