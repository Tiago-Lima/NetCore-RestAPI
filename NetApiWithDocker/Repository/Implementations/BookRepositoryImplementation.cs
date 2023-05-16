using NetApiWithDocker.Model;
using NetApiWithDocker.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiWithDocker.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {


        private MySQLContext _context; //Criando uma instância da classe contexto para ser injetada nesta classe

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges(); //Métodos da classe context injetada
            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {


                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges(); //Métodos da classe context injetada
                }
                catch (Exception)
                {

                    throw;
                }


            }
        }


        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));
            if (result != null)
            {


                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }


            }
            return book;
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
           