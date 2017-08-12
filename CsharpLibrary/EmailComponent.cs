using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Xml;

namespace CsharpLibrary
{
    public class EmailComponent
    {
        #region Send mail with template content
        /// <summary>
        /// Method sends emails with subject and body specified in XML templates
        /// </summary>
        /// <param name="smtpClient">SMTP configuration object</param>
        /// <param name="objMailMessage">Email specifications(To, From, CC)</param>
        /// <param name="templatePath">XML email templates path</param>
        /// <param name="templateName">XML template name to be used to compose email subject and body</param>
        /// <param name="templateParameters">Template parameters</param>
        /// <param name="isBodyHTML">True if email body is HTML, else false</param>
        /// <param name="isMailSent">True if email is sent successfully, else false</param>
        public void SendMailWithTemplateContent(SmtpClient smtpClient, MailMessage objMailMessage, string templatePath, string templateName, Dictionary<string, string> templateParameters, bool isBodyHTML, ref bool isMailSent)
        {
            try
            {
                if (smtpClient.Host != null & objMailMessage != null)
                {
                    if (objMailMessage.From != null && (objMailMessage.To != null && objMailMessage.To.Count() > 0) && !string.IsNullOrEmpty(templateName))
                    {
                        XmlDocument emailTemplates = new XmlDocument();
                        emailTemplates.Load(templatePath);
                        XmlNodeList xNodeList = emailTemplates.SelectNodes("/EmailTemplates/Template[@Name='" + Convert.ToString(templateName) + "']");

                        if (xNodeList != null && xNodeList.Count == 1)
                        {
                            Dictionary<string, string> emailDetails = new Dictionary<string, string>();

                            emailDetails.Add("Subject", xNodeList[0]["Subject"].InnerText);
                            emailDetails.Add("FullMailBody", string.Concat(xNodeList[0]["Salutation"].InnerText, xNodeList[0]["Body"].InnerText, xNodeList[0]["Signature"].InnerText, xNodeList[0]["AdditionalNote"].InnerText));
                            if (templateParameters != null & templateParameters.Count() > 0)
                            {
                                foreach (KeyValuePair<string, string> pair in templateParameters)
                                {
                                    if (emailDetails.Where(param => param.Key == "FullMailBody").FirstOrDefault().Value.ToString().Contains(Convert.ToString(pair.Key)))
                                    {
                                        string tempMailBody = string.Empty;
                                        tempMailBody = emailDetails.Where(param => param.Key == "FullMailBody").FirstOrDefault().Value.ToString().Replace(pair.Key.ToString(), pair.Value.ToString());
                                        emailDetails["FullMailBody"] = tempMailBody;
                                    }
                                }
                            }

                            objMailMessage.IsBodyHtml = isBodyHTML;
                            objMailMessage.Subject = emailDetails["Subject"];
                            objMailMessage.Body = emailDetails["FullMailBody"];
                            smtpClient.Send(objMailMessage);
                            isMailSent = true;
                        }
                        else if (xNodeList.Count > 1)
                        {
                            isMailSent = false;
                            throw new Exception("Ambiguous email templates (" + templateName.ToString() + ") found.");
                        }
                    }
                    else if (objMailMessage.From == null)
                    {
                        isMailSent = false;
                        throw new Exception("From address was not specified.");
                    }
                    else if (objMailMessage.To == null | objMailMessage.To.Count() == 0)
                    {
                        isMailSent = false;
                        throw new Exception("To address(es) was/were not specified.");
                    }
                    else if (string.IsNullOrEmpty(templateName))
                    {
                        isMailSent = false;
                        throw new Exception("Please specify email template.");
                    }
                    else
                    {
                        isMailSent = false;
                        throw new Exception("Some issue with email component.");
                    }
                }
                else
                {
                    isMailSent = false;
                    if (smtpClient.Host == null)
                    {
                        throw new Exception("The SMTP host was not specified.");
                    }
                    if (objMailMessage == null)
                    {
                        throw new Exception("Please specify mail details.");
                    }
                }
            }
            catch (Exception ex)
            {
                isMailSent = false;
                throw ex;
            }
        }
        #endregion Send mail with template content

        #region Send mail with user message(No templates)
        /// <summary>
        /// Method sends emails with user specified subject and body(Not template specified)
        /// </summary>
        /// <param name="smtpClient">SMTP configuration object</param>
        /// <param name="objMailMessage">Email specifications(To, From, CC)</param>
        /// <param name="isBodyHTML">True if email body is HTML, else false</param>
        /// <param name="isMailSent">True if email is sent successfully, else false</param>
        public void SendMailWithUserMessage(SmtpClient smtpClient, MailMessage objMailMessage, bool isBodyHTML, ref bool isMailSent)
        {
            try
            {
                if (smtpClient.Host != null & objMailMessage != null)
                {
                    if (objMailMessage.From != null && (objMailMessage.To != null && objMailMessage.To.Count() > 0))
                    {
                        objMailMessage.IsBodyHtml = isBodyHTML;
                        smtpClient.Send(objMailMessage);
                        isMailSent = true;
                    }
                    else if (objMailMessage.From == null)
                    {
                        isMailSent = false;
                        throw new Exception("From address was not specified.");
                    }
                    else if (objMailMessage.To == null | objMailMessage.To.Count() == 0)
                    {
                        isMailSent = false;
                        throw new Exception("To address(es) was/were not specified.");
                    }
                }
                else
                {
                    isMailSent = false;
                    if (smtpClient.Host == null)
                    {
                        throw new Exception("The SMTP host was not specified.");
                    }
                    if (objMailMessage == null)
                    {
                        throw new Exception("Please specify mail details.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Send mail with user message(No templates)
    }
}
