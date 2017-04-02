using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.Domain
{
    public class Fertilizer
    {
        public Guid Id { get; set; }
        public string FertilizerLevel { get; set; }
        public IList<Field> Fields { get; set; }

        public Fertilizer(string fertilizerLevel)
        {
            Id = Guid.NewGuid();
            FertilizerLevel = fertilizerLevel;
        }
        public Fertilizer()
        {
        }

        public override string ToString()
        {
            return FertilizerLevel;
        }
    }
}
