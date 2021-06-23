namespace Terrasoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Threading.Tasks;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.UI.WebControls.Controls;
	using UspsValidation.Interfaces;

	#region Class: KJProcessUserTask_ValidateUspsAddress

	/// <exclude/>
	public partial class KJProcessUserTask_ValidateUspsAddress
	{

		private IUSPS usps;
		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			usps = ClassFactory.Get<IUSPS>();
			if (Action == Guid.Parse("f02dd0c8-6a4f-42e0-8fa8-a260364b7ecc")) //Address
			{
				Task.Run(async () =>
				{
					await ValidateAddress();

				}).Wait();
				
			}
			else if(Action == Guid.Parse("798fb6b4-de7d-4ef6-8644-7f0f5c8fffb6")) //ZipCode
			{
				Task.Run(async () =>
				{
					await ValidateZipCode();

				}).Wait();
			}
			return true;
		}


		protected async Task ValidateAddress()
		{
			var constructorArguments = new ConstructorArgument("userConnection", UserConnection);
			IAddressValidateRequest request = ClassFactory.Get<IAddressValidateRequest>(constructorArguments);

			//request.FirmName = address.FirmName ?? "";
			request.FirmName = FirmName ?? "";
			request.Address1 = Address1 ?? "";
			request.Address2 = Address2 ?? "";
			request.City = City ?? "";
			request.State = GetState(State);
			request.Zip5 = Zip5 ?? "";
			request.Zip4 = Zip4 ?? "";
			IAddressValidateResponse result = await usps.AddressValidateAsync(request);
			
			if(result.Error == null)
			{
				Footnotes = result.Footnotes;
				DPVFootnotes = result.Footnotes;
				Vacant = result.Vacant;
				Business = result.Business;
				Zip5 = result.Zip5;
				Zip4 = result.Zip4;
				
			}
			else
			{
				Error = result.Error.Description;
			}
			
		}


		protected async Task ValidateZipCode()
		{
			var constructorArguments = new ConstructorArgument("userConnection", UserConnection);
			IZipCodeLookupRequest request = ClassFactory.Get<IZipCodeLookupRequest>(constructorArguments);
			request.FirmName = FirmName ?? "";
			request.Address1 = Address1 ?? "";
			request.Address2 = Address2 ?? "";
			request.City = City ?? "";
			request.State = GetState(State);
			IUspsAddress result = await usps.ZipCodeLookupAsync(request);

			if (result.Error == null)
			{
				Zip5 = result.Zip5;
				Zip4 = result.Zip4;
			}
			else
			{
				Error = result.Error.Description;
			}

		}

		private string GetState(string state)
		{
			state = state.ToUpper().Trim();
			if (state.Length == 2)
			{
				return state;
			}
			else
			{
				return usps.GetStateCodeByName(state) ?? state;
			}
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion

}

