using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Job
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

        public Job()
        {
            Tasks = new HashSet<Task>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
