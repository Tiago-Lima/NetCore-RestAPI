using Microsoft.EntityFrameworkCore;
using NetApiWithDocker.Model.Base;
using NetApiWithDocker.Model.Context;
using NetApiWithDocker.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiWithDocker.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context; //Criando uma instância da classe contexto para ser injetada nesta classe

        private DbSet<T> dataset; 
        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>(); // Dinamicamente será setado o tipo de dataset declarado lá na classe MySQLContext
        }
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges(); //Métodos da classe context injetada
                return item;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

       
        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {


                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges(); 
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }


            }
            else
            {
                return null;
            }
            
        }
        public void Delete(long Id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(Id));

            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges(); //Métodos da classe context injetada

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
