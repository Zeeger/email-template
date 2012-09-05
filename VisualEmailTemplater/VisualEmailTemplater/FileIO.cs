using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/*
 *	Written by: Adam Krieger
 */

namespace VisualEmailTemplater
{
	static class FileIO
	{
		public static List<string> ReadFileToStringList(string fullPath)
		{
			var reader = new StreamReader(fullPath);

			var stringList = new List<string>();
 
			do
			{
				stringList.Add(reader.ReadLine());
			}
			while (reader.Peek() != -1);

			return stringList;
		}

		public static bool CheckFileExistence(string fullPath, bool create = false)
		{
			try
			{
				if (create)
				{
					var fileStream = new FileStream(fullPath, FileMode.CreateNew);
					fileStream.Close();
				}
			}
			catch
			{ }

			var fileExists = File.Exists(fullPath);

			return fileExists;
		}

		public static string CombinePath(string part1, string part2)
		{
			part1 = part1.TrimEnd('\\');
			part2 = part2.TrimStart('\\');

			return part1 + "\\" + part2;
		}

		public static string PresentWorkingDirectory()
		{
			var location = System.Reflection.Assembly.GetCallingAssembly().Location;

			var indexOfLastSlash = location.LastIndexOf("\\");

			return location.Substring(0, indexOfLastSlash + 1);
		}
	}
}
