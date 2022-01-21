using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGestorDocumentos.Repositories
{
    internal interface IRepository<T>
    {
        public List<T> GetAll();

        public void Create(T entity);

        public T Read(long id);

        public void Update(T entity);

        public void Delete(T entity);
    }
}
