namespace UspsValidation.Interfaces
{
	public interface IError
	{
		int Number { get; set; }
		string Source { get; set; }
		string Description { get; set; }
		string HelpFile { get; set; }
		string HelpContext { get; set; }
	}
}
