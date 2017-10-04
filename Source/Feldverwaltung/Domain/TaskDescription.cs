using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class TaskDescription
    {
        public virtual int Id { get; set; }
        public virtual string Comment { get; set; }
        public virtual Fruit Fruit { get; set; }
        public virtual Fertilizers Fertilizer { get; set; }
        public virtual Job JobName { get; set; }

        public TaskDescription(Fruit fruit, Job jobName)
        {
            Fruit = fruit;
            JobName = jobName;
        }

        public TaskDescription(Fruit fruit, Job jobName, string comment) : this(fruit, jobName)
        {
            Comment = comment;
        }
        public TaskDescription(Fertilizers fertilizer, Job jobName)
        {
            Fertilizer = fertilizer;
            JobName = jobName;
        }

        public TaskDescription(Fertilizers fertilizer, Job jobName, string comment) : this(fertilizer, jobName)
        {
            Comment = comment;
        }

        public TaskDescription()
        { }
    }
}
