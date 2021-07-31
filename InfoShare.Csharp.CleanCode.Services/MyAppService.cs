using System;
using System.Collections.Generic;
using System.Linq;

namespace InfoShare.Csharp.CleanCode.Services
{
	public class MyAppService
	{
		public string HomePageTitle { get; set; }
		public string AboutPageTitle => "Briefly about us!";
		public string ContactPageTitle => "Have a question? Here we are :)";

		public string GetEmail(int type)
		{
			if (type == 1)
			{
				var d = DateTime.Now;

				if (d.DayOfWeek != DayOfWeek.Saturday &&
				    d.DayOfWeek != DayOfWeek.Sunday)
				{
					return Data["weekend-support"].ToString();
				}

				return Data["workingday-support"].ToString();
			}
			else if (type == 2)
			{
				if (Data.ContainsKey("marketing"))
					return Data["marketing"].ToString();
				else
					return Data["workingday-support"].ToString();
			}

			//One should never be here :) - just leave it as is
			return "wedonotcare@myapp.com";
		}

		private Dictionary<string, object> Data => new Dictionary<string, object>
		{
			{"weekend-support", "support-sussan@myapp.com"},
			{"workingday-support", "support-michale@myapp.com"},
			{"marketing", "marketing@myapp.com"},
			{
				"contact-address-PL-GD", new ContactAddress
				{
					AddressLineOne = "aleja Grunwaldzka 472B",
					AddressLineTwo = "80-309 Gdańsk",
					AddressLineThree = "tel: 730 833 804"
				}
			},
			{
				"contact-address-PL-WAW", new ContactAddress
				{
					AddressLineOne = "Puławska 2",
					AddressLineTwo = "02-515 Warszawa",
					AddressLineThree = "tel: 730 833 804"
				}
			},

		};

		public string GetContactAddressForGd()
		{
			if (Data.ContainsKey("contact-address-PL-GD"))
			{
				var t = Data["contact-address-PL-GD"] as ContactAddress;
				return t.AddressLineOne + "<br>" + t.AddressLineTwo + "<br>" + t.AddressLineThree;
			}

			return string.Empty;
		}

		public string GetContactAddressForWaw(string suffix)
		{
			if (Data.ContainsKey("contact-address-PL-WAW"))
			{
				var t = Data["contact-address-PL-WAW"] as ContactAddress;
				return t.AddressLineOne + "<br>" + t.AddressLineTwo + "<br>" + t.AddressLineThree;
			}

			return string.Empty;
		}

		public string GetAbout()
		{
			var service = new ClientDataService();
			var clients = service.GetClientList("admin", "admin");

			return
				$@"We are software house. We will do whatever you need.
				It will be chaep, fast and with high quality ;).
				We cooperate with such gigants as: {string.Join(", ", clients.Select(i => i.Name))}";
		}

		public IEnumerable<Client> GetOurClients()
		{
			var service = new ClientDataService();
			return service.GetClientList("admin", "admin");
		}
	}

	public class ContactAddress
	{
		public string AddressLineOne { get; set; }
		public string AddressLineTwo { get; set; }
		public string AddressLineThree { get; set; }
	}
}
