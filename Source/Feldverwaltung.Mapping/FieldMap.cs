using Feldverwaltung.Domain;
using FluentNHibernate.Mapping;

namespace Feldverwaltung.Mapping
{
    public class FieldMap : ClassMap<Field>
    {
        public FieldMap()
        {
            Table("Field");
            Id(x => x.Id)
                .Column("FieldId")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.HiLo("10");
            Map(_ => _.Number).Unique().Not.Nullable();
            Map(_ => _.Size);
            HasMany<Task>(_ => _.Tasks)
                .Access.Property()
                .AsSet()
                .Cascade.None()
                .LazyLoad()
                .Inverse()
                .Generic()
                .KeyColumns.Add("TaskId", mapping => mapping.Name("TaskId")
                                                                .SqlType("INTEGER")
                                                                .Not.Nullable());

            //HasOne<Fruit>(_ => _.Fruit);
            //HasOne<Growth>(_ => _.GrowthState);
            //HasOne<Fertilizer>(_ => _.FertilizerLevel);
            //HasOne<Ploughed>(_ => _.PloughedState);
        }
    }
}