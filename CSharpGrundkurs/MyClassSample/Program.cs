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

            lebewesen.gewicht = -5;

            lebewesen.SetGewicht(90);
            lebewesen.SetBezeichnung("Hund");
            lebewesen.SetBezeichnung(string.Empty);
        }
    }

    //Klasse -> Zur Designzeit spricht man von einer Klasse
    public class Lebewesen
    {
        #region Klassen-Variablen oder Fields (Felder) sind private
        private string bezeichnung; //private Variablen lassen sich innerhalb einer Klasse nur ansprechen
        private DateTime birthday;

        public int gewicht;
        //Private Variablen können nur innerhalb deren Klasse angesprochen werden
        public void GeburtEinerKatze()
        {
            bezeichnung = "Katze";
            birthday = DateTime.Now;
        }

        public void SetGewicht(int gewicht)
        {
            if (gewicht < 0)
                gewicht = 0;
            //this Bedeutet -> Variable Gewicht der eigenen Klasse 
            this.gewicht = gewicht;
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

        #endregion
    }
}
