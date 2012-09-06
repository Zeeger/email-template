using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisualEmailTemplater.Interfaces;
using VisualEmailTemplater.Classes;

namespace VisualEmailTemplater.Model
{


	class EmailTemplateModel
	{
		TemplateManager templateManager = new TemplateManager();

		 List<IEmail> _emailTemplates;

		 Variables _variables;

		public List<IEmail> EmailTemplates
		{
			get
			{
				if (_emailTemplates == null)
				{
					_emailTemplates = templateManager.FetchTemplates();
				}
				return _emailTemplates;
			}
		}

		public Variables Variables
		{
			get
			{
				if (_variables == null)
				{ 
					var configMgr = new ConfigManager();
					_variables = configMgr.FetchVariables();
				}

				return _variables;
			}
		}
	}
}
