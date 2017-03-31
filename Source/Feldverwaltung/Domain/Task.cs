using Feldverwaltung.Enums;
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
        public int FieldNumber { get; set; }                                                                                
        public TaskDescription TaskDescription { get; set; }
        public string Employee { get; set; }
        public bool Active { get; set; }
        public bool Done { get; set; }

        public Task(int fieldNumber, JobName jobName, Fruit fruit)
        {
            FieldNumber = fieldNumber;
            TaskDescription = new TaskDescription(fruit, jobName);
            Active = false;
            Done = false;
        }

        public Task(int fieldNumber, JobName jobName, Fruit fruit, string comment)
        {
            FieldNumber = fieldNumber;
            TaskDescription = new TaskDescription(fruit, jobName, comment);
            Active = false;
            Done = false;
        }
    }
}
