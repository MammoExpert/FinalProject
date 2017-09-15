﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MammoExpert.PatientServices.Sources;
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

    /// <summary>
    /// Преобразует объект типа <see cref="SourceType"/> в соответствующее ему представление
    /// </summary>
    public class ContentConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            SourceType option;
            Enum.TryParse(values[0].ToString(), out option);
            switch (option)
            {
                case SourceType.DataBase:
                    return new UcDBConnectionConfiguration();
                case SourceType.Worklist:
                    return new UcWorklistConnectionConfiguration();
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
