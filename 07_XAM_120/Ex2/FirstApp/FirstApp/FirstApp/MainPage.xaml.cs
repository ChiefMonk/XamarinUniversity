using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			Task.Run(async () => await SaveProperties().ConfigureAwait(false));
		}

		private async Task SaveProperties()
		{
			Application.Current.Properties["username"] = "Chipo";
			await Application.Current.SavePropertiesAsync();
		}
	}
}
