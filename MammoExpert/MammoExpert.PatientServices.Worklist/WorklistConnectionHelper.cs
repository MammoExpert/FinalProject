using Dicom.Network;
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
        public bool CheckConnection(WorklistSource worklistSource)
        {
            DicomClient client = new DicomClient();
            client.AddRequest(new DicomCEchoRequest());
            client.Send(worklistSource.Host, Int32.Parse(worklistSource.Port),
                        false, worklistSource.DisplayName, worklistSource.AETitle);

            if (client.IsSendRequired) return true;

            return false;
        }
    }
}
