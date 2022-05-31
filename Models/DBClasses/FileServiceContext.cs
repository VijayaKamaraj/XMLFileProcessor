using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
//using System.Data.Entity.ModelConfiguration.Configuration;


namespace XMLWebApiCore.Models.DBClasses
{
    public class FileServiceContext:DbContext
    {
        public FileServiceContext(DbContextOptions<FileServiceContext> options):base(options)
        {

        }
        
        public DbSet<Drawing> Drawings {get;set;}
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Nozzle> Nozzles { get; set; }

        public DbSet<InstrumentComponent> InstrumentComponents{get;set;}

        public DbSet<PipeConnectorSymbol> PipeConnectorSymbols{get;set;}

        }
    }