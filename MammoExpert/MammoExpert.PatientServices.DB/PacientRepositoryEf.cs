using MammoExpert.PatientServices.Core;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace MammoExpert.PatientServices.DB
{
    public class PacientRepositoryEf : IPatientRepository
    {
        private readonly PatientContext _patientContext;
        private readonly string _connectionString;
        public PacientRepositoryEf(string dbNameOrConnection, PatientContext patientContext)
        {
            _connectionString = dbNameOrConnection;
            _patientContext = patientContext;
        }

        /// <summary>
        /// Добавляет нового пациента в базу данных
        /// </summary>
        /// <param name="patient"></param>
        public void AddNewPatient(Patient patient)
        {
            //using (_patientContext = new PatientContext(_connectionString))
            //{
            //    _patientContext.Patients.Add(patient);
            //}
            _patientContext.Patients.Add(patient);
            _patientContext.SaveChanges();
        }

        /// <summary>
        /// Получает список пациентов из базы данных по вводимому значению
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public IEnumerable<Patient> FindPatientsByValue(string searchString)
        {
            //using (_patientContext = new PatientContext(_connectionString))
            //{
            //    var patients = _patientContext.Patients.Where(s => s.AccessionNumber.Contains(searchString) ||
            //       s.BirthDate.ToString(CultureInfo.InvariantCulture).Contains(searchString) || s.Contingent.Contains(searchString) ||
            //       s.FirstName.Contains(searchString) || s.InsuranceCompany.Contains(searchString) ||
            //       s.Job.Contains(searchString) || s.LastName.Contains(searchString) || s.Sex.ToString().Contains(searchString)
            //       || s.MedicalRecordLocator.Contains(searchString) || s.MiddleName.Contains(searchString) || 
            //       s.NumberOfPassport.Contains(searchString) || s.NumberPolicy.Contains(searchString) || 
            //       s.PatientAddress.Contains(searchString) || s.PatientCategory.Contains(searchString) || 
            //       s.PatientComments.Contains(searchString) || s.PatientId.Contains(searchString) || 
            //       s.PatientWorkAddres.Contains(searchString) || s.Telephone == searchString).ToList();
            //    return patients;
            //}
            var patients = _patientContext.Patients.Where(s => s.AccessionNumber.Contains(searchString) ||
                                                               s.BirthDate.ToString(CultureInfo.InvariantCulture).Contains(searchString) || s.Contingent.Contains(searchString) ||
                                                               s.FirstName.Contains(searchString) || s.InsuranceCompany.Contains(searchString) ||
                                                               s.Job.Contains(searchString) || s.LastName.Contains(searchString) || s.Sex.ToString().Contains(searchString)
                                                               || s.MedicalRecordLocator.Contains(searchString) || s.MiddleName.Contains(searchString) ||
                                                               s.NumberOfPassport.Contains(searchString) || s.NumberPolicy.Contains(searchString) ||
                                                               s.PatientAddress.Contains(searchString) || s.PatientCategory.Contains(searchString) ||
                                                               s.PatientComments.Contains(searchString) || s.PatientId.Contains(searchString) ||
                                                               s.PatientWorkAddres.Contains(searchString) || s.Telephone == searchString).ToList();
            return patients;
        }

        /// <summary>
        /// Получает список всех пациентов из базы данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> GetAllPatients()
        {
            //using (_patientContext = new PatientContext(_connectionString))
            //{
            //    var patients = _patientContext.Patients.Select(s=>s).ToList();
            //    return patients;
            //}
            return _patientContext.Patients.Select(s => s).ToList();
        }

        /// <summary>
        /// Получает данные о пациенте по идентификатору
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatientData(string patientId)
        {
            //using (_patientContext = new PatientContext(_connectionString))
            //{
            //    var patient = _patientContext.Patients.FirstOrDefault(s => s.PatientId == patientId);
            //    return patient;
            //}
            return _patientContext.Patients.FirstOrDefault(s => s.PatientId == patientId);
        }
    }
}
