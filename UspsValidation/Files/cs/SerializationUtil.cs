using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace UspsValidation
{
	public static class SerializationUtil
	{
		public static T Deserialize<T>(XDocument doc)
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

				using (var reader = doc.Root.CreateReader())
				{
					return (T)xmlSerializer.Deserialize(reader);
				}

			}
			catch (Exception ex)
			{

				throw;
			}

		}
	}
}