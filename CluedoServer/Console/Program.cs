using Regulus.Framework;
using Regulus.Utility;

using User;

namespace Console
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var view = new ConsoleViewer();
			var input = new ConsoleInput(view);

			// var core = _LoadGame("Game.dll");
			var client = new Client<IUser>(view, input);
			client.ModeSelectorEvent += new ModeCreator().Select;

			var updater = new Updater();
			updater.Add(client);

			while(client.Enable)
			{
				input.Update();
				updater.Working();
			}

			updater.Shutdown();
		}
	}
}
