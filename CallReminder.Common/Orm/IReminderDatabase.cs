using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CallReminder.Core.Orm
{
    public interface IReminderDatabase
    {
        Task<int> Insert<TOrm>(TOrm objOrm, CancellationToken cancellationToken)
            where TOrm : IModelOrm, new();

        Task<IEnumerable<TOrm>> SelectAll<TOrm>(CancellationToken cancellationToken)
            where TOrm : IModelOrm, new();

        Task<TOrm> Select<TOrm>(TOrm objOrm, CancellationToken cancellationToken)
            where TOrm : IModelOrm, new();

        Task<int> Remove<TOrm>(TOrm objOrm, CancellationToken cancellationToken)
            where TOrm : IModelOrm, new();
    }
}
