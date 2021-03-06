﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace PelisApp.View
{
    public class NegatedBooleanToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool esVisible = (bool)value;

            return !esVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
