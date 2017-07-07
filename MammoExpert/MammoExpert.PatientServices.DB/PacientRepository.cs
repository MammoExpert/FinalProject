using MammoExpert.PatientServices.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.DB
{
    public class PacientRepository : IDataSourcePatient
    {
        PatientContext patientContext;
        public PacientRepository(string dbNameOrConnection)
        {
            patientContext = new PatientContext(dbNameOrConnection);
        }

        //Получение пациентов по строке поиска
        public List<Patient> FindPatientsOnTheSearchBar(string searchString)
        {
            var patients = patientContext.Patients.Where(s => s.AccessionNumber.Contains(searchString) ||
                s.BirthDate.ToString().Contains(searchString) || s.Contingent.Contains(searchString) || 
                s.FirstName.Contains(searchString) || s.InsuranceCompany.Contains(searchString) || 
                s.Job.Contains(searchString) || s.LastName.Contains(searchString) || s.MedicalRecordLocator.Contains(searchString) 
                || s.MiddleName.Contains(searchString) || s.NumberOfPassport.Contains(searchString)
                || s.NumberPolicy.Contains(searchString) || s.PatientAddress.Contains(searchString) || 
                s.PatientCategory.Contains(searchString) || s.PatientComments.Contains(searchString) || 
                s.PatientId.Contains(searchString) || s.PatientWorkAddres.Contains(searchString) ||
                s.Telephone == searchString).ToList();
            return patients;
        }

        //Получение всех пациентов из БД
        public List<Patient> GetAllPatients()
        {
            var patients = patientContext.Patients.ToList();
            return patients;
        }

        //Получение пациента по идентификатору
        public Patient GetPatientData(string patientId)
        {
            var patient = patientContext.Patients.Where(s => s.PatientId == patientId).FirstOrDefault();
            return patient; 
        }
    }
}
