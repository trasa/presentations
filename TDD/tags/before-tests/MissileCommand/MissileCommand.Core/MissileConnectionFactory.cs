using Blackfin.DataAccess;

namespace MissileCommand.Core
{
    public class MissileConnectionFactory : SqlConnectionFactory
    {
        public override string ConnectionStringName
        {
            get { return "MissileCommandConnection"; }
        }
    }
}