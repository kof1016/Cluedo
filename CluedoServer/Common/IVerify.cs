using Regulus.Remoting;

namespace Common
{
	public interface IVerify
	{
		Value<bool> Login(string id, string password);
	}
}