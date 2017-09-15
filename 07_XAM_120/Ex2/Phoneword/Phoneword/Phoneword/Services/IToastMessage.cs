namespace Phoneword.Services
{
	public interface IToastMessage
	{
		void LongAlert(string message);
		void ShortAlert(string message);
	}
}
