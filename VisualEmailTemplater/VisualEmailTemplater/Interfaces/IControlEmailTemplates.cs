using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisualEmailTemplater.Interfaces;

namespace VisualEmailTemplater.Controller
{
	interface IControlEmailTemplates
	{
		//This method pulls back template names. The name is passed into the Generate E-mail func while gives us a useful looking message.
		//	Once visually confirmed, the user can send that e-mail.

		List<IEmail> LoadedTemplates { get; }

		IEmail GenerateEmail(string templateName);

		void SaveEmail(IEmail email, string filePath);
	}
}
