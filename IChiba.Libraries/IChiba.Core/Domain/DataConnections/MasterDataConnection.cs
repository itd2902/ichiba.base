using LinqToDB.Configuration;
using LinqToDB.Data;

namespace IChiba.Core.Domain.Master
{
    public partial class MasterDataConnection : DataConnection
    {
        public MasterDataConnection(LinqToDbConnectionOptions<MasterDataConnection> options)
            : base(options)
        {

        }
    }
}
