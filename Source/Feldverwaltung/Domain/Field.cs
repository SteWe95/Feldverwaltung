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
        public Guid GrowthStateId { get; set; }
        public double Size { get; set; }
        public Guid FertilizerLevelId { get; set; }
        public Guid PloughedStateId { get; set; }


        public Field(int number, Guid growthId, double size, Guid fertilizerLevelId, Guid ploughedId, Guid fruitId) : this(number, growthId, size, fertilizerLevelId, ploughedId)
        {
            FruitId = fruitId;
        }

        public Field(int number, Guid growthId, double size, Guid fertilizerLevelId, Guid ploughedId)
        {
            Number = number;
            GrowthStateId = growthId;
            Size = size;
            FertilizerLevelId = fertilizerLevelId;
            PloughedStateId = ploughedId;
        }
        public Field()
        {
        }

        private Fruit GetFruit(int number)
        {
            Array values = Enum.GetValues(typeof(Fruit));
            Fruit fruit = (Fruit)values.GetValue(number);
            return fruit;
        }

        public override string ToString()
        {
            return "Feldnummer: " + Number +
                   "\r\nFruchtart: " + FruitId +
                    "\r\nWachstum: " + GrowthStateId +
                   "\r\nGröße: " + Size +
                "\r\nDüngestufe: " + FertilizerLevelId +
                "\r\nPflugstatus: " + PloughedStateId;
        }
    }
}
