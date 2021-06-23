using System.Collections.Generic;
using System.Linq;

namespace UspsValidation
{
	static class UspsStates
	{
		/// <summary>
		/// Dictionary of States <br/>
		/// "AL", "Alabama"
		/// </summary>
		public static Dictionary<string, string> States { get; private set; } = new Dictionary<string, string>
		{
			{"AL", "Alabama"},
			{"AK", "Alaska"},
			{"AZ", "Arizona"},
			{"AR", "Arkansas"},
			{"CA", "California"},
			{"CO", "Colorado"},
			{"CT", "Connecticut"},
			{"DE", "Delaware"},
			{"DC", "District of Columbia"},
			{"FL", "Florida"},
			{"GA", "Georgia"},
			{"HI", "Hawaii"},
			{"ID", "Idaho"},
			{"IL", "Illinois"},
			{"IN", "Indiana"},
			{"IA", "Iowa"},
			{"KS", "Kansas"},
			{"KY", "Kentucky"},
			{"LA", "Louisiana"},
			{"ME", "Maine"},
			{"MD", "Maryland"},
			{"MA", "Massachusetts"},
			{"MI", "Michigan"},
			{"MN", "Minnesota"},
			{"MS", "Mississippi"},
			{"MO", "Missouri"},
			{"MT", "Montana"},
			{"NE", "Nebraska"},
			{"NV", "Nevada"},
			{"NH", "New Hampshire"},
			{"NJ", "New Jersey"},
			{"NM", "New Mexico"},
			{"NY", "New York"},
			{"NC", "North Carolina"},
			{"ND", "North Dakota"},
			{"OH", "Ohio"},
			{"OK", "Oklahoma"},
			{"OR", "Oregon"},
			{"PA", "Pennsylvania"},
			{"PR", "Puerto Rico"},
			{"RI", "Rhode Island"},
			{"SC", "South Carolina"},
			{"SD", "South Dakota"},
			{"TN", "Tennessee"},
			{"TX", "Texas"},
			{"UT", "Utah"},
			{"VT", "Vermont"},
			{"VA", "Virginia"},
			{"WA", "Washington"},
			{"WV", "West Virginia"},
			{"WI", "Wisconsin"},
			{"WY", "Wyoming"}
		};
		internal static string GetCodeByName(string name)
		{
			return States.FirstOrDefault(i => i.Value.ToLower() == name.ToLower()).Key;
		}
	}
}
