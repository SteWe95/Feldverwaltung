using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class TaskDescription
    {
        public Guid Id { get; set; }
        public Fruit Fruit { get; set; }                                                                                   //TODO: Own entity ?
        public JobName JobName { get; set; }
        public string Comment { get; set; }

        public TaskDescription(Fruit fruit, JobName jobName)
        {
            Fruit = fruit;
            JobName = jobName;
        }

        public TaskDescription(Fruit fruit, JobName jobName, string comment) : this(fruit, jobName)
        {
            Comment = comment;
        }
    }
}
