using System.IO;

using Regulus.Framework;
using Regulus.Remoting;
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

			var core = _LoadGame("Game.dll");

			var client = new Client<IUser>(view, input);

			client.ModeSelectorEvent += new ModeCreator(core , client.Command ).Select;
			
            

            var updater = new Updater();
			updater.Add(client);
			updater.Add(core);

			while(client.Enable)
			{
				input.Update();
				updater.Working();
			}

			updater.Shutdown();
		}

		private static ICore _LoadGame(string path)
		{
            var stream = File.ReadAllBytes(path);
			return Loader.Load(stream, "Game.Center");
		}
	}
}
