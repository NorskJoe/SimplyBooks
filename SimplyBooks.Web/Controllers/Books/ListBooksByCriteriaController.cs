using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Services.Books.Interfaces;

namespace SimplyBooks.Web.Controllers.Books
{
    public class ListBooksByCriteriaController : Controller
    {
        private readonly IListBooksByCriteriaService _listBooksService;

        public ListBooksByCriteriaController(IListBooksByCriteriaService listBooksService)
        {
            _listBooksService = listBooksService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}