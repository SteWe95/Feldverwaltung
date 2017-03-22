using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feldverwaltung.DatabaseBuilder
{
    interface IReadOnlyClassMap
    {
        string GetCreateScriptForSqlServer();
        string GetDropScriptForSqlServer();
    }   
}
