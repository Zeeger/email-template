using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisualEmailTemplater.Classes;

namespace VisualEmailTemplater.Interfaces
{
	interface IEmail
	{
		string Name { get; set; }

		Recipients Recipients { get; }

		string Subject { get; set; }

		string Body { get; set; }

		Attachments Attachments { get; }
	}
}
