using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualEmailTemplater.Model
{


	class EmailTemplateModel
	{
		TemplateManager templateManager = new TemplateManager();

		List<string> _emailTemplates;

		public List<string> EmailTemplates
		{
			get
			{
				return _emailTemplates = templateManager.FetchNames();
			}
		}
	}
}
