using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Fertilizers
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public Fertilizers(string fertilizerName)
        {
            Id = Guid.NewGuid();
            Name = fertilizerName;
        }
        public Fertilizers()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
