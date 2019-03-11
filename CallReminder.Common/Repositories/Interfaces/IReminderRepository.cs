using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CallReminder.Core.Domain;

namespace CallReminder.Core.Repositories.Interfaces
{
    public interface IReminderRepository
    {
        Task<ReminderModel> CreateOrUpdateReminderAsync(ReminderModel model, CancellationToken cancellationToken);

        Task<IEnumerable<ReminderModel>> GetReminders(CancellationToken cancellationToken);

        Task<ReminderModel> GetReminderById(Guid id, CancellationToken cancellationToken);

        Task<bool> RemoveReminderByIdTask(Guid id, CancellationToken cancellationToken);
    }
}
