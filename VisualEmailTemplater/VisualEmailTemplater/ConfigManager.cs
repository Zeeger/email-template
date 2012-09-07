using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisualEmailTemplater.Classes;

namespace VisualEmailTemplater
{
	class ConfigManager
	{
		public Variables FetchVariables()
		{
			var varDict = new Variables();

			foreach (var line in ReadConfigFileToStringList("variables.cfg"))
			{
				var cur = (line ?? string.Empty).Split('=');

				if (cur.Count() > 1 && cur[0].StartsWith("%"))
					varDict.Add(cur[0].Trim(), cur[1].Trim());
			}

			return varDict;
		}

		private string GetConfigPath(string filename)
		{
			return FileIO.CombinePath(FileIO.PresentWorkingDirectory(), filename);			
		}

		public List<string> ReadConfigFileToStringList(string configFilename)
		{
			var fullPath = GetConfigPath(configFilename);

			if (FileIO.CheckFileExistence(fullPath, true))
			{
				return FileIO.ReadFileToStringList(fullPath);
			}
			else
			{
				throw new Exception("File does not exist, even after creating.");
			}
		}
	}
}
