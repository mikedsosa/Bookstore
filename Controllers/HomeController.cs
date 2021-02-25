using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mike05.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mike05.Models.ViewModels;

namespace Mike05.Controllers
{
    public class HomeController : Controller
    {
        //set up private and public variables for the repository
        private readonly ILogger<HomeController> _logger;
        private IBookRepository _repository;
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Controller for the index page
        public IActionResult Index(int page = 1)
        {
            //add in information for pagination
            return View(new BookListViewModel
            {
                Books = _repository.Books
                        .OrderBy(b => b.BookId)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                    ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = _repository.Books.Count()
                }
            });
        }

        // not being used right not
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}