﻿using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListBooksByAuthorQuery
    {
        Task<IList<Book>> Execute(int id);
    }

    public class ListBooksByAuthorQuery : IListBooksByAuthorQuery
    {
        public Task<IList<Book>> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
