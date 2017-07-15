using MammoExpert.PatientServices.Core;
using System.Collections.Generic;

namespace Infrastructure
{
    public interface IDataSourcePatient
    {
        //Проверка подключения
        string CheckConnection();
        //Получить список всех пациентов
        List<Patient> GetAllPatients();
        //Найти пациентов по строке поиска
        List<Patient> FindPatientsOnTheSearchBar(string searchString);
        //Получить все данные пациента по идентификатору
        Patient GetPatientData(string patientId);
        //Добавить нового пациента
        void AddNewPatient(Patient patient);
    }
}
