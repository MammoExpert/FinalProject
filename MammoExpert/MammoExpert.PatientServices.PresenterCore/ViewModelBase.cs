using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using MammoExpert.PatientServices.PresenterCore.Annotations;

namespace MammoExpert.PatientServices.PresenterCore
{
    /// <summary>
    /// Базовый класс для моделей представления
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// Свойство для отображения названия представления
        /// </summary>
        public virtual string DisplayName { get; protected set; }

        /// <summary>
        /// Отвечает за закрытие представления
        /// </summary>
        public Action CloseAction { get; set; }

        #endregion // Prtiesoper

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string p)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(p);
                handler(this, e);
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

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

        public void Close()
        {
            var handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion
      
    }
}
