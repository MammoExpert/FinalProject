using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Core
{
    public interface IDataSourcePatient
    {
        //Получить список всех пациентов
        List<Patient> GetAllPatients();
        //Найти пациентов по строке поиска
        List<Patient> FindPatientsOnTheSearchBar(string searchString);
        //Получить все данные пациента по идентификатору
        Patient GetPatientData(string patientId);
    }
}
