using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CallReminder.Core.Domain;
using CallReminder.Core.Presentation.ValueConverters;
using CallReminder.Core.Repositories.Interfaces;

#pragma warning disable 1998

namespace CallReminder.Core.Repositories
{
    internal class ReminderMockRepository : IReminderRepository
    {
        public async Task<bool> CreateOrUpdateReminderAsync(ReminderModel model, CancellationToken cancellationToken)
        {
            return true;
        }

        public async Task<ReminderModel> GetReminderById(Guid id, CancellationToken cancellationToken)
        {
            return new ReminderModel()
            {
                Id = id,
                DayOfWeeks = DayOfWeeksFlags.Monday | DayOfWeeksFlags.Friday | DayOfWeeksFlags.Thursday,
                Name = "Grandma",
                Phone = "+375291112233",
                Repeat = true,
                Time = new DateTime(1990, 01, 01, 10, 00, 00)
            };
        }

        public async Task<IEnumerable<ReminderModel>> GetRemindersAsync(CancellationToken cancellationToken)
        {
            return new List<ReminderModel>()
            {
                new ReminderModel()
                {
                    Id = Guid.NewGuid(),
                    DayOfWeeks = DayOfWeeksFlags.Monday | DayOfWeeksFlags.Friday | DayOfWeeksFlags.Thursday,
                    Name = "Grandma",
                    Phone = "+375291112233",
                    Repeat = true,
                    Time = new DateTime(1990, 01, 01, 10, 00, 00)
                },
                new ReminderModel()
                {
                    Id = Guid.NewGuid(),
                    DayOfWeeks = DayOfWeeksFlags.Saturday | DayOfWeeksFlags.Friday | DayOfWeeksFlags.Wednesday,
                    Name = "Father",
                    Phone = "+375299998877",
                    Repeat = true,
                    Time = new DateTime(1990, 01, 01, 11, 00, 00)
                },
                new ReminderModel()
                {
                    Id = Guid.NewGuid(),
                    DayOfWeeks = DayOfWeeksFlags.Sunday | DayOfWeeksFlags.Wednesday,
                    Name = "Mother",
                    Phone = "+375298974111",
                    Repeat = true,
                    Time = new DateTime(1990, 01, 01, 12, 00, 00)
                },
                new ReminderModel()
                {
                    Id = Guid.NewGuid(),
                    DayOfWeeks = DayOfWeeksFlags.Thursday,
                    Name = "Brother",
                    Phone = "++375294567896",
                    Repeat = true,
                    Time = new DateTime(1990, 01, 01, 14, 00, 00)
                }
            };
        }

        public async Task<bool> RemoveReminderByIdTask(Guid id, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
