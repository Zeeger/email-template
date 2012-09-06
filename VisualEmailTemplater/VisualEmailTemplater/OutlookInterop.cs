using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;

namespace VisualEmailTemplater
{
	public static class OutlookInterop
	{
		public static void SaveMessage(string[] recipients, string subject, string body, string[] attachments, string filepath)
		{
			var curpwd = FileIO.PresentWorkingDirectory();

			var outlookApplication = new Application();

			var mailObject = outlookApplication.CreateItem(OlItemType.olMailItem) as MailItem;

			mailObject.Body = body;
			mailObject.Subject = subject;

			if (recipients != null)
			{
				foreach (var recipient in recipients)
				{
					mailObject.Recipients.Add(recipient);
				}
			}

			if (attachments != null)
			{
				foreach (var attachment in attachments)
				{
					if ((attachment ?? string.Empty) != string.Empty)
						mailObject.Attachments.Add(attachment);
				}
			}

			mailObject.SaveAs(FileIO.CombinePath(curpwd, "sample.msg"));
		}
	}
}
