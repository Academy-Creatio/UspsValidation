namespace UspsValidation.Interfaces
{
	public interface IAddressValidateRequest
	{
		int Revision { get; set; }
		string Address1 { get; set; }
		string Address2 { get; set; }
		string City { get; set; }
		string FirmName { get; set; }
		string State { get; set; }
		string Username { get; set; }
		string XML { get; }
		string Zip4 { get; set; }
		string Zip5 { get; set; }
	}
}