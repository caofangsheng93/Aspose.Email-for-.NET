﻿/* This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Email for .NET 
   API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq 
   for more information. If you do not wish to use NuGet, you can manually download 
   Aspose.Email for .NET API from http://www.aspose.com/downloads, 
   install it and then add its reference to this project. For any issues, questions or suggestions 
   please feel free to contact us using http://www.aspose.com/community/forums/default.aspx            
*/

using Aspose.Email.Mail;
namespace CSharp.SMTP
{
    class InsertHeaderAtSpecificLocation
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_IMAP();
            string loadFile = dataDir + "InsertHeaders.eml";
            MailMessage eml = MailMessage.Load(loadFile);
            eml.Headers.Insert("secret-header", "mystery1");
            eml.Save(dataDir + "Updated-MessageHeaders.eml");
        }
    }
}
