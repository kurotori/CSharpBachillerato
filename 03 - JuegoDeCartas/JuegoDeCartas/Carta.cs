﻿using System;
namespace JuegoDeCartas
{
    public class Carta
    {
        private int numero = 0;
        private string palo = "";

        public Carta(int numero, string palo)
        {
            this.numero = numero;
            this.palo = palo;
        }

        public int GetNumero(){
            return numero;
        }

        public string GetPalo(){
            return palo;
        }
    }
}
