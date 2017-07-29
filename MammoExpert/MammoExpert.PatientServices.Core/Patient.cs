using System;
using System.ComponentModel.DataAnnotations;

namespace MammoExpert.PatientServices.Core
{
    public class Patient
    {
        //Фамилия
        public string LastName { get; set; }
        //Имя
        public string FirstName { get; set; }
        //Отчество
        public string MiddleName { get; set; }
        //Пол
        public Enum Sex { get; set; }
        //Дата рождения
        public DateTime BirthDate { get; set; }
        //Адрес
        public string PatientAddress { get; set; }
        //Дополнительная информация
        public string PatientComments { get; set; }
        //Инвертарный номер
        public string AccessionNumber { get; set; }
        //Идентификатор пациента
        public string PatientId { get; set; }
        //Данные направления на исследование
        public string MedicalRecordLocator { get; set; }
        //Контингенты
        public string Contingent { get; set; }
        //Группа риска
        public string PatientCategory { get; set; }
        //Номер паспорта
        public string NumberOfPassport { get; set; }
        //Место работы
        public string PatientWorkAddres { get; set; }
        //Профессия
        public string Job { get; set; }
        //Номер мед. страховки
        public string NumberPolicy { get; set; }
        //Страховая компания
        public string InsuranceCompany { get; set; }
        //Телефон
        public string Telephone { get; set; }
    }
}
