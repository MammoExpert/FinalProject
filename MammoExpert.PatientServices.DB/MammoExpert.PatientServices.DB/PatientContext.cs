using MammoExpert.PatientServices.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.DB
{
    public class PatientContext : DbContext
    {
        public PatientContext() { }
        public PatientContext(string dbNameOrConnection) : 
            base(dbNameOrConnection) { }
        public DbSet<Patient> Patients { get; set; }
    }
}
