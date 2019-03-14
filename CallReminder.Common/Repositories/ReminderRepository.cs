using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CallReminder.Core.Domain;
using CallReminder.Core.Mapper;
using CallReminder.Core.Orm;
using CallReminder.Core.Repositories.Interfaces;

namespace CallReminder.Core.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly IReminderDatabase _context;

        public ReminderRepository(IReminderDatabase context)
        {
            _context = context;
        }

        public async Task<bool> CreateOrUpdateReminderAsync(ReminderModel model, CancellationToken cancellationToken)
        {
            var result = await _context.Insert(model.ToOrm(), cancellationToken);
            return result > 0;
        }

        public async Task<IEnumerable<ReminderModel>> GetRemindersAsync(CancellationToken cancellationToken)
        {
            var reminders = await _context.SelectAll<ReminderOrm>(cancellationToken);
            return reminders.Select(x => x.ToModel());
        }

        public async Task<ReminderModel> GetReminderById(Guid id, CancellationToken cancellationToken)
        {
            var reminder = await _context.Select(new ReminderOrm() {Id = id}, cancellationToken);
            return reminder.ToModel();
        }

        public async Task<bool> RemoveReminderByIdTask(Guid id, CancellationToken cancellationToken)
        {
            var result = await _context.Remove(new ReminderOrm() { Id = id }, cancellationToken);
            return result > 0;
        }
    }
}
