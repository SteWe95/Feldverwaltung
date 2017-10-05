using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Field
    {
<<<<<<< HEAD
        public int Number { get; set; }
        public Guid FruitId { get; set; }
        public Guid GrowthStateId { get; set; }
        public double Size { get; set; }
        public Guid FertilizerLevelId { get; set; }
        public Guid PloughedStateId { get; set; }

=======
        public virtual int Id { get; set; }
        public virtual int Number { get; set; }
        public virtual double Size { get; set; }
        public virtual Fruit Fruit { get; set; }
        public virtual Growth GrowthState { get; set; }
        public virtual Fertilizer FertilizerLevel { get; set; }
        public virtual Ploughed PloughedState { get; set; }
>>>>>>> origin/develop

        public Field(int number, Growth growth, double size, Fertilizer fertilizerLevel, Ploughed ploughed, Fruit fruit) : this(number, growth, size, fertilizerLevel, ploughed)
        {
            Fruit = fruit;
        }

        public Field(int number, Growth growth, double size, Fertilizer fertilizerLevel, Ploughed ploughed)
        {
            Number = number;
            GrowthState = growth;
            Size = size;
            FertilizerLevel = fertilizerLevel;
            PloughedState = ploughed;
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
