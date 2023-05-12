﻿using NetApiWithDocker.Model;
using NetApiWithDocker.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiWithDocker.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;
        public BookBusinessImplementation( IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long Id)
        {
            _repository.Delete(Id); 
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
