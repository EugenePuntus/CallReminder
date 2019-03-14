using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SQLite;

namespace CallReminder.Core.Orm
{
    internal class ReminderDatabase : IReminderDatabase
    {
        private readonly SQLiteConnection _context;

        public ReminderDatabase()
        {
            var pathDatabase = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "reminder.db3");

            _context = new SQLiteConnection(pathDatabase);
            _context.CreateTable<ReminderOrm>();
        }

        public Task<int> Insert<TOrm>(TOrm objOrm, CancellationToken cancellationToken) 
            where TOrm : IModelOrm, new()
        {
            var taskComplication = new TaskCompletionSource<int>();

            Task.Run(() =>
            {
                if(objOrm.Id == Guid.Empty)
                {
                    objOrm.Id = Guid.NewGuid();
                }

                var result = _context.InsertOrReplace(objOrm);
                taskComplication.SetResult(result);
            }, cancellationToken);

            return taskComplication.Task;
        }

        public Task<IEnumerable<TOrm>> SelectAll<TOrm>(CancellationToken cancellationToken) 
            where TOrm : IModelOrm, new()
        {
            var taskComplication = new TaskCompletionSource<IEnumerable<TOrm>>();

            Task.Run(() =>
            {
                var result = _context.Table<TOrm>();
                taskComplication.SetResult(result);
            }, cancellationToken);

            return taskComplication.Task;
        }

        public Task<TOrm> Select<TOrm>(TOrm objOrm, CancellationToken cancellationToken) 
            where TOrm : IModelOrm, new()
        {
            var taskComplication = new TaskCompletionSource<TOrm>();

            Task.Run(() =>
            {
                var result = _context.Get<TOrm>(objOrm.Id);
                taskComplication.SetResult(result);
            }, cancellationToken);

            return taskComplication.Task;
        }

        public Task<int> Remove<TOrm>(TOrm objOrm, CancellationToken cancellationToken)
            where TOrm : IModelOrm, new()
        {
            var taskComplication = new TaskCompletionSource<int>();

            Task.Run(() =>
            {
                var result = _context.Delete<TOrm>(objOrm.Id);
                taskComplication.SetResult(result);
            }, cancellationToken);

            return taskComplication.Task;
        }
    }
}
