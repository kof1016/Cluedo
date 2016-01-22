using Regulus.Remoting;

namespace Common.GPI
{
	public interface IVerify
	{
		Value<bool> Login(string id, string password);
	}
}