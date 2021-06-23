namespace UspsValidation.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IAddressValidateResponse : IUspsAddress
	{
		/// <summary>
		/// Indicates whether address is a business or not
		/// </summary>
		bool Business { get; set; }

		/// <summary>
		/// Carrier Route code. Default is spaces. Alphanumeric(5)
		/// </summary>
		string CarrierRoute { get; set; }

		/// <summary>
		/// Central Delivery is for all business office buildings, office complexes, 
		/// and/or industrial/professional parks.This may include call windows, horizontal locked mail
		/// receptacles, cluster box units.
		/// </summary>
		bool CentralDeliveryPoint { get; set; }
		
		/// <summary>
		/// No specification
		/// </summary>
		string DeliveryPoint { get; set; }

		/// <summary>
		/// CMRA Indicates a private business that acts as a mailreceiving agent for specific clients.
		/// <para>
		/// "Y" Address was found in the CMRA table.
		/// </para>
		/// <para>
		/// "N" Address was not found in the CMRA table.
		/// </para>
		/// Blank Address not presented to the hash table
		/// </summary>
		bool DPVCMRA { get; set; }

		/// <summary>
		/// The DPV Confirmation Indicator is the primary method used by the USPS to determine whether an
		/// address was considered deliverable or undeliverable
		/// <para>
		/// Possible values (Y, D, S, N)
		/// </para>
		/// <para>
		/// Y - Address was DPV confirmed for both primary and (if present) secondary numbers.</para><br />
		/// D - Address was DPV confirmed for the primary number only, and the secondary number information was missing.
		/// S - Address was DPV confirmed for the primary number only, and the secondary number information was present by not confirmed.
		/// N - Both primary and (if present) secondary number information failed to DPV confirm.
		/// </para>
		/// Blank Address not presented to the hash table.
		/// </summary>
		string DPVConfirmation { get; set; }

		/// <summary>
		/// DPV® Standardized Footnotes
		/// EZ24x7Plus and Mail* STAR are required to express DPV results using USPS standard two character footnotes.
		/// Example: AABB
		/// <para>Footnotes Reporting CASS™ ZIP+4™ Certification</para>
		/// <para>
		/// AA – Input address matched to the ZIP+4 file.<br />
		/// A1 – Input address not matched to the ZIP+4 file.
		/// </para>
		/// Footnotes Reporting DPV Validation Observations
		/// <para>
		/// BB - Matched to DPV (all components).<br />
		/// CC - Secondary number not matched(present but invalid).<br />
		/// N1 - High-rise address missing secondary number.<br />
		/// M1 - Primary number missing.<br />
		/// M3 - Primary number invalid.<br />
		/// P1 - Input Address RR or HC Boxnumber Missing.<br />
		/// P3 - Input Address PO, RR, or HC Box number Invalid.<br />
		/// F1 - Input Address Matched to aMilitary Address.<br />
		/// G1 - Input Address Matched to a General Delivery Address.<br />
		/// U1- Input Address Matched to a Unique ZIP Code™
		/// </para>
		/// </summary>
		string DPVFootnotes { get; set; }

		/// <summary>
		/// A - Zip Code Corrected <br />
		/// B - City / State Spelling Corrected<br />
		/// C - Invalid City / State / Zip<br />
		/// D - NO ZIP+4 Assigned<br />
		/// E - Zip Code Assigned for Multiple Response<br />
		/// F - Address could not be found in the National Directory File Database<br />
		/// G - Information in Firm Line used for matching<br />
		/// H - Missing Secondary Number<br />
		/// I - Insufficient / Incorrect Address Data<br />
		/// J - Dual Address <br />
		/// K - Multiple Response due to Cardinal Rule <br />
		/// L - Address component changed <br />
		/// LI - Match has been converted via LACS <br />
		/// M - Street Name changed<br />
		/// N - Address Standardized<br />
		/// O - Lowest +4 Tie-Breaker<br />
		/// P - Better address exists<br />
		/// Q - Unique Zip Code match<br />
		/// R - No match due to EWS<br />
		/// S - Incorrect Secondary Address<br />
		/// T - Multiple response due to Magnet Street Syndrome<br />
		/// U - Unofficial Post Office name<br />
		/// V - Unverifiable City / State<br />
		/// W - Invalid Delivery Address<br />
		/// X - No match due to out of range alias<br />
		/// Y - Military match<br />
		/// </summary>
		string Footnotes { get; set; }

		/// <summary>
		/// Is the location not occupied.
		/// </summary>
		bool Vacant { get; set; }
	}
}