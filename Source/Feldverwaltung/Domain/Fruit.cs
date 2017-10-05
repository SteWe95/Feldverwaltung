using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Fruit
    {
<<<<<<< HEAD
        public Guid Id { get; set; }
        public string FruitName { get; set; }
        public ICollection<Field> Fields { get; set; }

        public ICollection<TaskDescription> TaskDescriptions { get; set; }
=======
        public virtual int Id { get; set; }
        public virtual string FruitName { get; set; }
        public virtual ICollection<Field> Fields { get; set; }

        public virtual ICollection<TaskDescription> TaskDescriptions { get; set; }
>>>>>>> origin/develop

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
