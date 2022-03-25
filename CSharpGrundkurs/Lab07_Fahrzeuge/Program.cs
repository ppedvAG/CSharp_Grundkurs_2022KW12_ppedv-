using System;

namespace Lab07_Fahrzeuge
{
    public class Fahrzeug
    {
        #region Lab 06
        public string Name { get; set; }
        public int MaxGeschwindigkeit { get; set; }
        public int AktGeschwindigkeit { get; set; }
        public double Preis { get; set; }
        public bool MotorLäuft { get; set; } //true = Motor läuft / false = Motor ist aus


        public Fahrzeug()
        {
            AnzahlFahrzeuge++;
        }

        public Fahrzeug(string name, int maxG, double preis)
            :this()
        {
            Name = name;
            this.MaxGeschwindigkeit = maxG;
            this.Preis = preis;
            this.AktGeschwindigkeit = 0;
            this.MotorLäuft = false;
        }

        public void StarteMotor()
        {
            //läuft der Motor schon
            if (MotorLäuft)
            {
                Console.WriteLine($"Der Motor von {this.Name} läuft bereits.");
            }
            else
            {
                this.MotorLäuft = true; //Motor wird gestartet
                Console.WriteLine($"Der Motor von {this.Name} wurde gestartet.");
            }
        }

        public void StoppeMotor()
        {
            //Prüfen ob der Motor schon ausgeschaltet ist
            if (MotorLäuft == false) // if(!MotorLäuft)
            {
                Console.WriteLine($"Der Motor von {this.Name} ist bereits gestoppt");
            }
            else
            {
                this.MotorLäuft = false; //Motor wird ausgeschaltet
                Console.WriteLine($"Der Motor von {this.Name} wurde gestoppt.");
            }
        }

        public void Beschleunige(int offsetKmh)
        {
            if (MotorLäuft)
            {
                if (this.AktGeschwindigkeit + offsetKmh > this.MaxGeschwindigkeit) //Prüfung: AktGeschwindigkeit Soll MaxGeschwindigkeit nicht überschreiten 
                {
                    this.AktGeschwindigkeit = this.MaxGeschwindigkeit;
                }
                else if (this.AktGeschwindigkeit + offsetKmh < 0)//Prüfung: AktGeschwindigkeit nicht unter 0 sein 
                {
                    this.AktGeschwindigkeit = 0;
                }
                else
                {
                    this.AktGeschwindigkeit += offsetKmh; //normale Beschleunigen
                }
            }
        }

        //Methode zur Ausgabe von Objektinformationen
        public string Info()
        {
            if (this.MotorLäuft)
                return $"{this.Name} kostet {this.Preis}€ und fährt momentan mit {this.AktGeschwindigkeit} von maximal {this.MaxGeschwindigkeit}km/h.";
            else
                return $"{this.Name} kostet {this.Preis}€ und könnte maximal {this.MaxGeschwindigkeit}km/h fahren.";
        }
        #endregion

        #region Lab 07: Statische Member, Destruktor

 

        public static int AnzahlFahrzeuge { get; set; } = 0;

        public static string ZeigeAnzahlFahrzeuge()
        {
            return $"Es wurden {AnzahlFahrzeuge} Fahrzeuge gebaut.";
        }

        ~Fahrzeug()
        {
            AnzahlFahrzeuge--;
            Console.WriteLine($"{this.Name} wurde gerade verschrottet.");
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Lab 06
            //Lab07 ist Erweiterung von Lab06
            #endregion

            #region Lab 07: GC und statische Member

            //Generierung von div. Objekten (zur Überschwemmung des RAM)
            Fahrzeug fz1 = new Fahrzeug("BMW", 230, 25999.99);
            for (int i = 0; i < 1000; i++)
            {
                fz1 = new Fahrzeug("BMW", 230, 25999.99);
            }

            //Bsp-Aufruf der GarbageCollection
            GC.Collect();
            //Abwarten der Finalizer-Ausführungen (der Objekte)
            GC.WaitForPendingFinalizers();

            //Aufruf der statischen Methode
            Console.WriteLine(Fahrzeug.ZeigeAnzahlFahrzeuge());

            #endregion

        }
    }
}
