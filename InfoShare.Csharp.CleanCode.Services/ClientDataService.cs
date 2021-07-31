using System.Collections.Generic;

namespace InfoShare.Csharp.CleanCode.Services
{
	public class ClientDataService
	{
		public IEnumerable<Client> GetClientList(string login, string password)
		{
			if (login == "admin" && password == "admin")
			{
				return new[]
				{
					new Client("Coma", "cmp-coma.jpg"),
					new Client("Calories", "cmp-calories.jpg"),
					new Client("Fail", "cmp-fail.jpg"),
					new Client("MCDiabetess", "cmp-mcdiabetess.jpg"),
					new Client("Suckers", "cmp-suckers.jpg")
				};
			}

			return null;
		}
	}

	public class Client
	{
		public Client() { }

		public Client(string name, string logo)
		{
			Name = name;
			Logo = logo;
		}

		public string Name { get; set; }
		public string Logo { get; set; }
	}
}
