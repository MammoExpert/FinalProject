using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.PresenterCore
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public virtual string DisplayName { get; protected set; }
        public Action CloseAction { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(p);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members
    }
}
