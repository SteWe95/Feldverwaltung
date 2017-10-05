using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Fertilizer
    {
        public virtual int Id { get; set; }
        public virtual string FertilizerLevel { get; set; }
        public virtual ICollection<Field> Fields { get; set; }

        public Fertilizer()
        {
            Fields = new HashSet<Field>();
        }

        public override string ToString()
        {
            return FertilizerLevel;
        }
    }
}
