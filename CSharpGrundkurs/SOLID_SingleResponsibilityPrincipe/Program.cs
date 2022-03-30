using System;

namespace SOLID_SingleResponsibilityPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    #region Bad Code

    public class BadEmployee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        public string ReportType { get; set; }

        /// <summary>
        /// This method used to insert into employee table
        /// </summary>
        /// <param name="em">Employee object</param>
        /// <returns>Successfully inserted or not</returns>
        public bool InsertIntoEmployeeTable(BadEmployee em)
        {
            // Insert into employee table.
            return true;
        }
        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>


        public void GenerateReport(BadEmployee em)
        {
            if (ReportType == "CRS")
            {
                // Report generation with employee data in Crystal Report.
            }
            if (ReportType == "PDF")
            {
                // Report generation with employee data in PDF.
            }
        }
    }

    #endregion


    public class Employee //POCO Objects (Entities)
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    //Repository kommuniziert mit der Tabelle Employee
    public class EmployeeRepository
    {

        //Erstelle einen Datensatz in der DB
        public void Create (Employee employee)
        {
            //Speicher Employee in die DB
        }

        //Lesen / Updaten oder Löschen
        //...
    }


    public class ReportGenerator
    {
        public string ReportType { get; set; }
        public void GenerateReport(Employee em)
        {
            if (ReportType == "CRS")
            {
                // Report generation with employee data in Crystal Report.
            }
            if (ReportType == "PDF")
            {
                // Report generation with employee data in PDF.
            }
        }
    }
}
