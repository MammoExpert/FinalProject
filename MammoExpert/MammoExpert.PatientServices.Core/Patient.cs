using System;
using System.ComponentModel.DataAnnotations;

namespace MammoExpert.PatientServices.Core
{
    public class Patient
    {
        /// <summary>
        /// Получает или задает значение фамилии пациента
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Получает или задает значение имени пациента
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Получает или задает значение отчества пациента
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Получает или задает значение пола пациента
        /// </summary>
        public Sex Sex { get; set; }
        /// <summary>
        /// Получает или задает значение даты рождения пациента
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Получает или задает значение адреса проживания пациента
        /// </summary>
        public string PatientAddress { get; set; }
        /// <summary>
        /// Получает или задает значение дополнительной информации о пациенте
        /// </summary>
        public string PatientComments { get; set; }
        /// <summary>
        /// Получает или задает значение инвертарного номера
        /// </summary>
        public string AccessionNumber { get; set; }
        /// <summary>
        /// Получает или задает значение идентификатора пациента
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// Получает или задает значение данных направления на исследование
        /// </summary>
        public string MedicalRecordLocator { get; set; }
        /// <summary>
        /// Получает или задает значение контингентам
        /// </summary>
        public string Contingent { get; set; }
        /// <summary>
        /// Получает или задает значение группе риска пациента
        /// </summary>
        public string PatientCategory { get; set; }
        /// <summary>
        /// Получает или задает значение номеру паспорта пациента
        /// </summary>
        public string NumberOfPassport { get; set; }
        /// <summary>
        /// Получает или задает значение месту работы пациента
        /// </summary>
        public string PatientWorkAddress { get; set; }
        /// <summary>
        /// Получает или задает значение профессии пациента
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// Получает или задает значение номеру медицинской страховки пациента
        /// </summary>
        public string NumberPolicy { get; set; }
        /// <summary>
        /// Получает или задает значение страховой компании пациента
        /// </summary>
        public string InsuranceCompany { get; set; }
        /// <summary>
        /// Получает или задает значение номеру телефона пациента
        /// </summary>
        public string Telephone { get; set; }
    }
}
