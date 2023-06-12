using NetApiWithDocker.Model;
using NetApiWithDocker.Model.Base;
using System.Collections.Generic;

namespace NetApiWithDocker.Repository.Implementations
{
    public interface IRepository<T> where T : BaseEntity // Interface genérica do tipo T onde obrigatóriamente precisa extender a interface BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long Id);
        bool Exists(long id);
    }
}
