using System.Runtime.Serialization;
using Terrasoft.Core.Factories;
using UspsValidation.Interfaces;

namespace UspsValidation.DataContract
{
	[DataContract]
	[DefaultBinding(typeof(IAddressValidateResponse))]
	public class AddressValidateResponse : UspsAddress
	{
		[DataMember(Name = "deliveryPoint", IsRequired = false, EmitDefaultValue =false, Order = 20)]
		public string DeliveryPoint { get; set; }

		[DataMember(Name = "carrierRoute", IsRequired = false, EmitDefaultValue = false, Order = 21)]
		public string CarrierRoute { get; set; }

		[DataMember(Name = "footnotes", IsRequired = false, EmitDefaultValue = false, Order = 22)]
		public string Footnotes { get; set; }

		[DataMember(Name = "dpvConfirmation", IsRequired = false, EmitDefaultValue = false, Order = 23)]
		public string DPVConfirmation { get; set; }

		[DataMember(Name = "dpvcmra", IsRequired = false, Order = 24)]
		public bool DPVCMRA { get; set; }

		[DataMember(Name = "dpvFootnotes", IsRequired = false, EmitDefaultValue = false, Order = 25)]
		public string DPVFootnotes { get; set; }

		[DataMember(Name = "business", IsRequired = false, Order = 26)]
		public bool Business { get; set; }

		[DataMember(Name = "centralDeliveryPoint", IsRequired = false, Order = 27)]
		public bool CentralDeliveryPoint { get; set; }

		[DataMember(Name = "vacant", IsRequired = false, Order = 28)]
		public bool Vacant { get; set; }
	}
}
