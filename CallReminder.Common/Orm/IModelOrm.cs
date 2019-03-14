using System;

namespace CallReminder.Core.Orm
{
    public interface IModelOrm
    {
        Guid Id { get; set; }
    }
}
