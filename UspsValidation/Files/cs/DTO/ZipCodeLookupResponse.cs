using System.Xml.Serialization;
using UspsValidation.Interfaces;

namespace UspsValidation.DTO
{
	[XmlRoot(ElementName = "ZipCodeLookupResponse")]
	public class ZipCodeLookupResponse
	{
		[XmlElement(ElementName = "Address", Type =typeof(ZipCodeAddress))]
		public ZipCodeAddress Address { get; set; }
	}
	public class ZipCodeAddress
	{
		[XmlElement(ElementName = "FirmName", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string FirmName { get; set; }

		[XmlElement(ElementName = "Address1", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string Address1 { get; set; }

		[XmlElement(ElementName = "Address2", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string Address2 { get; set; }

		[XmlElement(ElementName = "City", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string City { get; set; }

		[XmlElement(ElementName = "State", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string State { get; set; }

		[XmlElement(ElementName = "Zip5", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string Zip5 { get; set; }

		[XmlElement(ElementName = "Zip4", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string Zip4 { get; set; }

		[XmlElement(ElementName = "ReturnText", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string ReturnText { get; set; }

		[XmlElement(ElementName = "Error",IsNullable = true, Type = typeof(Error))]
		public Error Error { get; set; }
	}
}
