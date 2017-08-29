using System;
using MammoExpert.PatientServices.Core;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace MammoExpert.PatientServices.DB
{
    public class PacientRepositoryEf : IPatientRepository
    {
        #region Поля
        private readonly PatientContext _patientContext;
        private bool _disposed = false;
        #endregion
        #region Конструкторы
        public PacientRepositoryEf()
        {
            _patientContext = new PatientContext();
            _patientContext.Database.Connection.Open();
        }
        public PacientRepositoryEf(string connectionString)
        {
            _patientContext = new PatientContext(connectionString);
        }
        #endregion
        #region Методы
        /// <summary>
        /// Добавляет нового пациента в базу данных
        /// </summary>
        /// <param name="patient"></param>
        public void AddNewPatient(Patient patient)
        {
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
            var patients = _patientContext.Patients.Where(s => s.AccessionNumber.Contains(searchString) ||
                                                               s.FirstName.Contains(searchString) || 
                                                               s.InsuranceCompany.Contains(searchString) ||
                                                               s.LastName.Contains(searchString) || 
                                                               s.MiddleName.Contains(searchString) ||
                                                               s.NumberOfPassport.Contains(searchString) || 
                                                               s.NumberPolicy.Contains(searchString) ||
                                                               s.PatientAddress.Contains(searchString)||
                                                               s.PatientId.Contains(searchString));
            return patients;
        }

        /// <summary>
        /// Получает список всех пациентов из базы данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientContext.Patients.Select(s => s).ToList();
        }

        /// <summary>
        /// Получает данные о пациенте по идентификатору
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatientData(string patientId)
        {
            return _patientContext.Patients.FirstOrDefault(s => s.PatientId == patientId);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _patientContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
