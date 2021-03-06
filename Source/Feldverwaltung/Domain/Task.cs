﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public partial class Task
    {
        public virtual int Id { get; set; }
        public virtual string Employee { get; set; }
        public virtual bool Active { get; set; }
        public virtual bool Done { get; set; }
        public virtual Field Field { get; set; }
        public virtual TaskDescription TaskDescription { get; set; }

        partial void OnCreated();

        public Task(int fieldNumber, Job jobName, Fruit fruit)
        {
           
            //TaskDescription = new TaskDescription(fruit, jobName);
            Active = false;
            Done = false;
            OnCreated();
        }

        public Task(int fieldNumber, Job jobName, Fruit fruit, string comment)
        { 
            //TaskDescription = new TaskDescription(fruit, jobName, comment);
            Active = false;
            Done = false;
            OnCreated();
        }
        public Task()
        {
            OnCreated();
        }
    }
}
