using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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
                foreach (var property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        /// <summary>
        /// Возвращает строку с текстом ошибки или null/>, если ошибок нет
        /// </summary>
        internal string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;
            try
            {
                // получаем имя тестируемого свойства
                var value = this.GetType().GetProperty(propertyName)?.GetValue(this, null) ?? "";

                switch (propertyName)
                {
                    case nameof(FirstName):
                    case nameof(LastName):
                    case nameof(MiddleName):
                        ValidateNameValue(value.ToString());
                        break;
                    case "BirthDate":
                        ValidateBirthDate();
                        break;
                    case "Telephone":
                        ValidateTelephone();
                        break;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        /// <summary>
        /// Проверяет на ошибки валидации свойство <see cref="FirstName"/>, <see cref="LastName"/> и  <see cref="MiddleName"/>
        /// </summary>
        internal void ValidateNameValue(string fieldValue)
        {
            if (string.IsNullOrWhiteSpace(fieldValue) || string.IsNullOrEmpty(fieldValue))
                throw new Exception("Обязательно для заполнения:");
            foreach (var c in fieldValue)
                if (char.IsNumber(c) || char.IsPunctuation(c) || char.IsSymbol(c))
                    throw new Exception("Поле не должно содержать цифр, знаков пунктуации или символов:");
        }

        /// <summary>
        /// Проверяет на ошибки валидации свойство <see cref="BirthDate"/>
        /// </summary>
        internal void ValidateBirthDate()
        {
            if (BirthDate == default(DateTime))
                throw new Exception("Выберите дату:");
        }

        /// <summary>
        /// Проверяет на ошибки валидации свойство <see cref="Telephone"/>
        /// </summary>
        internal void ValidateTelephone()
        {
            if (!string.IsNullOrWhiteSpace(Telephone) || !string.IsNullOrEmpty(Telephone))
            {
                foreach (var c in Telephone)
                {
                    if (char.IsLetter(c))
                        throw new Exception("Поле не должно содержать букв:");
                    if (char.IsPunctuation(c))
                    {
                        if (c != '-' && c != '(' && c != ')')
                            throw new Exception("Поле не должно содержать знаков препинания, кроме '-' и скобок:");
                    }
                    if (char.IsSymbol(c))
                    {
                        if (c != '+')
                            throw new Exception("Поле не должно содержать символы, кроме '+':");
                    }
                }
            }
        }

        #endregion // Validation
    }
}
