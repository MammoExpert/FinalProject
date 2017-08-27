using MammoExpert.PatientServices.Core;
using System.Data.Entity;

namespace MammoExpert.PatientServices.DB
{
    public class PatientContext : DbContext
    {
       // public PatientContext() { }
        public PatientContext() :
            base("SqlConnection")
        { }
        public DbSet<Patient> Patients { get; set; }
    }
}
