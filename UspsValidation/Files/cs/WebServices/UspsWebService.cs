using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using Terrasoft.Core;
using Terrasoft.Core.Factories;
using Terrasoft.Web.Common;
using UspsValidation.DataContract;
using UspsValidation.Interfaces;

namespace UspsValidation
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class UspsWebService : BaseService
	{
		#region Properties
		private IUSPS usps;

		private SystemUserConnection _systemUserConnection;
		private SystemUserConnection SystemUserConnection
		{
			get
			{
				return _systemUserConnection ?? (_systemUserConnection = (SystemUserConnection)AppConnection.SystemUserConnection);
			}
		}
		#endregion

		#region Methods : REST
		
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, 
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public async Task<DataContract.UspsAddress> ValidateZipCode(DataContract.UspsAddress address)
		{
			UserConnection userConnection = UserConnection ?? SystemUserConnection;
			usps = ClassFactory.Get<IUSPS>();

			//ZipCodeLookupRequest requires userConnection to lookup SysSetting for default uspsUsername
			//Pass UserConnection as constructor argument
			var constructorArguments = new ConstructorArgument("userConnection", userConnection);
			IZipCodeLookupRequest request = ClassFactory.Get<IZipCodeLookupRequest>(constructorArguments);
			request.FirmName = address.FirmName ?? "";
			request.Address1 = address.Address1 ?? "";
			request.Address2 = address.Address2 ?? "";
			request.City = address.City ?? "";
			request.State = GetState(address.State);

			var x = await usps.ZipCodeLookupAsync(request);
			var returnType = WebServices.Converter.Convert<DataContract.UspsAddress, IUspsAddress>(x);
			return returnType;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
		public async Task<DataContract.AddressValidateResponse> ValidateAddress(DataContract.UspsAddress address)
		{
			UserConnection userConnection = UserConnection ?? SystemUserConnection;
			usps = ClassFactory.Get<IUSPS>();

			//ZipCodeLookupRequest requires userConnection to lookup SysSetting for default uspsUsername
			//Pass UserConnection as constructor argument
			var constructorArguments = new ConstructorArgument("userConnection", userConnection);
			IAddressValidateRequest request = ClassFactory.Get<IAddressValidateRequest>(constructorArguments);

			request.FirmName = address.FirmName ?? "";
			request.Address1 = address.Address1 ?? "";
			request.Address2 = address.Address2 ?? "";
			request.City = address.City ?? "";
			request.State = GetState(address.State);
			request.Zip5 = address.Zip5 ?? "";
			request.Zip4 = address.Zip4 ?? "";

			var x = await usps.AddressValidateAsync(request);
			var returnType = WebServices.Converter.Convert<DataContract.AddressValidateResponse, IAddressValidateResponse>(x);
			return returnType;
		}

		#endregion

		private string GetState(string state)
		{
			state = state.ToUpper().Trim();
			if (state.Length == 2 && UspsStates.States.ContainsKey(state))
			{
				return state;
			}
			else
			{
				return usps.GetStateCodeByName(state) ?? state;
			}
		}
	}
}
