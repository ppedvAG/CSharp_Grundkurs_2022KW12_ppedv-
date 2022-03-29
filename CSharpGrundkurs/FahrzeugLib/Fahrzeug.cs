using System;

namespace FahrzeugLib
{
    public class Fahrzeug
    {
        public int PublicGeschwindigkeit { get; set; } //überall verwendbar
        private string PrivateFarbe { get; set; } //kann NUR inner der selben Klasse verwendet werden 
        internal object InternalRadio { get; set; } // Innerhalb des aktuellen Namespaces/Assembly verwendet werden 
        protected object ProtectedAntrieb { get; set; } //innerhalb der selben Klasse oder innerhalb abgeleiteter Klassen 

        protected internal object ProtectedInternalKofferraum {get;set; } //innerhalb des aktuellAssemblys oder oder innerhalb abgeleiteter Klassen 
        private protected object PrivateProtectedLenkrad { get; set; } //innerhalb der selben Klasse oder innerhalb einer abgeleitetend Klasse im aktuellen Assembly
    
        
        public void LackiereAuto ()
        {
            this.PrivateFarbe = "Orange";
        }
    }


    public class ExlectroCar : Fahrzeug
    {
        public void WhatCanIUse()
        {
            //Auf welche Properties können wir Zugreifen?

            this.PublicGeschwindigkeit = 123;
            //this.PrivateFarbe = "rot";
            this.InternalRadio = new object();
            this.ProtectedAntrieb = new Object();
            this.ProtectedInternalKofferraum = new object();
            this.PrivateProtectedLenkrad = new object();
        }
    }
}
