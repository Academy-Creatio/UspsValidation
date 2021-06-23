using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
	public class UspsTestWebService : BaseService
	{
		#region Properties
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
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public async Task<DataContract.UspsAddress> ZipCodeLookup()
		{
			UserConnection userConnection = UserConnection ?? SystemUserConnection;
			IUSPS usps = ClassFactory.Get<IUSPS>();

			ConstructorArgument constructorArguments = new ConstructorArgument("userConnection", userConnection);
			IZipCodeLookupRequest request = ClassFactory.Get<IZipCodeLookupRequest>(constructorArguments);

			request.Address1 = "280 Summer St";
			request.Address2 = "6th floor";
			request.City = "Boston";
			request.State = "MA";

			var x = await usps.ZipCodeLookupAsync(request);
			var returnType = WebServices.Converter.Convert<DataContract.UspsAddress, IUspsAddress>(x);

			return returnType;
		}


		[OperationContract]
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public async Task<AddressValidateResponse> AddressValidate()
		{
			UserConnection userConnection = UserConnection ?? SystemUserConnection;
			IUSPS usps = ClassFactory.Get<IUSPS>();

			ConstructorArgument constructorArguments = new ConstructorArgument("userConnection", userConnection);
			IAddressValidateRequest request = ClassFactory.Get<IAddressValidateRequest>(constructorArguments);

			request.Address1 = "280 Summer St";
			request.Address2 = "6th floor";
			request.City = "Boston";
			request.State = "MA";
			request.Revision = 1;

			return (AddressValidateResponse)await usps.AddressValidateAsync(request);
		}
		#endregion

		#region Methods : Private
		
		#endregion
	}
}



