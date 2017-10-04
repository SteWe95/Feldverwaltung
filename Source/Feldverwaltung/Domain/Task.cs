using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Task
    {
        public virtual int Id { get; set; }
        public virtual string Employee { get; set; }
        public virtual bool Active { get; set; }
        public virtual bool Done { get; set; }
        public virtual Field Field { get; set; }
        public virtual TaskDescription TaskDescription { get; set; }

        public Task(int fieldNumber, Job jobName, Fruit fruit)
        {
            Field.Number = fieldNumber;
            TaskDescription = new TaskDescription(fruit, jobName);
            Active = false;
            Done = false;
        }

        public Task(int fieldNumber, Job jobName, Fruit fruit, string comment)
        {
            Field.Number = fieldNumber;
            TaskDescription = new TaskDescription(fruit, jobName, comment);
            Active = false;
            Done = false;
        }
        public Task()
        {
        }
    }
}
