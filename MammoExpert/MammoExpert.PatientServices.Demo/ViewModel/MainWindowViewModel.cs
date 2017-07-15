using MammoExpert.PatientServices.Demo.Helpers;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MammoExpert.PatientServices.Demo.View;
using System.Windows.Controls;
using MammoExpert.PatientServices.UI.Controls.View;

namespace MammoExpert.PatientServices.Demo.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private static List<TabItem> _tabs = new List<TabItem>();

        public List<TabItem> Tabs
        {
            get { return _tabs; }
            set
            {
                if (_tabs != value)
                {
                    _tabs = value;
                    RaisePropertyChanged("Tabs");
                }
            }
        }

        public MainWindowViewModel()
        {
            AddTab("Ручной ввод", new UcManualInput());
        }

        public ICommand OpenAboutProgrammWindow
        {
            get
            {
                return new ActionCommand(() =>
                {
                    AboutProgrammWindow win = new AboutProgrammWindow();
                    win.Show();
                });
            }
        }

        public ICommand OpenSourcesWindow
        {
            get
            {
                return new ActionCommand(() =>
                {
                    SourcesWindow win = new SourcesWindow();
                    win.Show();
                });
            }
        }

        // метод создания вкладок
        public static void AddTab(string header, UIElement element)
        {
            var gr = new Grid()
            {
                ColumnDefinitions = { new ColumnDefinition() },
                RowDefinitions = { new RowDefinition() },
                Children = { element }
            };
            var tab = new TabItem()
            {
                Header = header,
                Content = gr
            };
            _tabs.Add(tab);
        }
    }
}
