using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.Server.Repository
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
