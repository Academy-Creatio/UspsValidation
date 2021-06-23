using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using UspsValidation.Interfaces;

namespace UspsValidation
{
	[DataContract]
	public class Error : IError
	{
		[XmlElement(ElementName = "Number", DataType="int", IsNullable = false, Type = typeof(int))]
		[DataMember(Name = "number", EmitDefaultValue = false, IsRequired = false, Order = 0)]
		public int Number { get; set; }

		[XmlElement(ElementName = "Source", IsNullable = true, Type = typeof(string))]
		[DataMember(Name = "source", EmitDefaultValue = false, IsRequired = false, Order = 1)]
		public string Source { get; set; }

		[XmlElement(ElementName = "Description", IsNullable = true, Type = typeof(string))]
		[DataMember(Name = "description", EmitDefaultValue = false, IsRequired = false, Order = 2)]
		public string Description { get; set; }

		[XmlElement(ElementName = "HelpFile", IsNullable = true, Type = typeof(string))]
		[DataMember(Name = "helpFile", EmitDefaultValue = false, IsRequired = false, Order = 3)]
		public string HelpFile { get; set; }

		[XmlElement(ElementName = "HelpContext", IsNullable = true, Type = typeof(string))]
		[DataMember(Name = "helpContext", EmitDefaultValue = false, IsRequired = false, Order = 4)]
		public string HelpContext { get; set; }
	}
}
