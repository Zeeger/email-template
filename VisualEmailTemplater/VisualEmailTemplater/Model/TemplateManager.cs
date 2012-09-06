using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisualEmailTemplater.Interfaces;

namespace VisualEmailTemplater.Model
{
    class TemplateManager
    {
		public List<IEmail> FetchTemplates()
		{
			var configMgr = new ConfigManager();

			var fileContents = configMgr.ReadConfigFileToStringList("templates.cfg");

			return ParseFileToTemplates(fileContents);
		}

		public List<IEmail> ParseFileToTemplates(List<string> fileContents)
		{
			return TemplateParser.ParseConfig(fileContents);
		}
    }
}
