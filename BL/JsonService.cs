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
        public string CreateJson()
         {
            List<Drawing> drawings=new List<Drawing>();
            var drawingsList=_context.Drawings.ToList();
             foreach(var drawing in drawingsList)
             {
                 Drawing drawingList =new Drawing();
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
                 List<InstrumentComponent> instrumentComponents=_context.InstrumentComponents.Where(x=>x.DrawingId==drawing.Id).ToList();
                 drawingList.InstrumentComponents=instrumentComponents;
                drawings.Add(drawingList);

             }

            string json = JsonConvert.SerializeObject(drawings, Formatting.Indented);
            return json;
         }
    }
}