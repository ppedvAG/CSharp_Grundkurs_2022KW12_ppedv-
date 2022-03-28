using System;

namespace Modul08B_LabLoesungVererbung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fahrzeug[] fahrzeuge = new Fahrzeug[10];

            //Array wird mit Fahrzeuge (PWK/Schiff/Flugzeug) per Zufall erstellt
            for (int i = 0; i < fahrzeuge.Length; i++)
            {
                fahrzeuge[i] = Fahrzeug.GeneriereFahrzeug($"_{i}");
            }


            int pkws = 0, schiffe = 0, flugzeuge = 0;

            //Wir zählen unsere Fahrzeuge nach Typ 
            foreach(Fahrzeug currentVehicle in fahrzeuge)
            {
                switch (currentVehicle)
                {
                    case PKW:
                        pkws++;
                        break;
                    case Flugzeug:
                        flugzeuge++;
                        break;
                    case Schiff:
                        schiffe++;
                        break;
                    default:
                        Console.WriteLine("Diese Objekt wurde Fehler -> Eigetlich eine Fehlermeldung soll hier entstehen");
                        break;
                }
            }

            //Ausgabe
            Console.WriteLine($"Es wurden {pkws} PKW(s), {flugzeuge} Flugzeug(e) und {schiffe} Schiff(e) produziert.");

            //Ausführung der abstrakten Methode
            fahrzeuge[2].Hupen();
        }
    }




    public abstract class Fahrzeug
    {
        public string Name { get; set; }
        public int MaxGeschwindigkeit { get; set; }
        public int AktGeschwindigkeit { get; set; }
        public double Preis { get; set; }
        public bool MotorLäuft { get; set; } //true = Motor läuft / false = Motor ist aus


        #region Konstruktoren
        public Fahrzeug()
        {
            AnzahlFahrzeuge++;
        }

        public Fahrzeug(string name, int maxG, double preis)
            : this()
        {
            Name = name;
            this.MaxGeschwindigkeit = maxG;
            this.Preis = preis;
            this.AktGeschwindigkeit = 0;
            this.MotorLäuft = false;
        }
        #endregion

        #region Klassen-Methdoen

        public abstract void Hupen();



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
        public virtual string Info()
        {
            if (this.MotorLäuft)
                return $"{this.Name} kostet {this.Preis}€ und bewegt sich momentan mit {this.AktGeschwindigkeit} von maximal {this.MaxGeschwindigkeit}km/h.";
            else
                return $"{this.Name} kostet {this.Preis}€ und könnte maximal {this.MaxGeschwindigkeit}km/h bewegen.";
        }
        #endregion

        #region Statische Member



        public static int AnzahlFahrzeuge { get; set; } = 0;

        public static string ZeigeAnzahlFahrzeuge()
        {
            return $"Es wurden {AnzahlFahrzeuge} Fahrzeuge gebaut.";
        }

        public static Fahrzeug GeneriereFahrzeug(string nameSuffix = "")
        {
            Random generator = new Random();



            switch (generator.Next(1,4))
            {
                case 1:
                    return new PKW("Mercedes" + nameSuffix, 210, 23000, 5);
                case 2:
                    return new Schiff("Titanic" + nameSuffix, 40, 25000000, Schiff.SchiffsTreibstoff.Dampf, 5);
                default:
                    return new Flugzeug("Boing" + nameSuffix, 350, 90000000, 9800);
            }
        }

        public override string ToString()
        {
            return this.GetType().Name + " : " + this.Name;
        }
        #endregion

        ~Fahrzeug()
        {
            AnzahlFahrzeuge--;
            Console.WriteLine($"{this.Name} wurde gerade verschrottet.");
        }
    }


    public class Schiff : Fahrzeug
    {
        public double Tiefgang { get; set; }
        public SchiffsTreibstoff Treibstoff { get; set; }

        public Schiff(string name, int maxG, double preis, SchiffsTreibstoff treibstoff, double tiefgang)
            : base(name, maxG, preis)
        {
            Treibstoff = treibstoff;
            Tiefgang = tiefgang;
        }


        public override string Info()
        {
            return "Das Schiff " + base.Info() + $"Es fährt mit {this.Treibstoff} und hat einen Tiefgang von {this.Tiefgang} Meter";
        }

        public override void Hupen()
        {
            Console.WriteLine($"{this.Name} : 'Trööööt' ");
        }

        //Nested Type
        public enum SchiffsTreibstoff { Diesel = 0, Dampf, Wind, Muskelkraft }
    }

    public class PKW : Fahrzeug
    {
        public int AnzahlTueren { get; set; }

        public PKW(string name, int maxG, double preis, int anzTueren) : base(name, maxG, preis)
        {
            this.AnzahlTueren = anzTueren;
        }

        public override string Info()
        {
            return "Der PKW " + base.Info() + $" Er hat {this.AnzahlTueren} Türen.";
        }

        public override void Hupen()
        {
            Console.WriteLine($"{this.Name}: 'Hup Hup'");
        }
    }

    //vgl. Schiff
    public class Flugzeug : Fahrzeug
    {
        public int MaxFlughöhe { get; set; }

        public Flugzeug(string name, int maxG, double preis, int maxFH) : base(name, maxG, preis)
        {
            this.MaxFlughöhe = maxFH;
        }

        public override string Info()
        {
            return "Das Flugzeug " + base.Info() + $" Es kann bis auf {this.MaxFlughöhe}m aufsteigen.";
        }

        public override void Hupen()
        {
            Console.WriteLine($"{this.Name}: 'Biep Biep'");
        }
    }

}
