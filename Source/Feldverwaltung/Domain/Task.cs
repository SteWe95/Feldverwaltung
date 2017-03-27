using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Task
    {
        public Guid Id { get; set; }
        public Field Field { get; set; }                                                                                
        public TaskDescription TaskDescription { get; set; }
        public string Employee { get; set; }
        public bool Active { get; set; }
        public bool Done { get; set; }

        public Task(Field field, JobName jobName, Fruit fruit)
        {
            Field = field;
            TaskDescription = new TaskDescription(fruit, jobName);
            Active = false;
            Done = false;
        }

        public Task(Field field, JobName jobName, Fruit fruit, string comment)
        {
            Field = field;
            TaskDescription = new TaskDescription(fruit, jobName, comment);
            Active = false;
            Done = false;
        }
    }
}
