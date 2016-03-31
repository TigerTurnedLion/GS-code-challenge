using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Data.OleDb;

namespace GS_Data_API.Models
{
    public class GSData
    {
        public string AccountName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string LoanNumber { get; set; }
        public string LoanAmount { get; set; }
        public string InterestRate { get; set; }
        public string MaturityDate { get; set; }

        public List<GSData> getData()
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Content") + "/GS_challenge_data.xls";
            List<GSData> data = new List<GSData>();

            string con =
              @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" +
              @"Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [GS_challenge_data$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        data.Add(new GSData()
                        {
                            AccountName = (string)dr[0],
                            Street = (string)dr[1],
                            City = (string)dr[2]
                            ,
                            State = (string)dr[3],
                            FirstName = (string)dr[4],
                            LastName = (string)dr[5],
                            Title = (string)dr[6],

                            Phone = (string)dr[7],
                            LoanNumber = dr[8].ToString(),
                            LoanAmount = dr[9].ToString(),
                            InterestRate = dr[10].ToString(),
                            MaturityDate = ((DateTime)dr[11]).ToString("MM/dd/yyyy")
                        });

                    }
                }
            }

            return data;
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

    }
}