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
        public Guid FruitId { get; set; }
        public Fruit Fruit { get; set; }
        public Guid FertilizerId { get; set; }
        public Fertilizers Fertilizer { get; set; }
        public Guid JobNameId { get; set; }
        public Job JobName { get; set; }
        public string Comment { get; set; }

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
