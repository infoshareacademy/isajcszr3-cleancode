using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Repository
{
	public class ClientRepository : IClientRepository
	{
		private readonly string _connectionString;

		public ClientRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public void Add(Client client)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Insert(client);
		}

		public void Remove(Guid clientId)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Delete(new Client(clientId));
		}

		public void Update(Guid clientId, string name, string logo)
		{
			using var connection = new SqlConnection(_connectionString);
			connection.Delete(new Client(clientId)
			{
				Name = name,
				Logo = logo
			});
		}

		public Client GetById(Guid clientId)
		{
			using var connection = new SqlConnection(_connectionString);
			return connection.Get<Client>(clientId);
		}

		public IEnumerable<Client> GetAll()
		{
			using var connection = new SqlConnection(_connectionString);
			return connection.GetAll<Client>();
		}

		public IEnumerable<Client> GetByName(string name)
		{
			using var connection = new SqlConnection(_connectionString);
			return connection.GetAll<Client>().Where(i => i.Name == name);
		}
	}
}