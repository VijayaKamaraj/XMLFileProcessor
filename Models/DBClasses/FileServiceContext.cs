using Microsoft.EntityFrameworkCore;
namespace XMLWebApiCore.Models.DBClasses
{
    public class FileServiceContext : DbContext
    {
        public FileServiceContext(DbContextOptions<FileServiceContext> options) : base(options)
        {

        }

        public DbSet<DrawingDB> Drawings { get; set; }
        public DbSet<EquipmentDB> Equipments { get; set; }
        public DbSet<NozzleDB> Nozzles { get; set; }

        public DbSet<InstrumentComponentDB> InstrumentComponents { get; set; }

        public DbSet<PipeConnectorSymbolDB> PipeConnectorSymbols { get; set; }

        public DbSet<ProcessInstrumentDB> ProcessInstruments { get; set; }

        public DbSet<PipingNetworkSystemDB> PipingNetworkSystems { get; set; }

        public DbSet<PipingNetworkSegmentDB> PipingNetworkSegments { get; set; }

        public DbSet<SignalLineDB> SignalLines { get; set; }

        public DbSet<ProcessLine> ProcessLines { get; set; }

        public DbSet<IntermediateElement> IntermediateElements { get; set; }

    }
}