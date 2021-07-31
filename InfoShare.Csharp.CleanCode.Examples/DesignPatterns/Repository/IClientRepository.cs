using System;
using System.Collections.Generic;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Repository
{
	public interface IClientRepository
	{
		void Add(Client client);
		void Remove(Guid clientId);
		void Update(Guid clientId, string name, string logo);
		Client GetById(Guid clientId);
		IEnumerable<Client> GetAll();
		IEnumerable<Client> GetByName(string name);
	}
}