using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualEmailTemplater.Model
{


	class EmailTemplateModel
	{
		TemplateManager templateManager = new TemplateManager();

		Dictionary<string,Template > _emailTemplates;

		public Dictionary<string, Template> EmailTemplates
		{
			get
			{
				return _emailTemplates = templateManager.FetchTemplates();
			}
		}
	}
}
