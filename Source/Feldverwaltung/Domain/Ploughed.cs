using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Ploughed
    {
        public Guid Id { get; set; }
        public string PloughedState { get; set; }
        public ICollection<Field> Fields { get; set; }

        public Ploughed(string ploughedState)
        {
            Id = Guid.NewGuid();
            PloughedState = ploughedState;
        }
        public Ploughed()
        {
        }

        public override string ToString()
        {
            return PloughedState;
        }
    }
}
