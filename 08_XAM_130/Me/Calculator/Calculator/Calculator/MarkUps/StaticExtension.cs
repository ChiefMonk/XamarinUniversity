using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.MarkUps
{
	[ContentProperty("Member")]
	public class StaticExtension : IMarkupExtension
	{
		public string Member { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			throw new NotImplementedException();
		}
	}
}
