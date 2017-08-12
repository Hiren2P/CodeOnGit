using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CsharpLibrary
{
    public class Datasets
    {
        public DataSet GenerateDataSet()
        {
            try
            {
                DataSet ds = new DataSet();
                DataColumn dcEmpId = new DataColumn("EmpId");
                DataColumn dcEmpName = new DataColumn("EmpName");
                DataColumn dcCity = new DataColumn("City");
                ds.Tables.Add("Employees");
                ds.Tables[0].Columns.Add(dcEmpId);
                ds.Tables[0].Columns.Add(dcEmpName);
                ds.Tables[0].Columns.Add(dcCity);

                ds.Tables[0].Rows.Add(1, "A", "A");
                ds.Tables[0].Rows.Add(2, "B", "B");
                ds.Tables[0].Rows.Add(3, "C", "C");
                ds.Tables[0].Rows.Add(4, "D", "D");
                ds.Tables[0].Rows.Add(5, "E", "E");
                ds.Tables[0].Rows.Add(6, "F", "F");
                ds.Tables[0].Rows.Add(7, "G", "G");
                ds.Tables[0].Rows.Add(8, "H", "H");
                ds.Tables[0].Rows.Add(9, "I", "I");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
