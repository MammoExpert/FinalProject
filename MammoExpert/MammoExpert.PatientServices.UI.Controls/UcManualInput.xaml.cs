using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MammoExpert.PatientServices.UI.Controls
{
    /// <summary>
    /// Логика взаимодействия для UcManualInput.xaml
    /// </summary>
    public partial class UcManualInput : UserControl
    {
        public UcManualInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события для отмены введенных значений
        /// </summary>
        public void BtnClearAll_Click(object sender, RoutedEventArgs e)
        {
            LoopVisualTree(this);
        }

        /// <summary>
        /// Обнуляет значения всех TextBox-ов
        /// </summary>
        private void LoopVisualTree(DependencyObject obj)
        {
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {

                if (obj is TextBox)
                {
                    ((TextBox)obj).Text = null;
                }

                LoopVisualTree(VisualTreeHelper.GetChild(obj, i));
            }

        }
    }

    /// <summary>
    /// Конвертер для Enum-значений
    /// </summary>
    public class EnumBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var parameterString = parameter as string;
            if (parameterString == null)
                return DependencyProperty.UnsetValue;

            if (Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            var parameterValue = Enum.Parse(value.GetType(), parameterString);

            return parameterValue.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var parameterString = parameter as string;
            if (parameterString == null)
                return DependencyProperty.UnsetValue;

            return Enum.Parse(targetType, parameterString);
        }
    }
}
