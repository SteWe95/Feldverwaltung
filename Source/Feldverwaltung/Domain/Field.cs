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
        public Guid FruitId { get; set; }
        public Fruit Fruit { get; set; }
        public Guid GrowthId { get; set; }
        public Growth GrowthState { get; set; }
        public double Size { get; set; }
        public Guid FertilizerId { get; set; }
        public Fertilizer FertilizerLevel { get; set; }
        public Guid PloughedId { get; set; }
        public Ploughed PloughedState { get; set; }

        public Field(int number, Growth growthState, double size, Fertilizer fertilizerLevel, Ploughed ploughed, Fruit fruit) : this(number, growthState, size, fertilizerLevel, ploughed)
        {
            Fruit = fruit;
        }

        public Field(int number, Growth growthState, double size, Fertilizer fertilizerLevel, Ploughed ploughed)
        {
            Number = number;
            GrowthState = growthState;
            Size = size;
            FertilizerLevel = fertilizerLevel;
            PloughedState = ploughed;
        }
        public Field()
        {
        }

        public override string ToString()
        {
            return "Feldnummer: " + Number +
                "\r\nFruchtart: " + Fruit +
                "\r\nWachstum: " + GrowthState +
                "\r\nGröße: " + Size +
                "\r\nDüngestufe: " + FertilizerLevel +
                "\r\nPflugstatus" + PloughedState;
        }
    }
}
