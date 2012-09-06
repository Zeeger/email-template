using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualEmailTemplater
{
	class GenericFunctions<T>
	{
		public string ConcatenateList(IList<T> input, string delimiter)
		{
			var output = string.Empty;

			foreach (var item in input)
			{
				output += item.ToString() + delimiter;
			}

			output = output.TrimEnd(delimiter.ToCharArray());

			return output;
		}
	}
}
