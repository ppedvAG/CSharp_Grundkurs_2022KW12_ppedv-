using System;

namespace Lab06_Fahrzeug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Fahrzeug fz1 = new Fahrzeug("VW", 200, 10_000);
            Console.WriteLine(fz1.Info() + "\n");

            fz1.StarteMotor();
            fz1.Beschleunige(120);
            Console.WriteLine(fz1.Info() + "\n");

            fz1.Beschleunige(300);
            Console.WriteLine(fz1.Info() + "\n");


            fz1.StoppeMotor();
            fz1.Beschleunige(-500);
            Console.WriteLine(fz1.Info() + "\n");

            
            fz1.StoppeMotor();
            Console.WriteLine(fz1.Info() + "\n");
        }
    }

    public class Fahrzeug
    {
        //Properties
        public string Name { get; set; }
        public int MaxGeschwindigkeit { get; set; }
        public int AktGeschwindigkeit { get; set; }
        public double Preis { get; set; }
        public bool MotorLäuft { get; set; } //true = Motor läuft / false = Motor ist aus

        public Fahrzeug (string name, int maxG, double preis)
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

        public void StoppeMotor ()
        {
            //Prüfen ob der Motor schon ausgeschaltet ist
            if(MotorLäuft == false) // if(!MotorLäuft)
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
    }
}
