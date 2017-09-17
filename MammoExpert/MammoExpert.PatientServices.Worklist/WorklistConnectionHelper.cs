using Dicom.Network;
using MammoExpert.PatientServices.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Worklist
{
    /// <summary>
    /// Предоставляет метод взаимодействия с подключение к Dicom серверу.
    /// </summary>
    public class WorklistConnectionHelper
    {
        /// <summary>
        /// Проверяет подключени к Dicom серверу
        /// </summary>
        /// <param name="worklistSource"></param>
        /// <returns></returns>
        public static bool CheckConnection(WorklistSource worklistSource)
        {
            try
            {
                DicomClient client = new DicomClient();
                client.AddRequest(new DicomCEchoRequest());
                client.Send(worklistSource.Host, Int32.Parse(worklistSource.Port), 
                            false, worklistSource.DisplayName, worklistSource.AETitle);
                Messenger.ShowConnectionWorklistSuccess("Соединение с Dicom сервером установленно!");
                return true;
            }
            catch(Exception exc)
            {
                Messenger.ShowConnectionWorklistErrorMessage(exc);
                return false;
            }
        }
    }
}
