using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityXmlContext.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(object parentId);
        T GetByKey(object keyValue);

        void Insert(T entidade, bool autoPersist = true);
        void Update(T entidade, bool autoPersist = true);
        void Delete(T entidade, bool autoPersist = true);

        void Save();
    }
}
