using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Labo5.Converter
{
    public class WeatherDescriptionToImageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var forcast = (string)value;
            if (forcast.Contains("nuageux"))
                return new BitmapImage(new Uri("ms-appx:/Images/pluie.png"));
            else
                return new BitmapImage(new Uri("ms-appx:/Images/soleil.jpg"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}
