using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SayMore.UI.Utilities
{
	public class JSONUtils
	{
		/// ------------------------------------------------------------------------------------
		public static string MakeKeyValuePair(string key, string value)
		{
			return MakeKeyValuePair(key, value, false);
		}

		/// ------------------------------------------------------------------------------------
		public static string MakeKeyValuePair(string key, string value, bool bracketValue)
		{
			if (key == null || value == null || key + value == string.Empty)
				return null;

			var retValue = string.Format("\"{0}\":\"{1}\"", key, value);
			return (!bracketValue ? retValue : string.Format("[{0}]", retValue));
		}

		/// ------------------------------------------------------------------------------------
		public static string MakeArrayFromValues(string key, IEnumerable<string> values)
		{
			var bldr = new StringBuilder();
			int i = 0;
			foreach (var val in values)
				bldr.AppendFormat("\"{0}\":{{{1}}},", i++, val);

			// Get rid of last comma.
			bldr.Length--;

			return string.Format("\"{0}\":{{{1}}}", key, bldr);
		}

		/// ------------------------------------------------------------------------------------
		public static string EncodeData(string data)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
		}
	}
}
