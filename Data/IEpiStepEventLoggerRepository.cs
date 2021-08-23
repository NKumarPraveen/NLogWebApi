using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLogApi.Data
{
    public interface IEpiStepEventLoggerRepository
    {
        bool InsertEpiStepLog(EpiplexStep epiplexStep);
        bool InsertUniqueStepLog(UniqueStep uniqueStep);
    }
}
