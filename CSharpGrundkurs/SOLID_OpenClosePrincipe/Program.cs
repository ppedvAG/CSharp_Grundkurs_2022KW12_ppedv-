using System;

namespace SOLID_OpenClosePrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

  
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }



    #region BadCode
    public class BadReportGenerator
    {
        public string ReportType { get; set; } = string.Empty;

        //Negative folgen -> Methode GenerateReport wird zuviele Zeilen beinhalten + mehrere Dlls werden hier anprogrammiert. 
        public void GenerateReport(Employee em)
        {
            if (ReportType == "CR")
            {
                //Möglickeiten mit Crystal Report Dll zusammen zu arbeiten
            }
            else if (ReportType == "List10")
            {

            }
            else if (ReportType == "PDF")
            {

            }
        }
    }


    #endregion


    //Open Part
    public abstract class ReportGenerator
    {
        protected string OutputVerzeichnis { get; set; }
        public abstract void GenerateReport(Employee em);


        public void Init()
        {

        }

        public virtual string Info()
        {
            return "";
        }
    }

    //Weitere Variante
    public interface IReportGenerator
    {
        public void GenerateReport(Employee em);
    }


    //Cloese Part
    public class PDFReportGenerator : ReportGenerator
    {
        public override void GenerateReport(Employee em)
        {
            //Wird PDF erstellt
        }
    }

    //Close-Prinzip Implementiert 
    public class CrystalReports : ReportGenerator
    {
        public override void GenerateReport(Employee em)
        {

        }

        //Template Vorlagen
        //Template Verzeichnis
    }
}
