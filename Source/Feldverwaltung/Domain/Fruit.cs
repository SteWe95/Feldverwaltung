using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Fruit
    {
        public Guid Id { get; set; }
        public string FruitName { get; set; }
        public ICollection<Field> Fields { get; set; }

        public ICollection<TaskDescription> TaskDescriptions { get; set; }

        public Fruit(string fruitName)
        {
            Id = Guid.NewGuid();
            FruitName = fruitName;
        }
        public Fruit()
        {
        }

        public override string ToString()
        {
            return FruitName;
        }
    }
}
