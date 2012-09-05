using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualEmailTemplater.Model
{
	class TemplateParser
	{
		internal static Dictionary<string, Template> ParseConfig(List<string> fileContents)
		{
			var parsingDictionary = new Dictionary<string, Template>();

			const string template = "TEMPLATE";
			const string end = "END";
			const string to = "TO";
			const string subject = "SUBJECT";
			const string body = "BODY";
			const string attachment = "ATTACHMENT";

			var currentProperty = string.Empty;

			var currentStringList = new List<string>();
			var currentTemplate = new Template();

			//First, parse the template configurations out into individual groups
			foreach (var line in fileContents)
			{

				//We can only enter a template if we're not in anything
				if (currentProperty == string.Empty && line.ToUpper().StartsWith(template))
				{
					currentProperty = template;
					var templateName = line.Substring(template.Length).Trim();
					
					currentStringList = new List<string>();
					
					currentTemplate = new Template { StringDump=currentStringList };

					parsingDictionary.Add(templateName, currentTemplate);
				}
				else if (currentProperty == body)
				{
					if (line.ToUpper().StartsWith(end + body))
					{
						currentProperty = template;
					}
					else
					{
						if ((currentTemplate.Body ?? string.Empty).Length > 0) currentTemplate.Body += Environment.NewLine;
						currentTemplate.Body += line;
					}
				}
				else if (currentProperty == template)
				{
					//Check for start of properties
					//	We can't start any property unless already in a template body

					if (line.ToUpper().StartsWith(end + template))
					{
						currentProperty = string.Empty;
					}
					else
					{
						currentStringList.Add(line);

						foreach (var x in new string[] { to, subject, body, attachment })
						{
							if (line.ToUpper().StartsWith(x))
							{
								var lineContent = line.Substring(x.Length).TrimStart();

								switch (x)
								{
									case to:
										currentTemplate.Recipients = lineContent.Replace(" ","").Split(';');
										break;
									case subject:
										currentTemplate.Subject = lineContent.Trim();
										break;
									case attachment:
										currentTemplate.Attachments = lineContent.Split(';');
										break;
									case body:
										currentProperty = body;
										currentTemplate.Body = lineContent.Trim();
										break;
								}
							}
						}
					}
				}



			}

			return parsingDictionary;
		}
	}
}
