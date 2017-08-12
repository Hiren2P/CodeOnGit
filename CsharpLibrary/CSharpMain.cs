using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Configuration;
using System.Net.Mail;

namespace CsharpLibrary
{
    public class CSharpMain
    {
        static void Main(string[] args)
        {
            Console.Title = "C# Library";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to C# library");

            //Datasets ds = new Datasets();
            //ExportToFiles.ExportToExcel(ds.GenerateDataSet());

            //string plainText;
            //Console.Write("Enter text to encrypt : ");
            //plainText = Console.ReadLine();
            //EncryptionDecryptionAlgorithms.HashAlgorithms obj = new EncryptionDecryptionAlgorithms.HashAlgorithms();

            //Console.WriteLine("MD5 Encryption(Hashed) of " + plainText + " :" + obj.EncryptText(plainText, true, EncryptionDecryptionAlgorithms.HashName.MD5));
            //Console.WriteLine("MD5 Encryption(Not Hashed) of " + plainText + " :" + obj.EncryptText(plainText, false, EncryptionDecryptionAlgorithms.HashName.MD5));
            //Console.WriteLine();
            //Console.WriteLine("SHA1 Encryption(Hashed) of " + plainText + " :" + obj.EncryptText(plainText, true, EncryptionDecryptionAlgorithms.HashName.SHA1));
            //Console.WriteLine("SHA1 Encryption(Not Hashed) of " + plainText + " :" + obj.EncryptText(plainText, false, EncryptionDecryptionAlgorithms.HashName.SHA1));
            //Console.WriteLine();
            //Console.WriteLine("SHA256 Encryption(Hashed) of " + plainText + " :" + obj.EncryptText(plainText, true, EncryptionDecryptionAlgorithms.HashName.SHA256));
            //Console.WriteLine("SHA256 Encryption(Not Hashed) of " + plainText + " :" + obj.EncryptText(plainText, false, EncryptionDecryptionAlgorithms.HashName.SHA256));
            //Console.WriteLine();
            //Console.WriteLine("SHA384 Encryption(Hashed) of " + plainText + " :" + obj.EncryptText(plainText, true, EncryptionDecryptionAlgorithms.HashName.SHA384));
            //Console.WriteLine("SHA384 Encryption(Not Hashed) of " + plainText + " :" + obj.EncryptText(plainText, false, EncryptionDecryptionAlgorithms.HashName.SHA384));
            //Console.WriteLine();
            //Console.WriteLine("SHA512 Encryption(Hashed) of " + plainText + " :" + obj.EncryptText(plainText, true, EncryptionDecryptionAlgorithms.HashName.SHA512));
            //Console.WriteLine("SHA512 Encryption(Not Hashed) of " + plainText + " :" + obj.EncryptText(plainText, false, EncryptionDecryptionAlgorithms.HashName.SHA512));

            //ConnectWithFTP objConnectFTP = new ConnectWithFTP();
            ////objConnectFTP.ConnectToFTP(@"D:\SIEVServiceTest\InternalServerPath");
            //objConnectFTP.Upload(@"D:\ScanDirectory\Incoming\B0639151_20130808084115739_SIEV_201308080841283844.txt");

            //FolderWatcher.WatchFolder("D:\\ScanDirectory\\");

            //FileReadingWriting.ReadFile("../../text.txt");

            //CSharpDataTypes obj = new CSharpDataTypes();
            //obj.CallLocalMethods();

            //MixedCodes obj = new MixedCodes();
            //obj.CallLocalMethods();

            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Host = ConfigurationManager.AppSettings["mailServer"];

            //MailMessage objMailMessage = new MailMessage();
            //MailAddress fromMailAddress = new MailAddress(ConfigurationManager.AppSettings["fromEmail"], "Email component");//Sender of the mail
            //MailAddress toMailAddress = new MailAddress("hiren2.p@tcs.com");//To
            //MailAddress ccMailAddress = new MailAddress("hiren2.p@tcs.com");//CC
            //objMailMessage.Priority = MailPriority.High;
            //objMailMessage.From = fromMailAddress;
            //objMailMessage.To.Add(toMailAddress);
            //objMailMessage.CC.Add(toMailAddress);
            //Attachment fileAttachment = new Attachment("../../Attachment.txt");
            //objMailMessage.Attachments.Add(fileAttachment); ;

            ////Dictionary<string, string> paramList = new Dictionary<string, string>();

            ////string templatePath = "../../EmailTemplates.xml";
            ////bool isMailSent = false;

            ////EmailComponent objSendMail = new EmailComponent();
            ////objSendMail.SendMailWithTemplateContent(smtpClient, objMailMessage, templatePath, Templates.SayHello, paramList, true, ref isMailSent);
            ////if (isMailSent)
            ////{
            ////    Console.WriteLine("Email has been sent successfully.");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("Some problem with email component.");
            ////}

            //objMailMessage.Subject = "Hello from auto-generated mail";
            //objMailMessage.Body = "Hi<br/>This is mail body.<br/>This is auto-generated email. Please do not respond to this mail.";
            //bool isMailSent = false;
            //EmailComponent objSendMail = new EmailComponent();
            //objSendMail.SendMailWithUserMessage(smtpClient, objMailMessage, true, ref isMailSent);
            //if (isMailSent)
            //{
            //    Console.WriteLine("Email has been sent successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Some problem with email component.");
            //}

            //DelegateAndEventHandler objDelegateAndEventHandler = new DelegateAndEventHandler();
            //objDelegateAndEventHandler.TestHandler();

            Delegates obj = new Delegates(); ;
            //ConsumeWCFService.CallServiceUsingProxy();//proxy
            //Console.WriteLine("----------------------------------------------------------");
            //ConsumeWCFService.CallServiceUsingChannelFactory();//ChannelFactory

            Console.ReadKey();
        }

        public static class Templates
        {
            public const string SayHello = "Say Hello Template";
        }
    }
}
