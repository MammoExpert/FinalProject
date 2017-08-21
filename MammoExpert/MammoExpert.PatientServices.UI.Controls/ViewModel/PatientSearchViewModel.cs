using MammoExpert.PatientServices.PresenterCore;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.UI.Controls.ViewModel
{
    public class PatientSearchViewModel : ViewModelBase
    {
        public PatientSearchViewModel(Source source)
        {
            if (source != null) base.DisplayName = source.Name;
        }
    }
}
