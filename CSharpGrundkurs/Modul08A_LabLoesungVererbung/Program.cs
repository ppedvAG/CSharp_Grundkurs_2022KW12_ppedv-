using System;

namespace Modul08A_LabLoesungVererbung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instanziierung verschiedener Fahrzeuge
            PKW pkw1 = new PKW("Mercedes", 210, 23000, 5);
            Schiff schiff1 = new Schiff("Titanic", 40, 25000000, Schiff.SchiffsTreibstoff.Dampf, 5);
            Flugzeug flugzeug1 = new Flugzeug("Airbus", 350, 90000000, 9800);

            //Ausgabe der verschiedenen Info()-Methoden
            Console.WriteLine(pkw1.Info());
            Console.WriteLine(schiff1.Info());
            Console.WriteLine(flugzeug1.Info());
        }
    }



    public class Fahrzeug
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
            :base(name, maxG, preis)
        {
            Treibstoff = treibstoff;
            Tiefgang = tiefgang;
        }


        public override string Info()
        {
            return "Das Schiff " + base.Info() + $"Es fährt mit {this.Treibstoff} und hat einen Tiefgang von {this.Tiefgang} Meter";
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
    }



}
