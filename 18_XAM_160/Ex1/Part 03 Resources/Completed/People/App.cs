using Xamarin.Forms;

namespace People
{
	public class App : Application
	{
		public static PersonRepository PersonRepo { get; private set; }

		public App(string dbPath)
		{
			//set database path first, then retrieve main page
			PersonRepo = new PersonRepository(dbPath);

			this.MainPage = new MainPage();
		}
	}
}