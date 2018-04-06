using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public partial class Field
    {
        public virtual int Id { get; set; }
        public virtual int Number { get; set; }
        public virtual double Size { get; set; }
        public virtual Fruit Fruit { get; set; }
        public virtual Growth GrowthState { get; set; }
        public virtual Fertilizer FertilizerLevel { get; set; }
        public virtual Ploughed PloughedState { get; set; }
        public virtual System.Collections.Generic.HashSet<Task> Tasks { get; set; }

        partial void OnCreated();

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
            this.Tasks = new System.Collections.Generic.HashSet<Task>();
            OnCreated();
        }
        public Field()
        {
            OnCreated();
        }
      

        public override string ToString()
        {
            return "Feldnummer: " + Number +
                   "\r\nFruchtart: " + Fruit.FruitName +
                    "\r\nWachstum: " + GrowthState.GrowthState +
                   "\r\nGröße: " + Size +
                "\r\nDüngestufe: " + FertilizerLevel.FertilizerLevel +
                "\r\nPflugstatus: " + PloughedState.PloughedState;
        }
    }
}
