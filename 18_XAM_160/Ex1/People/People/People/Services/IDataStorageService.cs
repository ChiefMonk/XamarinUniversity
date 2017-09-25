namespace People.Services
{
	public interface IDataStorageService
	{
		string GetLocalFilePath(string fileName);

		string GetAppHomePath();

		string GetDatabaseHomePath();
	}
}
