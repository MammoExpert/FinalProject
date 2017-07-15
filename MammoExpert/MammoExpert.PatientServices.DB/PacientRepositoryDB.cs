using Infrastructure;
using MammoExpert.Infrastructure;
using MammoExpert.PatientServices.Core;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MammoExpert.PatientServices.DB
{
    public class PacientRepositoryDB : IDataSourcePatient
    {
        private PatientContext _patientContext;
        private string _connectionString;
        public PacientRepositoryDB(string dbNameOrConnection)
        {
            _connectionString = dbNameOrConnection;
        }

        //Проверка подключения
        public string CheckConnection()
        {
            string state;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                state = connection.State.ToString() + "\n"
                        + connection.ConnectionTimeout.ToString();
                return state;
            }
        }

        //Добавление нового пациента
        public void AddNewPatient(Patient patient)
        {
            using (_patientContext = new PatientContext(_connectionString))
            {
                _patientContext.Patients.Add(patient);
            }
        }

        //Получение пациентов по строке поиска
        public List<Patient> FindPatientsOnTheSearchBar(string searchString)
        {
            using (_patientContext = new PatientContext(_connectionString))
            {
                var patients = _patientContext.Patients.Where(s => s.AccessionNumber.Contains(searchString) ||
                   s.BirthDate.ToString().Contains(searchString) || s.Contingent.Contains(searchString) ||
                   s.FirstName.Contains(searchString) || s.InsuranceCompany.Contains(searchString) ||
                   s.Job.Contains(searchString) || s.LastName.Contains(searchString) || s.Sex.ToString().Contains(searchString)
                   || s.MedicalRecordLocator.Contains(searchString) || s.MiddleName.Contains(searchString) || 
                   s.NumberOfPassport.Contains(searchString) || s.NumberPolicy.Contains(searchString) || 
                   s.PatientAddress.Contains(searchString) || s.PatientCategory.Contains(searchString) || 
                   s.PatientComments.Contains(searchString) || s.PatientId.Contains(searchString) || 
                   s.PatientWorkAddres.Contains(searchString) || s.Telephone == searchString).ToList();
                return patients;
            }     
        }

        //Получение всех пациентов из БД
        public List<Patient> GetAllPatients()
        {
            using (_patientContext = new PatientContext(_connectionString))
            {
                var patients = _patientContext.Patients.Select(s=>s).ToList();
                return patients;
            }
        }

        //Получение пациента по идентификатору
        public Patient GetPatientData(string patientId)
        {
            using (_patientContext = new PatientContext(_connectionString))
            {
                var patient = _patientContext.Patients.Where(s => s.PatientId == patientId).FirstOrDefault();
                return patient;
            }   
        }
    }
}
