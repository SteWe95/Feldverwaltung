using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Position
    {

        public virtual int Id { get; set; }
        public virtual string PositionName { get; set; }
        public virtual ICollection<Field> Users { get; set; }
        public virtual ICollection<TaskDescription> TaskDescriptions { get; set; }

        public Position()
        {
            Users = new HashSet<Field>();
            TaskDescriptions = new HashSet<TaskDescription>();
        }

        public override string ToString()
        {
            return PositionName;
        }
    }
}
