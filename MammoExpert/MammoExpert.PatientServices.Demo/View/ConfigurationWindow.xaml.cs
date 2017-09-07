using System;
using System.Windows;
using System.Windows.Data;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.Demo.ViewModel;
using MammoExpert.PatientServices.UI.Controls;

namespace MammoExpert.PatientServices.Demo.View
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public ConfigurationWindow()
        {
            InitializeComponent();
        }
    }

    public class ContentConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SourceType option1;
            Enum.TryParse(values[0].ToString(), out option1);
            switch (option1)
            {
                case SourceType.DataBase:
                    return new UcDBConnectionConfiguration();
                case SourceType.Worklist:
                    return new UcWorklistConnectionConfiguration();
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
