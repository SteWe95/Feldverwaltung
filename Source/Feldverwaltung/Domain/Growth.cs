using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Growth
    {
        public virtual int Id { get; set; }
        public virtual string GrowthState { get; set; }
        public virtual ICollection<Field> Fields { get; set; }

        public Growth()
        {
            Fields = new HashSet<Field>();
        }

        public override string ToString()
        {
            return GrowthState;
        }
    }
}
