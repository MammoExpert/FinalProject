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
    public class PatientRepositoryDicom : IPatientRepository
    {
        private Patient _patient;
        private readonly List<Patient> _patients;
        private readonly DicomClient _client;
        private readonly string _host;
        private readonly int _port;
        private readonly bool _useTls;
        private readonly string _callingAe;
        private readonly string _calledAe;

        public PatientRepositoryDicom(string host, int port, bool useTls, string callingAe, string calledAe)
        {
            this._host = host;
            this._port = port;
            this._useTls = useTls;
            this._callingAe = callingAe;
            this._calledAe = calledAe;
            _client = new DicomClient();
            _patients = new List<Patient>();
        }

        public void AddNewPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> FindPatientsByValue(string searchString)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            var cfind = DicomCFindRequest.CreateWorklistQuery();
            cfind.OnResponseReceived = (DicomCFindRequest rq, DicomCFindResponse rp) =>
            {
                for (int i = 0; i < rp.Dataset.Count(); i++)
                {
                    _patient = GetPatientInformation(rp);
                    _patients.Add(_patient);
                }
            };
            _client.AddRequest(cfind);
            _client.Send(_host, _port, _useTls, _callingAe, _calledAe);
            return _patients;
        }

        public Patient GetPatientData(string patientId)
        {
            var cfind = DicomCFindRequest.CreatePatientQuery(patientId);
            cfind.OnResponseReceived = (DicomCFindRequest rq, DicomCFindResponse rp) =>
            {
                _patient = GetPatientInformation(rp);
            };
            _client.AddRequest(cfind);
            _client.Send(_host, _port, _useTls, _callingAe, _calledAe);
            return _patient;
        }

        private Patient GetPatientInformation(DicomCFindResponse rp)
        {
            Patient patient = new Patient
            {
                FirstName = rp.Dataset.Get<string>(DicomTag.PatientName),
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
