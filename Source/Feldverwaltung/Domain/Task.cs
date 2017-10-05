using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Task
    {
<<<<<<< HEAD
        public Guid Id { get; set; }
        public int FieldId { get; set; }
        public Guid TaskDescriptionId { get; set; }
        public string Employee { get; set; }
        public bool Active { get; set; }
        public bool Done { get; set; }
=======
        public virtual int Id { get; set; }
        public virtual string Employee { get; set; }
        public virtual bool Active { get; set; }
        public virtual bool Done { get; set; }
        public virtual Field Field { get; set; }
        public virtual TaskDescription TaskDescription { get; set; }
>>>>>>> origin/develop

        public Task(int fieldNumber, Job jobName, Fruit fruit)
        {
            FieldId = fieldNumber;
            //TaskDescription = new TaskDescription(fruit, jobName);
            Active = false;
            Done = false;
        }

        public Task(int fieldNumber, Job jobName, Fruit fruit, string comment)
        {
            FieldId = fieldNumber;
            //TaskDescription = new TaskDescription(fruit, jobName, comment);
            Active = false;
            Done = false;
        }
        public Task()
        {
        }
    }
}
