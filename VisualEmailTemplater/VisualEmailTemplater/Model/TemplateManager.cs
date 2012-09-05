using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualEmailTemplater.Model
{
    class TemplateManager
    {
		public Dictionary<string,Template> FetchTemplates()
		{
			var configMgr = new ConfigManager();

			var fileContents = configMgr.ReadConfigFileToStringList("templates.cfg");

			return ParseFileToTemplates(fileContents);
		}

		public Dictionary<string,Template > ParseFileToTemplates(List<string> fileContents)
		{
			return TemplateParser.ParseConfig(fileContents);
		}
    }
}
