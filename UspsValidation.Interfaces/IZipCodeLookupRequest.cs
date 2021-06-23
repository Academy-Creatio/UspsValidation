namespace UspsValidation.Interfaces
{

	public interface IZipCodeLookupRequest
	{
		string Address1 { get; set; }
		string Address2 { get; set; }
		string City { get; set; }
		string FirmName { get; set; }
		string State { get; set; }
		string Username { get; set; }
		string XML { get; }
	}
}