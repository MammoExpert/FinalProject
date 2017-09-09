using System.Collections.Generic;

namespace MammoExpert.PatientServices.Core
{
    /// <summary>
    /// Предоставляет методы для взаимодействия с данными из базы данных.
    /// </summary>
    public interface IPatientRepository
    {
        // Получить список всех пациентов
        IEnumerable<Patient> GetAllPatients();
        //Найти пациентов по значению
        IEnumerable<Patient> FindPatientsByValue(string searchString);
        // Получить все данные пациента по идентификатору
        Patient GetPatientData(string patientId);
        //Добавить нового пациента
        void AddNewPatient(Patient patient);
    }
}
