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

        public Field(int number, Fruit fruit, GrowthState growthState, double size, FertilizerLevel fertilizerLevel, Ploughed ploughed)
        {
            Number = number;
            Fruit = fruit;
            GrowthState
        }
    }
}
