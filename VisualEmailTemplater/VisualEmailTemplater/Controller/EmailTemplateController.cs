using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisualEmailTemplater.Model;

namespace VisualEmailTemplater.Controller
{
    class EmailTemplateController
    {
        EmailTemplateModel model = new EmailTemplateModel();

        public Dictionary<string,Template > GetEmailTemplates()
        {
            return model.EmailTemplates;
        }
    }
}
