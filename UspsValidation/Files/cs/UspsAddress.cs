using Terrasoft.Core.Factories;
using UspsValidation.Interfaces;

namespace UspsValidation
{
	[DefaultBinding(typeof(IUspsAddress))]
	public class UspsAddress : IUspsAddress
	{
		public string FirmName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip4 { get; set; }
		public string Zip5 { get; set; }
		public string ReturnText { get; set; }
		public string Urbanization { get; set; }
		public string ErrorDescription { get; set; }
		public IError Error { get; set; }
	}
}