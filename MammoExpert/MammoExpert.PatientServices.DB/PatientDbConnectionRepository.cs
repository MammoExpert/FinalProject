using MammoExpert.PatientServices.Core;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.DB
{
    /// <summary>
    /// Предоставляет методы для взаимодействия с данными из базы данных. Наследуется от <see cref="IPatientRepository"/>
    /// </summary>
    public class PatientDbConnectionRepository : IPatientRepository
    {
        private readonly DbSource _dbSource;
        private readonly DbConnectionConfiguration _configuration;
        private readonly List<Patient> _patients;
        public PatientDbConnectionRepository(DbConnectionConfiguration configuration)
        {
            _dbSource = configuration.DbSource;
            _configuration = configuration;
            _patients = new List<Patient>();
        }

        /// <summary>
        /// Добавляет нового пациента в базу данных
        /// </summary>
        /// <param name="patient"></param>
        public void AddNewPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает пациента на основании полученного значения
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public IEnumerable<Patient> FindPatientsByValue(string searchString)
        {
            var patients = _patients.Where(s => s.AccessionNumber.Contains(searchString) ||
                           s.FirstName.Contains(searchString) ||
                           s.InsuranceCompany.Contains(searchString) ||
                           s.LastName.Contains(searchString) ||
                           s.MiddleName.Contains(searchString) ||
                           s.NumberOfPassport.Contains(searchString) ||
                           s.NumberPolicy.Contains(searchString) ||
                           s.PatientAddress.Contains(searchString) ||
                           s.PatientId.Contains(searchString));
            return patients;
        }

        /// <summary>
        /// Возвращает всех пациентов из базы данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> GetAllPatients()
        {
            var descriptionProvider = _dbSource.Provider;
            var provider = _configuration.GetProvider(descriptionProvider);
            var dbf = DbProviderFactories.GetFactory(provider);
            using (var conn = dbf.CreateConnection())
            {
                conn.ConnectionString = _configuration.GetConnectionString(descriptionProvider);
                conn.Open();

                var dbcmd = conn.CreateCommand();
                dbcmd.CommandType = System.Data.CommandType.Text;
                dbcmd.CommandText = "SELECT * FROM Patients";
                var dbrdr = dbcmd.ExecuteReader();
                while (dbrdr.Read() != false)
                {
                    var patient = new Patient();
                    patient.LastName = dbrdr["LastName"].ToString();
                    patient.FirstName = dbrdr["FirstName"].ToString();
                    patient.MiddleName = dbrdr["MiddleName"].ToString();
                    patient.Sex = ConvertorToEnum.GetEnum(dbrdr["Sex"].ToString());
                    patient.BirthDate = (DateTime)dbrdr["BirthDate"];
                    patient.PatientAddress = dbrdr["PatientAddress"].ToString();
                    patient.PatientComments = dbrdr["PatientComments"].ToString();
                    patient.AccessionNumber = dbrdr["AccessionNumber"].ToString();
                    patient.PatientId = dbrdr["PatientId"].ToString();
                    patient.MedicalRecordLocator = dbrdr["MedicalRecordLocator"].ToString();
                    patient.Contingent = dbrdr["Contingent"].ToString();
                    patient.PatientCategory = dbrdr["PatientCategory"].ToString();
                    patient.NumberOfPassport = dbrdr["NumberOfPassport"].ToString();
                    patient.PatientWorkAddress = dbrdr["PatientWorkAddress"].ToString();
                    patient.Job = dbrdr["Job"].ToString();
                    patient.NumberPolicy = dbrdr["NumberPolicy"].ToString();
                    patient.InsuranceCompany = dbrdr["InsuranceCompany"].ToString();
                    patient.Telephone = dbrdr["Telephone"].ToString();
                    _patients.Add(patient);
                }
            }
            return _patients;
        }

        /// <summary>
        /// Возвращает пациента по его идентификатору
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatientData(string patientId)
        {
            return _patients.FirstOrDefault(s => s.PatientId == patientId);
        }
    }
}
