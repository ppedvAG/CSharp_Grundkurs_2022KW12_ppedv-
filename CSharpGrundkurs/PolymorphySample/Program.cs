using System;
using System.Collections.Generic;

namespace PolymorphySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> namensListe = new List<string>();
            namensListe.Add("Harry");
            namensListe.Add("Otto");

            List<PDFDocument> pdfDocList = new List<PDFDocument>();
            pdfDocList.Add(new PDFDocument());
            pdfDocList.Add(new PDFDocument());


            List<DocumentBase> documentList = new List<DocumentBase>();

            documentList.Add(new PDFDocument());
            documentList.Add(new ExcelDocument());
            documentList.Add(new WordDocument());


            foreach(DocumentBase current in documentList)
            {
                current.Print(); //Alle Dokumente können gedruckt werden 


                //sample 2 -> wir können immer noch wissen, welcher Typ verwendet wird (WordDocument / PDFDcoument /ExcelDocument) 
                if (current.GetType() == typeof(PDFDocument))
                {
                    Console.WriteLine("PDF Dokument kann... ");
                }

                //Sample 3 is operator prüft auch nach dem Typ (kürzer Schreibweise) 
                if (current is PDFDocument castedPDFDoc )
                    Console.WriteLine("PDF Dokuemtn kann ... " + castedPDFDoc.Name + castedPDFDoc.Title + castedPDFDoc.CompressRate);
            }


            


            #region Sample 1
            // Es ist ein WordDocument Objekt, aber aktuell bieten wir nur die Variablen/Methoden Schnittmenge aus DocumentBase
            DocumentBase myWordDoc2 = new WordDocument();
            myWordDoc2.Title = "C#";
            myWordDoc2.Name = "Steve Smith";
            myWordDoc2.Print();

            if (myWordDoc2 is WordDocument wordDocument)
            {
                wordDocument.ConvertWordToOpenXML();
            }
            #endregion


            //DocumentBase beinhaltet weiterhin alle Properties aus PDF /Doc /ExcelDocument
            #region Sample 2 
            WordDocument wordDocument1 = new WordDocument();
            wordDocument1.Title = "C#";
            wordDocument1.Name = "von Steve Smith";
            wordDocument1.Verzeichnisstruktur = "C:\\Windows\\Temp";
            wordDocument1.Copyright = "ppedv AG";


            DocumentBase myBaseType = wordDocument1;

            if (myBaseType is WordDocument myWordDoc)
            {
                Console.WriteLine(myWordDoc.Title);
                Console.WriteLine(myWordDoc.Name);
                Console.WriteLine(myWordDoc.Verzeichnisstruktur);
                Console.WriteLine(myWordDoc.Copyright );

            }
            #endregion
        }


        public static void MakeBackup (DocumentBase docbase)
        {
            switch (docbase)
            {
                case PDFDocument pdfDoc:
                    Console.WriteLine("Backup wird von PDF erstellt");
                    break;

                case WordDocument wordDoc:
                    Console.WriteLine("Backup wird von WordDocument erstellt");
                    break;

                case ExcelDocument wordDoc:
                    Console.WriteLine("Backup wird von WordDocument erstellt");
                    break;

                default:
                    Console.WriteLine("this object is not available");
                    break;
            }
        }
    }

    public abstract class DocumentBase
    {
        public string Name { get; set; }
        public string Title { get; set; }

        public abstract void Print();
    }

    public class PDFDocument : DocumentBase
    {
        public int CompressRate { get; set; }

        public override void Print()
        {
            Console.WriteLine("PDF wird gedruckt");
        }
    }

    public class WordDocument : DocumentBase
    {
        public string Copyright { get; set; }
        public string Verzeichnisstruktur { get; set; }
        
        public override void Print()
        {
            Console.WriteLine("Ein Word-Document wird geprintet");
        }

        public void ConvertWordToOpenXML()
        {
            Console.WriteLine("Konventiert");
        }
        public void MakeWatermark()
        {
            Console.WriteLine("Watermark");
        }
    }

    public class ExcelDocument : DocumentBase
    {
        public override void Print()
        {
            Console.WriteLine("Drucke ein Excel-Dokument aus");
        }

        
    }
}
