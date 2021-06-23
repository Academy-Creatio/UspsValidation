using System.Threading.Tasks;

namespace UspsValidation.Interfaces
{
	public interface IUSPS
	{
		/// <summary>
		/// <para>
		/// The ZipCodeLookup API, which returns the ZIP Code and ZIP Code + 4 corresponding to the given 
		/// address, city, and state(use USPS state abbreviations). The ZipCodeLookup API processes up to five
		/// lookups per request
		/// </para>
		/// </summary>
		/// <param name="request"></param>
		/// <returns>Validated Address</returns>
		Task<IUspsAddress> ZipCodeLookupAsync(IZipCodeLookupRequest request);

		/// <summary>
		/// Verify and Address
		/// <para>
		/// The Address/Standardization “Verify” API, which corrects errors in street addresses, including 
		/// abbreviations and missing information, and supplies ZIP Codes and ZIP Codes + 4. The Verify API
		/// supports up to five lookups per transaction.By eliminating address errors, you will improve overall
		/// package delivery service.
		/// </para>
		/// </summary>
		/// <param name="request">IAddressValidateRequest</param>
		/// <returns>Validated adress</returns>
		Task<IAddressValidateResponse> AddressValidateAsync(IAddressValidateRequest request);

		/// <summary>
		/// Returns 2 letter USPS state code
		/// </summary>
		/// <param name="state">State Full name</param>
		/// <returns>USPS State Code</returns>
		/// <example>
		/// <code>
		/// string stateCode = IUSPS.GetCodeByName("New York");
		/// </code>
		/// </example>
		string GetStateCodeByName(string state);
	}
}