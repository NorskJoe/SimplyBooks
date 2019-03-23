﻿using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Interfaces.Genres
{
    public interface IUpdateGenreCommand
    {
        Task<HttpResponseMessage> UpdateGenre(Genre genre);
    }
}