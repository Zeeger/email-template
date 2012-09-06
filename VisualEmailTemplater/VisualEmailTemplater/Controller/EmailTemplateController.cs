using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisualEmailTemplater.Model;
using VisualEmailTemplater.Interfaces;
using VisualEmailTemplater.Classes;

namespace VisualEmailTemplater.Controller
{
    class EmailTemplateController : IControlEmailTemplates 
    {
        EmailTemplateModel model = new EmailTemplateModel();

		List<IEmail> _loadedTemplates;

		Variables _variables;

		public List<IEmail> LoadedTemplates
		{
			get
			{
				if (_loadedTemplates == null)
				{
					_loadedTemplates = model.EmailTemplates;
				}

				return _loadedTemplates;
			}
		}

		public Variables Variables
		{
			get
			{
				if (_variables == null)
				{
					_variables = model.Variables;
				}

				return _variables;
			}
		}

		public List<string> GetTemplateNames()
		{
			throw new NotImplementedException();
		}

		public List<IEmail> GenerateEmail()
		{
			return FindAndReplaceVariablesInEmails(LoadedTemplates, Variables);
		}

		private List<IEmail> FindAndReplaceVariablesInEmails(List<IEmail> emailTemplates, Variables _variables)
		{
			var generatedEmails = emailTemplates;

			foreach (var email in generatedEmails)
			{
				email.Subject = FindAndReplaceVariablesInString(email.Subject);
				email.Body = FindAndReplaceVariablesInString(email.Body);

				var newRecipients = new Recipients();

				foreach (var recipient in email.Recipients)
				{
					newRecipients.Add(FindAndReplaceVariablesInString(recipient));
				}

				email.Recipients.Clear();

				foreach (var newR in newRecipients)
				{
					email.Recipients.Add(newR);
				}

				var newAttachments = new Attachments();

				foreach (var attachment in email.Attachments)
				{ 
					newAttachments.Add(FindAndReplaceVariablesInString(attachment));
				}

				email.Attachments.Clear();

				foreach (var newA in newAttachments)
				{
					email.Attachments.Add(newA);
				}
			}
			return generatedEmails;
		}

		private string FindAndReplaceVariablesInString(string input)
		{
			return input;
		}

		public void SaveEmail(Email email, string filePath)
		{
			throw new NotImplementedException();
		}


		Interfaces.IEmail IControlEmailTemplates.GenerateEmail(string templateName)
		{
			throw new NotImplementedException();
		}

		public void SaveEmail(Interfaces.IEmail email, string filePath)
		{
			throw new NotImplementedException();
		}
	}
}
