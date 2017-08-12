using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace CsharpLibrary
{
    public class ConnectWithFTP
    {
        public void ConnectToFTP(string localPath)
        {
            FTP_CLASS.FTP DFTP = new FTP_CLASS.FTP();
            int Retry_Count = 3;
            Boolean Successful = true;

            //Connect to FTP Server
            string I_FTP_SERVER = "pgmftp.mbxg.com";//ftp://pgmftp.mbxg.com/UAT/
            string I_FTP_USER = "pgmsiev";
            string I_FTP_PASSWORD = "pgM513v!";
            string I_FTP_PATH = "/UAT";

            if (!DFTP.ConnectToServer(I_FTP_SERVER, 21, FTP_CLASS.FTP.ConnectionModes.Active, I_FTP_USER, I_FTP_PASSWORD))
            {
                Successful = false;

                for (int i = 1; i <= Retry_Count; i++)
                {
                    if (DFTP.ConnectToServer(I_FTP_SERVER, 21, FTP_CLASS.FTP.ConnectionModes.Active, I_FTP_USER, I_FTP_PASSWORD))
                    {
                        Successful = true;
                        EventLog e = new EventLog();
                        e.Source = "H2P Developments";
                        e.WriteEntry("Point1");
                        break;
                    }
                }

                if (!Successful)
                {
                    EventLog e = new EventLog();
                    e.Source = "H2P Developments";
                    e.WriteEntry("Point2");
                }
                else
                {
                    EventLog e = new EventLog();
                    e.Source = "H2P Developments";
                    e.WriteEntry("Point2.1");
                }
            }
            else
            {
                EventLog e = new EventLog();
                e.Source = "H2P Developments";
                e.WriteEntry("Point3");
            }

            if (Successful)
            {
                EventLog e = new EventLog();
                e.Source = "H2P Developments";
                e.WriteEntry("Point4");
                if (!DFTP.SetWorkingDir(I_FTP_PATH))
                {

                    Successful = false;
                    for (int i = 1; i <= Retry_Count; i++)
                    {
                        if (DFTP.SetWorkingDir(I_FTP_PATH))
                        {
                            Successful = true;
                            EventLog eLog = new EventLog();
                            eLog.Source = "H2P Developments";
                            eLog.WriteEntry("Point5");
                            break;
                        }
                    }
                    if (!Successful)
                    {
                        EventLog eLog = new EventLog();
                        eLog.Source = "H2P Developments";
                        eLog.WriteEntry("Point6");
                    }
                    else
                    {
                        EventLog eLog = new EventLog();
                        eLog.Source = "H2P Developments";
                        eLog.WriteEntry("Point7");
                    }
                }
                else
                {
                    EventLog eLog = new EventLog();
                    eLog.Source = "H2P Developments";
                    eLog.WriteEntry("Point8");
                }
            }

            if (Successful)
            {
                EventLog eLog = new EventLog();
                eLog.Source = "H2P Developments";
                eLog.WriteEntry("Point9");
                eLog.WriteEntry("FTP path : " + I_FTP_SERVER + I_FTP_PATH);
                eLog.WriteEntry("Local folder : " + localPath);
                if (Directory.Exists(localPath))
                {
                    foreach (var file in new DirectoryInfo(localPath).GetFiles().OrderBy(P => P.CreationTime))
                    {
                        DFTP.PutFile(file.FullName, file.Name);
                    }
                }
            }
        }

        public bool Upload(string filename)
        {
            string ftpServerIP = "pgmftp.mbxg.com/UAT";//ftp://pgmftp.mbxg.com/UAT/
            string ftpUserID = "pgmsiev";
            string ftpPassword = "pgM513v!";

            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileInf.Name));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID,
                                                       ftpPassword);

            // By default KeepAlive is true, where the control connection is 
            // not closed after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            reqFTP.Proxy = new WebProxy();
            reqFTP.Proxy = null;

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the 
                    // FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("FTP upload error.");
            }
        }

    }
}
