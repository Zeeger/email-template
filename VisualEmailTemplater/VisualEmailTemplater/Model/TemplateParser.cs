using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisualEmailTemplater.Interfaces;

namespace VisualEmailTemplater.Model
{
	class TemplateParser
	{
		const string _TEMPLATE = "TEMPLATE";
		const string _END = "END";
		const string _TO = "TO";
		const string _SUBJECT = "SUBJECT";
		const string _BODY = "BODY";
		const string _ATTACHMENT = "ATTACHMENT";

		internal static List<IEmail> ParseConfig(List<string> fileContents)
		{
			var currentProperty = string.Empty;

			var templateList = new List<IEmail>();
			
			var currentTemplate = new Email();
			templateList.Add(currentTemplate);

			//First, parse the template configurations out into individual groups
			foreach (var line in fileContents)
			{
				currentProperty = DetermineCurrentProperty(currentProperty, line);

				string lineWithoutProperty = string.Empty;

				if (line.ToUpper().StartsWith(currentProperty))
					lineWithoutProperty = line.Substring(currentProperty.Length).Trim();
				else
					lineWithoutProperty = line;

				switch (currentProperty)
				{
					case _TEMPLATE:

						if (currentTemplate.Name != string.Empty)
						{
							currentTemplate = new Email();
							templateList.Add(currentTemplate);
						}

						currentTemplate.Name = lineWithoutProperty;

						break;

					case _SUBJECT:
						currentTemplate.Subject = lineWithoutProperty;

						break;

					case _BODY:

						var templine = line;

						if ((currentTemplate.Body ?? string.Empty) == string.Empty)
						{
							//Cut body from the beginning of the line
							templine = lineWithoutProperty;
						}
						else
						{
							templine = Environment.NewLine + templine;
						}

						currentTemplate.Body += templine;

						break;

					case _TO:
					case _ATTACHMENT:
						foreach (var current in lineWithoutProperty.Split(';'))
						{
							var itemToAdd = current.Trim();

							switch (currentProperty)
							{
								case _TO:
									currentTemplate.Recipients.Add(itemToAdd);
									break;
								case _ATTACHMENT:
									currentTemplate.Attachments.Add(itemToAdd);
									break;
							}
						}

						break;


				}

			}

			return templateList;
		}

		private static string DetermineCurrentProperty(string currentProperty, string input)
		{
			
			//We're in a property field. See if we change properties

			// The only multiline, sub-template property is body. In this case, the only thing that exits body is endbody
			if (currentProperty == _BODY)
			{
				if (!input.ToUpper().StartsWith(_END + _BODY))
				{
					return _BODY;
				}
			}

			//We're allowed to enter a different property from any existing property other than body

			foreach (var property in new string[] { _TEMPLATE, _TO, _SUBJECT, _BODY, _ATTACHMENT })
			{
				if (input.ToUpper().StartsWith(property))
				{
					return property;
				}
			}

			//Default is to back out of a template
			return string.Empty;
		}
	}
}
