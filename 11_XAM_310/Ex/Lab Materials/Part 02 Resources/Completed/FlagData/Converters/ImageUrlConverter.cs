using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace FlagData.Converters
{
	public class ImageUrlConverter : IValueConverter
	{
		public Type ResolvingAssemblyType { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return null;

			var imageUrl = (string)value;

			if (string.IsNullOrWhiteSpace(imageUrl))
				return null;

			Type type = typeof(Flag);			
			return ImageSource.FromResource(imageUrl, ResolvingAssemblyType.GetTypeInfo().Assembly);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
