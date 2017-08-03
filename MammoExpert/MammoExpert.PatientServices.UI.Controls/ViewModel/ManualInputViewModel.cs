using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.UI.Controls.Properties;

namespace MammoExpert.PatientServices.UI.Controls.ViewModel
{
    public class ManualInputViewModel : WorkspaceViewModel
    {
        public ManualInputViewModel()
        {
            base.DisplayName = Resources.ManualInputViewModel_DisplayName;
        }
    }
}
