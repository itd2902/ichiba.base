using LinqToDB.Configuration;
using LinqToDB.Data;

namespace IChiba.Core.Domain.OP
{
    public partial class OPDataConnection : DataConnection
    {
        public OPDataConnection(LinqToDbConnectionOptions<OPDataConnection> options)
            : base(options)
        {

        }
    }
}
