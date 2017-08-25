using System;
using System.ComponentModel;
using System.Windows.Input;

namespace MammoExpert.PatientServices.PresenterCore
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Properties

        // Свойство для отображения названия представления в заголовке окна
        public virtual string DisplayName { get; protected set; }

        // отвечает за закрытие представления без использования команды CloseCommand
        public Action CloseAction { get; set; }

        #endregion // Prtiesoper

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

        #region CloseCommand Members

        private ActionCommand _closeCommand;
        public event EventHandler RequestClose;
        
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new ActionCommand(Close);

                return _closeCommand;
            }
        }

        // вызывает событие закрыть представление
        public void Close()
        {
            var handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion
    }
}
