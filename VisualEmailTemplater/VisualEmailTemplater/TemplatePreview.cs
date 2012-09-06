using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisualEmailTemplater
{
	public class TemplatePreview
	{
		public string[] Recipients
		{
			get;
			set;
		}

		public string Subject { get; set; }

		public string Body { get; set; }

		public string[] Attachments { get; set; }

		public List<string> StringDump { get; set; }
	}
}
