using System;

namespace MyClassSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Typen/Klassen deklaration
            Lebewesen lebewesen;

            ///Instanziierung -> ab einer Instanziierung kann ich auf die Instanz (Klasse) zugreifen
            lebewesen = new Lebewesen();
            lebewesen.SetGewicht(90);
            lebewesen.SetBezeichnung("Hund");
            lebewesen.SetBezeichnung(string.Empty);

            Lebewesen lebewesen1 = new Lebewesen("Wau Wau", DateTime.Now); //Konstruktoren initialisieren das Objekt Lebewesen



            lebewesen.Bezeichnung = "Duck";
        }
    }

    //Klasse -> Zur Designzeit spricht man von einer Klasse
    public class Lebewesen
    {
        #region Klassen-Variablen oder Fields (Felder) sind private
        private string bezeichnung; //private Variablen lassen sich innerhalb einer Klasse nur ansprechen
        private DateTime birthday;

      
        //Private Variablen können nur innerhalb deren Klasse angesprochen werden
        public Lebewesen()
        {
        }

        public Lebewesen(string bezeichnung, DateTime birthday)
        {
            Bezeichnung = bezeichnung;
            Birthday = birthday;
        }
         
        public void GeburtEinerKatze()
        {
            bezeichnung = "Katze";
            Birthday = DateTime.Now;
        }

        public void SetGewicht(int gewicht)
        {
            //if (gewicht < 0)
            //    gewicht = 0;
            ////this Bedeutet -> Variable Gewicht der eigenen Klasse 
            //this.gewicht = gewicht;
        }

        public void SetBezeichnung(string bez)
        {

            //bevor ich den Wert zuweise, kann ich den übergebenen Wert überprüfen
            if (bez == string.Empty)
                bez = "Katze";

            bezeichnung = bez;
        }

        public string GetBezeichnung()
        {
            return bezeichnung;
        }

        public string Bezeichnung
        {
            set
            {
                //Set hat eine Hilfsvariabe, die nennt sich 'value'
                if (string.IsNullOrEmpty(value))
                    bezeichnung = "Katze";
                else
                    bezeichnung = value;
            }

            get
            {
                return bezeichnung;
            }
        }

        public DateTime Birthday 
        { 
            get => birthday; 
            set => birthday = value; 
        }

        public void Essen()
        {
            Console.WriteLine($"{bezeichnung} isst gerade sehr laut");
        }

        #endregion
    }


    public class Auto
    {
        private string brand;
        private string model;
        

        public string Brand
        {
            set
            {
                //if ...
                brand = value;
            }

            get
            {
                return brand;
            }
        }

        public string Model
        {
            //Achtung geht nur Einzeil -> Wer eine validierung sich wünscht, bitte übergeordnetes Beispiel


            //set
            //{
            //    //if ...
            //    model = value;
            //}
            set => model = value;
            get => model;
        }


        //Auto Property
        public int PS { get; set; } //Auto Properties legen ihre Field-Variable beim kompilieren automatisch an 
    }
}
