using MammoExpert.PatientServices.Core;
using System.Data.Entity;

namespace MammoExpert.Infrastructure
{
    public class PatientContext : DbContext
    {
        public PatientContext() { }
        public PatientContext(string dbNameOrConnection) :
            base(dbNameOrConnection)
        { }
        public DbSet<Patient> Patients { get; set; }
    }
}
