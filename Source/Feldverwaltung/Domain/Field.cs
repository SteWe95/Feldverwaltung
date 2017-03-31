using Feldverwaltung.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Field
    {
        public int Number { get; set; }
        public Fruit Fruit { get; set; }
        public GrowthState GrowthState { get; set; }
        public double Size { get; set; }
        public FertilizerLevel FertilizerLevel { get; set; }
        public Ploughed Ploughed { get; set; }

        public Field(int number, GrowthState growthState, double size, FertilizerLevel fertilizerLevel, Ploughed ploughed, Fruit fruit) : this(number, growthState, size, fertilizerLevel, ploughed)
        {
            Fruit = fruit;
        }

        public Field(int number, GrowthState growthState, double size, FertilizerLevel fertilizerLevel, Ploughed ploughed)
        {
            Number = number;
            GrowthState = growthState;
            Size = size;
            FertilizerLevel = fertilizerLevel;
            Ploughed = ploughed;
        }

        public override string ToString()
        {
            return "Feldnummer: " + Number +
                "\r\nFruchtart: " + Fruit + 
                "\r\nWachstum: " + GrowthState + 
                "\r\nGröße: " + Size + 
                "\r\nDüngestufe: " + FertilizerLevel + 
                "\r\nPflugstatus" + Ploughed;
        }
    }
}
