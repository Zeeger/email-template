using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisualEmailTemplater.Classes;
using VisualEmailTemplater.Interfaces;

namespace VisualEmailTemplater
{
	class Email : IEmail
	{
		private Recipients _recipients;
		private Attachments _attachments;

		public string Name { get; set; }

		public Recipients Recipients
		{
			get
			{
				if (_recipients == null)
				{
					_recipients = new Recipients();
				}

				return _recipients;
			}

		}

		public string Subject { get; set; }

		public string Body { get; set; }

		public Attachments Attachments
		{
			get
			{
				if (_attachments == null)
				{
					_attachments = new Attachments();
				}
				return _attachments;
			}

		}

	}
}
