using FluentNHibernate.Mapping;
using RobotArmy.Core.Model;

namespace RobotArmy.Core.Mapping
{
    public  class RobotMap : ClassMap<Robot>
    {
        public RobotMap()
        {
            Id(x => x.Id)
                .GeneratedBy.Identity();
            Map(x => x.Name)
                .Not.Nullable();
            Map(x => x.IsPsychotic)
                .Not.Nullable();
        }
    }
}
