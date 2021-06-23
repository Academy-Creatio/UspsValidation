using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Terrasoft.Core.Factories;
using UspsValidation.Interfaces;

namespace UspsValidation
{
	[DefaultBinding(typeof(IUSPS))]
	public class USPS : IUSPS
	{
		const string BaseUrl = "https://secure.shippingapis.com/ShippingAPI.dll?API=";
		public async Task<IUspsAddress> ZipCodeLookupAsync(IZipCodeLookupRequest request)
		{
			const string API = "ZipCodeLookup";
			Uri Url = new Uri($"{BaseUrl}{API}&XML={request.XML}");
			
			try
			{
				WebRequest wr = WebRequest.Create(Url);
				wr.Timeout = 5000;
				WebResponse response = await wr.GetResponseAsync();

				using (Stream dataStream = response.GetResponseStream())
				{
					using (StreamReader reader = new StreamReader(dataStream))
					{
						string responseFromServer = reader.ReadToEnd();

						XDocument ZipCodeLookupResponse = XDocument.Parse(responseFromServer);
						DTO.ZipCodeLookupResponse x = SerializationUtil.Deserialize<DTO.ZipCodeLookupResponse>(ZipCodeLookupResponse);

						string state = null;
						if (!string.IsNullOrEmpty(x.Address.State))
						{
							UspsStates.States.TryGetValue(x.Address.State??"", out state);
						}
						
						return new UspsAddress()
						{
							FirmName = x.Address.FirmName,
							Address1 = x.Address.Address1,
							Address2 = x.Address.Address2,
							City = x.Address.City,
							State = state,
							Zip4 = x.Address.Zip4,
							Zip5 = x.Address.Zip5,
							ReturnText = x.Address.ReturnText,
							Error = x.Address.Error
						};
					}
				}
			}
			catch (Exception ex)
			{
				return new UspsAddress()
				{
					Error = new Error
					{
						Description = ex.Message
					}
				};
			}
		}

		public async Task<IAddressValidateResponse> AddressValidateAsync(IAddressValidateRequest request)
		{
			const string API = "Verify";
			Uri Url = new Uri($"{BaseUrl}{API}&XML={request.XML}");

			try
			{
				WebRequest wr = WebRequest.Create(Url);
				wr.Timeout = 5000;
				WebResponse response = await wr.GetResponseAsync();

				string responseFromServer = "";
				using (Stream dataStream = response.GetResponseStream())
				{
					using (StreamReader reader = new StreamReader(dataStream))
					{
						responseFromServer = reader.ReadToEnd();
						XDocument AddressValidateResponse = XDocument.Parse(responseFromServer);
						DTO.AddressValidateResponse x = SerializationUtil.Deserialize<DTO.AddressValidateResponse>(AddressValidateResponse);
						var y = WebServices.Converter.Convert<AddressValidateResponse, DTO.Address>(x.Address);
						return y;
					}
				}
			}
			catch (WebException ex)
			{
				var r = new AddressValidateResponse();
				r.Error = new Error
				{
					Description = ex.Message
				};
				return r;
			}
		}

		public string GetStateCodeByName(string state)
		{
			return UspsStates.GetCodeByName(state);
		}
	}
}