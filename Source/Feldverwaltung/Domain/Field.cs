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
        public Guid FertilizerLevelId { get; set; }
        public Fertilizer FertilizerLevel { get; set; }
        public Guid PloughedStateId { get; set; }
        public Ploughed PloughedState { get; set; }

        public Field(int number, Guid growthId, double size, Guid fertilizerLevelId, Guid ploughedId, Guid fruitId) : this(number, growthId, size, fertilizerLevelId, ploughedId)
        {
            FruitId = fruitId;
        }

        public Field(int number, Guid growthId, double size, Guid fertilizerLevelId, Guid ploughedId)
        {
            Number = number;
            GrowthId = growthId;
            Size = size;
            FertilizerLevelId = fertilizerLevelId;
            PloughedStateId = ploughedId;
        }
        public Field()
        {
        }

        public override string ToString()
        {
            return "Feldnummer: " + Number +
                "\r\nFruchtart: " + Fruit.ToString() +
                "\r\nWachstum: " + GrowthState.ToString() +
                "\r\nGröße: " + Size +
                "\r\nDüngestufe: " + FertilizerLevel.ToString() +
                "\r\nPflugstatus: " + PloughedState.ToString();
        }
    }
}
