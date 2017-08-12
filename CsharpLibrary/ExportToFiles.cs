using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;

namespace CsharpLibrary
{
    public class ExportToFiles
    {
        public static void ExportToExcel(DataSet dsExport)
        {
            try
            {
                Microsoft.Office.Interop.Excel.ApplicationClass excelApp = new ApplicationClass();//New excel application
                excelApp.Visible = false;
                object oMissing = System.Reflection.Missing.Value;
                string excelFileName = "Excel_" + DateTime.Now.ToString("ddMMyyyyHHMMss") + ".xls";
                Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Add(oMissing);//New excel book

                //Delete sheet#2 and sheet#3
                ((Microsoft.Office.Interop.Excel.Worksheet)excelBook.Sheets["Sheet2"]).Delete();
                ((Microsoft.Office.Interop.Excel.Worksheet)excelBook.Sheets["Sheet3"]).Delete();
                Microsoft.Office.Interop.Excel.Worksheet workingSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Sheets["Sheet1"];//Sheet#1 set as working sheet
                workingSheet.Select(true);
                workingSheet.Name = "Exported Dataset";

                //Header cell naming & formatting
                int columnCounter = 1;
                int rowCounter = 1;
                foreach (DataColumn dataColumn in dsExport.Tables[0].Columns)
                {
                    Microsoft.Office.Interop.Excel.Range headerCell = ((Microsoft.Office.Interop.Excel.Range)workingSheet.Cells[rowCounter, columnCounter]);
                    headerCell.Value = dataColumn.ColumnName;
                    headerCell.Font.Bold = true;
                    headerCell.Locked = true;
                    headerCell.Columns.AutoFit();//Auto width to columns
                    columnCounter++;
                }
                rowCounter++;
                columnCounter = 1;

                //Data row binding
                foreach (DataRow row in dsExport.Tables[0].Rows)
                {
                    int col = 1;
                    foreach (DataColumn column in dsExport.Tables[0].Columns)
                    {
                        Microsoft.Office.Interop.Excel.Range dataCell = ((Microsoft.Office.Interop.Excel.Range)workingSheet.Cells[rowCounter, col]);
                        dataCell.Value = row.Field<string>(column);
                        col++;
                    }
                    rowCounter++;
                }
                excelBook.SaveAs(excelFileName);
                Console.WriteLine("File saved to : " + Directory.GetCurrentDirectory() + excelFileName);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
