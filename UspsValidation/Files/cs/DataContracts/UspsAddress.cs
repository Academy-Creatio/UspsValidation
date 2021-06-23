using System.Runtime.Serialization;
using Terrasoft.Core.Factories;
using UspsValidation.Interfaces;

namespace UspsValidation.DataContract
{

	[DataContract]
	[DefaultBinding(typeof(IUspsAddress))]
	public class UspsAddress
	{
		[DataMember(Name= "firmName", IsRequired = false, EmitDefaultValue = false, Order =0)]
		public string FirmName { get; set; }

		[DataMember(Name = "address1", IsRequired = false, EmitDefaultValue = false, Order = 1)]
		public string Address1 { get; set; }

		[DataMember(Name = "address2", IsRequired = false, EmitDefaultValue = false, Order = 2)]
		public string Address2 { get; set; }

		[DataMember(Name = "city", IsRequired = false, EmitDefaultValue = false, Order = 3)]
		public string City { get; set; }

		[DataMember(Name = "state", IsRequired = false, EmitDefaultValue = false, Order = 4)]
		public string State { get; set; }

		[DataMember(Name = "zip4", IsRequired = false, EmitDefaultValue = false, Order = 5)]
		public string Zip4 { get; set; }

		[DataMember(Name = "zip5", IsRequired = false, EmitDefaultValue = false, Order = 6)]
		public string Zip5 { get; set; }

		[DataMember(Name = "returnText", IsRequired = false, EmitDefaultValue = false, Order = 8)]
		public string ReturnText { get; set; }
		
		[DataMember(Name = "urbanization", IsRequired = false, EmitDefaultValue = false, Order = 9)]
		public string Urbanization { get; set; }

		[DataMember(Name = "errorDescription", IsRequired = false, EmitDefaultValue = false, Order =10)]
		public string ErrorDescription { get; set; }

		[DataMember(Name = "error", IsRequired = false, EmitDefaultValue = false, Order = 11)]
		public Error Error { get; set; }
	}
}