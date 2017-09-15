using System;
using System.ComponentModel;
using System.Diagnostics;

namespace MammoExpert.PatientServices.Core
{
    /// <summary>
    /// Представляет тип данных, моделирующий пациента.
    /// </summary>
    public class Patient : IDataErrorInfo
    {
        #region Properties

        /// <summary>
        /// Получает или задает значение фамилии пациента.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Получает или задает значение имени пациента.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Получает или задает значение отчества пациента.
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Получает или задает значение пола пациента.
        /// </summary>
        public Sex Sex { get; set; }
        /// <summary>
        /// Получает или задает значение даты рождения пациента.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Получает или задает значение адреса проживания пациента.
        /// </summary>
        public string PatientAddress { get; set; }
        /// <summary>
        /// Получает или задает значение дополнительной информации о пациенте.
        /// </summary>
        public string PatientComments { get; set; }
        /// <summary>
        /// Получает или задает значение инвертарного номера.
        /// </summary>
        public string AccessionNumber { get; set; }
        /// <summary>
        /// Получает или задает значение идентификатора пациента.
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// Получает или задает значение данных направления на исследование.
        /// </summary>
        public string MedicalRecordLocator { get; set; }
        /// <summary>
        /// Получает или задает значение контингентам.
        /// </summary>
        public string Contingent { get; set; }
        /// <summary>
        /// Получает или задает значение группе риска пациента.
        /// </summary>
        public string PatientCategory { get; set; }
        /// <summary>
        /// Получает или задает значение номеру паспорта пациента.
        /// </summary>
        public string NumberOfPassport { get; set; }
        /// <summary>
        /// Получает или задает значение месту работы пациента.
        /// </summary>
        public string PatientWorkAddress { get; set; }
        /// <summary>
        /// Получает или задает значение профессии пациента.
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// Получает или задает значение номеру медицинской страховки пациента.
        /// </summary>
        public string NumberPolicy { get; set; }
        /// <summary>
        /// Получает или задает значение страховой компании пациента.
        /// </summary>
        public string InsuranceCompany { get; set; }
        /// <summary>
        /// Получает или задает значение номеру телефона пациента.
        /// </summary>
        public string Telephone { get; set; }

        #endregion // Properties

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return GetValidationError(propertyName); }
        }

        #endregion // IDataErrorInfo Members

        #region Validation

        /// <summary>
        /// Содержит массив валидируемых свойств
        /// </summary>
        private static readonly string[] ValidatedProperties =
        {
            "FirstName",
            "LastName",
            "MiddleName",
            "BirthDate",
            "Telephone"
        };

        /// <summary>
        /// Вернет true если у объекта нет ошибок валидации
        /// </summary>
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        /// <summary>
        /// Возвращает строку с текстом ошибки или null/>, если ошибок нет
        /// </summary>
        private string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "FirstName":
                    error = ValidateFirstName();
                    break;
                case "LastName":
                    error = ValidateLastName();
                    break;
                case "MiddleName":
                    error = ValidateMiddleName();
                    break;
                case "BirthDate":
                    error = ValidateBirthDate();
                    break;
                case "Telephone":
                    error = ValidateTelephone();
                    break;
                default:
                    Debug.Fail("Неожиданное имя для свойства объекта типа Patient: " + propertyName);
                    break;
            }

            return error;
        }

        /// <summary>
        /// Проверяет на ошибки валидации свойство <see cref="FirstName"/>
        /// </summary>
        private string ValidateFirstName()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrEmpty(FirstName))
                return "Обязательно для заполнения:";
            foreach (var c in FirstName)
                if (char.IsNumber(c) || char.IsPunctuation(c) || char.IsSymbol(c))
                    return "Поле не должно содержать цифр, знаков пунктуации или символов:";

            return null;
        }

        /// <summary>
        /// Проверяет на ошибки валидации свойство <see cref="LastName"/>
        /// </summary>
        private string ValidateLastName()
        {
            if (string.IsNullOrWhiteSpace(LastName) || string.IsNullOrEmpty(LastName))
                return "Обязательно для заполнения:";
            foreach (var c in LastName)
                if (char.IsNumber(c) || char.IsPunctuation(c) || char.IsSymbol(c))
                    return "Поле не должно содержать цифр, знаков пунктуации или символов:";

            return null;
        }

        /// <summary>
        /// Проверяет на ошибки валидации свойство <see cref="MiddleName"/>
        /// </summary>
        private string ValidateMiddleName()
        {
            if (string.IsNullOrWhiteSpace(MiddleName) || string.IsNullOrEmpty(MiddleName))
                return "Обязательно для заполнения:";
            foreach (var c in MiddleName)
                if (char.IsNumber(c) || char.IsPunctuation(c) || char.IsSymbol(c))
                    return "Поле не должно содержать цифр, знаков пунктуации или символов:";


            return null;
        }

        /// <summary>
        /// Проверяет на ошибки валидации свойство <see cref="BirthDate"/>
        /// </summary>
        private string ValidateBirthDate()
        {
            if (BirthDate == default(DateTime))
                return "Выберите дату:";

            return null;
        }

        /// <summary>
        /// Проверяет на ошибки валидации свойство <see cref="Telephone"/>
        /// </summary>
        private string ValidateTelephone()
        {
            if (!string.IsNullOrWhiteSpace(Telephone) || !string.IsNullOrEmpty(Telephone))
            {
                foreach (var c in Telephone)
                {
                    if (char.IsLetter(c))
                        return "Поле не должно содержать букв:";
                    if (char.IsPunctuation(c))
                    {
                        if (c != '-' && c != '(' && c != ')')
                            return "Поле не должно содержать знаков препинания, кроме '-' и скобок:";
                    }
                    if (char.IsSymbol(c))
                    {
                        if (c != '+')
                            return "Поле не должно содержать символы, кроме '+':";
                    }
                }
            }
            return null;
        }

        #endregion // Validation
    }
}
