        using System;
        using System.Collections.Generic;
        using System.Configuration;
        using System.IO;
        using System.Linq;
        using System.Web;
        using System.Xml;
        using System.Xml.Linq;
        using System.Xml.Schema;
        using System.Xml.Serialization;
        using XMLWebApiCore.Models.Classes;
        using XMLWebApiCore.Models.DBClasses;


        namespace XMLWebApiCore.BL
        {
            public class FileService:IFileService
            {
                string folderPath=Path.Combine(Environment.CurrentDirectory, "Files");
                FileServiceContext _context;

                public FileService(FileServiceContext context)=>_context=context;

                //string folderPath = ConfigurationManager.AppSettings["FilePath"].ToString();
                public PlantModel ProcessXMLFile(string path)
                {
                    PlantModel plantModel = new PlantModel();
        
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


                public bool CheckFileType(string fileName)
                {
                string path=folderPath+"\\"+fileName;
                bool result=fileName.EndsWith(".xml")?(Directory.Exists(folderPath) ? 
                                (File.Exists(path) ? true : false) : false):false;

                return result;
                }
                

                public bool AddEquipmentAndNozzleDetails(PlantModel plantModel)
                {
                    if(plantModel.Drawing!=null)
                    {
                    Models.DBClasses.Drawing drawing=new Models.DBClasses.Drawing();
                    drawing.Name=plantModel.Drawing.Name;
                    drawing.Revision=plantModel.Drawing.Revision==null? "NA":plantModel.Drawing.Revision;
                    drawing.MaxX=plantModel.Drawing.Extent.Max.X;
                    drawing.MaxY=plantModel.Drawing.Extent.Max.Y;
                    drawing.MinX=plantModel.Drawing.Extent.Min.X;
                    drawing.MinY=plantModel.Drawing.Extent.Min.Y;
                    _context.Drawings.Add(drawing);
                    _context.SaveChanges();
                    if(plantModel.InstrumentComponent!=null)
                    {
                        foreach(var instrumentComponent in plantModel.InstrumentComponent)
                    {
                        Models.DBClasses.InstrumentComponent instrumentComponents = new Models.DBClasses.InstrumentComponent();
                        instrumentComponents.DrawingId=drawing.Id;
                        instrumentComponents.TagName=instrumentComponent.TagName;
                        instrumentComponents.ComponentClass=instrumentComponent.ComponentClass;
                        instrumentComponents.ComponentName=instrumentComponent.ComponentName;
                        instrumentComponents.StockNumber=instrumentComponent.StockNumber==null?"NA":instrumentComponent.StockNumber;
                        instrumentComponents.PersistentId=instrumentComponent.PersistentID.Identifier;
                        instrumentComponents.MaxX=instrumentComponent.Extent.Max.X;
                        instrumentComponents.MaxY=instrumentComponent.Extent.Max.Y;
                        instrumentComponents.MinX=instrumentComponent.Extent.Min.X;
                        instrumentComponents.MinY=instrumentComponent.Extent.Min.Y;
                        instrumentComponents.LocationX=instrumentComponent.Position.Location.X;
                        instrumentComponents.LocationY=instrumentComponent.Position.Location.Y;
                        _context.InstrumentComponents.Add(instrumentComponents);
                        _context.SaveChanges();

                    }
                    }
                if(plantModel.Equipment!=null)
                {
                    foreach(var equipment in plantModel.Equipment)
                    {
                        Models.DBClasses.Equipment equipments = new Models.DBClasses.Equipment();
                        equipments.DrawingId=drawing.Id;
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

                        foreach (var nozzle in equipment.Nozzle)
                        {
                            Models.DBClasses.Nozzle nozzles = new Models.DBClasses.Nozzle();
                            nozzles.EquipmentId = equipments.Id;
                            nozzles.TagName = nozzle.TagName;
                            nozzles.ComponentClass = nozzle.ComponentClass;
                            nozzles.ComponentName = nozzle.ComponentName;
                            nozzles.LocationX = nozzle.Position.Location.X;
                            nozzles.LocationY = nozzle.Position.Location.Y;
                            nozzles.MaxX = nozzle.Extent.Max.X;
                            nozzles.MaxY = nozzle.Extent.Max.Y;
                            nozzles.MinX = nozzle.Extent.Min.X;
                            nozzles.MinY = nozzle.Extent.Min.Y;
                            _context.Nozzles.Add(nozzles);

                            _context.SaveChanges();


                        }



                    }
                    
                }
                
                var  pipeConnectorDetails = (plantModel.PipingNetworkSystem).Where(x => x.PipingNetworkSegment != null).SelectMany(x => x.PipingNetworkSegment).Where(y => y.PipeConnectorSymbol != null).Select(x=>x.PipeConnectorSymbol).ToList();
                if(pipeConnectorDetails!=null)
                {
                foreach(var pipeConnector in pipeConnectorDetails)
                {
                    Models.DBClasses.PipeConnectorSymbol pipeConnectorSymbol=new  Models.DBClasses.PipeConnectorSymbol();
                    pipeConnectorSymbol.DrawingId=drawing.Id;
                    pipeConnectorSymbol.ComponentClass=pipeConnector.ComponentClass;
                    pipeConnectorSymbol.ComponentName=pipeConnector.ComponentName;
                    pipeConnectorSymbol.PersistentId=pipeConnector.PersistentID.Identifier;
                    pipeConnectorSymbol.MaxX=pipeConnector.Extent.Max.X;
                    pipeConnectorSymbol.MaxY=pipeConnector.Extent.Max.Y;
                    pipeConnectorSymbol.MinX=pipeConnector.Extent.Min.X;
                    pipeConnectorSymbol.MinY=pipeConnector.Extent.Min.Y;
                    pipeConnectorSymbol.LocationX=pipeConnector.Position.Location.X;
                    pipeConnectorSymbol.LocationY=pipeConnector.Position.Location.Y;
                    pipeConnectorSymbol.CrossPageDrawingName=pipeConnector.CrossPageConnection.DrawingName==null?"NA":pipeConnector.CrossPageConnection.DrawingName;
                    pipeConnectorSymbol.CrossPageLinkLabel=pipeConnector.CrossPageConnection.LinkLabel==null?"NA":pipeConnector.CrossPageConnection.LinkLabel;
                    _context.PipeConnectorSymbols.Add(pipeConnectorSymbol);
                    _context.SaveChanges();
                }
            }
        }
                
    return true;
    }


                public bool CheckRevisionNumber(string revision,string name)
                {
                    bool result=false;
                    var drawing=_context.Drawings.FirstOrDefault(x=>x.Revision==revision || x.Name==name);
                    if(drawing!=null)
                    {
                        result=true;
                    }
                    return result;
                }
        
                
        
            }
        }