using Feldverwaltung.Enums;
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
        public Fruit Fruit { get; set; }
        public Fertilizers Fertilizer { get; set; }
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
        public TaskDescription(Fertilizers fertilizer, JobName jobName)
        {
            Fertilizer = fertilizer;
            JobName = jobName;
        }

        public TaskDescription(Fertilizers fertilizer, JobName jobName, string comment) : this(fertilizer, jobName)
        {
            Comment = comment;
        }
    }
}
