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
        public string PositionName { get; set; }
        public IList<Field> Users { get; set; }

        public IList<TaskDescription> TaskDescriptions { get; set; }

        public Position(string positionName)
        {
            Id = Guid.NewGuid();
            PositionName = positionName;
        }
        public Position()
        {
        }

        public override string ToString()
        {
            return PositionName;
        }
    }
}
