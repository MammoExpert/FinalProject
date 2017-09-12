using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dicom;
using Dicom.Network;
using MammoExpert.PatientServices.Core;

namespace MammoExpert.PatientServices.Worklist
{
    /// <summary>
    /// Предоставляет методы для взаимодействия с данными из Dicom Worklist. Реализует интерфейс <see cref="IPatientRepository"/>.
    /// </summary>
    public class PatientRepositoryDicom : IPatientRepository
    {
       // private readonly WorklistSource _worklistSource;

        private readonly List<Patient> _patients;
        private readonly string _host;
        private readonly int _port;
        private readonly bool _useTls;
        private readonly string _callingAe;
        private readonly string _calledAe;

        public PatientRepositoryDicom(WorklistSource worklistSource)
        {
            this._host = worklistSource.Host;
            this._port = Int32.Parse(worklistSource.Port);
            this._useTls = false;
            this._callingAe = worklistSource.DisplayName;
            this._calledAe = worklistSource.AETitle;
            _patients = new List<Patient>();
        }

        /// <summary>
        /// Добавляет нового пациента в Dicom Worklist
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
        /// Возвращает всех пациентов из Dicom Worklist
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> GetAllPatients()
        {
            Patient patient = new Patient();
            var cfind = DicomCFindRequest.CreateWorklistQuery();
            DicomClient client = new DicomClient();

            cfind.OnResponseReceived = (DicomCFindRequest rq, DicomCFindResponse rp) =>
            {
                for (int i = 0; i < rp.Dataset.Count(); i++)
                {
                    patient = GetPatientInformation(rp);
                    _patients.Add(patient);
                }
            };

            client.AddRequest(cfind);
            client.Send(_host, _port, _useTls, _callingAe, _calledAe);

            return _patients;
        }

        /// <summary>
        /// Возвращает пациента по его идентификатору
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatientData(string patientId)
        {
            //var cfind = DicomCFindRequest.CreatePatientQuery(patientId);
            //cfind.OnResponseReceived = (DicomCFindRequest rq, DicomCFindResponse rp) =>
            //{
            //    _patient = GetPatientInformation(rp);
            //};
            //_client.AddRequest(cfind);
            //_client.Send(_host, _port, _useTls, _callingAe, _calledAe);
            //return _patient;
            return _patients.FirstOrDefault(s => s.PatientId == patientId);
        }

        //получает информацио о патиентах в Dicom Worklist
        private Patient GetPatientInformation(DicomCFindResponse rp)
        {
            string patientName = rp.Dataset.Get<string>(DicomTag.PatientName);
            Patient patient = new Patient
            {
                FirstName = patientName.Substring(patientName.IndexOf('^') + 1, patientName.IndexOf('^') - 2),
                LastName = patientName.Substring(0, patientName.IndexOf('^')),
                MiddleName = patientName.Substring(patientName.LastIndexOf('^') + 1),
                Sex = rp.Dataset.Get<Sex>(DicomTag.PatientSex),
                BirthDate = rp.Dataset.Get<DateTime>(DicomTag.PatientBirthDate),
                PatientAddress = rp.Dataset.Get<string>(DicomTag.PatientAddress),
                PatientComments = rp.Dataset.Get<string>(DicomTag.PatientComments),
                AccessionNumber = rp.Dataset.Get<string>(DicomTag.AccessionNumber),
                PatientId = rp.Dataset.Get<string>(DicomTag.PatientID),
                MedicalRecordLocator = rp.Dataset.Get<string>(DicomTag.MedicalRecordLocator),
                Telephone = rp.Dataset.Get<string>(DicomTag.PatientTelephoneNumbers)
            };
            return patient;
        }
    }
}
