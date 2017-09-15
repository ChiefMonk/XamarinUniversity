using People.Data;
using People.Services;
using Xamarin.Forms;

namespace People
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			InitialiseRepository();

			MainPage = new People.MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		#region Repo

		public static PersonRepository PersonRepo => PersonRepository.Instance;


		private void InitialiseRepository()
		{
			var dataStorage = DependencyService.Get<IDataStorageService>();
			var dbPath = dataStorage.GetLocalFilePath("person.db3");
			PersonRepository.Initialize(dbPath);
		}


		#endregion
	}
}
