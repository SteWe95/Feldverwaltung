using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public Job(string jobName)
        {
            Id = Guid.NewGuid();
            Name = jobName;
        }
        public Job()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
