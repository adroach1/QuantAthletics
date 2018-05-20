using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Core.ModelServices
{
    public abstract class GenericDbRepository<T>
    {
        public abstract T Add(T item);
        public abstract T Update(T item);
        public abstract T Delete(T item);
        public abstract IQueryable<T> GetAll();
    }
}
