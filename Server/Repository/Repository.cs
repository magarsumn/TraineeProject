
using HRApp.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRApp.Server.Repository
{
    public class Repository<T> : RepositoryWithTypedId<T, int>, IRepository<T> where T : class, IEntityWithTypedId<int>
    {
        public Repository(ApplicationDbContext context) : base(context)
        {
        }
    }
}