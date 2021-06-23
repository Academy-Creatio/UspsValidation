namespace UspsValidation.Interfaces
{
	/// <summary>
	/// <a href="https://www.usps.com/business/web-tools-apis/address-information-api.pdf">Official specification</a> 
	/// </summary>
	public interface IUspsAddress
	{
		/// <summary>
		/// <para>
		/// Up to 5 address verifications can be included per transaction.
		/// </para>
		/// </summary>
		string FirmName { get; set; }

		/// <summary>
		/// <para>
		/// Delivery Address in the 
		/// destination address.May contain
		/// secondary unit designator, such
		/// as APT or SUITE, for 
		/// Accountable mail.)
		/// </para>
		/// </summary>
		string Address1 { get; set; }
		
		/// <summary>
		/// <para>
		/// Delivery Address in the 
		/// destination address.May contain
		/// secondary unit designator, such
		/// as APT or SUITE, for 
		/// Accountable mail.)
		/// </para>
		/// </summary>
		string Address2 { get; set; }

		/// <summary>
		/// <para>
		/// City name of the destination address. Field is required, unless a verified 11-digit DPV is provided for the mail piece.
		/// </para>
		/// </summary>
		string City { get; set; }

		/// <summary>
		/// <para>
		/// Two-character state code of the destination address.
		/// Use IUsps.GetStateCodeByName get get state name
		/// </para>
		/// </summary>
		string State { get; set; }

		/// <summary>
		/// <para>
		/// Destination ZIP+4. Numeric values(0-9) only. If International, all zeroes.
		/// Default to spaces if not available.
		/// </para>
		/// </summary>
		string Zip4 { get; set; }
		
		/// <summary>
		/// <para>
		/// Destination 5-digit ZIP Code.Must be 5-digits.Numeric values
		/// (0-9) only.If International, all zeroes
		/// </para>
		/// </summary>
		string Zip5 { get; set; }

		/// <summary>
		/// Missing from documentation, Some info when partial match
		/// </summary>
		string ReturnText { get; set; }

		/// <summary>
		/// Missing from documentation, Some info when partial match
		/// </summary>
		string Urbanization { get; set; }
		string ErrorDescription { get; set; }

		/// <summary>
		/// Missing from documentation, Some info when partial match
		/// </summary>
		IError Error { get; set; }
	}
}