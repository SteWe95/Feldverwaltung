using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Fruit
    {
        public virtual int Id { get; set; }
        public virtual string FruitName { get; set; }
        public virtual ICollection<Field> Fields { get; set; }

        public virtual ICollection<TaskDescription> TaskDescriptions { get; set; }

        public Fruit()
        {
            Fields = new HashSet<Field>();
            TaskDescriptions = new HashSet<TaskDescription>();
        }

        public override string ToString()
        {
            return FruitName;
        }
    }
}
