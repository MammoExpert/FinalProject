﻿using MammoExpert.PatientServices.Core;
using System.Data.Entity;

namespace MammoExpert.PatientServices.DB
{
    public class PatientContext : DbContext
    {
        public PatientContext() { }
        public PatientContext(string dbNameOrConnection = "SqlConnection") :
            base(dbNameOrConnection)
        { }
        public DbSet<Patient> Patients { get; set; }
    }
}