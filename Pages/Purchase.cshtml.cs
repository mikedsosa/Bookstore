using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mike05.Models;
using Mike05.Infrastructure;

namespace Mike05.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookRepository repository;

        //constructor
        public PurchaseModel(IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            //Set the ReturnUrl = returnUrl or / if nothing was passed in
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            //look at first or default
            Book book = repository.Books
                .FirstOrDefault(b => b.BookId == bookId);
            //get the cart or add a new cart
            Cart.AddItem(book, 1);
            //send to a new page using the returnUrl
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        //handler to remove an item from the cart
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
