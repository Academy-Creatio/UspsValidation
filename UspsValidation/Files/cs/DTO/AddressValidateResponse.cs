using System.Xml.Serialization;

namespace UspsValidation.DTO
{
	[XmlRoot(ElementName ="AddressValidateResponse")]
	public class AddressValidateResponse
	{
		[XmlElement(ElementName = "Address", Type =typeof(Address))]
		public Address Address { get; set; }
	}

	public class Address : BaseAddress
	{

		[XmlElement(ElementName = "DeliveryPoint", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string DeliveryPoint { get; set; }

		[XmlElement(ElementName = "CarrierRoute", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string CarrierRoute { get; set; }

		[XmlElement(ElementName = "Footnotes", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string Footnotes { get; set; }

		[XmlElement(ElementName = "DPVConfirmation", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string DPVConfirmation { get; set; }

		[XmlElement(ElementName = "DPVCMRA", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string DPVCMRA { get; set; }

		[XmlElement(ElementName = "DPVFootnotes", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string DPVFootnotes { get; set; }

		[XmlElement(ElementName = "Business", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string Business { get; set; }

		[XmlElement(ElementName = "CentralDeliveryPoint", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string CentralDeliveryPoint { get; set; }

		[XmlElement(ElementName = "Vacant", DataType = "string", IsNullable = true, Type = typeof(string))]
		public string Vacant { get; set; }
	}
}
