using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Models;
using System.Windows.Data;
using System.Windows.Media;

namespace VacationPlannerWPFApp.Converter
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == Status.Pending.ToString())
                return new SolidColorBrush(Colors.Red);
            return new SolidColorBrush(Colors.Black);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
