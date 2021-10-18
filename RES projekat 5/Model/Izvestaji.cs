using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RES_projekat_5.Model
{
    [ExcludeFromCodeCoverage]
    public class Izvestaji : DbContext
    {
        public DbSet<SnagaElektrodistribucija> Elektrodistribucije { get; set; }
        public DbSet<EnergijaIzBaterije> Baterije { get; set; }
        public DbSet<PotrosnjaPotrosaca> Potrosaci { get; set; }
        public DbSet<ProizvodnjaSolarnihPanela> SolarniPaneli { get; set; }     
    }
}
