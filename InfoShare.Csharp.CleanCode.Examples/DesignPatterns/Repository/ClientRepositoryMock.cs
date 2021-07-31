using System;
using System.Collections.Generic;
using System.Linq;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Repository
{
	public class ClientRepositoryMock : IClientRepository
	{
		private List<Client> _clients = new List<Client>
		{
			new Client("Coma", "cmp-coma.jpg"),
			new Client("Calories", "cmp-calories.jpg"),
			new Client("Fail", "cmp-fail.jpg"),
			new Client("MCDiabetess", "cmp-mcdiabetess.jpg"),
			new Client("Suckers", "cmp-suckers.jpg")
		};

		public void Add(Client client)
		{
			_clients.Add(client);
		}

		public void Remove(Guid clientId)
		{
			var client = _clients.FirstOrDefault(i => i.Id == clientId);
			if (client == null)
			{
				return;
			}

			_clients.Remove(client);
		}

		public void Update(Guid clientId, string name, string logo)
		{
			var client = _clients.FirstOrDefault(i => i.Id == clientId);
			if (client == null)
			{
				return;
			}

			client.Name = name;
			client.Logo = logo;
		}

		public Client GetById(Guid clientId)
		{
			return _clients.FirstOrDefault(i => i.Id == clientId);
		}

		public IEnumerable<Client> GetAll()
		{
			return _clients;
		}

		public IEnumerable<Client> GetByName(string name)
		{
			return _clients.Where(i => i.Name == name);
		}
	}
}