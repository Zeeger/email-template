using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualEmailTemplater
{
	class ConfigManager
	{
		public List<string> ReadConfigFileToStringList(string configFilename)
		{
		
			var fullPath = FileIO.CombinePath(FileIO.PresentWorkingDirectory(),configFilename);

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
