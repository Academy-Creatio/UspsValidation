using UspsValidation.Interfaces;

namespace UspsValidation
{
	public class AddressValidateResponse : IAddressValidateResponse
	{
		public bool Business {get; set;}
		public string CarrierRoute {get; set;}
		public bool CentralDeliveryPoint {get; set;}
		public string DeliveryPoint {get; set;}
		public bool DPVCMRA {get; set;}
		public string DPVConfirmation {get; set;}
		public string DPVFootnotes {get; set;}
		public string Footnotes {get; set;}
		public bool Vacant {get; set;}
		public string FirmName {get; set;}
		public string Address1 {get; set;}
		public string Address2 {get; set;}
		public string City {get; set;}
		public string State {get; set;}
		public string Zip4 {get; set;}
		public string Zip5 {get; set;}
		public string ReturnText {get; set;}
		public string Urbanization {get; set;}
		public string ErrorDescription {get; set;}
		public IError Error {get; set;}
	}
}
