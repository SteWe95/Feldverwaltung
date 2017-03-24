using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Position(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void AddPositions()
        {
            
        }
    }
}
