using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Growth
    {
        public Guid Id { get; set; }
        public string GrowthState { get; set; }
        public ICollection<Field> Fields { get; set; }

        public Growth(string growthState)
        {
            Id = Guid.NewGuid();
            GrowthState = growthState;
        }
        public Growth()
        {
        }

        public override string ToString()
        {
            return GrowthState;
        }
    }
}
