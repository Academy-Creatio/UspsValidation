using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UspsValidation.WebServices
{
	internal static class Converter
	{
		internal static TTo Convert<TTo, TFrom>(TFrom origin) where TTo : class, new()
		{
			var returnType = new TTo();

			List<PropertyInfo> destProps = returnType.GetType().GetProperties().ToList();

			foreach (var prop in destProps)
			{
				var origPpropValue = origin.GetType().GetProperty(prop.Name)?.GetValue(origin);

				var destType = prop.PropertyType;
				var origType = origin.GetType().GetProperty(prop.Name)?.PropertyType;


				if(destType == typeof(bool) && origType == typeof(string))
				{
					bool propValue = origPpropValue?.ToString() == "Y";
					returnType.GetType().GetProperty(prop.Name).SetValue(returnType, propValue);
				}
				else if (destType == typeof(string) && origType == typeof(string))
				{
					returnType.GetType().GetProperty(prop.Name).SetValue(returnType, origPpropValue);
				}
				else if (destType == typeof(string) && origType != typeof(string))
				{
					if(origPpropValue != null)
					{
						returnType.GetType().GetProperty(prop.Name).SetValue(returnType, origPpropValue.ToString());
					}
				}
				else
				{
					returnType.GetType().GetProperty(prop.Name).SetValue(returnType, origPpropValue);
				}
			}
			return returnType;
		}
	}
}
