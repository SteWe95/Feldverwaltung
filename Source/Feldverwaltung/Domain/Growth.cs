using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Growth
    {
<<<<<<< HEAD
        public Guid Id { get; set; }
        public string GrowthState { get; set; }
        public ICollection<Field> Fields { get; set; }
=======
        public virtual int Id { get; set; }
        public virtual string GrowthState { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
>>>>>>> origin/develop

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
