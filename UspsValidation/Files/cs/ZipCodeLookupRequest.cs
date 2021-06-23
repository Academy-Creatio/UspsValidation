using System.Xml.Linq;
using Terrasoft.Core;
using Terrasoft.Core.Factories;
using UspsValidation.Interfaces;

namespace UspsValidation
{
	[DefaultBinding(typeof(IZipCodeLookupRequest))]
	public class ZipCodeLookupRequest : IZipCodeLookupRequest
	{
		public ZipCodeLookupRequest(UserConnection userConnection)
		{
			if(!Terrasoft.Core.Configuration.SysSettings.TryGetValue(userConnection, "UspsUserName", out object uspsUserName))
			{
				return;
			}
			Username = (string)uspsUserName;
		}
		public string FirmName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Username { get; set; }
		public string XML
		{
			get
			{
				XElement root = new XElement("ZipCodeLookupRequest",
					new XAttribute("USERID", Username),
					new XElement("Address",
						new XElement("FirmName", FirmName),
						new XElement("Address1", Address1),
						new XElement("Address2", Address2),
						new XElement("City", City),
						new XElement("State", State)
					)
				);
				return root.ToString();
			}
		}
	}

}