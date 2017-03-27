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
        public string Fruit { get; set; }
        public string JobName { get; set; }
    }
}
