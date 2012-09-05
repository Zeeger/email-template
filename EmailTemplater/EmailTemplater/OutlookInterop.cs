using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;

namespace EmailTemplater
{
    class OutlookInterop
    {
        public static void SendOne()
        {
            // Create an Outlook Application object. 
            Application outLookApp = new Application();
            // Create a new TaskItem.
            MailItem newMail =
              (MailItem)outLookApp.CreateItem(OlItemType.olMailItem);
            // Configure the task at hand and save it.
            newMail.Body = "Don't forget to send DOM the links...";
            newMail.Importance = OlImportance.olImportanceHigh;
            newMail.Subject = "Get DOM to stop bugging me.";
            newMail.Recipients.Add("emailaddress");


            var curpwd = pwd();

            newMail.Attachments.Add(curpwd + "myattachment.txt");

            newMail.SaveAs("billburr.msg");

            

            

            Console.WriteLine(curpwd);
            Console.ReadKey();
        }

        public static string pwd()
        {
            var location = System.Reflection.Assembly.GetCallingAssembly().Location;

            var lastIndexOf = location.LastIndexOf("\\");
            var locationDir = location.Substring(0, lastIndexOf + 1);

            return locationDir;
        }
    }
}
