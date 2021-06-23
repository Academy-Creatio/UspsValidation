using System.Xml.Linq;
using Terrasoft.Core;
using Terrasoft.Core.Factories;
using UspsValidation.Interfaces;

namespace UspsValidation
{
	[DefaultBinding(typeof(IAddressValidateRequest))]
	public class AddressValidateRequest : IAddressValidateRequest
	{
		public AddressValidateRequest(UserConnection userConnection)
		{
			if (!Terrasoft.Core.Configuration.SysSettings.TryGetValue(userConnection, "UspsUserName", out object uspsUserName))
			{
				return;
			}
			Username = (string)uspsUserName;
		}

		public int Revision { get; set; } = 1;
		public string FirmName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip5 { get; set; }
		public string Zip4 { get; set; }
		public string Username { get; set; }
		public string XML
		{
			get
			{
				XElement root = new XElement("AddressValidateRequest",
					new XAttribute("USERID", Username),
					new XElement("Revision", Revision),
					new XElement("Address",
						new XElement("FirmName", FirmName),
						new XElement("Address1", Address1),
						new XElement("Address2", Address2),
						new XElement("City", City),
						new XElement("State", State),
						new XElement("Zip5", Zip5),
						new XElement("Zip4", Zip4)
					)
				);
				return root.ToString();
			}
		}
	}

}