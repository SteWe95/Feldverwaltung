using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Position
    {
<<<<<<< HEAD
        public Guid Id { get; set; }
        public string PositionName { get; set; }
        public ICollection<Field> Users { get; set; }

        public ICollection<TaskDescription> TaskDescriptions { get; set; }

        public Position(string positionName)
        {
            Id = Guid.NewGuid();
            PositionName = positionName;
        }
=======
        public virtual int Id { get; set; }
        public virtual string PositionName { get; set; }
        public virtual ICollection<Field> Users { get; set; }
        public virtual ICollection<TaskDescription> TaskDescriptions { get; set; }

>>>>>>> origin/develop
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
