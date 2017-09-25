using System.Threading.Tasks;

namespace Phoneword.Services
{
	public interface IPhoneDialer
	{
		Task<bool> DialNumberAsync(string number);
	}
}
