using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Ploughed
    {
<<<<<<< HEAD
        public Guid Id { get; set; }
        public string PloughedState { get; set; }
        public ICollection<Field> Fields { get; set; }
=======
        public virtual int Id { get; set; }
        public virtual string PloughedState { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
>>>>>>> origin/develop

        public Ploughed()
        {
            Fields = new HashSet<Field>();
        }

        public override string ToString()
        {
            return PloughedState;
        }
    }
}
