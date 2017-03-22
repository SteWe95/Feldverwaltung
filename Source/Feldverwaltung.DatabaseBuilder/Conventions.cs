using FluentNHibernate.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Instances;
using NHibernate;

namespace Feldverwaltung.DatabaseBuilder
{
    public class Conventions : IPropertyConvention
    {

        private IList<Type> decimalTechnicalDataTypes;
        private IDictionary<Type, string> dbFieldTypeToTechnicalTypeMapping;

        public Conventions()
        {
            dbFieldTypeToTechnicalTypeMapping = new Dictionary<System.Type, String>();
            dbFieldTypeToTechnicalTypeMapping.Add(typeof(string), NHibernateUtil.AnsiString.Name);
            dbFieldTypeToTechnicalTypeMapping.Add(typeof(DateTime), NHibernateUtil.Timestamp.Name);

            decimalTechnicalDataTypes = new List<Type>();
            decimalTechnicalDataTypes.Add(typeof(decimal));
            decimalTechnicalDataTypes.Add(typeof(Nullable<Decimal>));
        }

        public void Apply(IPropertyInstance instance)
        {
            Type PropertyType = instance.Property.PropertyType;
            if (dbFieldTypeToTechnicalTypeMapping.ContainsKey(PropertyType))
            {
                var value = "";
                dbFieldTypeToTechnicalTypeMapping.TryGetValue(PropertyType, out value);
                instance.CustomType(value);
            }

            if (decimalTechnicalDataTypes.Contains(PropertyType))
            {
                instance.CustomType(NHibernateUtil.Decimal.Name);
                instance.Precision(38);
                instance.Scale(6);
            }
        }
    }
}
