using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Core
{
    public enum Sex {Male, Female};
    public class Patient
    {
        //Фамилия
        [Required]
        [StringLength(64)] 
        public string LastName { get; set; }
        //Имя
        [Required]
        [StringLength(64)] 
        public string FirstName { get; set; }
        //Отчество
        [Required]
        [StringLength(64)]
        public string MiddleName { get; set; }
        //Пол
        public Enum Sex { get; set; }
        //Дата рождения
        public DateTime BirthDate { get; set; }
        //Адрес
        [Required]
        [StringLength(255)]
        public string PatientAddress { get; set; }
        //Дополнительная информация
        [Required]
        [StringLength(2000)]
        public string PatientComments { get; set; }
        //Инвертарный номер
        [Required]
        [StringLength(64)]
        public string AccessionNumber { get; set; }
        //Идентификатор пациента
        [Required]
        [StringLength(64)]
        public string PatientId { get; set; }
        //Данные направления на исследование
        [Required]
        [StringLength(64)]
        public string MedicalRecordLocator { get; set; }
        //Контингенты
        [Required]
        [StringLength(64)]
        public string Contingent { get; set; }
        //Группа риска
        [Required]
        [StringLength(64)]
        public string PatientCategory { get; set; }
        //Номер паспорта
        [Required]
        [StringLength(64)]
        public string NumberOfPassport { get; set; }
        //Место работы
        [Required]
        [StringLength(255)]
        public string PatientWorkAddres { get; set; }
        //Профессия
        [Required]
        [StringLength(64)]
        public string Job { get; set; }
        //Номер мед. страховки
        [Required]
        [StringLength(64)]
        public string NumberPolicy { get; set; }
        //Страховая компания
        [Required]
        [StringLength(255)]
        public string InsuranceCompany { get; set; }
        //Телефон
        [Required]
        [StringLength(64)]
        public string Telephone { get; set; }
 
    }
}
