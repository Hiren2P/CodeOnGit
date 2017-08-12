using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace CsharpLibrary
{
    public class FileReadingWriting
    {
        public static void ReadFile(string filePath)
        {
            List<string> fileLines = new List<string>();
            string line;
            var lines = new List<string>();
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    int lineCounter = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        lines.Add(line);
                        fileLines.Add(line);
                        lineCounter++;
                    }
                    Console.WriteLine("Line counter : {0}", lineCounter);
                    WriteFile(fileLines);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
            else
            {
                Console.WriteLine("File does not exist @ provided path.");
            }
        }

        public static void WriteFile(List<string> fileLines)
        {
            try
            {
                string strTransmissionTotal = string.Empty;
                strTransmissionTotal = fileLines.Where(transTotal => transTotal.Substring(0, 3) == "12;").Count() == 0 ? string.Empty : fileLines.Where(transTotal => transTotal.Substring(0, 3) == "12;").First().ToString().TrimEnd();

                StringBuilder fileContents = new StringBuilder();
                StringBuilder sbAgency = new StringBuilder();
                StringBuilder sbStationPayee = new StringBuilder();
                StringBuilder sbInvoice = new StringBuilder();

                if (fileLines.Count > 0 & fileLines != null)
                {
                    fileLines.Add("--End of file--");
                    for (int iter = 0; iter < fileLines.Count - 1; iter++)
                    {
                        if (fileLines[iter].Substring(0, 3) == "21;")
                        {
                            sbAgency = new StringBuilder();
                            sbAgency.AppendLine(fileLines[iter]);
                        }

                        if (fileLines[iter].Substring(0, 3) == "22;" | fileLines[iter].Substring(0, 3) == "23;" | fileLines[iter].Substring(0, 3) == "24;" | fileLines[iter].Substring(0, 3) == "25;")
                        {
                            if (fileLines[iter].Substring(0, 3) == "22;")
                            {
                                sbStationPayee = new StringBuilder();
                            }
                            sbStationPayee.AppendLine(fileLines[iter]);
                            if (fileLines[iter].Substring(0, 3) == "23;" & fileLines[iter + 1] != null & !(fileLines[iter + 1].Substring(0, 3) == "24;" | fileLines[iter + 1].Substring(0, 3) == "25;"))
                            {
                                sbStationPayee = new StringBuilder();
                            }
                            else
                            {
                            }
                        }

                        if (fileLines[iter].Substring(0, 3) == "31;" | fileLines[iter].Substring(0, 3) == "32;" | fileLines[iter].Substring(0, 3) == "33;" | fileLines[iter].Substring(0, 3) == "41;" | fileLines[iter].Substring(0, 3) == "51;" | fileLines[iter].Substring(0, 3) == "52;" | fileLines[iter].Substring(0, 3) == "42;" | fileLines[iter].Substring(0, 3) == "34;")
                        {
                            sbInvoice.AppendLine(fileLines[iter]);
                            //if (fileLines[iter].Substring(0, 3) == "34;")
                            //fileLines[iter].Substring(0, 3) == "34;" | 
                            if (fileLines[iter].Substring(0, 3) == "34;" | ((!string.IsNullOrEmpty(fileLines[iter + 1]) & (fileLines[iter + 1].Substring(0, 3) == "21;" | fileLines[iter + 1].Substring(0, 3) == "22;" | fileLines[iter + 1].Substring(0, 3) == "31;" | fileLines[iter + 1].Substring(0, 3) == "12;"))))
                            {
                                FileStream fs = null;
                                Thread.Sleep(1);
                                string fileLoc = @"D:\GeneratedFiles\" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
                                if (!File.Exists(fileLoc))
                                {
                                    using (StreamWriter sw = new StreamWriter(fileLoc))
                                    {
                                        fileContents.Append(sbAgency.ToString());
                                        fileContents.AppendLine(sbStationPayee.ToString().TrimEnd());
                                        fileContents.AppendLine(sbInvoice.ToString().TrimEnd());
                                        fileContents.Append(strTransmissionTotal);
                                        sw.WriteLine(fileContents.ToString().TrimEnd());
                                        sbInvoice = new StringBuilder();//Fulsh sbInvoice
                                        fileContents = new StringBuilder();
                                    }
                                }
                                else
                                {
                                    using (fs = File.OpenWrite(fileLoc))
                                    {
                                        using (StreamWriter sw = new StreamWriter(fileLoc))
                                        {
                                            fileContents.Append(sbAgency.ToString());
                                            fileContents.AppendLine(sbStationPayee.ToString());
                                            fileContents.AppendLine(sbInvoice.ToString());
                                            fileContents.Append(strTransmissionTotal);
                                            sw.WriteLine(fileContents.ToString().TrimEnd());
                                            sbInvoice = new StringBuilder();//Fulsh sbInvoice
                                            fileContents = new StringBuilder();
                                        };
                                    };
                                }
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File has no contents.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
